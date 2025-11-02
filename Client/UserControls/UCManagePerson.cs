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
                MessageBox.Show("Неисправан унос емаила (@)");
                txtEmail.BackColor = Color.Salmon;
                isValid = false;
            }
            return isValid;
        }
    }
}
