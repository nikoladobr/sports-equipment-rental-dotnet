using Azure;
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
using Response = Common.Communication.Response;

namespace Client.GuiController
{
    public class RentGuiController
    {
        private UCAddRent addRent;
        private UCManageRent manageRent;
        private UCShowRent showRent;

        private Iznajmljivanje iznajmljivanje;
        private StavkaIznajmljivanja stavkaIznajmljivanja;

        private int selectedId;

        private readonly BindingList<StavkaIznajmljivanja> stavke = new();






        // ~~~~~~~~~~~~~~~ UCAddRent ~~~~~~~~~~~~~~~

        internal Control CreateAddRent()
        {
            iznajmljivanje = new();
            stavkaIznajmljivanja = new();

            addRent = new UCAddRent();

            addRent.DtpSince.Format = DateTimePickerFormat.Custom;
            addRent.DtpSince.CustomFormat = "dd.MM.yyyy. HH:mm";
            addRent.DtpTo.Format = DateTimePickerFormat.Custom;
            addRent.DtpTo.CustomFormat = "dd.MM.yyyy. HH:mm";



            BindingList<Oprema> oprema = new BindingList<Oprema>((List<Oprema>)Communication.Instance.GetAllOprema());
            addRent.CbOprema.DataSource = oprema;
            addRent.CbOprema.DisplayMember = "Naziv";
            addRent.CbOprema.SelectedIndex = -1;

            BindingList<Osoba> osobe = new BindingList<Osoba>((List<Osoba>)Communication.Instance.GetAllOsoba());
            addRent.CbOsoba.DataSource = osobe;
            addRent.CbOsoba.DisplayMember = "Email";
            addRent.CbOsoba.SelectedIndex = -1;

            if (addRent.CbOprema.SelectedItem != null)
            {
                Oprema opremica = (Oprema)addRent.CbOprema.SelectedItem;
                addRent.TxtCena.Text = opremica.Cena.ToString();
            }
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
            {
                s.Iznajmljivanje = novoIznajmljivanje;
            }

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











        // ~~~~~~~~~~~~~~~ UCManageRent ~~~~~~~~~~~~~~~
        internal Control CreateManageRent()
        {
            manageRent = new UCManageRent();

            manageRent.BtnSearchIznajmljivanje.Click += SearchIznajmljivanja;
            manageRent.BtnShowIznajmljivanje.Click += ShowIznajmljivanje;

            var dgv = manageRent.DgvIznajmljivanja;
            dgv.AutoGenerateColumns = true;
            dgv.Columns.Clear();

            var iznajmljivanja = new List<Iznajmljivanje>();

            BindingList<Oprema> oprema = new BindingList<Oprema>((List<Oprema>)Communication.Instance.GetAllOprema());
            manageRent.CbOprema.DataSource = oprema;
            manageRent.CbOprema.DisplayMember = "Naziv";
            manageRent.CbOprema.SelectedIndex = -1;

            BindingList<Osoba> osobe = new BindingList<Osoba>((List<Osoba>)Communication.Instance.GetAllOsoba());
            manageRent.CbOsoba.DataSource = osobe;
            manageRent.CbOsoba.DisplayMember = "Email";
            manageRent.CbOsoba.SelectedIndex = -1;

            BindingList<Zaposleni> zaposleni = new BindingList<Zaposleni>((List<Zaposleni>)Communication.Instance.GetAllZaposleni());
            manageRent.CbZaposleni.DataSource = zaposleni;
            manageRent.CbZaposleni.DisplayMember = "Ime";
            manageRent.CbZaposleni.SelectedIndex = -1;

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
                var dgv = manageRent.DgvIznajmljivanja;
                if (dgv.Columns.Contains("UkupanIznos"))
                    dgv.Columns["UkupanIznos"].HeaderText = "Укупан износ";
                if (dgv.Columns.Contains("VremeOd"))
                    dgv.Columns["VremeOd"].HeaderText = "Од";
                if (dgv.Columns.Contains("Zaposleni"))
                    dgv.Columns["Zaposleni"].HeaderText = "Запослени";
                if (dgv.Columns.Contains("Osoba"))
                    dgv.Columns["Osoba"].HeaderText = "Особа";
                dgv.Columns[5].Visible = false;
                dgv.Columns[6].Visible = false;

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
            if(manageRent.DgvIznajmljivanja.SelectedRows.Count != 1)
            {
                MessageBox.Show("Изаберите изнајмљивање из табеле.");
                return;
            }
            if (manageRent.DgvIznajmljivanja.CurrentRow?.DataBoundItem is not Iznajmljivanje selektovano)
            {
                MessageBox.Show("Изаберите изнајмљивање из табеле.");
                return;
            }

            var full = Communication.Instance.GetIznajmljivanjeById(selektovano.Id);
            if (full == null)
            {
                MessageBox.Show("Систем не може да нађе изнајмљивање");
                return;
            }

            selectedId = selektovano.Id;
            iznajmljivanje = (Iznajmljivanje)full;

            MessageBox.Show("Систем је нашао изнајмљивање");
            MainCoordinator.Instance.ShowShowRentPanel();
        }











        // ~~~~~~~~~~~~~~~ UCShowRent ~~~~~~~~~~~~~~~
        internal Control CreateShowRent()
        {
            if (iznajmljivanje == null && selectedId > 0)
                iznajmljivanje = (Iznajmljivanje)Communication.Instance.GetIznajmljivanjeById(selectedId);

            if (iznajmljivanje == null || iznajmljivanje.Id <= 0)
            {
                MessageBox.Show("Није учитано изнајмљивање (ID).");
                return new Panel();
            }

            showRent = new UCShowRent();

            //DTP
            showRent.DtpSince.Format = DateTimePickerFormat.Custom;
            showRent.DtpSince.CustomFormat = "dd.MM.yyyy. HH:mm";
            showRent.DtpTo.Format = DateTimePickerFormat.Custom;
            showRent.DtpTo.CustomFormat = "dd.MM.yyyy. HH:mm";

            //CB
            var sveOpreme = Communication.Instance.GetAllOprema();
            showRent.CbOprema.DataSource = new BindingList<Oprema>(sveOpreme);
            showRent.CbOprema.DisplayMember = "NazivO";
            showRent.CbOprema.SelectedIndex = -1;
            showRent.CbOprema.SelectedItem = null;

            var sveOsobe = Communication.Instance.GetAllOsoba();
            showRent.CbOsoba.DataSource = new BindingList<Osoba>(sveOsobe);
            showRent.CbOsoba.DisplayMember = "Email";
            if (iznajmljivanje.Osoba != null)
            {
                showRent.CbOsoba.SelectedItem = sveOsobe.FirstOrDefault(x => x.Id == iznajmljivanje.Osoba.Id);
            }

            var sviZaposleni = Communication.Instance.GetAllZaposleni();
            showRent.CbZaposleni.DataSource = new BindingList<Zaposleni>(sviZaposleni);
            showRent.CbZaposleni.DisplayMember = "KorisnickoIme";
            if (iznajmljivanje.Zaposleni != null)
            {
                showRent.CbZaposleni.SelectedItem = sviZaposleni.FirstOrDefault(x => x.Id == iznajmljivanje.Zaposleni.Id);
            }

            showRent.TxtUkupanIznos.Text = iznajmljivanje.UkupanIznos.ToString("0.00");
            showRent.DtpSince.Value = iznajmljivanje.VremeOd;

            var dgv = showRent.DgvStavkeIznajmljivanja;
            dgv.AutoGenerateColumns = true;
            dgv.Columns.Clear();

            showRent.CbOprema.SelectedIndexChanged += (s, e) =>
            {
                if (showRent.CbOprema.SelectedItem is Oprema op)
                    showRent.TxtCena.Text = op.Cena.ToString("0.00");
                else
                    showRent.TxtCena.Text = "";
                IzracunajIznosStavkeShow();
            };
            showRent.TxtKolicina.TextChanged += (s, e) => IzracunajIznosStavkeShow();
            showRent.DtpSince.ValueChanged += (s, e) => { PostaviTrajanjeShow(); IzracunajIznosStavkeShow(); };
            showRent.DtpTo.ValueChanged += (s, e) => { PostaviTrajanjeShow(); IzracunajIznosStavkeShow(); };

            showRent.BtnPrikazi.Click += (s, e) => PrikaziSelektovanuStavku();
            showRent.BtnAddRentalItem.Click += (s, e) => DodajStavkuNaPostojeceIznajmljivanje();
            showRent.BtnObrisi.Click += (s, e) => ObrisiSelektovanuStavku();

            OsveziStavkeINapuniUkupanIznos();

            showRent.Load += (s, e) =>
            {
                PostaviTrajanjeShow();
                IzracunajIznosStavkeShow();
            };

            return showRent;
        }



        private void PostaviTrajanjeShow()
        {
            if (showRent == null) 
                return;

            var diffHours = (showRent.DtpTo.Value - showRent.DtpSince.Value).TotalHours;
            int trajanje = (int)Math.Ceiling(diffHours);
            if (trajanje <= 0) trajanje = 1;

            showRent.TxtTrajanje.Text = trajanje.ToString();
        }



        private void IzracunajIznosStavkeShow()
        {
            if (showRent == null) return;

            decimal cena = decimal.TryParse(showRent.TxtCena.Text?.Trim(), out var c) ? c : 0M;
            int kolicina = int.TryParse(showRent.TxtKolicina.Text?.Trim(), out var k) ? k : 0;
            int trajanje = int.TryParse(showRent.TxtTrajanje.Text?.Trim(), out var t) ? t : 0;
            if (trajanje <= 0)
            {
                var razlika = (showRent.DtpTo.Value - showRent.DtpSince.Value).TotalHours;
                trajanje = Math.Max(1, (int)Math.Ceiling(razlika));
                showRent.TxtTrajanje.Text = trajanje.ToString();
            }

            showRent.TxtIznos.Text = (cena * kolicina * trajanje).ToString("0.00");
        }



        private void OsveziStavkeINapuniUkupanIznos()
        {
            if (iznajmljivanje == null || showRent == null) return;

            var stavke = Communication.Instance.GetStavkeByIznajmljivanjeId(iznajmljivanje.Id);
            showRent.DgvStavkeIznajmljivanja.DataSource = new BindingList<StavkaIznajmljivanja>(stavke);
            showRent.DgvStavkeIznajmljivanja.Columns[1].Visible = false;
            showRent.DgvStavkeIznajmljivanja.Columns[8].Visible = false;
            showRent.DgvStavkeIznajmljivanja.Columns[9].Visible = false;
            showRent.DgvStavkeIznajmljivanja.Columns[10].Visible = false;

            var dgv = showRent.DgvStavkeIznajmljivanja;
            if (dgv.Columns.Contains("Rb"))
                dgv.Columns["Rb"].HeaderText = "Редни број";
            if (dgv.Columns.Contains("IdIznajmljivanje"))
                dgv.Columns["IdIznajmljivanje"].HeaderText = "ID изнајмљивања";
            if (dgv.Columns.Contains("Kolicina"))
                dgv.Columns["Kolicina"].HeaderText = "Количина";
            if (dgv.Columns.Contains("Cena"))
                dgv.Columns["Cena"].HeaderText = "Цена (дин)";
            if (dgv.Columns.Contains("Trajanje"))
                dgv.Columns["Trajanje"].HeaderText = "Трајање (h)";
            if (dgv.Columns.Contains("Iznos"))
                dgv.Columns["Iznos"].HeaderText = "Износ (дин)";
            if (dgv.Columns.Contains("VremeDo"))
                dgv.Columns["VremeDo"].HeaderText = "До";
            if (dgv.Columns.Contains("Oprema"))
                dgv.Columns["Oprema"].HeaderText = "Опрема";
            var full = Communication.Instance.GetIznajmljivanjeById(iznajmljivanje.Id);
            if (full is Iznajmljivanje i)
            {
                iznajmljivanje = i;
                showRent.TxtUkupanIznos.Text = i.UkupanIznos.ToString("0.00");
            }
            
            PostaviTrajanjeShow();
            IzracunajIznosStavkeShow();
        }



        private void PrikaziSelektovanuStavku()
        {
            var grid = showRent.DgvStavkeIznajmljivanja;
            if (grid.CurrentRow == null || grid.CurrentRow.DataBoundItem is not StavkaIznajmljivanja stavka)
            {
                MessageBox.Show("Изаберите ставку из табеле ставки.");
                return;
            }

            if (showRent.CbOprema.DataSource == null)
            {
                var sveOpreme = Communication.Instance.GetAllOprema();
                showRent.CbOprema.DataSource = new BindingList<Oprema>(sveOpreme);
                showRent.CbOprema.DisplayMember = "NazivO";
            }

            if (showRent.CbOprema.DataSource is BindingList<Oprema> opreme && stavka.Oprema != null)
            {
                var match = opreme.FirstOrDefault(o => o.Id == stavka.Oprema.Id);
                showRent.CbOprema.SelectedItem = match;
            }

            showRent.TxtCena.Text = stavka.Cena.ToString("0.00");
            showRent.TxtKolicina.Text = stavka.Kolicina.ToString();

            showRent.DtpTo.Value = stavka.VremeDo;

            var razlika = stavka.VremeDo - showRent.DtpSince.Value;
            int trajanje = (int)Math.Ceiling(razlika.TotalHours);
            if (trajanje < 0) trajanje = 0;
            showRent.TxtTrajanje.Text = trajanje.ToString();

            decimal iznos = stavka.Cena * trajanje * stavka.Kolicina;
            showRent.TxtIznos.Text = iznos.ToString("0.00");
        }



        private void DodajStavkuNaPostojeceIznajmljivanje()
        {
            if (iznajmljivanje == null)
            {
                MessageBox.Show("Нема учитаног изнајмљивања");
                return;
            }
            if (showRent.CbOprema.SelectedItem is not Oprema oprema)
            {
                MessageBox.Show("Одабери опрему");
                return;
            }
            if (!int.TryParse(showRent.TxtKolicina.Text.Trim(), out int kolicina) || kolicina <= 0)
            {
                showRent.TxtKolicina.BackColor = Color.MistyRose;
                MessageBox.Show("Количина мора бити цео број > 0");
                return;
            }
            if (!decimal.TryParse(showRent.TxtCena.Text.Trim(), out decimal cena) || cena <= 0)
            {
                showRent.TxtCena.BackColor = Color.MistyRose;
                MessageBox.Show("Цена мора бити > 0");
                return;
            }

            DateTime vremeOd = showRent.DtpSince.Value;
            DateTime vremeDo = showRent.DtpTo.Value;
            if (vremeDo <= vremeOd)
            {
                MessageBox.Show("Поље 'До' мора бити после поља 'Од'.");
                return;
            }

            var diff = showRent.DtpTo.Value - showRent.DtpSince.Value;
            int trajanje = Math.Max(1, (int)Math.Ceiling(diff.TotalHours));
            decimal iznos = cena * trajanje * kolicina;

            var s = new StavkaIznajmljivanja
            {
                IdIznajmljivanje = iznajmljivanje.Id,
                Iznajmljivanje = new Iznajmljivanje { Id = iznajmljivanje.Id },
                Oprema = new Oprema { Id = oprema.Id },
                Kolicina = kolicina,
                Cena = cena,
                VremeDo = showRent.DtpTo.Value,
                Trajanje = trajanje,
                Iznos = iznos
            };

            Communication.Instance.AddStavka(s);

            OsveziStavkeINapuniUkupanIznos();
            MessageBox.Show("Систем је запамтио изнајмљивање.");

            showRent.CbOprema.SelectedIndex = -1;
            showRent.TxtKolicina.Text = "";
            showRent.TxtCena.Text = "";
            showRent.TxtIznos.Text = "";
            showRent.DtpTo.Value = showRent.DtpSince.Value;

            showRent.TxtKolicina.BackColor = SystemColors.Window;
            showRent.TxtCena.BackColor = SystemColors.Window;

            PostaviTrajanjeShow();
            IzracunajIznosStavkeShow();
        }



        private void ObrisiSelektovanuStavku()
        {
            var grid = showRent.DgvStavkeIznajmljivanja;
            if (grid.CurrentRow == null || grid.CurrentRow.DataBoundItem is not StavkaIznajmljivanja s)
            {
                MessageBox.Show("Изабери ставку из табеле за брисање.");
                return;
            }

            var potvrdjeno = MessageBox.Show("Да ли сигурно желиш да обришеш ставку?", "Потврда", MessageBoxButtons.YesNo) == DialogResult.Yes;
            if (!potvrdjeno) 
                return;

            Communication.Instance.RemoveStavka(new StavkaIznajmljivanja
            {
                IdIznajmljivanje = iznajmljivanje.Id,
                Rb = s.Rb
            });

            OsveziStavkeINapuniUkupanIznos();
            MessageBox.Show("Систем је запамтио изнајмљивање.");
        }

       
    }
}
