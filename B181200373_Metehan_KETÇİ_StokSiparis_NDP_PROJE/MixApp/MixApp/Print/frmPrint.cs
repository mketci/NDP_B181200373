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
using MixApp.Stok;
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
using MixApp.Uc;

namespace MixApp.Print
{
    public partial class frmPrint : Form
    {
        public string HangiForm;  //Diğer formlarda kullanmak için public olarak en dış kısma yazılır.
        DbFirstDataContext db = new DbFirstDataContext();
        public frmPrint()
        {
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            switch (HangiForm)
            {
                case "StokGiris":
                    StokGiris();
                    break;
                case "SiparisAl":
                    SiparisAl();
                    break;
                default:
                    break;
            }
        }

        private void StokGiris()
        {
            frmStokGiris stk = Application.OpenForms["frmStokGiris"] as frmStokGiris;
            rStokGiris rsg = new rStokGiris();
            var lst = (from s in db.vwStokGiris
                       where s.StokGNo == int.Parse(MainPage.Aktar)
                       select s).ToList();
            if (lst != null)
            {
                PrintYardim ch = new PrintYardim(); //ch : crystal Help kısaltması.
                DataTable dt = ch.ConverTo(lst);
                rsg.SetDataSource(dt);
                crvPrint.ReportSource = rsg;
            }
            MainPage.Aktar = "";
        }
        private void SiparisAl()
        {
            frmSiparisAl stk = Application.OpenForms["frmSiparisAl"] as frmSiparisAl;
            rSiparisAl ral = new rSiparisAl();
            var lst = (from s in db.vwSiparisAls
                       where s.SiparisNo == int.Parse(MainPage.Aktar)
                       select s).ToList();
            if (lst != null)
            {
                PrintYardim ch = new PrintYardim(); //ch : crystal Help kısaltması.
                DataTable dt = ch.ConverTo(lst);
                ral.SetDataSource(dt);
                crvPrint.ReportSource = ral;
            }
            MainPage.Aktar = "";
        }
    }
}
