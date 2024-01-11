using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS_PBO.Admin_add;
using System.Windows.Forms;

namespace UAS_PBO
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            Data_mahasiswa data_mahasiswa = new Data_mahasiswa();
            addUserControl(data_mahasiswa);
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            SetRoundedPictureBoxBorder();
        }
        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void addUserControl(UserControl Admin)
        {
            panel5.Controls.Clear();
            panel5.Controls.Add(Admin);
            panel5.BringToFront();
        }

        private void Datamahasiswa_Click(object sender, EventArgs e)
        {
            Data_mahasiswa data_mahasiswa = new Data_mahasiswa();
            addUserControl(data_mahasiswa);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Datanilai_Click(object sender, EventArgs e)
        {
            Data_nilai data_Nilai = new Data_nilai();
            addUserControl(data_Nilai);
        }

        private void Datakrs_Click(object sender, EventArgs e)
        {
            Data_krs data_Krs = new Data_krs();
            addUserControl(data_Krs);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void KeluarProgram()
        {
            // Cara 1: Menggunakan Application.Exit()
            Application.Exit();

            // Cara 2: Menggunakan Close() pada form utama
            // this.Close(); // Jika ini adalah form utama
        }
        private void keluaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeluarProgram();
        }
    }
}
