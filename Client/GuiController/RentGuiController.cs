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
        private BindingList<StavkaIznajmljivanja> stavkeShow = new();





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
            addRent.CbOprema.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            addRent.CbOprema.AutoCompleteSource = AutoCompleteSource.ListItems;

            BindingList<Osoba> osobe = new BindingList<Osoba>((List<Osoba>)Communication.Instance.GetAllOsoba());
            addRent.CbOsoba.DataSource = osobe;
            addRent.CbOsoba.DisplayMember = "Email";
            addRent.CbOsoba.SelectedIndex = -1;
            addRent.CbOsoba.AutoCompleteMode = AutoCompleteMode.SuggestAppend; 
            addRent.CbOsoba.AutoCompleteSource = AutoCompleteSource.ListItems;

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

            var dgv = addRent.DgvStavke;
            dgv.AutoGenerateColumns = false;                 
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Rb", HeaderText = "Редни број", Width = 90 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Kolicina", HeaderText = "Количина", Width = 90 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cena", HeaderText = "Цена (дин)", Width = 100, DefaultCellStyle = { Format = "0.00" } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VremeDo", HeaderText = "До", Width = 150, DefaultCellStyle = { Format = "g" } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Trajanje", HeaderText = "Трајање (h)", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Iznos", HeaderText = "Износ (дин)", Width = 110, DefaultCellStyle = { Format = "0.00" } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Oprema.NazivO", HeaderText = "Опрема", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            dgv.DataSource = stavke;

            addRent.BtnObrisi.Enabled = false;

            addRent.DgvStavke.SelectionChanged += (s, e) =>
            {
                var grid = addRent.DgvStavke;
                addRent.BtnObrisi.Enabled =
                    grid.CurrentRow != null &&
                    grid.CurrentRow.Index >= 0 &&
                    grid.CurrentRow.DataBoundItem is StavkaIznajmljivanja;
            };

            addRent.DgvStavke.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Delete && addRent.BtnObrisi.Enabled)
                {
                    RemoveSelectedAddItem();
                    e.Handled = true;
                }
            };

            addRent.BtnObrisi.Click += (s, e) => RemoveSelectedAddItem();

            return addRent;
        }

        private void RemoveSelectedAddItem()
        {
            var grid = addRent?.DgvStavke;
            if (grid == null || grid.CurrentRow == null ||
                grid.CurrentRow.DataBoundItem is not StavkaIznajmljivanja sel)
            {
                MessageBox.Show("Изабери ставку из табеле за брисање.");
                return;
            }

            var potvrda = MessageBox.Show(
                "Да ли сигурно желиш да обришеш изабрану ставку?",
                "Потврда", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

            if (!potvrda) return;

            stavke.Remove(sel);

            int rb = 1;
            foreach (var it in stavke) it.Rb = rb++;

            addRent.TxtUkupanIznos.Text = stavke.Sum(x => x.Iznos).ToString("0.00");
            addRent.LblRb.Text = (stavke.Count + 1).ToString();

            addRent.CbOprema.SelectedIndex = -1;
            addRent.TxtKolicina.Text = "";
            addRent.TxtCena.Text = "";
            addRent.TxtIznos.Text = "";
            addRent.TxtTrajanje.Text = "";

            if (stavke.Count > 0)
            {
                var last = stavke.Count - 1;
                grid.ClearSelection();
                grid.Rows[last].Selected = true;
                grid.CurrentCell = grid.Rows[last].Cells[0];
                addRent.BtnObrisi.Enabled = true;
            }
            else
            {
                addRent.BtnObrisi.Enabled = false;
            }
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
                MessageBox.Show("Систем не може да запамти изнајмљивање");
                MessageBox.Show("Додај бар једну ставку изнајмљивања пре чувања документа.");
                return;
            }

            if (addRent.CbOsoba.SelectedItem is not Osoba osoba)
            {
                MessageBox.Show("Систем не може да запамти изнајмљивање");
                MessageBox.Show("Одабери особу.");
                return;
            }

            var zaposleni = Session.Instance.Zaposleni;
            if (zaposleni == null)
            {
                MessageBox.Show("Систем не може да запамти изнајмљивање");
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
                MessageBox.Show("Систем је запамтио изнајмљивање");

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
                MessageBox.Show("Систем не може да запамти изнајмљивање");
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

            var oprema = new BindingList<Oprema>((List<Oprema>)Communication.Instance.GetAllOprema());
            manageRent.CbOprema.DataSource = oprema;
            manageRent.CbOprema.DisplayMember = "NazivO";
            manageRent.CbOprema.SelectedIndex = -1;
            manageRent.CbOprema.DropDownStyle = ComboBoxStyle.DropDown;
            manageRent.CbOprema.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            manageRent.CbOprema.AutoCompleteSource = AutoCompleteSource.ListItems;

            var osobe = new BindingList<Osoba>((List<Osoba>)Communication.Instance.GetAllOsoba());
            manageRent.CbOsoba.DataSource = osobe;
            manageRent.CbOsoba.DisplayMember = "Email";
            manageRent.CbOsoba.SelectedIndex = -1;
            manageRent.CbOsoba.DropDownStyle = ComboBoxStyle.DropDown;
            manageRent.CbOsoba.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            manageRent.CbOsoba.AutoCompleteSource = AutoCompleteSource.ListItems;

            var zaposleni = new BindingList<Zaposleni>((List<Zaposleni>)Communication.Instance.GetAllZaposleni());
            manageRent.CbZaposleni.DataSource = zaposleni;
            manageRent.CbZaposleni.DisplayMember = "Ime"; 
            manageRent.CbZaposleni.SelectedIndex = -1;
            manageRent.CbZaposleni.DropDownStyle = ComboBoxStyle.DropDown;
            manageRent.CbZaposleni.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            manageRent.CbZaposleni.AutoCompleteSource = AutoCompleteSource.ListItems;

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
                                        new StavkaIznajmljivanja { Oprema = new Oprema { Id = op.Id } }
                                    };
                }

                bool imaMin = false, imaMax = false;
                decimal min = 0m, max = 0m;

                var rawMin = (manageRent.TxtMin.Text ?? string.Empty).Trim().Replace(" ", "").Replace("\u00A0", "");
                var rawMax = (manageRent.TxtMax.Text ?? string.Empty).Trim().Replace(" ", "").Replace("\u00A0", "");

                if (!string.IsNullOrEmpty(rawMin))
                {
                    imaMin =
                        decimal.TryParse(rawMin, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out min) ||
                        decimal.TryParse(rawMin.Replace(',', '.'), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out min) ||
                        decimal.TryParse(rawMin.Replace('.', ','), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("sr-RS"), out min);
                }
                if (!string.IsNullOrEmpty(rawMax))
                {
                    imaMax =
                        decimal.TryParse(rawMax, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out max) ||
                        decimal.TryParse(rawMax.Replace(',', '.'), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out max) ||
                        decimal.TryParse(rawMax.Replace('.', ','), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.GetCultureInfo("sr-RS"), out max);
                }

                if (imaMin && imaMax && min > max)
                {
                    MessageBox.Show("Минимални износ не може бити већи од максималног.");
                    return;
                }

                var lista = Communication.Instance.SearchIznajmljivanje(i) ?? new List<Iznajmljivanje>();

                if (imaMin) lista = lista.Where(x => x != null && x.UkupanIznos >= min).ToList();
                if (imaMax) lista = lista.Where(x => x != null && x.UkupanIznos <= max).ToList();

                manageRent.DgvIznajmljivanja.DataSource = new BindingList<Iznajmljivanje>(lista.ToList());
                var dgv = manageRent.DgvIznajmljivanja;
                if (dgv.Columns.Contains("UkupanIznos")) dgv.Columns["UkupanIznos"].HeaderText = "Укупан износ";
                if (dgv.Columns.Contains("VremeOd")) dgv.Columns["VremeOd"].HeaderText = "Од";
                if (dgv.Columns.Contains("Zaposleni")) dgv.Columns["Zaposleni"].HeaderText = "Запослени";
                if (dgv.Columns.Contains("Osoba")) dgv.Columns["Osoba"].HeaderText = "Особа";
                if (dgv.Columns.Count > 5) dgv.Columns[5].Visible = false;
                if (dgv.Columns.Count > 6) dgv.Columns[6].Visible = false;

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

            showRent.DtpSince.Format = DateTimePickerFormat.Custom;
            showRent.DtpSince.CustomFormat = "dd.MM.yyyy. HH:mm";
            showRent.DtpTo.Format = DateTimePickerFormat.Custom;
            showRent.DtpTo.CustomFormat = "dd.MM.yyyy. HH:mm";

            var sveOpreme = Communication.Instance.GetAllOprema();
            var sveOsobe = Communication.Instance.GetAllOsoba();
            var sviZaposleni = Communication.Instance.GetAllZaposleni();

            showRent.CbOprema.DataSource = new BindingList<Oprema>(sveOpreme);
            showRent.CbOprema.DisplayMember = "NazivO";
            showRent.CbOprema.SelectedIndex = -1;
            showRent.CbOprema.SelectedItem = null;
            showRent.CbOprema.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            showRent.CbOprema.AutoCompleteSource = AutoCompleteSource.ListItems;

            showRent.CbOsoba.DataSource = new BindingList<Osoba>(sveOsobe);
            showRent.CbOsoba.DisplayMember = "Email";
            if (iznajmljivanje.Osoba != null)
                showRent.CbOsoba.SelectedItem = sveOsobe.FirstOrDefault(x => x.Id == iznajmljivanje.Osoba.Id);

            showRent.CbZaposleni.DataSource = new BindingList<Zaposleni>(sviZaposleni);
            showRent.CbZaposleni.DisplayMember = "KorisnickoIme";
            if (iznajmljivanje.Zaposleni != null)
                showRent.CbZaposleni.SelectedItem = sviZaposleni.FirstOrDefault(x => x.Id == iznajmljivanje.Zaposleni.Id);

            showRent.TxtUkupanIznos.Text = iznajmljivanje.UkupanIznos.ToString("0.00");
            showRent.DtpSince.Value = iznajmljivanje.VremeOd;

            var inic = Communication.Instance.GetStavkeByIznajmljivanjeId(iznajmljivanje.Id) ?? new List<StavkaIznajmljivanja>();
            stavkeShow = new BindingList<StavkaIznajmljivanja>(inic);

            var dgv = showRent.DgvStavkeIznajmljivanja;
            dgv.AutoGenerateColumns = true;
            dgv.Columns.Clear();
            dgv.DataSource = stavkeShow;

            if (dgv.Columns.Contains("Rb")) dgv.Columns["Rb"].HeaderText = "Редни број";
            if (dgv.Columns.Contains("IdIznajmljivanje")) dgv.Columns["IdIznajmljivanje"].HeaderText = "ID изнајмљивања";
            if (dgv.Columns.Contains("Kolicina")) dgv.Columns["Kolicina"].HeaderText = "Количина";
            if (dgv.Columns.Contains("Cena")) dgv.Columns["Cena"].HeaderText = "Цена (дин)";
            if (dgv.Columns.Contains("Trajanje")) dgv.Columns["Trajanje"].HeaderText = "Трајање (h)";
            if (dgv.Columns.Contains("Iznos")) dgv.Columns["Iznos"].HeaderText = "Износ (дин)";
            if (dgv.Columns.Contains("VremeDo")) dgv.Columns["VremeDo"].HeaderText = "До";
            if (dgv.Columns.Contains("Oprema")) dgv.Columns["Oprema"].HeaderText = "Опрема";
            dgv.Columns[1].Visible = false;
            dgv.Columns[8].Visible = false;
            dgv.Columns[9].Visible = false;
            dgv.Columns[10].Visible = false;

            showRent.CbOprema.SelectedIndexChanged += (s, e) =>
            {
                if (showRent.CbOprema.SelectedItem is Oprema op) showRent.TxtCena.Text = op.Cena.ToString("0.00");
                else showRent.TxtCena.Text = "";
                IzracunajIznosStavkeShow();
            };
            showRent.TxtKolicina.TextChanged += (s, e) => IzracunajIznosStavkeShow();
            showRent.DtpSince.ValueChanged += (s, e) => { PostaviTrajanjeShow(); IzracunajIznosStavkeShow(); };
            showRent.DtpTo.ValueChanged += (s, e) => { PostaviTrajanjeShow(); IzracunajIznosStavkeShow(); };

            showRent.BtnPrikazi.Click += (s, e) => PrikaziSelektovanuStavku();

            showRent.BtnAddRentalItem.Click += (s, e) =>
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

                var diff = showRent.DtpTo.Value - showRent.DtpSince.Value;
                int trajanje = Math.Max(1, (int)Math.Ceiling(diff.TotalHours));
                decimal iznos = cena * trajanje * kolicina;

                var sItem = new StavkaIznajmljivanja
                {
                    IdIznajmljivanje = iznajmljivanje.Id,
                    Rb = (stavkeShow.Count == 0 ? 1 : stavkeShow.Max(x => x.Rb) + 1),
                    Oprema = new Oprema { Id = oprema.Id, NazivO = oprema.NazivO, Cena = oprema.Cena },
                    Kolicina = kolicina,
                    Cena = cena,
                    VremeDo = showRent.DtpTo.Value,
                    Trajanje = trajanje,
                    Iznos = iznos
                };

                stavkeShow.Add(sItem);
                showRent.TxtUkupanIznos.Text = stavkeShow.Sum(x => x.Iznos).ToString("0.00");

                showRent.CbOprema.SelectedIndex = -1;
                showRent.TxtKolicina.Text = "";
                showRent.TxtCena.Text = "";
                showRent.TxtIznos.Text = "";
                showRent.DtpTo.Value = showRent.DtpSince.Value.AddHours(1);
                showRent.TxtKolicina.BackColor = SystemColors.Window;
                showRent.TxtCena.BackColor = SystemColors.Window;

                PostaviTrajanjeShow();
                IzracunajIznosStavkeShow();
            };

            showRent.BtnObrisi.Click += (s, e) =>
            {
                var grid = showRent.DgvStavkeIznajmljivanja;
                if (grid.CurrentRow == null || grid.CurrentRow.DataBoundItem is not StavkaIznajmljivanja sItem)
                {
                    MessageBox.Show("Изабери ставку из табеле за брисање.");
                    return;
                }

                var potvrdjeno = MessageBox.Show("Да ли сигурно желиш да обришеш ставку?", "Потврда", MessageBoxButtons.YesNo) == DialogResult.Yes;
                if (!potvrdjeno) return;

                stavkeShow.Remove(sItem);
                int rb = 1; foreach (var it in stavkeShow) it.Rb = rb++;

                showRent.TxtUkupanIznos.Text = stavkeShow.Sum(x => x.Iznos).ToString("0.00");
                PostaviTrajanjeShow();
                IzracunajIznosStavkeShow();
            };

            showRent.BtnSacuvaj.Click += (s, e) =>
            {
                if (showRent.CbOsoba.SelectedItem is not Osoba osoba)
                {
                    MessageBox.Show("Систем не може да запамти изнајмљивање");
                    MessageBox.Show("Одабери особу.");
                    return;
                }
                if (showRent.CbZaposleni.SelectedItem is not Zaposleni zap)
                {
                    MessageBox.Show("Систем не може да запамти изнајмљивање");
                    MessageBox.Show("Одабери запосленог.");
                    return;
                }
                if (stavkeShow.Count == 0)
                {
                    MessageBox.Show("Систем не може да запамти изнајмљивање");
                    MessageBox.Show("Додај бар једну ставку.");
                    return;
                }

                var vremeOd = showRent.DtpSince.Value;

                foreach (var sItem in stavkeShow)
                {
                    if (sItem.Trajanje <= 0)
                    {
                        MessageBox.Show($"Ставка #{sItem.Rb}: трајање мора бити > 0.");
                        return;
                    }
                    if (sItem.VremeDo <= vremeOd)
                    {
                        MessageBox.Show($"Ставка #{sItem.Rb}: поље 'До' мора бити после поља 'Од'.");
                        return;
                    }
                    if (sItem.Oprema == null || sItem.Oprema.Id <= 0)
                    {
                        MessageBox.Show($"Ставка #{sItem.Rb}: недостаје опрема.");
                        return;
                    }
                }

                iznajmljivanje.Osoba = new Osoba { Id = osoba.Id };
                iznajmljivanje.Zaposleni = new Zaposleni { Id = zap.Id };
                iznajmljivanje.VremeOd = vremeOd;
                iznajmljivanje.UkupanIznos = stavkeShow.Sum(x => x.Iznos);

                int rbN = 1; foreach (var it in stavkeShow) it.Rb = rbN++;

                iznajmljivanje.Stavke = stavkeShow.Select(sx => new StavkaIznajmljivanja
                {
                    IdIznajmljivanje = iznajmljivanje.Id,
                    Rb = sx.Rb,
                    Kolicina = sx.Kolicina,
                    Cena = sx.Cena,
                    VremeDo = sx.VremeDo,
                    Trajanje = sx.Trajanje,
                    Iznos = sx.Iznos,
                    Oprema = new Oprema { Id = sx.Oprema.Id }
                }).ToList();

                try
                {
                    var resp = Communication.Instance.UpdateIznajmljivanje(iznajmljivanje);
                    if (resp.ExceptionMessage != null)
                    {
                        MessageBox.Show("Систем не може да запамти изнајмљивање"); 
                        return;
                    }

                    MessageBox.Show("Систем је запамтио изнајмљивање.");

                    var osvezi = Communication.Instance.GetIznajmljivanjeById(iznajmljivanje.Id);
                    if (osvezi is Iznajmljivanje iOsvezi)
                    {
                        iznajmljivanje = iOsvezi;
                        showRent.TxtUkupanIznos.Text = iOsvezi.UkupanIznos.ToString("0.00");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Систем не може да запамти изнајмљивање");
                }
            };

            showRent.Load += (s, e) =>
            {
                PostaviTrajanjeShow();
                IzracunajIznosStavkeShow();
                showRent.TxtUkupanIznos.Text = stavkeShow.Sum(x => x.Iznos).ToString("0.00");
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
    }
}
