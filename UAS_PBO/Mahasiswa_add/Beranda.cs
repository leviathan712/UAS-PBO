using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UAS_PBO.Mahasiswa
{

    public partial class Beranda : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-FVAV4PC\\SQLEXPRESS;Initial Catalog=PBO;Integrated Security=True;Encrypt=False"; // Ganti dengan string koneksi SQL Server kamu

        public Beranda()
        {
            InitializeComponent();
            monthCalendar1.Size = new Size(700, 175);
            monthCalendar1.CalendarDimensions = new Size(2,2);
        }

        private void Beranda_Load(object sender, EventArgs e)
        {
            // Panggil fungsi untuk mengisi data hari
            FillDays();
            GetSchedule("Senin", panel_matkul1, 1);
            GetSchedule("Senin", panel_matkul2, 2);
            SetRoundedPanel(panel_matkul1);
            SetRoundedPanel(panel_matkul2);
            richTextBox1.Text = $"Welcome, Mahasiswa {UserSession.Username}!, dengan NIM = {UserSession.NIM}";
        }
        private void SetRoundedPanel(Panel panel)
        {
            int borderRadius = 30; // Ubah nilai sesuai keinginan, ini adalah nilai radius bulatan
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(panel.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(panel.Width - borderRadius, panel.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, panel.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            panel.Region = new Region(path);
        }

        private void list_matkul_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDay = list_matkul.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selectedDay))
            {
                // Panggil fungsi untuk mengambil jadwal berdasarkan hari yang dipilih
                GetSchedule(selectedDay, panel_matkul1, 1);
                GetSchedule(selectedDay, panel_matkul2, 2);
            }
        }

        private void FillDays()
        {
            // Isi data hari Senin-Jumat ke dalam listbox
            list_matkul.Items.Add("Senin");
            list_matkul.Items.Add("Selasa");
            list_matkul.Items.Add("Rabu");
            list_matkul.Items.Add("Kamis");
            list_matkul.Items.Add("Jumat");
        }
        private void GetSchedule(string day, Panel panel, int matkulNumber)
        {
            string query = "SELECT Kuliah, Mulai, Selesai, Pengajar, Ruang, Sks, Pertemuan FROM Perkuliahan WHERE Hari = @Hari AND Matkul_number = @MatkulNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Hari", day);
                command.Parameters.AddWithValue("@MatkulNumber", matkulNumber);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Set nilai label sesuai dengan hasil query
                        panel.Controls["Jadwal_matkul" + matkulNumber].Text = reader["Kuliah"]+" (01)".ToString();
                        panel.Controls["Jam_matkul" + matkulNumber].Text = reader["Mulai"]+(" - ") + reader["Selesai"] + (" WIB").ToString();
                        panel.Controls["Dosen_matkul" + matkulNumber].Text = reader["Pengajar"].ToString();
                        panel.Controls["Ruang_matkul" + matkulNumber].Text = ("Ruang ") + reader["Ruang"].ToString();
                        panel.Controls["Sks_matkul" + matkulNumber].Text = reader["Sks"] + (" SKS").ToString();
                        panel.Controls["Pertemuan_matkul" + matkulNumber].Text = ("Pertemuan ke ") + reader["Pertemuan"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void Sks_matkul1_Click(object sender, EventArgs e)
        {

        }

        private void Pertemuan_matkul1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
