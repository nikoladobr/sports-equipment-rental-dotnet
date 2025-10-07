using Common.Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCManagePerson : UserControl
    {
        public UCManagePerson()
        {
            InitializeComponent();

            var osobe = new List<Osoba>();

            var kategorije = Communication.Instance.GetAllKategorijaOsobe() ?? new List<KategorijaOsobe>();
            kategorije.Insert(0, new KategorijaOsobe { Id = 0, Naziv = "" });

            cbKategorija.DisplayMember = "Naziv";
            cbKategorija.ValueMember = "Id";
            cbKategorija.DataSource = new BindingList<KategorijaOsobe>(kategorije);
            cbKategorija.SelectedIndex = 0;

            dgvOsobe.AutoGenerateColumns = false;
            dgvOsobe.AllowUserToAddRows = false;
            dgvOsobe.ReadOnly = true;

            dgvOsobe.Columns.Clear();
            dgvOsobe.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ime", DataPropertyName = "Ime" });
            dgvOsobe.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Prezime", DataPropertyName = "Prezime" });
            dgvOsobe.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email" });

            var colKat = new DataGridViewComboBoxColumn
            {
                HeaderText = "Kategorija",
                DataPropertyName = "KategorijaId",
                DataSource = kategorije,
                ValueMember = "Id",
                DisplayMember = "Naziv",
                ValueType = typeof(int),
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            };
            dgvOsobe.Columns.Add(colKat);

            dgvOsobe.DataSource = new BindingList<Osoba>(osobe);
        }
        public bool Validacija()
        {
            txtIme.BackColor = Color.White;
            txtPrezime.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            cbKategorija.BackColor = Color.White;
            bool isValid = true;
            if (string.IsNullOrEmpty(txtIme.Text))
            {
                txtIme.BackColor = Color.Salmon;
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtPrezime.Text))
            {
                txtPrezime.BackColor = Color.Salmon;
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.BackColor = Color.Salmon;
                isValid = false;
            }
            if (cbKategorija.SelectedIndex == -1)
            {
                cbKategorija.BackColor = Color.Salmon;
                isValid = false;
            }
            if (!txtEmail.Text.Contains('@'))
            {
                MessageBox.Show("Neispravan unos emaila (@)");
                txtEmail.BackColor = Color.Salmon;
                isValid = false;
            }
            return isValid;
        }
    }
}
