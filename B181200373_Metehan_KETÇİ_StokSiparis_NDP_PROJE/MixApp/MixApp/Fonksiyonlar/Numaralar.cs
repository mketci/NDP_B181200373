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

namespace MixApp.Fonksiyonlar
{
    class Numaralar
    {
        Fonksiyonlar.DbFirstDataContext db = new DbFirstDataContext();

        public string CariNumara()
        {
            try
            {
                double numara = double.Parse((from s in db.tblFirmas
                                              orderby s.ID descending
                                              select s).First().CariKod);
                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;
            }
            catch (Exception)
            {
                return "0000001";
            }
        }
        public string UrunNumara()
        {
            try
            {
                int numara = ((from s in db.tblUrunlers
                                              orderby s.ID descending
                                              select s).First().UrunKodu.Value);
                numara++;
                string num = numara.ToString().PadLeft(5, '0');
                return num;
            }
            catch (Exception)
            {
                return "00001";
            }

        }
        public string StokGNo()
        {
            try
            {
               int numara = ((from s in db.tblStokGirisUsts
                                  orderby s.Id descending
                                  select s).First().StokGNo.Value);
                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;
            }
            catch (Exception)
            {
                return "0000001";
            }
        }
        public String SiparisNo()
        {
            try
            {
                int numara = ((from s in db.tblSiparisUsts
                               orderby s.Id descending
                               select s).First().SiparisNo.Value);
                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;
            }
            catch (Exception)
            {
                return "0000001";
            }
        }
    }
}
