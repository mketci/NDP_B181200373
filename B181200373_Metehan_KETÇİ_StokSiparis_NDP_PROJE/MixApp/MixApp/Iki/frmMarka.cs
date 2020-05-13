/*************************************************************************************************************************************
 **                                                    SAKARYA ÜNİVERSİTESİ
 **                                            BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ 
 **                                              BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ 
 **                                                  NESNEYE DAYALI PROGRAMLAMA DERSİ    
 **                                                      2019-2020 BAHAR DÖNEMİ 
 ** 
 **                                             PROJE NUMARASI.........: 01 
 **                                             ÖĞRENCİ ADI............: Metehan KETÇİ 
 **                                             ÖĞRENCİ NUMARASI.......: B181200373 
 **                                             DERSİN ALINDIĞI GRUP...: A
 ************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MixApp.Fonksiyonlar;

namespace MixApp.Iki
{
    public partial class frmMarka : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        string mar = "";
        int MarID = -1;

        public frmMarka()
        {
            InitializeComponent();
        }

        private void Marka_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = from x in db.tblMarkalars select new { id = x.ID, mar = x.MarkaAdi };
            foreach (var m in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[1].Value = m.id;
                Liste.Rows[i].Cells[2].Value = m.mar;
                i++;
            }
            Liste.AllowUserToAddRows = false;
            Liste.AllowUserToDeleteRows = false;
        }
        void YeniKayıt()
        {
            try
            {
                tblMarkalar frm = new tblMarkalar();
                frm.MarkaAdi = txtMarka.Text;
                db.tblMarkalars.InsertOnSubmit(frm);
                db.SubmitChanges();
                txtMarka.Text = "";
                Listele();
            }
            catch (Exception e)
            {
                MessageBox.Show("Hata var Dostum" + e.Message);
            }

        }
        void Guncelle()
        {
            try
            {

                tblMarkalar frm = db.tblMarkalars.First(x => x.ID == MarID);
                frm.MarkaAdi = txtMarka.Text;
                db.SubmitChanges();
                txtMarka.Text = "";
                MarID = -1;
                Listele();
            }
            catch (Exception)
            {

                MessageBox.Show("Güncelleme Hatası");
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string deger = "";
            if (Liste.CurrentRow.Cells[0].Value != null && Liste.CurrentRow.Cells[0].Value.ToString() != "False")
            {
                deger = Liste.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                MarID = -1;
                deger = "False";
            }
            if (deger == "True" && MarID > 0 && MessageBox.Show("Bu kayıt güncelenecektir\n Onaylıyor musunuz?", "Kayıt Güncelleme:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Guncelle();
            }
            else if (MarID == -1 && deger == "False")
            {
                YeniKayıt();
            }
        }

        private void frmMarka_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }

        private void Liste_Click(object sender, EventArgs e)
        {
            txtMarka.Text = Liste.CurrentRow.Cells[2].Value.ToString();
            MarID = int.Parse(Liste.CurrentRow.Cells[1].Value.ToString());
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            mar = Liste.CurrentRow.Cells[2].Value.ToString();
            if (MessageBox.Show(mar + " " + "isimli kategoriyi silmek istiyor musunuz?", "Silme işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Sil();
            }
        }
        void Sil()
        {
            try
            {
                db.tblMarkalars.DeleteOnSubmit(db.tblMarkalars.First(s => s.MarkaAdi == mar));
                db.SubmitChanges();
                Listele();
                mar = "";
                txtMarka.Text = "";

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }
    }
}
            
