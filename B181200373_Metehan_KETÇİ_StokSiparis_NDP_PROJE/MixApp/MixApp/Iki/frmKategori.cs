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
    public partial class frmKategori : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        string Kat = "";
        int KatID = -1;
        public frmKategori()
        {
            InitializeComponent();
        }


        private void frmKategori_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = from s in db.tblKategorilers select new { id = s.ID, kat = s.KategoriAdi };
            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[1].Value = k.id;
                Liste.Rows[i].Cells[2].Value = k.kat;
                i++;
            }
            Liste.AllowUserToAddRows = false;
            Liste.AllowUserToDeleteRows = false;
        }
        void YeniKayıt()
        {
            try
            {
                tblKategoriler frm = new tblKategoriler();
                frm.KategoriAdi = txtKategori.Text;
                db.tblKategorilers.InsertOnSubmit(frm);
                db.SubmitChanges();
                txtKategori.Text = "";
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
                //tblKategoriler frm = db.tblKategorilers.First(x => x.KategoriAdi == txtKategori.Text);
                tblKategoriler frm = db.tblKategorilers.First(x => x.ID == KatID);
                frm.KategoriAdi = txtKategori.Text;
                db.SubmitChanges();
                txtKategori.Text = "";
                KatID = -1;
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
                KatID = -1;
                deger = "False";
            }
            if (deger == "True" && KatID > 0 && MessageBox.Show("Bu kayıt güncelenecektir\n Onaylıyor musunuz?", "Kayıt Güncelleme:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Guncelle();
            }
            else if (KatID == -1 && deger == "False")
            {
                YeniKayıt();
            }
        }

        private void frmKategori_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }
        private void Liste_Click(object sender, EventArgs e)
        {
            txtKategori.Text = Liste.CurrentRow.Cells[2].Value.ToString();
            KatID = int.Parse(Liste.CurrentRow.Cells[1].Value.ToString());
        }
        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Kat = Liste.CurrentRow.Cells[2].Value.ToString();
            if (MessageBox.Show(Kat + " " + "isimli kategoriyi silmek istiyor musunuz?", "Silme işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Sil();
            }
        }
        void Sil()
        {
            try
            {
                db.tblKategorilers.DeleteOnSubmit(db.tblKategorilers.First(s => s.KategoriAdi == Kat));
                db.SubmitChanges();
                Listele();
                Kat = "";
                txtKategori.Text = "";

            }
            catch (Exception)
            {

                throw;
            }
        }



        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
