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

namespace MixApp.Uc
{
    public partial class frmSiparisAl : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        Numaralar N = new Numaralar();
        Formlar F = new Formlar();
        bool edit = false;
        int sipId = -1;

        public frmSiparisAl()
        {
            InitializeComponent();
        }
        public String[] MyArray { get; set; }
        private void frmSiparisAl_Load(object sender, EventArgs e)
        {
            Combo();
            txtSiparisNo.Text = N.SiparisNo();
        }
        protected override void OnLoad(EventArgs e)
        {
            var btnSiparis = new Button();
            btnSiparis.Size = new Size(25, txtSiparisNo.ClientSize.Height + 2);
            btnSiparis.Location = new Point(txtSiparisNo.ClientSize.Width - btnSiparis.Width, -1);
            btnSiparis.Cursor = Cursors.Default;
          //  btnSiparis.BackgroundImage = Resources.sepet;
            btnSiparis.BackgroundImageLayout = ImageLayout.Stretch;
            btnSiparis.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            txtSiparisNo.Controls.Add(btnSiparis);

            base.OnLoad(e);

            btnSiparis.Click += btnSiparis_Click;
        }
        private void btnSiparis_Click(object sender, EventArgs e)
        {
            F.SiparisAlListe();
            int id = MainPage.iAktar;
            if (id > 0)
            {
                SiparisAc(id);
            }
            MainPage.iAktar = -1;
        }
        private void SiparisAc(int id)
        {
            try
            {
                int i = 0;
                edit = true;
                sipId = id;
                tblSiparisUst ust = db.tblSiparisUsts.First(x => x.SiparisNo == sipId);
                txtFirma.Text = ust.tblFirma.FirmaAdi;
                txtSTarih.Text = ust.ATarih.ToString();
                txtAciklama.Text = ust.SiparisAciklama;
                txtSiparisNo.Text = sipId.ToString().PadLeft(7, '0');

                var sorgu = from s in db.tblSiparisAlts where s.SiparisNo == sipId select s;
                foreach (var k in sorgu)
                {
                    Liste.Rows.Add();
                    Liste.Rows[i].Cells[0].Value = k.tblUrunler.ID;
                    Liste.Rows[i].Cells[1].Value = k.tblUrunler.UrunAdi;
                    Liste.Rows[i].Cells[2].Value = k.tblUrunler.UrunKodu;
                    Liste.Rows[i].Cells[3].Value = k.LotSeriNo;
                    Liste.Rows[i].Cells[4].Value = k.tblUrunler.Acıklama;

                    Liste.Rows[i].Cells[6].Value = k.Adet;

                    //ListeIlk.Rows.Add();
                    //ListeIlk.Rows[i].Cells[0].Value = k.tblUrunler.ID;
                    //ListeIlk.Rows[i].Cells[1].Value = k.tblUrunler.UrunAdi;
                    //ListeIlk.Rows[i].Cells[2].Value = k.tblUrunler.Acıklama;
                    //ListeIlk.Rows[i].Cells[3].Value = k.LotSeriNo;
                    //ListeIlk.Rows[i].Cells[4].Value = k.Adet;                   

                    i++;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Combo()
        {
            //txtFirma.ValueMember = "ID";
            //txtFirma.DisplayMember = "FirmaAdi";
            //txtFirma.DataSource = db.tblFirmas.ToList();
            //txtFirma.SelectedIndex = -1;

            txtFirma.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection veri = new AutoCompleteStringCollection();
            var lst = db.tblFirmas.Select(x => x.FirmaAdi).Distinct();
            foreach (string frm in lst)
            {
                veri.Add(frm);
                txtFirma.Items.Add(frm);
            }
            txtFirma.AutoCompleteCustomSource = veri;

            /*************************************************/

            urncmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection veri1 = new AutoCompleteStringCollection();
            var lst1 = db.tblUrunlers.Select(x => x.UrunAdi).Distinct();
            foreach (string frm in lst1)
            {
                veri1.Add(frm);
                urncmb.Items.Add(frm);
            }
            urncmb.AutoCompleteCustomSource = veri1;
            try
            {
                int dgv;
                dgv = urncmb.Items.Count;
                MyArray = new string[dgv];
                for (int i = 0; i < dgv; i++)
                {
                    MyArray[i] = urncmb.Items[i].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Liste_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                TextBox txt = e.Control as TextBox;
                if (Liste.CurrentCell.ColumnIndex == 1 && txt != null)
                {
                    txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txt.AutoCompleteCustomSource.AddRange(MyArray);
                }
                else if (Liste.CurrentCell.ColumnIndex != 1 && txt != null)

                {
                    txt.AutoCompleteMode = AutoCompleteMode.None;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Liste_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    foreach (DataGridViewCell cell in Liste.SelectedCells)
                    {
                        if (cell.Value != null)
                        {
                            //string urn = Liste.CurrentRow.Cells[1].Value.ToString();

                            var lst = (from s in db.tblUrunlers where s.UrunAdi == Liste.CurrentRow.Cells[1].Value.ToString() select s).First();
                            int Id = lst.ID;
                            string acik = lst.Acıklama;
                            if (Liste.CurrentRow != null)
                            {
                                Liste.CurrentRow.Cells[0].Value = Id;
                                Liste.CurrentRow.Cells[4].Value = acik;
                            }
                        }
                        else { MessageBox.Show("Boş veya hatalı ürün seçtiniz."); break; } //return de kullanılabilir.
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        void YeniKayit()
        {
            Liste.AllowUserToAddRows = false;
            try
            {
                tblSiparisUst ust = new tblSiparisUst();
                ust.ATarih = DateTime.Parse(txtSTarih.Text);
                ust.SiparisAciklama = txtAciklama.Text;
                ust.SiparisNo = int.Parse(txtSiparisNo.Text);
                ust.FirmaID = txtFirma.Text != "" ? db.tblFirmas.First(x => x.FirmaAdi == txtFirma.Text).ID : -1;

                //tblStokGirisUst ust1 = new tblStokGirisUst
                //{
                //    ATarih = DateTime.Parse(txtSTarih.Text),
                //    StokAciklama = txtAciklama.Text,
                //    StokGNo = int.Parse(txtStokGirisNo.Text),
                //    FirmaID = txtFirma.Text != "" ? db.tblFirmas.First(x => x.FirmaAdi == txtFirma.Text).ID : -1,
                //};

                db.tblSiparisUsts.InsertOnSubmit(ust);
                db.SubmitChanges();

                //int urunId;
                string barkod;
                tblSiparisAlt[] alt = new tblSiparisAlt[Liste.RowCount];
                tblStokDurum[] durum = new tblStokDurum[Liste.RowCount];
                for (int i = 0; i < Liste.RowCount; i++) // döngü içinde hepsini tabloya kaydetme işlemi yapıyoruz. alt olarak dediğimiz kısım sipariş alta, durum olan stokdurum tablosunu ifade ediyor.
                {
                    //urunId = int.Parse(Liste.Rows[i].Cells[0].Value.ToString());

                    alt[i] = new tblSiparisAlt();
                    alt[i].LotSeriNo = Liste.Rows[i].Cells[3].Value.ToString();
                    alt[i].SiparisNo = int.Parse(txtSiparisNo.Text);
                    //alt[i].UrunID = urunId;                    
                    alt[i].Adet = Convert.ToInt32(Liste.Rows[i].Cells[6].Value);

                    db.tblSiparisAlts.InsertOnSubmit(alt[i]); //=> bu kısımda verilen değerleri SiparişAlt tablosuna kayıt ettiriyoruz.

                    barkod = Liste.Rows[i].Cells[1].Value + "/" + Liste.Rows[i].Cells[3].Value;
                    tblStokDurum sd = db.tblStokDurums.First(s => s.Barkod == barkod);
                    sd.Adet -= int.Parse(Liste.Rows[i].Cells[6].Value.ToString());
                    //var sorgu = (from s in db.tblStokDurums       //Stoktaki durum üzerinde gelenleri eklemek için
                    //             where s.Barkod == barkod
                    //             select s).ToList();
                    //if (sorgu.Count == 0)
                    //{
                    //    durum[i].Barkod = barkod;
                    //    durum[i].UrunID = urunId;
                    //    durum[i].LotSeriNo = Liste.Rows[i].Cells[3].Value.ToString();
                    //    durum[i].Adet = int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                    //    db.tblStokDurums.InsertOnSubmit(durum[i]);
                    //}
                    //else
                    //{
                    //    tblStokDurum sd = db.tblStokDurums.First(s => s.Barkod == barkod);
                    //    sd.Adet -= int.Parse(Liste.Rows[i].Cells[5].Value.ToString());
                    //    db.tblSiparisAlts.InsertOnSubmit(alt[i]);
                    //}

                }
                db.SubmitChanges();
                MessageBox.Show("Kaydetme işlemi gerçekleştirildi.");
                Temizle();
                Close();
                F.frmSiparisAl();

            }
            catch (Exception)
            {

                MessageBox.Show("Hata");
            }


        }

        private void frmSiparisAl_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }

        private void Liste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        void Temizle()
        {
            foreach (Control ct in splitContainer1.Panel1.Controls)
            {
                if (ct is TextBox || ct is ComboBox)
                {
                    ct.Text = "";
                }
                txtSiparisNo.Text = N.SiparisNo();
                Liste.Rows.Clear();
                MainPage.iAktar = -1;
                edit = false;
                sipId = -1;
            }
        }

        private void Liste_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Liste.CurrentRow != null && e.ColumnIndex == 2 && Liste.CurrentRow.Cells[1].Value.ToString() != "")
            {
                var x = Liste.CurrentRow.Index;

                MainPage.Aktar = Liste.Rows[x].Cells[1].Value.ToString();
                F.LotBul();
                var id = MainPage.iAktar;
                if (id > 0)
                {
                    LotAc(id);
                }
            }
        }
        void LotAc(int id)
        {
            sipId = id;
            var stok = db.tblStokDurums.First(x => x.Id == sipId);
            if (Liste.CurrentRow != null)
            {
                Liste.CurrentRow.Cells[3].Value = stok.LotSeriNo;
                Liste.CurrentRow.Cells[5].Value = stok.Adet;

            }
        }
    }
}
