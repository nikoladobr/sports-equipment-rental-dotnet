using Client.UserControls;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class PersonGuiController
    {
        private UCAddPerson addPerson;
        private UCManagePerson managePerson;
        Osoba o;

        internal Control CreateAddPerson()
        {
            addPerson = new UCAddPerson();
            o = new Osoba();
            MessageBox.Show("Систем је креирао особу");
            addPerson.BtnAddPerson.Click += AddPerson;
            return addPerson;
        }

        internal Control CreateManagePerson()
        {
            managePerson = new UCManagePerson();

            var kategorije = Communication.Instance.GetAllKategorijaOsobe() ?? new List<KategorijaOsobe>();
            kategorije.Insert(0, new KategorijaOsobe { Id = 0, Naziv = "" });

            managePerson.CbKategorija.DisplayMember = "Naziv";
            managePerson.CbKategorija.ValueMember = "Id";
            managePerson.CbKategorija.DataSource = kategorije;
            managePerson.CbKategorija.SelectedIndex = 0;

            managePerson.BtnSearchPerson.Click += SearchPerson;
            managePerson.BtnShowPerson.Click += ShowPerson;
            managePerson.BtnEditPerson.Click += EditPerson;
            managePerson.BtnEditPerson.Enabled = false;
            managePerson.BtnRemovePerson.Enabled = false;
            managePerson.BtnShowPerson.Enabled = false;

            managePerson.DgvOsobe.SelectionChanged += (s, e) =>
                managePerson.BtnShowPerson.Enabled = managePerson.DgvOsobe.SelectedRows.Count > 0;

            managePerson.BtnRemovePerson.Click += RemovePerson;

            return managePerson;
        }

        private void AddPerson(object? sender, EventArgs e)
        {
            o.Ime = addPerson.TxtIme.Text;
            o.Prezime = addPerson.TxtPrezime.Text;
            o.Email = addPerson.TxtEmail.Text;
            o.KategorijaOsobe = (KategorijaOsobe)addPerson.CbKategorija.SelectedItem;

            Response response = Communication.Instance.CreatePerson(o);
            if (response.ExceptionMessage == null)
            {
                MessageBox.Show("Систем је запамтио особу.");
            }
            else
            {
                Debug.WriteLine(response.ExceptionMessage);
            }
        }

        private void RemovePerson(object? sender, EventArgs e)
        {
            Osoba osoba = (Osoba)managePerson.DgvOsobe.SelectedRows[0].DataBoundItem;

            Response response = Communication.Instance.RemovePerson(osoba);
            if (response.ExceptionMessage == null)
            {
                MessageBox.Show("Систем је обрисао особу.");
            }
            else
            {
                Debug.WriteLine(response.ExceptionMessage);
            }
        }

        private void SearchPerson(object? sender, EventArgs e)
        {
            managePerson.BtnEditPerson.Enabled = false;
            managePerson.BtnRemovePerson.Enabled = false;
            managePerson.BtnShowPerson.Enabled = false;

            Osoba kriterijum = new Osoba
            {
                Ime = managePerson.TxtIme.Text,
                Prezime = managePerson.TxtPrezime.Text,
                Email = managePerson.TxtEmail.Text,
                KategorijaOsobe = managePerson.CbKategorija.SelectedItem as KategorijaOsobe
            };

            var osobe = Communication.Instance.SearchPerson(kriterijum) ?? new List<Osoba>();
            managePerson.DgvOsobe.DataSource = new BindingList<Osoba>(osobe);

            MessageBox.Show(osobe.Count > 0
                ? "Систем је нашао особе по задатим критеријумима."
                : "Систем не може да нађе особе по задатим критеријумима.");
        }

        private void ShowPerson(object? sender, EventArgs e)
        {
            if (managePerson.DgvOsobe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Изаберите особу.");
                return;
            }

            var selektovana = managePerson.DgvOsobe.SelectedRows[0].DataBoundItem as Osoba;
            if (selektovana == null) { MessageBox.Show("Грешка при читању особе."); return; }

            var osoba = Communication.Instance.GetPersonById(new Osoba { Id = selektovana.Id });
            if (osoba == null) { MessageBox.Show("Систем не може да нађе особу."); return; }

            managePerson.TxtIme.Text = osoba.Ime;
            managePerson.TxtPrezime.Text = osoba.Prezime;
            managePerson.TxtEmail.Text = osoba.Email;

            var targetId = osoba.KategorijaOsobe?.Id ?? 0;
            if (managePerson.CbKategorija.DataSource == null || string.IsNullOrEmpty(managePerson.CbKategorija.ValueMember))
            {
                var kategorije = Communication.Instance.GetAllKategorijaOsobe() ?? new List<KategorijaOsobe>();
                kategorije.Insert(0, new KategorijaOsobe { Id = 0, Naziv = "" });
                managePerson.CbKategorija.DisplayMember = "Naziv";
                managePerson.CbKategorija.ValueMember = "Id";
                managePerson.CbKategorija.DataSource = kategorije;
            }

            if (targetId > 0) managePerson.CbKategorija.SelectedValue = targetId;
            else managePerson.CbKategorija.SelectedIndex = 0;

            MessageBox.Show("Систем је нашао особу.");

            managePerson.BtnEditPerson.Enabled = true;
            managePerson.BtnRemovePerson.Enabled = true;
        }

        private void EditPerson(object? sender, EventArgs e)
        {
            if (managePerson.DgvOsobe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Изаберите особу.");
                return;
            }

            Osoba staraOsoba = managePerson.DgvOsobe.SelectedRows[0].DataBoundItem as Osoba;
            if (staraOsoba == null) { MessageBox.Show("Грешка при читању особе."); return; }

            var o = new Osoba
            {
                Id = staraOsoba.Id,
                Ime = managePerson.TxtIme.Text,
                Prezime = managePerson.TxtPrezime.Text,
                Email = managePerson.TxtEmail.Text,
                KategorijaOsobe = managePerson.CbKategorija.SelectedItem as KategorijaOsobe
            };

            if (string.IsNullOrWhiteSpace(o.Ime) || string.IsNullOrWhiteSpace(o.Prezime))
            {
                MessageBox.Show("Попуните обавезна поља (Име, Презиме).");
                return;
            }

            var resp = Communication.Instance.UpdatePerson(o);
            if (resp.ExceptionMessage == null)
            {
                MessageBox.Show("Систем је запамтио особу.");

                //refresh tabele
                SearchPerson(null, EventArgs.Empty);
            }
            else
            {
                Debug.WriteLine(resp.ExceptionMessage);
                MessageBox.Show("Систем не може да запамти особу.");
            }
        }
    }
}
