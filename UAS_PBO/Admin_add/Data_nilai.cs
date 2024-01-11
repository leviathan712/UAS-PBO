using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UAS_PBO.Admin_add
{
    public partial class Data_nilai : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-FVAV4PC\\SQLEXPRESS;Initial Catalog=PBO;Integrated Security=True;Encrypt=False";
        private DataTable mahasiswaTable;
        private DataTable nilaiMahasiswaTable;

        public Data_nilai()
        {
            InitializeComponent();
            LoadMahasiswaData();
            button_Input_nilai.Click += button_Edit_nilai_Click;
        }

        private void LoadMahasiswaData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT NIM, Nama, Program_studi FROM Mahasiswa";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                mahasiswaTable = new DataTable();
                adapter.Fill(mahasiswaTable);
            }

            dataGridView_Mahasiswa.DataSource = mahasiswaTable;
        }

        private void LoadNilaiMahasiswa(string nim)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT Kode_mk, Nama_mk, Nilai_uas, Nilai_uts, Nilai_tugas_individu FROM Nilai_mahasiswa WHERE NIM = '{nim}'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                nilaiMahasiswaTable = new DataTable();
                adapter.Fill(nilaiMahasiswaTable);
            }

            dataGridView_Nilai_mahasiswa.DataSource = nilaiMahasiswaTable;
        }

        private void dataGridView_Mahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Mahasiswa.Rows[e.RowIndex];
                string nim = row.Cells["NIM"].Value.ToString();
                LoadNilaiMahasiswa(nim);
            }
        }

        private void dataGridView_Nilai_mahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_Nilai_mahasiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView_Nilai_mahasiswa.Rows[e.RowIndex];

                textBox_Kode_mk.Text = selectedRow.Cells["Kode_mk"].Value.ToString();
                textBox_Nama_mk.Text = selectedRow.Cells["Nama_mk"].Value.ToString();
                textBox_Nilai_uas.Text = selectedRow.Cells["Nilai_uas"].Value.ToString();
                textBox_Nilai_uts.Text = selectedRow.Cells["Nilai_uts"].Value.ToString();
                textBox_Nilai_tugas_individu.Text = selectedRow.Cells["Nilai_tugas_individu"].Value.ToString();
            }
        }

        private void button_Edit_nilai_Click(object sender, EventArgs e)
        {
            if (dataGridView_Nilai_mahasiswa.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView_Nilai_mahasiswa.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView_Nilai_mahasiswa.Rows[selectedRowIndex];

                // Mengambil nilai yang diubah dari TextBox
                string kode_mk = textBox_Kode_mk.Text;
                string nama_mk = textBox_Nama_mk.Text;
                string nilai_uas = textBox_Nilai_uas.Text;
                string nilai_uts = textBox_Nilai_uts.Text;
                string nilai_tugas_individu = textBox_Nilai_tugas_individu.Text;

                // Menyimpan nilai ke dalam database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = @"UPDATE Nilai_mahasiswa 
                                  SET Kode_mk = @kode_mk, Nama_mk = @nama_mk, Nilai_uas = @nilai_uas, 
                                      Nilai_uts = @nilai_uts, Nilai_tugas_individu = @nilai_tugas_individu 
                                  WHERE Kode_mk = @kode_mk"; // Sesuaikan kondisi WHERE sesuai kebutuhan

                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@kode_mk", kode_mk);
                    command.Parameters.AddWithValue("@nama_mk", nama_mk);
                    command.Parameters.AddWithValue("@nilai_uas", nilai_uas);
                    command.Parameters.AddWithValue("@nilai_uts", nilai_uts);
                    command.Parameters.AddWithValue("@nilai_tugas_individu", nilai_tugas_individu);

                    command.ExecuteNonQuery();
                    connection.Close();
                    
                }
                MessageBox.Show("Data berhasil diubah.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Pilih baris nilai yang ingin diubah.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadMahasiswaData();
        }
    }
}
