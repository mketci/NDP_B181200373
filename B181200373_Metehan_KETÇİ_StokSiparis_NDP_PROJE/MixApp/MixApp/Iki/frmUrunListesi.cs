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

namespace MixApp.Iki
{
    public partial class frmUrunListesi : Form
    {
        Fonksiyonlar.DbFirstDataContext db = new Fonksiyonlar.DbFirstDataContext();
        int secimId = -1;
        public frmUrunListesi()
        {
            InitializeComponent();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            liste.Rows.Clear();
            int i = 0;
            var lst = (from s in db.tblUrunlers where s.UrunAdi.Contains(txtBul.Text) select s).ToList();
            foreach (var k in lst)
            {
                liste.Rows.Add();
                liste.Rows[i].Cells[0].Value = k.ID;
                liste.Rows[i].Cells[1].Value = k.UrunKodu;
                liste.Rows[i].Cells[2].Value = k.UrunAdi;
                //liste.Rows[i].Cells[3].Value = k.SeriLotNo;
                liste.Rows[i].Cells[4].Value = k.tblMarkalar.MarkaAdi;
                liste.Rows[i].Cells[5].Value = k.tblKategoriler.KategoriAdi;
                i++;
            }
            liste.AllowUserToAddRows = false;
        }
        private void liste_DoubleClick_1(object sender, EventArgs e)
        {
            Sec();
            if (secimId > 0)
            {
                MainPage.iAktar = secimId;
                Close();
            }
        }

        void Sec()
        {
            try
            {
                secimId = int.Parse(liste.CurrentRow.Cells[1].Value.ToString());
            }
            catch (Exception)
            {

                secimId = -1;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUrunListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}