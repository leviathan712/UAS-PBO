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
using System.Drawing.Printing;

namespace UAS_PBO.Mahasiswa_add
{
    public partial class Riwayat_krs : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-FVAV4PC\\SQLEXPRESS;Initial Catalog=PBO;Integrated Security=True;Encrypt=False";

        public Riwayat_krs()
        {
            InitializeComponent();
            DisplayData();
            DisplayDataKRS();
        }

        private void DisplayData()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Kode_jurusan, Nama_Kelas, Sks, Jadwal FROM Krs_mahasiswa";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
                    
                    DataTable dataTable = new DataTable();

                    sqlConnection.Open();
                    dataAdapter.Fill(dataTable);

                    // Bind DataTable ke DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DisplayDataKRS()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Tahun_ajaran, Semester, NIM, Nama, Program_studi FROM Mahasiswa WHERE Nama = @Username"; // Sesuaikan Nama_Tabel dengan nama tabel yang tepat
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Username", UserSession.Username);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        // Tampilkan data pada label-label yang ada
                        Tahun_ajaran.Text = reader["Tahun_ajaran"].ToString();
                        Semester.Text = reader["Semester"].ToString();
                        NIM.Text = reader["NIM"].ToString();
                        Nama.Text = reader["Nama"].ToString();
                        Program_studi.Text = reader["Program_studi"].ToString();
                    }
                    else
                    {
                        // Jika tidak ada data yang ditemukan, atur label-label menjadi kosong atau pesan yang sesuai
                        Tahun_ajaran.Text = "";
                        Semester.Text = "";
                        NIM.Text = "";
                        Nama.Text = "";
                        Program_studi.Text = "";
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void panel_print_KRS_Paint(object sender, PaintEventArgs e)
        {

        }

        private void print_krs_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintImage);

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = pd;
            printPreviewDialog.ShowDialog();
        }

        private void PrintImage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(panel_print_KRS.Width, panel_print_KRS.Height);

            // Ubah ukuran bitmap sesuai dengan ukuran panel yang diinginkan (991x1000)
            //bmp = new Bitmap(991, 1000);

            // Gambar isi panel ke bitmap
            panel_print_KRS.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            // Gambar bitmap ke halaman cetak dengan lokasi yang diinginkan (75, 100)
            e.Graphics.DrawImage(bmp, new Point(0, 0)); // Ubah koordinat sesuai kebutuhan
        }

        private void Print_Click(object sender, EventArgs e)
        {

        }

        private void Riwayat_krs_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
