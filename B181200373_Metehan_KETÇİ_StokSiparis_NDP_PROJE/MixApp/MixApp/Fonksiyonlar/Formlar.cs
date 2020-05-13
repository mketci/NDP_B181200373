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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MixApp.Iki;
using MixApp.Stok;
using MixApp.Uc;
namespace MixApp.Fonksiyonlar
{
    class Formlar
    {

        public void FirmaForm()
        {
            frmFirma frm = new frmFirma();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            MainPage.Kontrol = true;
            frm.Show();
        }
        public void frmListe()
        {
            frmFirmaListesi frm = new frmFirmaListesi();
            // frm.MdiParent = Form.ActiveForm;
            //frm.WindowState = FormWindowState.Maximized;
            // MainPage.Kontrol = true;
            //frm.Show();
            frm.ShowDialog();
        }
        public void UrunForm()
        {
            frmUrun frm = new frmUrun();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            MainPage.Kontrol = true;
            frm.Show();

        }
        public void frmUrunliste()
        {
            frmUrunListesi frm = new frmUrunListesi();
            MainPage.Kontrol = true;
            frm.ShowDialog();
        }
        public void frmKategoriListe()
        {
            frmKategori frm = new frmKategori();
            MainPage.Kontrol = true;
            frm.ShowDialog();
        }
        public void frmMarkaListe()
        {
            frmMarka frm = new frmMarka();
            MainPage.Kontrol = true;
            frm.ShowDialog();
        }
        public void StokGiris()
        {
            frmStokGiris frm = new frmStokGiris();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            MainPage.Kontrol = true;
            frm.Show();
        }
        public void frmStokGirisListe()
        {
            frmStokListesi frm = new frmStokListesi();            
            MainPage.Kontrol = true;
            frm.ShowDialog();
        }
        public void frmStokDurumListe()
        {
            frmStokDurum frm = new frmStokDurum();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            MainPage.Kontrol = true;
            frm.Show();
        }
        public void frmSiparisAl()
        {
            frmSiparisAl frm = new frmSiparisAl();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            MainPage.Kontrol = true;
            frm.Show();
        }
        public void LotBul()
        {
            frmLotBul frm = new frmLotBul();
            MainPage.Kontrol = true;
            frm.ShowDialog();
        }
        public void SiparisAlListe()
        {
            frmSiparisAlListe frm = new frmSiparisAlListe();
            //MainPage.Kontrol = true;
            frm.ShowDialog();
        }
    }
}
