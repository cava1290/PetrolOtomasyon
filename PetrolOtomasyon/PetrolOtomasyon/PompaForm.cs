using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetrolOtomasyon
{
    public partial class PompaForm : Form
    {
        SqlConnection connection = new SqlConnection("Server=CAVA;Database=PetrolOtomasyonDB;Integrated Security=True;");

        public PompaForm()
        {
            InitializeComponent();
        }

        private void PompaForm_Load(object sender, EventArgs e)
        {
            // Form yükleme işlemleri burada yapılabilir.
        }

        private void btnOde_Click(object sender, EventArgs e)
        {
            try
            {
                // Kullanıcıdan veri alma
                string yakitTuru = cmbYakıtTürü.Text; // Combobox'tan yakıt türü
                float miktar = float.Parse(txtMiktar.Text); // Kullanıcıdan yakıt miktarı
                decimal litreFiyati = GetLitreFiyati(yakitTuru); // Litre fiyatını SQL'den çekiyoruz
                decimal toplamTutar = litreFiyati * (decimal)miktar;

                // Ödemeyi veritabanına kaydet
                connection.Open();
                string query = "INSERT INTO Satislar (YakitTuru, Miktar, Tutar, Tarih) VALUES (@YakitTuru, @Miktar, @Tutar, @Tarih)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@YakitTuru", yakitTuru);
                cmd.Parameters.AddWithValue("@Miktar", miktar);
                cmd.Parameters.AddWithValue("@Tutar", toplamTutar);
                cmd.Parameters.AddWithValue("@Tarih", DateTime.Now);

                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show($"Toplam Ödeme: {toplamTutar} TL\nÖdeme başarıyla kaydedildi.", "Ödeme Onayı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private decimal GetLitreFiyati(string YakıtTipi)
        {
            decimal fiyat = 0;
            try
            {
                connection.Open();
                string query = "SELECT LitreFiyati FROM AnaRezerv WHERE YakıtTipi = @YakitTuru"; // 'YakitTuru' doğru kolon adı
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@YakitTuru", YakıtTipi);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    fiyat = reader.GetDecimal(0);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fiyat çekilirken hata: {ex.Message}");
            }
            return fiyat;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (cmbYakıtTürü.SelectedItem == null || string.IsNullOrEmpty(txtMiktar.Text))
            {
                MessageBox.Show("Lütfen yakıt türü ve miktar giriniz!");
                return;
            }

            try
            {
                connection.Open();
                SqlCommand komut = new SqlCommand("SELECT LitreFiyati FROM AnaRezerv WHERE YakıtTipi = @tur", connection);
                komut.Parameters.AddWithValue("@tur", cmbYakıtTürü.SelectedItem.ToString());

                object fiyat = komut.ExecuteScalar();
                if (fiyat != null)
                {
                    double litreFiyat = Convert.ToDouble(fiyat);
                    double miktar = Convert.ToDouble(txtMiktar.Text);
                    double toplamFiyat = litreFiyat * miktar;

                    lblFiyat.Text = toplamFiyat.ToString("0.##") + " TL";
                }
                else
                {
                    MessageBox.Show("Yakıt türü bulunamadı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
