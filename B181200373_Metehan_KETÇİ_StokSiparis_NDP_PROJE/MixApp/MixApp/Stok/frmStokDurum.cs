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

namespace MixApp.Stok
{
    public partial class frmStokDurum : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        public frmStokDurum()
        {
            InitializeComponent();
        }

        private void frmStokDurum_Load(object sender, EventArgs e)
        {
            liste.Rows.Clear();
            int i = 0;
            var lst = (from s in db.tblStokDurums select s).ToList();
            foreach (var k in lst)
            {
                liste.Rows.Add();
                liste.Rows[i].Cells[0].Value = k.Id;
                liste.Rows[i].Cells[1].Value = k.Barkod;
                liste.Rows[i].Cells[2].Value = k.tblUrunler.UrunAdi;
                liste.Rows[i].Cells[3].Value = k.tblUrunler.Acıklama;
                liste.Rows[i].Cells[4].Value = k.LotSeriNo;
                liste.Rows[i].Cells[5].Value = k.Adet;
                i++;
            }
            liste.AllowUserToAddRows = false;
        }
    }
}
