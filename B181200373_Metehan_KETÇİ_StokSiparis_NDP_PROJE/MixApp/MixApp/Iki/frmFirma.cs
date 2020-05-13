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
using MixApp.Properties;

namespace MixApp.Iki
{
    public partial class frmFirma : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        Numaralar N = new Numaralar();
        Formlar F = new Formlar();
        bool edit = false;
        string firmaId = "";

        public object e { get; private set; }

        public frmFirma()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (edit && firmaId != "" && MessageBox.Show("Seçili olan kayıt güncellenecektir.\n Güncelleme işlemeni onaylıyor musunuz?", "Güncelle işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Guncelle();
            else if (edit == false) YeniKayit();
            else MessageBox.Show("Güncelleme İptal Edildi!!!");
        }

        protected override void OnLoad(EventArgs e)
        {
            var btnCari = new Button();
            btnCari.Size = new Size(25, txtCariKod.ClientSize.Height + 2);
            btnCari.Location = new Point(txtCariKod.ClientSize.Width - btnCari.Width, -1);
            btnCari.Cursor = Cursors.Default;
           // btnCari.BackgroundImage = Resources.At1;
            btnCari.BackgroundImageLayout = ImageLayout.Stretch;
            btnCari.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            txtCariKod.Controls.Add(btnCari);

            base.OnLoad(e);

            btnCari.Click += btnCari_Click;
        }
        private void btnCari_Click (object sender,EventArgs e)
        {
            F.frmListe();
            int id = MainPage.iAktar;
            if(id>0)
            {
                CariAc(id);
            }
            MainPage.iAktar = -1;
        }
        public void CariAc(int id)
        {
            edit = true;
            firmaId = id.ToString().PadLeft(7, '0');
            tblFirma frm = db.tblFirmas.First(s => s.CariKod == firmaId);

            txtAdres.Text = frm.Adres;
            txtCariKod.Text = frm.CariKod.ToString().PadLeft(7, '0');
            txtDepartman.Text = frm.Departman;
            txteMail.Text = frm.eMail;
            txtFaks.Text = frm.Faks;
            txtFirmaAdi.Text = frm.FirmaAdi;
            txtGsm.Text = frm.GSM;
            txtTel.Text = frm.Telefon;
            txtVd.Text = frm.VergiD;
            txtVn.Text = frm.VergiN;
            txtYetkili.Text = frm.Yetkili;
        }


        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFirma_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }
        void Temizle()
        {
            foreach (Control ct in splitContainer1.Panel1.Controls)
                if (ct is TextBox /*|| ct is ComboBox*/) ct.Text = ""; //=> silm işlemini genele yayan alternatif
            //else if (ct is ComboBox) ct.Text = ""; => combobox'ın alternatifi

            //txtAdres.Text = "";
            //txtCariKod.Text = "";
            //txtDepartman.Text = "";
            //txteMail.Text = "";
            //txtFaks.Text = "";
            //txtFirmaAdi.Text = "";
            //txtGsm.Text = "";
            //txtTel.Text = "";
            //txtVd.Text = "";
            //txtVn.Text = "";
            //txtYetkili.Text = "";

            txtCariKod.Text = N.CariNumara();        // Kaydet Butonundan sonra textboxları temizleyip carinumarayı 1                                               arttırdı.
            edit = false;
            firmaId = "";
        }
        void YeniKayit()
        {
            try
            {

                if (txtFirmaAdi.Text !="" && txtVd.Text!="" && txtVn.Text!="")
                {
                    tblFirma frm = new tblFirma();
                    frm.Adres = txtAdres.Text;
                    frm.CariKod = txtCariKod.Text;
                    frm.Departman = txtDepartman.Text;
                    frm.eMail = txteMail.Text;
                    frm.Faks = txtFaks.Text;
                    frm.FirmaAdi = txtFirmaAdi.Text;
                    frm.GSM = txtGsm.Text;
                    frm.Telefon = txtTel.Text;
                    frm.VergiD = txtVd.Text;
                    frm.VergiN = txtVn.Text;
                    frm.Yetkili = txtYetkili.Text;
                    db.tblFirmas.InsertOnSubmit(frm);   //InsertOnSubmit ekle ve onayla işlemi yapıyor.
                    db.SubmitChanges();                 //SubmitChanges ile değişlikler yapılıyor.
                    MessageBox.Show("Kayıtlar başarı bir şekilde gerçekleşti.");
                    Temizle(); 
                }
                else
                {
                    MessageBox.Show("Firma adı , Vergi adı ve Vergi No Zorunlu alandır");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ağır Ol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        void Guncelle()
        {
            tblFirma frm = db.tblFirmas.First(x => x.CariKod == firmaId);
            frm.Adres = txtAdres.Text;
            frm.CariKod = txtCariKod.Text;
            frm.Departman = txtDepartman.Text;
            frm.eMail = txteMail.Text;
            frm.Faks = txtFaks.Text;
            frm.FirmaAdi = txtFirmaAdi.Text;
            frm.GSM = txtGsm.Text;
            frm.Telefon = txtTel.Text;
            frm.VergiD = txtVd.Text;
            frm.VergiN = txtVn.Text;
            frm.Yetkili = txtYetkili.Text;
            db.SubmitChanges();
            MessageBox.Show("Güncelleme Başarıyla Gerçekleşti");
            Temizle();
        }
        private void frmFirma_Load(object sender, EventArgs e)
        {
            txtCariKod.Text = N.CariNumara();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (edit && firmaId!="" && MessageBox.Show("Silme işlemi gerçekleşecektir.\n Silme işlemeni onaylıyor musunuz?", "Silme işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Sil();
            
        }
        void Sil()
        {
            db.tblFirmas.DeleteAllOnSubmit(db.tblFirmas.Where(x => x.CariKod == firmaId));
            db.SubmitChanges();
            MessageBox.Show("Kayıt silindi.");
            Temizle();
        }
    }
}
