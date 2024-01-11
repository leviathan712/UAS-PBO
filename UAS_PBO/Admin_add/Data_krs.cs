using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UAS_PBO.Admin_add
{
    public partial class Data_krs : UserControl
    {
        private const string connectionString = "Data Source=DESKTOP-FVAV4PC\\SQLEXPRESS;Initial Catalog=PBO;Integrated Security=True;Encrypt=False";
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public Data_krs()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Kode_jurusan, Nama_kelas, Jadwal, Sks, Semester FROM Jadwal_krs";
                    dataAdapter = new SqlDataAdapter(query, connection);
                    dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);
                    dataGridView_Jadwal_krs.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView_Jadwal_krs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_Jadwal_krs.AllowUserToAddRows = false;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Jadwal_krs.Rows[e.RowIndex];
                textBox_kode_jurusan.Text = row.Cells["Kode_jurusan"].Value.ToString();
                textBox_nama_kelas.Text = row.Cells["Nama_kelas"].Value.ToString();
                textBox_jadwal.Text = row.Cells["Jadwal"].Value.ToString();
                textBox_sks.Text = row.Cells["Sks"].Value.ToString();
                textBox_semester.Text = row.Cells["Semester"].Value.ToString();
            }
        }

        private void button_input_Click(object sender, EventArgs e)
        {
            string kodeJurusan = textBox_kode_jurusan.Text;
            string namaKelas = textBox_nama_kelas.Text;
            string jadwal = textBox_jadwal.Text;
            string sks = textBox_sks.Text;
            string semester = textBox_semester.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string checkIfExistsQuery = "SELECT COUNT(*) FROM Jadwal_krs WHERE Nama_kelas = @Nama_kelas";
                    SqlCommand command = new SqlCommand(checkIfExistsQuery, connection);
                    command.Parameters.AddWithValue("@Nama_kelas", namaKelas);
                    int existingRecords = (int)command.ExecuteScalar();

                    if (existingRecords == 0)
                    {
                        string insertQuery = "INSERT INTO Jadwal_krs (Kode_jurusan, Nama_kelas, Jadwal, Sks, Semester) VALUES (@Kode_jurusan, @Nama_kelas, @Jadwal, @Sks, @Semester)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@Kode_jurusan", kodeJurusan);
                        insertCommand.Parameters.AddWithValue("@Nama_kelas", namaKelas);
                        insertCommand.Parameters.AddWithValue("@Jadwal", jadwal);
                        insertCommand.Parameters.AddWithValue("@Sks", sks);
                        insertCommand.Parameters.AddWithValue("@Semester", semester);
                        insertCommand.ExecuteNonQuery();

                        MessageBox.Show("Data berhasil ditambahkan.");
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Data dengan Nama Kelas tersebut sudah ada.");
                    }
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            string kodeJurusan = textBox_kode_jurusan.Text;
            string namaKelas = textBox_nama_kelas.Text;
            string jadwal = textBox_jadwal.Text;
            string sks = textBox_sks.Text;
            string semester = textBox_semester.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE Jadwal_krs SET Kode_jurusan = @Kode_jurusan, Jadwal = @Jadwal, Sks = @Sks, Semester = @Semester WHERE Nama_kelas = @Nama_kelas";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@Kode_jurusan", kodeJurusan);
                    command.Parameters.AddWithValue("@Nama_kelas", namaKelas);
                    command.Parameters.AddWithValue("@Jadwal", jadwal);
                    command.Parameters.AddWithValue("@Sks", sks);
                    command.Parameters.AddWithValue("@Semester", semester);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil diupdate.");
                        LoadData(); // Refresh tampilan setelah edit
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Tidak ada data dengan Nama Kelas tersebut.");
                    }
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button_hapus_Click(object sender, EventArgs e)
        {
            string namaKelas = textBox_nama_kelas.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Jadwal_krs WHERE Nama_kelas = @Nama_kelas";
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@Nama_kelas", namaKelas);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus.");
                        LoadData(); // Refresh tampilan setelah hapus
                        ClearTextBoxes(); // Bersihkan textbox setelah penghapusan
                    }
                    else
                    {
                        MessageBox.Show("Tidak ada data dengan Nama Kelas tersebut.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearTextBoxes()
        {
            textBox_kode_jurusan.Text = "";
            textBox_nama_kelas.Text = "";
            textBox_jadwal.Text = "";
            textBox_sks.Text = "";
            textBox_semester.Text = "";
        }

        private void Data_krs_Load(object sender, EventArgs e)
        {

        }
    }
}
