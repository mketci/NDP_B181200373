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
    public partial class frmStokListesi : Form
    {
        Fonksiyonlar.DbFirstDataContext db = new Fonksiyonlar.DbFirstDataContext();
        int secimId = -1;
        public frmStokListesi()
        {
            InitializeComponent();
        }


        private void frmStokListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            {
                liste.Rows.Clear();
                int i = 0;
                var lst = (from s in db.tblStokGirisUsts  select s).ToList();
                foreach (var k in lst)
                {
                    liste.Rows.Add();
                    liste.Rows[i].Cells[0].Value = k.StokGNo;
                    liste.Rows[i].Cells[1].Value = k.tblFirma.FirmaAdi;
                    liste.Rows[i].Cells[2].Value = k.ATarih;
                    liste.Rows[i].Cells[3].Value = k.StokAciklama;                   
                    i++;
                }
                liste.AllowUserToAddRows = false;
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
            if (secimId > 0)
            {
                MainPage.iAktar = secimId;
                Close();
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
