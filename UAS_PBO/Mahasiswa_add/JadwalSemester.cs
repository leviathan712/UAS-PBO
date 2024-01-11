using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS_PBO.Mahasiswa_add
{
    public partial class JadwalSemester : UserControl
    {
        String connectionString = "Data Source=DESKTOP-FVAV4PC\\SQLEXPRESS;Initial Catalog=PBO;Integrated Security=True;Encrypt=False";
        public JadwalSemester()
        {
            InitializeComponent();
        }

        private void JadwalSemester_Load(object sender, EventArgs e)
        {
            Tampilkandatajadwalsemester();
        }
        private void Tampilkandatajadwalsemester()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Guna2DataGridView dataGridView = new Guna2DataGridView();
                dataGridView.Width = 862; // Atur lebar DataGridView
                dataGridView.Height = 300; // Atur tinggi DataGridView
                dataGridView.Left = 20; // Atur posisi horizontal DataGridView
                this.Controls.Add(dataGridView);

                // Buat DataTable untuk menampung data dari database
                DataTable dataTable = new DataTable();
                string query = "SELECT Hari,Mulai,Selesai,Jenis,Kuliah,Materi,Ruang,Pengajar FROM Perkuliahan";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Baca data menggunakan SqlDataAdapter
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Isi data ke DataTable
                        adapter.Fill(dataTable);
                    }
                }
                dataGridView.DataSource = dataTable;
            }
        }
    }
}
