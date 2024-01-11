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
using Guna.UI2.WinForms;

namespace UAS_PBO.Mahasiswa_add
{
    public partial class JadwalMingguIni : UserControl
    {
        String connectionString = "Data Source=DESKTOP-FVAV4PC\\SQLEXPRESS;Initial Catalog=PBO;Integrated Security=True;Encrypt=False";
        public JadwalMingguIni()
        {
            InitializeComponent();
        }

        private void JadwalMingguIni_Load(object sender, EventArgs e)
        {

            TampilkanDataHari();
        }
        private void TampilkanDataHari()
        {
            // Mendapatkan koneksi ke database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Buka koneksi
                connection.Open();

                // Array untuk menyimpan nama hari
                string[] hari = { "Senin", "Selasa", "Rabu", "Kamis", "Jumat" };

                // Menentukan posisi awal DataGridView di dalam Form
                int posisiY = 30;

                // Perulangan untuk setiap hari
                for (int i = 0; i < hari.Length; i++)
                {
                    // Buat DataGridView baru untuk setiap hari
                    Guna2DataGridView dataGridView = new Guna2DataGridView();
                    dataGridView.Name = "dataGridView_" + hari[i]; // Beri nama DataGridView berdasarkan hari
                    dataGridView.Width = 862; // Atur lebar DataGridView
                    dataGridView.Height = 80; // Atur tinggi DataGridView
                    dataGridView.Left = 20; // Atur posisi horizontal DataGridView
                    dataGridView.Top = posisiY; // Atur posisi vertikal DataGridView


                    // Tambahkan DataGridView ke dalam Form
                    this.Controls.Add(dataGridView);

                    // Buat DataTable untuk menampung data dari database
                    DataTable dataTable = new DataTable();

                    // Query SQL untuk mengambil data berdasarkan nama hari
                    string query = "SELECT Hari,Mulai,Selesai,Jenis,Kuliah,Materi,Ruang,Pengajar FROM Perkuliahan WHERE Hari = @Hari";

                    // Buat command SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Tambahkan parameter untuk nama hari
                        command.Parameters.AddWithValue("@Hari", hari[i]);

                        // Baca data menggunakan SqlDataAdapter
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Isi data ke DataTable
                            adapter.Fill(dataTable);
                        }
                    }

                    // Tampilkan data ke dalam DataGridView sesuai dengan DataTable
                    dataGridView.DataSource = dataTable;

                    dataGridView.AutoResizeColumns();

                    // Sesuaikan posisi untuk DataGridView berikutnya
                    posisiY += dataGridView.Height + 20;
                }

                // Tutup koneksi setelah selesai mengambil data
                connection.Close();
            }
        }
    }
}
