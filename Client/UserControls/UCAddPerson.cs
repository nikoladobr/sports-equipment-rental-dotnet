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
    }
}
