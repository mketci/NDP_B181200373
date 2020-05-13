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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixApp.Fonksiyonlar
{
    public class PrintYardim
    {
        public object ProperityDescriptionCollection { get; private set; }

        public DataTable ConverTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (var item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;

        }

        private DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            return table;
        }
        
    }

}
