using Client.UserControls;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class RentGuiController
    {
        private UCAddRent addRent;
        private UCManageRent manageRent;

        private Iznajmljivanje iznajmljivanje;
        private StavkaIznajmljivanja stavkaIznajmljivanja;

        private readonly BindingList<StavkaIznajmljivanja> stavke = new();



        internal Control CreateAddRent()
        {
            iznajmljivanje = new();
            stavkaIznajmljivanja = new();

            addRent = new UCAddRent();

            addRent.CbOprema.SelectedIndexChanged += ShowPrice;

            addRent.DtpSince.ValueChanged += UpdateTrajanje;
            addRent.DtpTo.ValueChanged += UpdateTrajanje;

            addRent.DtpSince.Value = DateTime.Now;
            addRent.DtpTo.Value = DateTime.Now.AddHours(1);

            addRent.LblRb.Text = (stavke.Count + 1).ToString();

            // prvi obracun trajanja/iznosa
            UpdateTrajanje(this, EventArgs.Empty);

            addRent.TxtKolicina.TextChanged += (s, e) => UpdateIznos();
            addRent.TxtCena.TextChanged += (s, e) => UpdateIznos();
            addRent.TxtTrajanje.TextChanged += (s, e) => UpdateIznos();

            addRent.BtnAddRentalItem.Click += AddRentalItem;
            addRent.BtnAddRent.Click += AddRent;

            return addRent;
        }



        private void AddRentalItem(object? sender, EventArgs e)
        {
            // reset vizuelne validacije
            addRent.CbOprema.BackColor = SystemColors.Window;
            addRent.TxtKolicina.BackColor = SystemColors.Window;
            addRent.TxtTrajanje.BackColor = SystemColors.Window;
            addRent.DtpTo.CalendarMonthBackground = SystemColors.Window;

            // validacija stavke
            if (addRent.CbOprema.SelectedItem is not Oprema oprema)
            {
                MessageBox.Show("Одабери опрему.");
                addRent.CbOprema.BackColor = Color.Salmon;
                return;
            }
            if (!int.TryParse(addRent.TxtKolicina.Text, out int kolicina) || kolicina <= 0)
            {
                MessageBox.Show("Количинa мора бити цео број већи од 0.");
                addRent.TxtKolicina.BackColor = Color.Salmon;
                return;
            }
            if (!int.TryParse(addRent.TxtTrajanje.Text, out int trajanje) || trajanje <= 0)
            {
                MessageBox.Show("Трајање мора бити цео број већи од 0.");
                addRent.TxtTrajanje.BackColor = Color.Salmon;
                return;
            }

            decimal cena = oprema.Cena;

            // vremeDo posle vremeOd
            DateTime vremeOd = addRent.DtpSince.Value;
            DateTime vremeDo = addRent.DtpTo.Value;
            if (vremeDo <= vremeOd)
            {
                MessageBox.Show("Поље 'До' мора бити после поља 'Од'.");
                return;
            }

            // racunanje ukupnog iznosa
            decimal iznos = cena * kolicina * trajanje;

            var stavka = new StavkaIznajmljivanja
            {
                Rb = stavke.Count + 1,
                Kolicina = kolicina,
                Cena = cena,
                VremeDo = vremeDo,
                Trajanje = trajanje,
                Iznos = iznos,
                Oprema = oprema
            };

            try { typeof(StavkaIznajmljivanja).GetProperty("Trajanje")?.SetValue(stavka, trajanje); } catch { /* no-op */ }

            stavke.Add(stavka);
            addRent.TxtUkupanIznos.Text = stavke.Sum(s => s.Iznos).ToString("0.00");
            addRent.LblRb.Text = (stavke.Count + 1).ToString();

            // ciscenje polja
            addRent.CbOprema.SelectedIndex = -1;
            addRent.TxtKolicina.Text = "";
            addRent.TxtTrajanje.Text = "";
            addRent.TxtIznos.Text = "";
            addRent.TxtCena.Text = "";
            addRent.DtpTo.Value = addRent.DtpSince.Value;
        }



        private void AddRent(object? sender, EventArgs e)
        {
            if (stavke.Count == 0)
            {
                MessageBox.Show("Додај бар једну ставку изнајмљивања пре чувања документа.");
                return;
            }

            if (addRent.CbOsoba.SelectedItem is not Osoba osoba)
            {
                MessageBox.Show("Одабери особу.");
                return;
            }

            var zaposleni = Session.Instance.Zaposleni;
            if (zaposleni == null)
            {
                MessageBox.Show("Грешка: нема активног запосленог у сесији! Пријави се поново.");
                return;
            }

            DateTime vremeOd = addRent.DtpSince.Value;
            decimal ukupanIznos = Convert.ToDecimal(stavke.Sum(s => s.Iznos));

            var novoIznajmljivanje = new Iznajmljivanje
            {
                UkupanIznos = ukupanIznos,
                VremeOd = vremeOd,
                Osoba = osoba,
                Zaposleni = zaposleni,
                Stavke = stavke.ToList()
            };

            foreach (var s in stavke)
                s.Iznajmljivanje = novoIznajmljivanje;

            Response response = Communication.Instance.CreateIznajmljivanje(novoIznajmljivanje);

            if (response.ExceptionMessage == null)
            {
                MessageBox.Show("Систем је успешно креирао изнајмљивање.");

                // reset forme
                stavke.Clear();
                addRent.TxtUkupanIznos.Text = "0.00";
                addRent.LblRb.Text = "1";
                addRent.CbOsoba.SelectedIndex = -1;
                addRent.DtpSince.Value = DateTime.Now;
                addRent.DtpTo.Value = DateTime.Now.AddHours(1);
            }
            else
            {
                MessageBox.Show($"Систем не може да креира изнајмљивање.\n{response.ExceptionMessage}");
            }
        }



        private void UpdateTrajanje(object? sender, EventArgs e)
        {
            DateTime od = addRent.DtpSince.Value;
            DateTime doo = addRent.DtpTo.Value;

            if (doo < od)
            {
                addRent.TxtTrajanje.Text = "0";
                return;
            }

            // zaokruzivanje na sledeci sat
            var razlika = doo - od;
            int trajanje = (int)Math.Ceiling(razlika.TotalHours);
            if (trajanje < 0) 
                trajanje = 0;

            addRent.TxtTrajanje.Text = trajanje.ToString();

            iznajmljivanje.VremeOd = od;
            UpdateIznos();
        }



        private void ShowPrice(object? sender, EventArgs e)
        {
            if (addRent.CbOprema.SelectedItem is Oprema oprema)
                addRent.TxtCena.Text = oprema.Cena.ToString();

            UpdateIznos();
        }



        private void UpdateIznos()
        {
            if (!decimal.TryParse(addRent.TxtCena.Text, out decimal cena)) 
                cena = 0;
            if (!int.TryParse(addRent.TxtTrajanje.Text, out int trajanje)) 
                trajanje = 0;
            if (!int.TryParse(addRent.TxtKolicina.Text, out int kolicina)) 
                kolicina = 0;

            decimal iznos = cena * trajanje * kolicina;
            addRent.TxtIznos.Text = iznos.ToString("0.00");
        }












        internal Control CreateManageRent()
        {
            manageRent = new UCManageRent();

            manageRent.BtnSearchIznajmljivanje.Click += SearchIznajmljivanja;
            manageRent.BtnShowIznajmljivanje.Click += ShowIznajmljivanje;

            var dgv = manageRent.DgvIznajmljivanja;
            dgv.AutoGenerateColumns = true;
            dgv.Columns.Clear();

            return manageRent;
        }



        private void SearchIznajmljivanja(object? sender, EventArgs e)
        {
            try
            {
                var i = new Iznajmljivanje();

                // Zaposleni
                if (manageRent.CbZaposleni.SelectedItem is Zaposleni z)
                    i.Zaposleni = new Zaposleni { Id = z.Id };

                // Osoba
                if (manageRent.CbOsoba.SelectedItem is Osoba o)
                    i.Osoba = new Osoba { Id = o.Id };

                // Oprema (preko stavke)
                if (manageRent.CbOprema.SelectedItem is Oprema op)
                {
                    i.Stavke = new List<StavkaIznajmljivanja>
                    {
                        new StavkaIznajmljivanja 
                        { 
                            Oprema = new Oprema 
                            { 
                                Id = op.Id 
                            } 
                        }
                    };
                }

                bool imaMin = decimal.TryParse(manageRent.TxtMin.Text, out var min);
                bool imaMax = decimal.TryParse(manageRent.TxtMax.Text, out var max);

                if (imaMin && imaMax && min > max)
                {
                    MessageBox.Show("Минимални износ не може бити већи од максималног.");
                    return;
                }
                var lista = Communication.Instance.SearchIznajmljivanje(i) ?? new List<Iznajmljivanje>();

                if (imaMin)
                {
                    lista = lista.Where(x => x.UkupanIznos >= min).ToList();
                }
                if (imaMax)
                {
                    lista = lista.Where(x => x.UkupanIznos <= max).ToList();
                }

                manageRent.DgvIznajmljivanja.DataSource = new BindingList<Iznajmljivanje>(lista.ToList());

                MessageBox.Show(lista.Count == 0
                    ? "Систем не може да нађе изнајмљивања по задатим критеријумима."
                    : "Систем је нашао изнајмљивања по задатим критеријумима.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Систем не може да нађе изнајмљивања по задатим критеријумима.");
            }
        }




        private void ShowIznajmljivanje(object sender, EventArgs e)
        {
           
        }
    }
}
