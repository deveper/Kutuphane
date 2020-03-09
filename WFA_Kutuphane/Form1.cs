using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
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
                    if (nmb.Value == 0)
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
        void clearLst()
        {
            lstKitaplar.Items.Clear();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Kutuphane kutuphane = new Kutuphane();//instance aldık
            kutuphane.KitapAdi = txtKitapAdi.Text;
            kutuphane.YazarAdi = txtYazarAdi.Text;
            kutuphane.YayinEvi = txtYayinEvi.Text;
            kutuphane.BaskiSayi = Convert.ToString(nmrBaskiSayisi.Value);
            kutuphane.SayfaSayi = Convert.ToString(nmrSayfaSayisi.Value);
            kutuphane.BasimYili = dtBasimYili.Value;
            kutuphane.IsbnNo = int.Parse(txtISBNNo.Text);
            Kontrol(this.Controls);

            lstKitaplar.Items.Add(kutuphane.KitapAdi + "  " + kutuphane.YazarAdi + "  " + kutuphane.BasimYili + "  " + kutuphane.BaskiSayi);
            MetroMessageBox.Show(this, "Yeni Kitap Eklediniz...");
           
        }

        private void tsmSil_Click(object sender, EventArgs e)
        {
            DialogResult dio = new DialogResult();


            if (lstKitaplar.SelectedItems.Count == 0)
            {
                MetroMessageBox.Show(this, "Lütfen Bir Kayıt Seçiniz...");
            }

            else if (lstKitaplar.SelectedItems.Count > 0)
            {

                dio = MetroMessageBox.Show(this, "Kayıt silinecek", "Sil", MessageBoxButtons.YesNo);
                if (dio == DialogResult.Yes)
                {
                    lstKitaplar.Items.RemoveAt(lstKitaplar.SelectedIndex);
                    MetroMessageBox.Show(this, "Kitap Sildin...");
                }

            }

        }
    }
}
