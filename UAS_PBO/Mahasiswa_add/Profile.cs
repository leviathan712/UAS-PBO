using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UAS_PBO.Mahasiswa_add
{
    public partial class Profile : UserControl
    {
        private string username = UserSession.Username;
        private string connectionString = "Data Source=DESKTOP-FVAV4PC\\SQLEXPRESS;Initial Catalog=PBO;Integrated Security=True;Encrypt=False";
        private string selectedImagePath = "";
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            DisplayProfilePicture();
            GetDataFromDatabase();
        }
        private void GetDataFromDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query SQL untuk mengambil data berdasarkan nama pengguna yang login
                    string query = "SELECT NIM, Nama, Program_studi, Email FROM Mahasiswa WHERE Nama = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Ambil nilai dari database dan tampilkan di label atau tempat yang sesuai
                                string nim = reader["NIM"].ToString();
                                string nama = reader["Nama"].ToString();
                                string programStudi = reader["Program_studi"].ToString();
                                string email = reader["Email"].ToString();

                                // Tampilkan nilai di label atau tempat yang sesuai
                                NIM.Text = nim;
                                Nama.Text = nama;
                                Program_studi.Text = programStudi;
                                Email.Text = email;
                            }
                            else
                            {
                                MessageBox.Show("Data tidak ditemukan untuk pengguna dengan nama pengguna ini.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(selectedImagePath);

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "UPDATE Mahasiswa SET Foto_profile = @ProfilePicture WHERE Nama = @Username";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ProfilePicture", imageBytes);
                        command.Parameters.AddWithValue("@Username", UserSession.Username); // Sesuaikan dengan ID pengguna yang sesuai.

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Foto profil berhasil diperbarui dan disimpan ke database.");
                        }
                        else
                        {
                            MessageBox.Show("Gagal menyimpan foto profil ke database.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Pilih gambar terlebih dahulu.");
            }
        }
        private void DisplayProfilePicture()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Foto_profile FROM Mahasiswa WHERE Nama = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", UserSession.Username);

                    // ExecuteScalar returns the first column of the first row as an object
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        byte[] imageBytes = (byte[])result;
                        if (imageBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Foto profil kosong di database.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Foto profil tidak ditemukan di database.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(selectedImagePath);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
