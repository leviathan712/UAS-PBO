using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
// ... (kode lainnya tetap sama)

namespace UAS_PBO.Mahasiswa_add
{
    public partial class Pengisian_KRS : UserControl
    {
        public Pengisian_KRS()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-FVAV4PC\\SQLEXPRESS;Initial Catalog=PBO;Integrated Security=True;Encrypt=False");

        private void tampil1()
        {
            string sqlQuery = "SELECT Nama_Kelas,Jadwal,Sks,Semester,Kode_jurusan FROM Jadwal_krs;";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();

            sqlDataAdapter.Fill(dataSet, "Jadwal_KRS");
            dataGridView1.DataSource = dataSet.Tables["Jadwal_KRS"];
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["Nama_Kelas"].Width = 200;
            dataGridView1.Columns["Jadwal"].Width = 200;
            dataGridView1.Columns["Sks"].Width = 200;
            dataGridView1.Columns["Semester"].Width = 200;
            dataGridView1.Columns["Nama_Kelas"].HeaderText = "Nama Kelas"; // Replace "OriginalColumnName1" with the actual column name from your SQL Server table
            dataGridView1.Columns["Jadwal"].HeaderText = "Jadwal";
            dataGridView1.Columns["Sks"].HeaderText = "SKS"; // Replace "OriginalColumnName1" with the actual column name from your SQL Server table
            dataGridView1.Columns["Semester"].HeaderText = "Semester";
            // Tambahkan kolom checkbox ke DataGridView
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.HeaderText = ""; // Judul kolom
            checkboxColumn.Width = 50;
            checkboxColumn.Name = "checkboxColumn"; // Nama untuk referensi nanti
            dataGridView1.Columns.Insert(0, checkboxColumn); // Masukkan kolom sebagai kolom pertama
        }
        private void tampil2()
        {
            string sqlQuery = "SELECT Nama_Kelas,Jadwal,Sks,Semester,Kode_jurusan FROM krs_mahasiswa_sementara;";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();

            sqlDataAdapter.Fill(dataSet, "krs_mahasiswa_sementara");
            dataGridView2.DataSource = dataSet.Tables["krs_mahasiswa_sementara"];
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.Columns["Nama_Kelas"].Width = 200;
            dataGridView2.Columns["Jadwal"].Width = 200;
            dataGridView2.Columns["Sks"].Width = 200;
            dataGridView2.Columns["Semester"].Width = 200;
            dataGridView2.Columns["Nama_Kelas"].HeaderText = "Nama Kelas"; // Replace "OriginalColumnName1" with the actual column name from your SQL Server table
            dataGridView2.Columns["Jadwal"].HeaderText = "Jadwal";
            dataGridView2.Columns["Sks"].HeaderText = "SKS"; // Replace "OriginalColumnName1" with the actual column name from your SQL Server table
            dataGridView2.Columns["Semester"].HeaderText = "Semester";
            // Tambahkan kolom checkbox ke DataGridView
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.HeaderText = ""; // Judul kolom
            checkboxColumn.Width = 50;
            checkboxColumn.Name = "checkboxColumn"; // Nama untuk referensi nanti
            dataGridView2.Columns.Insert(0, checkboxColumn); // Masukkan kolom sebagai kolom pertama
        }

        private void Pengisian_KRS_Load(object sender, EventArgs e)
        {
            tampil1();
            tampil2();
        }

        private void Simpan_datagridview1_Click(object sender, EventArgs e)
        {
            int totalSKS = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool select1 = Convert.ToBoolean(row.Cells["checkboxColumn"].Value);
                if (select1)
                {
                    int sks = Convert.ToInt32(row.Cells["Sks"].Value);
                    if (totalSKS + sks > 10)
                    {
                        MessageBox.Show("SKS tidak boleh melebihi dari 10 SKS", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        foreach (DataGridViewRow selectedRow in dataGridView1.Rows)
                        {
                            selectedRow.Cells["checkboxColumn"].Value = false;
                        }
                        return; // Menghentikan proses penyimpanan jika melebihi batas SKS
                    }

                    totalSKS += sks;
                }
            }

            // Jika totalSKS masih kurang dari atau sama dengan 10, baru simpan ke krs_mahasiswa_sementara
            if (totalSKS <= 10)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool select1 = Convert.ToBoolean(row.Cells["checkboxColumn"].Value);
                    if (select1)
                    {
                        SqlCommand cmdInsert = new SqlCommand("INSERT INTO krs_mahasiswa_sementara (Nama_Kelas, Jadwal, Sks, Semester, Kode_jurusan) VALUES (@nama_kelas, @jadwal, @sks, @semester, @kode_jurusan)", sqlConnection);
                        cmdInsert.Parameters.AddWithValue("@nama_kelas", row.Cells["Nama_Kelas"].Value);
                        cmdInsert.Parameters.AddWithValue("@jadwal", row.Cells["Jadwal"].Value);
                        cmdInsert.Parameters.AddWithValue("@sks", row.Cells["Sks"].Value);
                        cmdInsert.Parameters.AddWithValue("@semester", row.Cells["Semester"].Value);
                        cmdInsert.Parameters.AddWithValue("@kode_jurusan", row.Cells["Kode_jurusan"].Value);
                        sqlConnection.Open();
                        cmdInsert.ExecuteNonQuery();
                        sqlConnection.Close();

                        // Hapus data dari Jadwal_KRS
                        SqlCommand cmdDelete = new SqlCommand("DELETE FROM Jadwal_krs WHERE Nama_Kelas = @nama_kelas", sqlConnection);
                        cmdDelete.Parameters.AddWithValue("@nama_kelas", row.Cells["Nama_Kelas"].Value);
                        sqlConnection.Open();
                        cmdDelete.ExecuteNonQuery();
                        sqlConnection.Close();

                        row.Cells["checkboxColumn"].Value = false; // Setelah disimpan, set nilai checkbox menjadi false
                    }
                }
            }
            else
            {
                MessageBox.Show("SKS tidak boleh melebihi dari 10 SKS", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (DataGridViewRow selectedRow in dataGridView1.Rows)
                {
                    selectedRow.Cells["checkboxColumn"].Value = false;
                }
            }

            MessageBox.Show("Data sukses dimasukkan dan dihapus dari Jadwal_KRS");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label_total_ambil_Click(object sender, EventArgs e)
        {

        }

        private void Simpan_krs_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil semua data dari krs_mahasiswa_sementara
                string sqlQuery = "SELECT * FROM krs_mahasiswa_sementara;";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                // Simpan semua data ke krs_mahasiswa
                sqlConnection.Open();
                foreach (DataRow row in dataTable.Rows)
                {
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO krs_mahasiswa (Nama_Kelas, Jadwal, Sks, Semester, Kode_jurusan) VALUES (@nama_kelas, @jadwal, @sks, @semester, @kode_jurusan)", sqlConnection);
                    cmdInsert.Parameters.AddWithValue("@nama_kelas", row["Nama_Kelas"]);
                    cmdInsert.Parameters.AddWithValue("@jadwal", row["Jadwal"]);
                    cmdInsert.Parameters.AddWithValue("@sks", row["Sks"]);
                    cmdInsert.Parameters.AddWithValue("@semester", row["Semester"]);
                    cmdInsert.Parameters.AddWithValue("@kode_jurusan", row["Kode_jurusan"]);
                    cmdInsert.ExecuteNonQuery();
                }
                sqlConnection.Close();

                // Hapus semua data dari krs_mahasiswa_sementara setelah disimpan
                sqlConnection.Open();
                SqlCommand cmdDeleteAll = new SqlCommand("DELETE FROM krs_mahasiswa_sementara", sqlConnection);
                cmdDeleteAll.ExecuteNonQuery();
                sqlConnection.Close();

                MessageBox.Show("Semua data berhasil disimpan ke krs_mahasiswa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tampil1();
            tampil2();
        }

        private void Batal_ambil_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>(); // Untuk menyimpan baris yang akan dihapus dari dataGridView2

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                bool select2 = Convert.ToBoolean(row.Cells["checkboxColumn"].Value);
                if (select2)
                {
                    // Simpan data kembali ke dataGridView1 (Jadwal_KRS)
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO Jadwal_krs (Nama_Kelas, Jadwal, Sks, Semester, Kode_jurusan) VALUES (@nama_kelas, @jadwal, @sks, @semester, @kode_jurusan)", sqlConnection);
                    cmdInsert.Parameters.AddWithValue("@nama_kelas", row.Cells["Nama_Kelas"].Value);
                    cmdInsert.Parameters.AddWithValue("@jadwal", row.Cells["Jadwal"].Value);
                    cmdInsert.Parameters.AddWithValue("@sks", row.Cells["Sks"].Value);
                    cmdInsert.Parameters.AddWithValue("@semester", row.Cells["Semester"].Value);
                    cmdInsert.Parameters.AddWithValue("@kode_jurusan", row.Cells["Kode_jurusan"].Value);
                    sqlConnection.Open();
                    cmdInsert.ExecuteNonQuery();
                    sqlConnection.Close();

                    // Tandai baris untuk dihapus setelah loop
                    rowsToRemove.Add(row);
                }
            }

            // Hapus baris yang telah ditandai untuk dihapus dari dataGridView2
            foreach (DataGridViewRow rowToRemove in rowsToRemove)
            {
                // Hapus data dari krs_mahasiswa_sementara
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM krs_mahasiswa_sementara WHERE Nama_Kelas = @nama_kelas", sqlConnection);
                cmdDelete.Parameters.AddWithValue("@nama_kelas", rowToRemove.Cells["Nama_Kelas"].Value);
                sqlConnection.Open();
                cmdDelete.ExecuteNonQuery();
                sqlConnection.Close();

                // Hapus baris dari dataGridView2
                dataGridView2.Rows.Remove(rowToRemove);
            }

            // Refresh tampilan dataGridView1
            tampil1();

            MessageBox.Show("Pembatalan pengambilan mata kuliah berhasil");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
