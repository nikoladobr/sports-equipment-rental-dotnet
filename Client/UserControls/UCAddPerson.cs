using Common.Domain;
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
    public partial class UCAddPerson : UserControl
    {
        public UCAddPerson()
        {
            InitializeComponent();
            BindingList<KategorijaOsobe> kategorije = new BindingList<KategorijaOsobe>((List<KategorijaOsobe>)Communication.Instance.GetAllKategorijaOsobe());
            cbKategorija.DataSource = kategorije;
            cbKategorija.DisplayMember = "Naziv";
            cbKategorija.SelectedIndex = -1;
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
