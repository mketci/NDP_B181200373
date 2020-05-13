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

namespace MixApp.Uc
{
    public partial class frmSiparisAlListe : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        int secimId = -1;
        public frmSiparisAlListe()
        {
            InitializeComponent();
        }

        private void frmSiparisAlListe_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            liste.Rows.Clear();
            int i = 0;
            var lst = (from s in db.tblSiparisUsts where s.tblFirma.FirmaAdi.Contains(txtBul.Text) select s).ToList().OrderByDescending(x => x.ATarih);
            foreach (var k in lst)
            {
                liste.Rows.Add();
                liste.Rows[i].Cells[0].Value = k.Id;
                liste.Rows[i].Cells[1].Value = k.SiparisNo;
                liste.Rows[i].Cells[2].Value = k.tblFirma.FirmaAdi;
                liste.Rows[i].Cells[3].Value = k.ATarih;
                
                i++;
            }
            liste.AllowUserToAddRows = false;
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

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
