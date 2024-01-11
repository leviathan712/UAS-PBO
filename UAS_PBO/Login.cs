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

namespace UAS_PBO
{
    public partial class Login : Form
    {
        private string connectionString = "Data Source=DESKTOP-FVAV4PC\\SQLEXPRESS;Initial Catalog=PBO;Integrated Security=True;Encrypt=False";
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT NIM, Role FROM Login WHERE Nama = @Username AND Password = @Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        UserSession.NIM = reader["NIM"].ToString(); // Set NIM
                        string role = reader["Role"].ToString();

                        MessageBox.Show($"Login berhasi sebagai {role}!");

                        // Simpan informasi sesi pengguna dan lanjutkan ke halaman yang sesuai dengan rolenya
                        SaveUserSession(username, role);

                        OpenNextFormBasedOnRole(role);
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void SaveUserSession(string username, string role)
        {
            UserSession.Username = username;
            UserSession.Role = role;
        }

        private void OpenNextFormBasedOnRole(string role)
        {
            Form nextForm = null;

            switch (role)
            {
                case "mahasiswa":
                    nextForm = new MahasiswaForm();
                    break;
                case "admin":
                    nextForm = new AdminForm();
                    break;
            }
            if (nextForm != null)
            {
                nextForm.Show();
                this.Hide();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Kelas sesi pengguna
    }
    public static class UserSession
    {
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static string NIM { get; set; }
    }
}


