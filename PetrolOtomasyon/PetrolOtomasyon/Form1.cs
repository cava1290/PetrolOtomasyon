using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace PetrolOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifreyi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT Rol FROM Kullanıcılar WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@Sifre", sifre);

                    var rol = command.ExecuteScalar();

                    if (rol != null)
                    {
                        string userRole = rol.ToString();
                        MessageBox.Show($"Hoşgeldiniz! Rolünüz: {userRole}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Rolüne göre yeni formu aç
                        switch (userRole)
                        {
                            case "Genel Müdür":
                                GenelMudurForm genelMudurForm = new GenelMudurForm();
                                genelMudurForm.Show();
                                break;
                            case "Şube Çalışanı":
                                SubeCalisaniForm subeCalisaniForm = new SubeCalisaniForm();
                                subeCalisaniForm.Show();
                                break;
                            case "Pompacı":
                                PompaForm pompaForm = new PompaForm();
                                pompaForm.Show();
                                break;
                            default:
                                MessageBox.Show("Bilinmeyen rol!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KayitForm kayitForm = new KayitForm();
            kayitForm.Show();
        }
    }
}
