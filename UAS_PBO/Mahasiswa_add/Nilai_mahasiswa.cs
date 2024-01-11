using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UAS_PBO.Mahasiswa_add
{
    public partial class Nilai_mahasiswa : UserControl
    {
        // Pastikan ganti dengan koneksi SQL Server Anda
        string connectionString = "Data Source=DESKTOP-FVAV4PC\\SQLEXPRESS;Initial Catalog=PBO;Integrated Security=True;Encrypt=False";
        
        public Nilai_mahasiswa()
        {
            InitializeComponent();
        }

        private void Nilai_mahasiswa_Load(object sender, EventArgs e)
        {
            LoadDataMahasiswa();
        }

        private void LoadDataMahasiswa()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string nim = UserSession.NIM;
                    connection.Open();
                    string query = "SELECT Kode_mk,Nama_mk, Nilai_uas, Nilai_uts, Nilai_tugas_individu FROM Nilai_mahasiswa where NIM = @nim"; // Ganti dengan nama tabel yang benar
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nim", UserSession.NIM);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Menambahkan kolom nilai akhir ke dalam DataTable
                    dataTable.Columns.Add("Nilai Akhir", typeof(double));

                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Hitung nilai akhir berdasarkan persentase UAS, UTS, dan Tugas Individu
                        double nilaiUAS = Convert.ToDouble(row["Nilai_uas"]);
                        double nilaiUTS = Convert.ToDouble(row["Nilai_uts"]);
                        double nilaiTugas = Convert.ToDouble(row["Nilai_tugas_individu"]);

                        // Ganti persentase sesuai kebutuhan
                        double persentaseUAS = 0.4;
                        double persentaseUTS = 0.3;
                        double persentaseTugas = 0.3;

                        double nilaiAkhir = (nilaiUAS * persentaseUAS) + (nilaiUTS * persentaseUTS) + (nilaiTugas * persentaseTugas);

                        // Set nilai akhir ke dalam kolom "Nilai Akhir"
                        row["Nilai Akhir"] = nilaiAkhir;
                    }

                    // Menampilkan data ke dalam DataGridView
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.Columns["Kode_mk"].HeaderText = "Kode Mata Kuliah";
                    dataGridView1.Columns["Nama_mk"].HeaderText = "Nama Mata Kuliah";
                    dataGridView1.Columns["Nilai_uas"].HeaderText = "Nilai UTS";
                    dataGridView1.Columns["Nilai_uts"].HeaderText = "Nilai UAS";
                    dataGridView1.Columns["Nilai_tugas_individu"].HeaderText = "Nilai Tugas Individu";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
