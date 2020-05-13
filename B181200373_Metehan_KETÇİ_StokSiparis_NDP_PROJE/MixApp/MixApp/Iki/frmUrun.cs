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
using MixApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq; // alt kısımda pasifleştirildi.
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixApp.Iki
{
    public partial class frmUrun : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        Formlar F = new Formlar();
        Numaralar N = new Numaralar();
        Resimler R = new Resimler();

        bool edit = false;
        bool resim = false;
        int urunId = -1;
        OpenFileDialog dosya = new OpenFileDialog();
        public frmUrun()
        {
            InitializeComponent();
        }

        private void frmUrun_Load(object sender, EventArgs e)
        {
            combo();
            txtUrunKodu.Text = N.UrunNumara();
        }
        void combo()
        {
            txtKategori.ValueMember = "ID"; //=>Combobaxa listedeki id sırasına göre çekecek.
            txtKategori.DisplayMember = "KategoriAdi";//=>Combobaxa listedeki kategori sırasına göre çekecek.
            txtKategori.DataSource = db.tblKategorilers.OrderBy(x => x.KategoriAdi).ToList();//=>Datebase'i kaynak olarak                                                                               gösterip bilgileri çeker
            txtKategori.SelectedIndex = -1;

            txtMarka.ValueMember = "ID";//=>Combobaxa listedeki id sırasına göre çekecek.
            txtMarka.DisplayMember = "MarkaAdi";//=>Combobaxa listedeki Marka sırasına göre çekecek.
            txtMarka.DataSource = db.tblMarkalars.OrderBy(x => x.MarkaAdi).ToList(); //=>Datebase'i kaynak olarak gösterip                                                                       bilgileri çeker ,
                                                                                     //=> .OrderBy(x => x.MarkaAdi) => alfabetik olarak sıralar.
            txtMarka.SelectedIndex = -1;                    //=>combo boxı boş görünmesini sağlar.

        }

        private void frmUrun_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }
        protected override void OnLoad(EventArgs e)
        {
            var btnUrun = new Button();
            btnUrun.Size = new Size(25, txtUrunKodu.ClientSize.Height + 2);
            btnUrun.Location = new Point(txtUrunKodu.ClientSize.Width - btnUrun.Width, -1);
            btnUrun.Cursor = Cursors.Default;
            btnUrun.BackgroundImageLayout = ImageLayout.Stretch;
            btnUrun.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            txtUrunKodu.Controls.Add(btnUrun);

            base.OnLoad(e);

            btnUrun.Click += btnListele_Click;
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            F.frmUrunliste();
            int id = MainPage.iAktar;
            if (id > 0)
            {
                UrunAc(id);
            }
            MainPage.iAktar = -1;
        }
        public void UrunAc(int id)
        {

            try
            {
                edit = true;
                urunId = int.Parse(id.ToString().PadLeft(5, '0'));

                tblUrunler urun = db.tblUrunlers.First(x => x.UrunKodu == urunId);
                txtUrunAdi.Text = urun.UrunAdi;
                txtUrunKodu.Text = urun.UrunKodu.ToString().PadLeft(5, '0');
                txtAciklama.Text = urun.Acıklama;
                txtKategori.Text = urun.tblKategoriler.KategoriAdi;
                txtMarka.Text = urun.tblMarkalar.MarkaAdi;
                txtMensei.Text = urun.Mensei;
                if (urun.Resim != null) pbResim.Image = R.ResimGetirme(urun.Resim.ToArray());
               
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Kodu: UrunAc01");
            }

        }

        private void btnCollaps_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed)
            {
                splitContainer1.Panel2Collapsed = false;
                btnCollaps.Text = "GİZLE";
            }
            else if (splitContainer1.Panel2Collapsed == false)
            {
                splitContainer1.Panel2Collapsed = true;
                btnCollaps.Text = "GÖSTER";
            }
        }
        void YeniKayit()
        {
            try
            {
                if (txtUrunAdi.Text != "")
                {
                    tblUrunler urun = new tblUrunler();
                    urun.UrunAdi = txtUrunAdi.Text;
                    urun.UrunKodu = int.Parse(txtUrunKodu.Text);
                    urun.Acıklama = txtAciklama.Text;
                    //urun.KategoriID = (int)txtKategori.SelectedValue;
                    //urun.KategoriID = db.tblKategorilers.First(x => x.KategoriAdi == txtKategori.Text).ID; => bir üstekini alternatifi.
                    urun.KategoriID = txtKategori.Text != "" ? db.tblKategorilers.First(x => x.KategoriAdi == txtKategori.Text).ID : 1; //=> Turn İf Yöntemi, bir üsteki If komutsuz hali.
                    urun.MarkaID = txtMarka.Text != "" ? (int)txtMarka.SelectedValue : 1;
                    //urun.MarkaID = txtMarka.SelectedIndex; => bu komutla combobaxtaki Id yi kaydeder.
                    urun.Mensei = txtMensei.Text;
                    if (pbResim.Image != null)
                        urun.Resim = new Binary(R.ResimYukleme(pbResim.Image));
                    // if komutu ile resimin boş gelmemesi gerektiği için kondu.
                    //System.Data.Linq.Binary kısmını yukarı yazarak alt kısımda pasifleşir.
                    urun.SaveDate = DateTime.Now;
                    urun.SaveUser = -1;
                    //urun.SeriLotNo = txtLot.Text;
                    urun.UpdateDate = DateTime.Now;
                    urun.UpdateUser = -1;

                    db.tblUrunlers.InsertOnSubmit(urun);
                    db.SubmitChanges();
                    MessageBox.Show("Kaydedildi.");
                    //Temizle();
                    Close();
                    F.UrunForm();
                }
                else MessageBox.Show("Zorunlu alandır");
            }
            catch (Exception e)
            {
                MessageBox.Show("Hata :", e.Message);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (edit && urunId != -1 && MessageBox.Show("Seçili olan kayıt güncellenecektir.\n Güncelleme işlemeni onaylıyor musunuz?", "Güncelle işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Guncelle();
            else if (edit == false) YeniKayit();
            else MessageBox.Show("Güncelleme İptal Edildi!!!");
        }
        void Guncelle()
        {
            try
            {
                DbFirstDataContext gb = new DbFirstDataContext();
                //int kat, mar;
                //kat = db.tblKategorilers.First(x => x.KategoriAdi == txtKategori.Text).ID;
                //mar = db.tblMarkalars.First(x => x.MarkaAdi == txtMarka.Text).ID;
                tblUrunler urun = gb.tblUrunlers.First(x => x.UrunKodu == urunId);
                urun.Acıklama = txtAciklama.Text;
                urun.KategoriID = txtKategori.Text != "" ? db.tblKategorilers.First(x => x.KategoriAdi == txtKategori.Text).ID : 1;
                urun.MarkaID = txtMarka.Text != "" ? (int)txtMarka.SelectedValue : 1;
                urun.Mensei = txtMensei.Text;
                //urun.SeriLotNo = txtLot.Text;
                urun.UrunAdi = txtUrunAdi.Text;
                urun.UrunKodu = int.Parse(txtUrunKodu.Text);
                if (pbResim.Image != null)
                    urun.Resim = new Binary(R.ResimYukleme(pbResim.Image));
                
                urun.UpdateDate = DateTime.Now;
                urun.UpdateUser = -1;                
                gb.SubmitChanges();
                MessageBox.Show("Güncelleme Başarıyla Gerçekleşti");
                Temizle();
                Close();
                F.UrunForm();
            }
            catch (Exception e)
            {

                MessageBox.Show("Hata Kodu :urunguncelle" + e.Message);
            }
        }
        void Temizle()
        {
            foreach (Control ct in splitContainer1.Panel1.Controls)
                if (ct is TextBox || ct is ComboBox) ct.Text = "";
            txtUrunKodu.Text = N.UrunNumara();
            edit = false;
            urunId = -1;
        }

        private void btnUrunResim_Click(object sender, EventArgs e)
        {
            ResimSec();
        }
        void ResimSec()
        {
            dosya.Filter="Jpg(*.jpg)|*.jpg|Jpeg(*.jpeg)|*.jpeg";
            if(dosya.ShowDialog()==DialogResult.OK)
            {
                pbResim.ImageLocation = dosya.FileName;
                resim = true;
            }
            
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
