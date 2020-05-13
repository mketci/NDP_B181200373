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
using MixApp.Fonksiyonlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixApp.Uc
{
    public partial class frmLotBul : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        Numaralar N = new Numaralar();
        Formlar F = new Formlar();

        int secimId = -1;

        public frmLotBul()
        {
            InitializeComponent();
        }
        private void frmLotBul_Load_1(object sender, EventArgs e)
        {
            txtUrun.Text = MainPage.Aktar;
            Listele();
        }

        void Listele()
        {
            liste.Rows.Clear();
            int i = 0;
            var lst = from s in db.tblStokDurums
                      where s.tblUrunler.UrunAdi == txtUrun.Text
                      where s.Adet != 0
                      select s;
            foreach (var k in lst)
            {
                liste.Rows.Add();

                liste.Rows[i].Cells[0].Value = k.Id;
                liste.Rows[i].Cells[1].Value = k.tblUrunler.UrunAdi;
                liste.Rows[i].Cells[2].Value = k.LotSeriNo;
                liste.Rows[i].Cells[3].Value = k.Adet;
                i++;
            }
        }             
               
        void Sec()
        {
            try
            {
                secimId = int.Parse(liste.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                secimId = -1;
            }
        }

        private void liste_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if (secimId>0)
            {
                MainPage.iAktar = secimId;
                Close();
            }
        }
    }
}