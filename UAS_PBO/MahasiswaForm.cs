using System.Windows.Forms;
using System;
using UAS_PBO.Mahasiswa;
using UAS_PBO.Mahasiswa_add;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;

namespace UAS_PBO
{
    public partial class MahasiswaForm : Form
    {
        private string _username;
        public MahasiswaForm()
        {
            InitializeComponent();
            Beranda beranda1 = new Beranda();
            addUserControl(beranda1);
        }

        private void SetRoundedPictureBoxBorder()
        {
            System.Drawing.Drawing2D.GraphicsPath roundedPath = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 20;
            roundedPath.AddArc(0, 0, 2 * radius, 2 * radius, 180, 90);
            roundedPath.AddArc(pictureBox1.Width - 2 * radius, 0, 2 * radius, 2 * radius, 270, 90);
            roundedPath.AddArc(pictureBox1.Width - 2 * radius, pictureBox1.Height - 2 * radius, 2 * radius, 2 * radius, 0, 90);
            roundedPath.AddArc(0, pictureBox1.Height - 2 * radius, 2 * radius, 2 * radius, 90, 90);
            roundedPath.CloseFigure();

            Region roundedRegion = new Region(roundedPath);
            pictureBox1.Region = roundedRegion;
        }

        private void addUserControl(UserControl mahasiswa)
        {
            panel5.Controls.Clear();
            panel5.Controls.Add(mahasiswa);
            panel5.BringToFront();
        }
        private void KeluarProgram()
        {
            // Cara 1: Menggunakan Application.Exit()
            Application.Exit();

            // Cara 2: Menggunakan Close() pada form utama
            // this.Close(); // Jika ini adalah form utama
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            Beranda beranda1 = new Beranda();
            addUserControl(beranda1);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_MouseHover(object sender, EventArgs e)
        {

        }

        private void jadwalMingguIniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JadwalMingguIni jadwalMingguIni1 = new JadwalMingguIni();
            addUserControl(jadwalMingguIni1);
        }

        private void jadwalSemesterIniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JadwalSemester jadwalSemester = new JadwalSemester();
            addUserControl(jadwalSemester);
        }

        private void pengisianKRSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pengisian_KRS pengisiankrs = new Pengisian_KRS();
            addUserControl(pengisiankrs);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MahasiswaForm_Load(object sender, EventArgs e)
        {
            SetRoundedPictureBoxBorder();
            SetUserImageOnToolStripDropDownButton();

        }

        private void keluaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeluarProgram();
        }

        private void toolStripDropDownButton3_Click(object sender, EventArgs e)
        {
           
        }
        private void SetUserImageOnToolStripDropDownButton()
        {
            // Gantilah "nama_pengguna" dengan variabel yang berisi nama pengguna yang sesuai
            string namaPengguna = UserSession.Username;

            // Ambil data gambar dari database berdasarkan nama pengguna
            byte[] imageBytes = GetImageFromDatabase(namaPengguna);

            if (imageBytes != null)
            {
                // Konversi data gambar menjadi objek Image
                Image userImage = ImageFromByteArray(imageBytes);

                // Atur gambar ke ToolStripDropDownButton
                toolStripDropDownButton3.BackgroundImage = userImage;
                toolStripDropDownButton3.Size = new Size(79, 52);
            }
            else
            {
                // Jika data gambar tidak ditemukan, atur gambar default atau kosong
                toolStripDropDownButton3.Image = null;
            }
        }

        // Metode untuk mengambil data gambar dari database berdasarkan nama pengguna
        private byte[] GetImageFromDatabase(string username)
        {
            byte[] imageBytes = null;

            // Implementasikan koneksi ke database SQL Server dan query untuk mengambil gambar
            // Gantilah "connectionString" dengan koneksi database yang sesuai
            string connectionString = "Data Source=DESKTOP-FVAV4PC\\SQLEXPRESS;Initial Catalog=PBO;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Foto_profile FROM Mahasiswa WHERE Nama = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Ambil data gambar dari database
                            imageBytes = (byte[])reader["Foto_profile"];
                        }
                    }
                }
            }

            return imageBytes;
        }

        // Metode untuk mengonversi data byte menjadi objek Image
        private Image ImageFromByteArray(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }

        private void mYProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profil = new Profile();
            addUserControl(profil);
        }

        private void MahasiswaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Cancel the form closing
            }
            else
            {
                Application.Exit();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void riwayatKRSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Riwayat_krs riwayat_krs = new Riwayat_krs();
            addUserControl(riwayat_krs);
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void nIlaiMahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nilai_mahasiswa nilai_Mahasiswa = new Nilai_mahasiswa();
            addUserControl(nilai_Mahasiswa);
        }

        private void miniToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
