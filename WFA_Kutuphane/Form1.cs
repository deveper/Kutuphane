using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace WFA_Kutuphane
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> turler = new List<string> { "macera", "roman", "Ders", "Biyografi" };
            cmbTur.Items.AddRange(turler.ToArray());
        }
        void Kontrol(Control.ControlCollection ctrl)
        {
            foreach (Control item in ctrl)
            {
                if (item is MetroTextBox)
                {
                    //MetroTextBox txt = (MetroTextBox)item;
                    if (String.IsNullOrEmpty(item.Text))
                    {
                        errorProvider1.SetError(item, "Alan Boş Bırakılamaz...");
                    }
                }
                else if (item is NumericUpDown)
                {
                    NumericUpDown nmb = (NumericUpDown)item;
                    if (nmb.Value==0)
                    {
                        errorProvider1.SetError(nmb, "Alan boş bırakılamaz!");
                    }
                }
                else if (item is GroupBox)
                {
                    GroupBox grp = (GroupBox)item;
                    Kontrol(grp.Controls);
                }

            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            //if (!String.IsNullOrEmpty(txtKitapAdi.Text) && !String.IsNullOrEmpty(txtYazarAdi.Text) && nmrSayfaSayisi.Value != 0)
            //{

            //}
            //else if (String.IsNullOrEmpty(txtKitapAdi.Text) && !String.IsNullOrEmpty(txtYazarAdi.Text) && nmrSayfaSayisi.Value != 0)
            //{
            //    errorProvider1.SetError(txtKitapAdi, "Kitap adı boş bırakılamaz!");
            //}
            //else if (!String.IsNullOrEmpty(txtKitapAdi.Text) && String.IsNullOrEmpty(txtYazarAdi.Text) && nmrSayfaSayisi.Value != 0)
            //{
            //    errorProvider1.SetError(txtYazarAdi, "Yazar adı boş bırakılamaz!");
            //}
            Kontrol(this.Controls);

        }

    }
}
