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
    public partial class SubeCalisaniForm : Form
    {
        SqlConnection connection = new SqlConnection("Server=CAVA;Database=PetrolOtomasyonDB;Integrated Security=True;");
        public SubeCalisaniForm()
        {
            InitializeComponent();
        }

        private void SubeCalisaniForm_Load(object sender, EventArgs e)
        {
            SatislariListele();
            OnayliSatislariGetir();
        }
        private void SatislariListele()
        {
            try
            {
                // SQL sorgusu: Beklemede olan satışları seç
                string query = "SELECT SatisID, YakitTuru, Miktar, Tutar, Tarih, OnayDurumu FROM Satislar WHERE OnayDurumu = 'Beklemede'";

                // SQL bağlantısı ve DataTable kullanarak verileri çekiyoruz
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // DataGridView'e veriyi atama
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satışları yüklerken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırın ID'sini al
                int seciliID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SatisID"].Value);

                // SQL sorgusu: OnayDurumu'nu güncelle
                string query = "UPDATE Satislar SET OnayDurumu = 'Onaylandı' WHERE SatisID = @id";

                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", seciliID);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Satış başarıyla onaylandı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Onaylama sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                connection.Close();
                SatislariListele(); // Listeyi yenile
            }
        }

        private void btnReddet_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırın ID'sini al
                int seciliID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SatisID"].Value);

                // SQL sorgusu: OnayDurumu'nu reddedildi olarak güncelle
                string query = "UPDATE Satislar SET OnayDurumu = 'Reddedildi' WHERE SatisID = @id";

                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", seciliID);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Satış başarıyla reddedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reddetme sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                connection.Close();
                SatislariListele(); // Listeyi yenile
            }
        }
        private void OnayliSatislariGetir()
        {
            try
            {
                connection.Open();
                string query = "SELECT SatisID, YakitTuru, Miktar, Tutar, Tarih FROM Satislar WHERE OnayDurumu = 'Onaylandı'";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSatislar.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnGunSonuHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "SELECT SUM(CAST(Tutar AS DECIMAL(18,2))) FROM Satislar WHERE OnayDurumu = 'Onaylandı' AND CAST(Tarih AS DATE) = CAST(GETDATE() AS DATE)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Tarih", DateTime.Today);

                object result = cmd.ExecuteScalar();
                decimal toplamTutar = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                lblGunSonuToplam.Text = $"Gün Sonu Toplam: {toplamTutar} TL";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private decimal GetGunSonuToplami()
        {
            decimal toplam = 0;

            try
            {
                connection.Open();
                string query = "SELECT SUM(CAST(Tutar AS DECIMAL(18,2))) FROM Satislar WHERE OnayDurumu = 'Onaylandı' AND CAST(Tarih AS DATE) = CAST(GETDATE() AS DATE)";
                SqlCommand cmd = new SqlCommand(query, connection);

                object result = cmd.ExecuteScalar(); // Tek değer alır
                toplam = result != DBNull.Value ? Convert.ToDecimal(result) : 0; // Null kontrolü
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return toplam;
        }

        private void btnGunSonuKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                decimal toplamTutarDecimal = GetGunSonuToplami();

                if (toplamTutarDecimal == 0)
                {
                    MessageBox.Show("Gün sonu raporu için işlem yapılacak satış bulunamadı.");
                    return;
                }

                connection.Open();
                string insertQuery = "INSERT INTO GunSonuRaporu (Tarih, ToplamTutar) VALUES (@Tarih, @ToplamTutar)";
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@Tarih", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@ToplamTutar", toplamTutarDecimal);

                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Gün sonu başarıyla kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void dgvSatislar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
