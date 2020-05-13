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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixApp
{
    public partial class MainPage : Form
    {
        Fonksiyonlar.Formlar F = new Fonksiyonlar.Formlar();

        public static bool Kontrol = false;
        public static string Aktar = "";
        public static int iAktar;        
        public static List<object> Laktar;
        public static ArrayList Aaktar;
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnBir_Click(object sender, EventArgs e)
        {
            
            grb2.Visible = false;
            grb3.Visible = false;          
            pnlTop.BackColor = Color.Orange;
        }

        private void BtnIki_Click(object sender, EventArgs e)
        {
            
            grb2.Visible = true;
            grb3.Visible = false;
            grb2.Text = "Alan İki";
            pnlTop.BackColor = Color.DarkSlateGray;
        }

        private void btnUc_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb3.Visible = true;
            grb3.Text = "Alan Üç";
            pnlTop.BackColor = Color.Maroon;
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
        }





  



   




  

        private void btnFirma_Click(object sender, EventArgs e)
        {
            if (Kontrol == false)
            {
                F.FirmaForm();
                //Kontrol = true;
            }

        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            if (Kontrol == false)
            {
                F.UrunForm();
                //Kontrol = true;
            }
        }

        private void btnKategoriGiris_Click(object sender, EventArgs e)
        {           
            if(Kontrol == false)
            {
                F.frmKategoriListe();
                //Kontrol = true;
            }
        }

        private void btnMarkaGiris_Click(object sender, EventArgs e)
        {
            if(Kontrol==false)
            {
                F.frmMarkaListe();
            }
        }

        private void btnStokGiris_Click(object sender, EventArgs e)
        {
            if(Kontrol==false)
            {
                F.StokGiris();
            }
        }

        private void btnStokDurum_Click(object sender, EventArgs e)
        {
            if (Kontrol == false)
            {
               F.frmStokDurumListe(); 
            }
        }

        private void btnSiparisAl_Click(object sender, EventArgs e)
        {
            F.frmSiparisAl();
        }
    }
}
