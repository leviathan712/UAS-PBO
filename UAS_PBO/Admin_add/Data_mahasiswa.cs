using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UAS_PBO.Admin_add
{
    public partial class Data_mahasiswa : UserControl
    {
        private const string connectionString = "Data Source=DESKTOP-FVAV4PC\\SQLEXPRESS;Initial Catalog=PBO;Integrated Security=True;Encrypt=False"; // Ganti dengan connection string SQL Server kamu

        public Data_mahasiswa()
        {
            InitializeComponent();
        }

        private void Data_mahasiswa_Load(object sender, EventArgs e)
        {
            LoadDataMahasiswa();
        }

        private void LoadDataMahasiswa()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT NIM, Nama, Email, Program_studi, Semester, Tahun_ajaran FROM Mahasiswa";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView_Mahasiswa.DataSource = dataTable;
                }
            }
        }

        private void dataGridView_Mahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_Mahasiswa.AllowUserToAddRows = false;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Mahasiswa.Rows[e.RowIndex];

                textBox_NIM.Text = row.Cells["NIM"].Value.ToString();
                textBox_Nama.Text = row.Cells["Nama"].Value.ToString();
                textBox_Email.Text = row.Cells["Email"].Value.ToString();
                textBox_Program_studi.Text = row.Cells["Program_studi"].Value.ToString();
                textBox_Semester.Text = row.Cells["Semester"].Value.ToString();
                textBox_Tahun_ajaran.Text = row.Cells["Tahun_ajaran"].Value.ToString();
            }
        }

        private void Button_Input_Click(object sender, EventArgs e)
        {
            string nim = textBox_NIM.Text;
            string nama = textBox_Nama.Text;
            string email = textBox_Email.Text;
            string programStudi = textBox_Program_studi.Text;
            string semester = textBox_Semester.Text;
            string tahunAjaran = textBox_Tahun_ajaran.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Cek apakah data dengan NIM yang sama sudah ada di tabel login
                string checkIfExistsQuery = "SELECT COUNT(*) FROM login WHERE NIM = @NIM";
                SqlCommand checkIfExistsCommand = new SqlCommand(checkIfExistsQuery, connection);
                checkIfExistsCommand.Parameters.AddWithValue("@NIM", nim);
                int existingCount = (int)checkIfExistsCommand.ExecuteScalar();

                if (existingCount == 0)
                {
                    // Jika data belum ada, tambahkan data ke tabel login
                    string insertQuery = "INSERT INTO login (NIM, Nama, Password, Role) VALUES (@NIM, @Nama, @Password, @Role)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@NIM", nim);
                    insertCommand.Parameters.AddWithValue("@Nama", nama);
                    insertCommand.Parameters.AddWithValue("@Password", "123456"); // Password default
                    insertCommand.Parameters.AddWithValue("@Role", "mahasiswa");

                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil ditambahkan.");
                }

                // Tambahkan atau perbarui data di tabel Mahasiswa
                string insertOrUpdateQuery = "MERGE INTO Mahasiswa USING (VALUES (@NIM, @Nama, @Email, @Program_studi, @Semester, @Tahun_ajaran)) " +
                                            "AS newValues (NIM, Nama, Email, Program_studi, Semester, Tahun_ajaran) " +
                                            "ON Mahasiswa.NIM = newValues.NIM " +
                                            "WHEN MATCHED THEN " +
                                            "UPDATE SET Nama = newValues.Nama, Email = newValues.Email, " +
                                            "Program_studi = newValues.Program_studi, Semester = newValues.Semester, " +
                                            "Tahun_ajaran = newValues.Tahun_ajaran " +
                                            "WHEN NOT MATCHED THEN " +
                                            "INSERT (NIM, Nama, Email, Program_studi, Semester, Tahun_ajaran) " +
                                            "VALUES (newValues.NIM, newValues.Nama, newValues.Email, " +
                                            "newValues.Program_studi, newValues.Semester, newValues.Tahun_ajaran);";

                SqlCommand insertOrUpdateCommand = new SqlCommand(insertOrUpdateQuery, connection);
                insertOrUpdateCommand.Parameters.AddWithValue("@NIM", nim);
                insertOrUpdateCommand.Parameters.AddWithValue("@Nama", nama);
                insertOrUpdateCommand.Parameters.AddWithValue("@Email", email);
                insertOrUpdateCommand.Parameters.AddWithValue("@Program_studi", programStudi);
                insertOrUpdateCommand.Parameters.AddWithValue("@Semester", semester);
                insertOrUpdateCommand.Parameters.AddWithValue("@Tahun_ajaran", tahunAjaran);

                insertOrUpdateCommand.ExecuteNonQuery();
                ClearTextBoxes();
            }

            LoadDataMahasiswa(); // Refresh dataGridView setelah proses input
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            string nim = textBox_NIM.Text;
            string nama = textBox_Nama.Text;
            string email = textBox_Email.Text;
            string programStudi = textBox_Program_studi.Text;
            string semester = textBox_Semester.Text;
            string tahunAjaran = textBox_Tahun_ajaran.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update nama di tabel login
                string updateLoginQuery = "UPDATE login SET Nama = @Nama WHERE NIM = @NIM";
                SqlCommand updateLoginCommand = new SqlCommand(updateLoginQuery, connection);
                updateLoginCommand.Parameters.AddWithValue("@Nama", nama);
                updateLoginCommand.Parameters.AddWithValue("@NIM", nim);

                updateLoginCommand.ExecuteNonQuery();

                // Update data di tabel Mahasiswa
                string updateMahasiswaQuery = "UPDATE Mahasiswa SET Nama = @Nama, Email = @Email, " +
                                              "Program_studi = @Program_studi, Semester = @Semester, " +
                                              "Tahun_ajaran = @Tahun_ajaran WHERE NIM = @NIM";
                SqlCommand updateMahasiswaCommand = new SqlCommand(updateMahasiswaQuery, connection);
                updateMahasiswaCommand.Parameters.AddWithValue("@Nama", nama);
                updateMahasiswaCommand.Parameters.AddWithValue("@Email", email);
                updateMahasiswaCommand.Parameters.AddWithValue("@Program_studi", programStudi);
                updateMahasiswaCommand.Parameters.AddWithValue("@Semester", semester);
                updateMahasiswaCommand.Parameters.AddWithValue("@Tahun_ajaran", tahunAjaran);
                updateMahasiswaCommand.Parameters.AddWithValue("@NIM", nim);

                updateMahasiswaCommand.ExecuteNonQuery();
                ClearTextBoxes();
            }
            MessageBox.Show("Data berhasil diubah.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataMahasiswa(); // Refresh dataGridView setelah proses edit
        }

        private void button_Hapus_Click(object sender, EventArgs e)
        {
            string nim = textBox_NIM.Text;

            if (MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Hapus data dari tabel Mahasiswa
                    string deleteMahasiswaQuery = "DELETE FROM Mahasiswa WHERE NIM = @NIM";
                    SqlCommand deleteMahasiswaCommand = new SqlCommand(deleteMahasiswaQuery, connection);
                    deleteMahasiswaCommand.Parameters.AddWithValue("@NIM", nim);

                    deleteMahasiswaCommand.ExecuteNonQuery();

                    // Hapus data dari tabel login
                    string deleteLoginQuery = "DELETE FROM login WHERE NIM = @NIM";
                    SqlCommand deleteLoginCommand = new SqlCommand(deleteLoginQuery, connection);
                    deleteLoginCommand.Parameters.AddWithValue("@NIM", nim);

                    deleteLoginCommand.ExecuteNonQuery();
                    ClearTextBoxes();
                }

                LoadDataMahasiswa(); // Refresh dataGridView setelah proses hapus

                MessageBox.Show("Data telah dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ClearTextBoxes()
        {
            textBox_NIM.Text = "";
            textBox_Nama.Text = "";
            textBox_Email.Text = "";
            textBox_Program_studi.Text = "";
            textBox_Semester.Text = "";
            textBox_Tahun_ajaran.Text = "";
        }
    }
}
