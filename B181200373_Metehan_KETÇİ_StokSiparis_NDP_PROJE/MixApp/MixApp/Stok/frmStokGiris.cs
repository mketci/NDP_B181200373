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
using MixApp.Print;
using MixApp.Properties;

namespace MixApp.Stok
{
    public partial class frmStokGiris : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        Numaralar N = new Numaralar();
        Formlar F = new Formlar();
        bool edit = false;
        int stkId = -1;

        public frmStokGiris()
        {
            InitializeComponent();
        }
        public String[] MyArray { get; set; }

        private void frmStokGiris_Load(object sender, EventArgs e)
        {
            Combo();
            txtStokGirisNo.Text = N.StokGNo();
        }
        protected override void OnLoad(EventArgs e)
        {
            var btnStok = new Button();
            btnStok.Size = new Size(25, txtStokGirisNo.ClientSize.Height + 2);
            btnStok.Location = new Point(txtStokGirisNo.ClientSize.Width - btnStok.Width, -1);
            btnStok.Cursor = Cursors.Default;
            //btnStok.BackgroundImage = Resources.sepet;
            btnStok.BackgroundImageLayout = ImageLayout.Stretch;
            btnStok.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            txtStokGirisNo.Controls.Add(btnStok);

            base.OnLoad(e);

            btnStok.Click += btnStok_Click;
        }
        private void btnStok_Click(object sender, EventArgs e)
        {
            F.frmStokGirisListe();
            int id = MainPage.iAktar;
            if (id > 0)
            {
                StokGirisAc(id);
            }
            MainPage.iAktar = -1;
        }
        private void StokGirisAc(int id)
        {
            try
            {
                int i = 0;
                edit = true;
                stkId = id;
                tblStokGirisUst ust = db.tblStokGirisUsts.First(x => x.StokGNo == stkId);
                txtFirma.Text = ust.tblFirma.FirmaAdi;
                txtSTarih.Text = ust.ATarih.ToString();
                txtAciklama.Text = ust.StokAciklama;
                txtStokGirisNo.Text = stkId.ToString().PadLeft(7, '0');

                var sorgu = from s in db.tblStokGirisAlts where s.StokGirisNo == stkId select s;
                foreach (var k in sorgu)
                {
                    Liste.Rows.Add();
                    Liste.Rows[i].Cells[0].Value = k.tblUrunler.ID;
                    Liste.Rows[i].Cells[1].Value = k.tblUrunler.UrunAdi;
                    Liste.Rows[i].Cells[2].Value = k.tblUrunler.Acıklama;
                    Liste.Rows[i].Cells[3].Value = k.LotSeriNo;
                    Liste.Rows[i].Cells[4].Value = k.Adet;


                    ListeIlk.Rows.Add();
                    ListeIlk.Rows[i].Cells[0].Value = k.tblUrunler.ID;
                    ListeIlk.Rows[i].Cells[1].Value = k.tblUrunler.UrunAdi;
                    ListeIlk.Rows[i].Cells[2].Value = k.tblUrunler.Acıklama;
                    ListeIlk.Rows[i].Cells[3].Value = k.LotSeriNo;
                    ListeIlk.Rows[i].Cells[4].Value = k.Adet;
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

        void YeniKayit()
        {
            Liste.AllowUserToAddRows = false;
            try
            {
                tblStokGirisUst ust = new tblStokGirisUst();
                ust.ATarih = DateTime.Parse(txtSTarih.Text);
                ust.StokAciklama = txtAciklama.Text;
                ust.StokGNo = int.Parse(txtStokGirisNo.Text);
                ust.FirmaID = txtFirma.Text != "" ? db.tblFirmas.First(x => x.FirmaAdi == txtFirma.Text).ID : -1;

                //tblStokGirisUst ust1 = new tblStokGirisUst
                //{
                //    ATarih = DateTime.Parse(txtSTarih.Text),
                //    StokAciklama = txtAciklama.Text,
                //    StokGNo = int.Parse(txtStokGirisNo.Text),
                //    FirmaID = txtFirma.Text != "" ? db.tblFirmas.First(x => x.FirmaAdi == txtFirma.Text).ID : -1,
                //};

                db.tblStokGirisUsts.InsertOnSubmit(ust);
                db.SubmitChanges();

                int urunId;
                string barkod;
                tblStokGirisAlt[] alt = new tblStokGirisAlt[Liste.RowCount];
                tblStokDurum[] durum = new tblStokDurum[Liste.RowCount];
                for (int i = 0; i < Liste.RowCount; i++)
                {
                    urunId = int.Parse(Liste.Rows[i].Cells[0].Value.ToString());
                    barkod = Liste.Rows[i].Cells[1].Value + "/" + Liste.Rows[i].Cells[3].Value;
                    alt[i] = new tblStokGirisAlt();
                    alt[i].StokGirisNo = int.Parse(txtStokGirisNo.Text);
                    alt[i].UrunID = urunId;
                    alt[i].LotSeriNo = Liste.Rows[i].Cells[3].Value.ToString();
                    alt[i].Adet = int.Parse(Liste.Rows[i].Cells[4].Value.ToString());

                    db.tblStokGirisAlts.InsertOnSubmit(alt[i]);


                    durum[i] = new tblStokDurum();
                    var sorgu = (from s in db.tblStokDurums where s.Barkod == barkod select s).ToList();

                    if (sorgu.Count == 0)
                    {
                        durum[i].Barkod = barkod;
                        durum[i].UrunID = urunId;
                        durum[i].LotSeriNo = Liste.Rows[i].Cells[3].Value.ToString();
                        durum[i].Adet = int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                        db.tblStokDurums.InsertOnSubmit(durum[i]);                        
                    }
                    else
                    {
                        tblStokDurum sd = db.tblStokDurums.First(s => s.Barkod == barkod);
                        sd.Adet += int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                        sd.LotSeriNo = Liste.Rows[i].Cells[3].Value.ToString();
                    }
                    db.SubmitChanges();
                }

                MessageBox.Show("Kaydetme işlemi gerçekleştirildi.");

            }
            catch (Exception)
            {

                throw;
            }
        }

        void Guncelle()
        {
            Liste.AllowUserToAddRows = false;
            ListeIlk.AllowUserToAddRows = false;
            
            edit = true;
            tblStokGirisUst ust = db.tblStokGirisUsts.First(x => x.StokGNo == int.Parse(txtStokGirisNo.Text)); //First komutu ile databaseden tek satırı çağırır. "=>" işareti büyük eşit değil gösterme komutu.
            ust.ATarih = DateTime.Parse(txtSTarih.Text);
            ust.FirmaID = txtFirma.Text != "" ? db.tblFirmas.First(x => x.FirmaAdi == txtFirma.Text).ID : -1; //".ID" yaparak satırdan sadece ID'yi çağırıyoruz. ID kullanılmazsa tüm satır gelecektir. ":" dan sonraki kısım else kısmıdır ve ID boş ise -1 değer getirir.
            ust.StokAciklama = txtAciklama.Text;
            db.SubmitChanges();

            int urunId;
            string barkod;
            //güncelleme işleminden önce adete eklenenleri toplamdurumdan çıkarmak için yeni bir listeye veriler güncelenecek yerleri çıkararak aktarırız.
            for (int i = 0; i < Liste.RowCount; i++)
            {
                barkod = ListeIlk.Rows[i].Cells[1].Value + "/" + Liste.Rows[i].Cells[3].Value;
                tblStokDurum sd = db.tblStokDurums.First(x => x.Barkod == barkod);
                sd.Adet -= int.Parse(ListeIlk.Rows[i].Cells[4].Value.ToString());
            }

            //günceleme işlemini de yapmadan önce bir önceki verileri databaseden silerek çıkarırız.
            db.tblStokGirisAlts.DeleteAllOnSubmit(db.tblStokGirisAlts.Where(x => x.StokGirisNo == int.Parse(txtStokGirisNo.Text)));
            db.SubmitChanges();

            //ve artık yeni bir database için instant değer verilerek yeni bir bağlantı oluşturulur. ve yeni kayıt gibi kayıtlar verileri sakladığımız listeye ekler ve son hali database kaydeder.
            DbFirstDataContext gb = new DbFirstDataContext();


            tblStokGirisAlt[] alt = new tblStokGirisAlt[Liste.RowCount];
            tblStokDurum[] durum = new tblStokDurum[Liste.RowCount];

            for (int i = 0; i < Liste.RowCount; i++)
            {
                urunId = int.Parse(Liste.Rows[i].Cells[0].Value.ToString());
                barkod = Liste.Rows[i].Cells[1].Value + "/" + Liste.Rows[i].Cells[3].Value;

                alt[i] = new tblStokGirisAlt();
                alt[i].StokGirisNo = int.Parse(txtStokGirisNo.Text);
                alt[i].UrunID = urunId;
                alt[i].LotSeriNo = Liste.Rows[i].Cells[3].Value.ToString();
                alt[i].Adet = int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                gb.tblStokGirisAlts.InsertOnSubmit(alt[i]);

                durum[i] = new tblStokDurum();
                var sorgu = (from s in gb.tblStokDurums where s.Barkod == barkod select s).ToList();

                if (sorgu.Count == 0)
                {
                    durum[i].Barkod = barkod;
                    durum[i].UrunID = urunId;
                    durum[i].LotSeriNo = Liste.Rows[i].Cells[3].Value.ToString();
                    durum[i].Adet = int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                    gb.tblStokDurums.InsertOnSubmit(durum[i]);                    
                }
                else
                {
                    tblStokDurum sd = gb.tblStokDurums.First(s => s.Barkod == barkod);
                    sd.Adet += int.Parse(Liste.Rows[i].Cells[4].Value.ToString());                   
                }
                gb.SubmitChanges();
            }
            MessageBox.Show("Güncelleme işlemi gerçekleştirildi.");
            Close();
            F.StokGiris();
        }

        private void frmStokGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
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
                                Liste.CurrentRow.Cells[2].Value = acik;
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (edit) Guncelle();
            else if (edit == false) YeniKayit();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Yazdir();
        }
        private void Yazdir()
        {
            frmPrint prnt = new frmPrint();
            prnt.HangiForm = "StokGiris";
            MainPage.Aktar = txtStokGirisNo.Text;
            prnt.Show();
        }
    }
}
