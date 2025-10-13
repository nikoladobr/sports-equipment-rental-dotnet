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
            addPerson.BtnAddPerson.Click += AddOsoba;
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

            managePerson.BtnSearchPerson.Click += SearchOsoba;
            managePerson.BtnShowPerson.Click += ShowOsoba;
            managePerson.BtnEditPerson.Click += EditOsoba;
            managePerson.BtnEditPerson.Enabled = false;
            managePerson.BtnRemovePerson.Enabled = false;
            managePerson.BtnShowPerson.Enabled = false;

            managePerson.DgvOsobe.SelectionChanged += (s, e) =>
                managePerson.BtnShowPerson.Enabled = managePerson.DgvOsobe.SelectedRows.Count > 0;

            managePerson.BtnRemovePerson.Click += RemoveOsoba;

            return managePerson;
        }

        private void AddOsoba(object? sender, EventArgs e)
        {
            if (!addPerson.Validacija())
            {
                MessageBox.Show("Попуните сва поља.");
                return;
            }
            o = new Osoba();
            o.Ime = addPerson.TxtIme.Text;
            o.Prezime = addPerson.TxtPrezime.Text;
            o.Email = addPerson.TxtEmail.Text;
            o.KategorijaOsobe = (KategorijaOsobe)addPerson.CbKategorija.SelectedItem;

            Response response = Communication.Instance.CreateOsoba(o);
            if (response.ExceptionMessage == null)
            {
                MessageBox.Show("Систем је креирао особу.");
            }
            else
            {
                Debug.WriteLine(response.ExceptionMessage);
            }
        }

        private void RemoveOsoba(object? sender, EventArgs e)
        {
            Osoba osoba = (Osoba)managePerson.DgvOsobe.SelectedRows[0].DataBoundItem;

            Response response = Communication.Instance.RemoveOsoba(osoba);
            if (response.ExceptionMessage == null)
            {
                MessageBox.Show("Систем је обрисао особу.");
            }
            else
            {
                Debug.WriteLine(response.ExceptionMessage);
            }
        }

        private void SearchOsoba(object? sender, EventArgs e)
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

            
            var osobe = Communication.Instance.SearchOsoba(kriterijum) ?? new List<Osoba>();
            managePerson.DgvOsobe.DataSource = new BindingList<Osoba>(osobe);

            MessageBox.Show(osobe.Count > 0
                ? "Систем је нашао особе по задатим критеријумима."
                : "Систем не може да нађе особе по задатим критеријумима.");
        }

        private void ShowOsoba(object? sender, EventArgs e)
        {
            if (managePerson.DgvOsobe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Изаберите особу.");
                return;
            }

            var selektovana = managePerson.DgvOsobe.SelectedRows[0].DataBoundItem as Osoba;
            if (selektovana == null) 
            { 
                MessageBox.Show("Грешка при читању особе."); 
                return; 
            }

            Osoba osoba = Communication.Instance.GetOsobaById(new Osoba { Id = selektovana.Id });
            if (osoba == null) 
            { 
                MessageBox.Show("Систем не може да нађе особу."); 
                return; 
            }

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

            if (targetId > 0) 
                managePerson.CbKategorija.SelectedValue = targetId;
            else 
                managePerson.CbKategorija.SelectedIndex = 0;

            MessageBox.Show("Систем је нашао особу.");

            managePerson.BtnEditPerson.Enabled = true;
            managePerson.BtnRemovePerson.Enabled = true;
        }

        private void EditOsoba(object? sender, EventArgs e)
        {
            if (managePerson.DgvOsobe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Изаберите особу.");
                return;
            }

            Osoba staraOsoba = managePerson.DgvOsobe.SelectedRows[0].DataBoundItem as Osoba;
            if (staraOsoba == null) 
            { 
                MessageBox.Show("Грешка при читању особе."); 
                return; 
            }

            if (!managePerson.Validacija())
            {
                MessageBox.Show("Неисправан унос.");
                return;
            }

            Osoba o = new Osoba
            {
                Id = staraOsoba.Id,
                Ime = managePerson.TxtIme.Text,
                Prezime = managePerson.TxtPrezime.Text,
                Email = managePerson.TxtEmail.Text,
                KategorijaOsobe = managePerson.CbKategorija.SelectedItem as KategorijaOsobe
            };

            

            var resp = Communication.Instance.UpdateOsoba(o);
            if (resp.ExceptionMessage == null)
            {
                MessageBox.Show("Систем је запамтио особу.");
                managePerson.TxtIme.Text = "";
                managePerson.TxtPrezime.Text = "";
                managePerson.TxtEmail.Text = "";
                
                //refresh tabele
                SearchOsoba(null, EventArgs.Empty);
            }
            else
            {
                Debug.WriteLine(resp.ExceptionMessage);
                MessageBox.Show("Систем не може да запамти особу.");
            }
        }
    }
}