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
    public partial class UCManageRent : UserControl
    {
        public UCManageRent()
        {
            InitializeComponent();

            var iznajmljivanja = new List<Iznajmljivanje>();

            BindingList<Oprema> oprema = new BindingList<Oprema>((List<Oprema>)Communication.Instance.GetAllOprema());
            cbOprema.DataSource = oprema;
            cbOprema.DisplayMember = "Naziv";
            cbOprema.SelectedIndex = -1;

            BindingList<Osoba> osobe = new BindingList<Osoba>((List<Osoba>)Communication.Instance.GetAllOsoba());
            cbOsoba.DataSource = osobe;
            cbOsoba.DisplayMember = "Email";
            cbOsoba.SelectedIndex = -1;

            BindingList<Zaposleni> zaposleni = new BindingList<Zaposleni>((List<Zaposleni>)Communication.Instance.GetAllZaposleni());
            cbZaposleni.DataSource = zaposleni;
            cbZaposleni.DisplayMember = "Ime";
            cbZaposleni.SelectedIndex = -1;



        }
    }
}
