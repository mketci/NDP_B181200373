﻿/*************************************************************************************************************************************
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
    public partial class frmFirmaListesi : Form
    {
        Fonksiyonlar.DbFirstDataContext db = new Fonksiyonlar.DbFirstDataContext();

        int secimId = -1;
        public frmFirmaListesi()
        {
            InitializeComponent();
        }

        private void frmFirmaListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            liste.Rows.Clear();
            int i = 0;
            var lst = (from s in db.tblFirmas where s.FirmaAdi.Contains(txtBul.Text) select s).ToList();
            foreach (var k in lst)
            {
                liste.Rows.Add();
                liste.Rows[i].Cells[0].Value = k.CariKod;
                liste.Rows[i].Cells[1].Value = k.FirmaAdi;
                liste.Rows[i].Cells[2].Value = k.Yetkili;
                liste.Rows[i].Cells[3].Value = k.Telefon;
                i++;
            }
            liste.AllowUserToAddRows = false;
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if(secimId>0)
            {
                MainPage.iAktar = secimId;
                Close();
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

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();        
        }
    }
}
