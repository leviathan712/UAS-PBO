namespace UAS_PBO.Mahasiswa_add
{
    partial class Riwayat_krs
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Riwayat_krs));
            this.panel_print_KRS = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Program_studi = new System.Windows.Forms.Label();
            this.Nama = new System.Windows.Forms.Label();
            this.NIM = new System.Windows.Forms.Label();
            this.Semester = new System.Windows.Forms.Label();
            this.Tahun_ajaran = new System.Windows.Forms.Label();
            this.label_program_studi = new System.Windows.Forms.Label();
            this.label_nama = new System.Windows.Forms.Label();
            this.label_nim = new System.Windows.Forms.Label();
            this.label_semester = new System.Windows.Forms.Label();
            this.label_tahun_ajar = new System.Windows.Forms.Label();
            this.label_KRS = new System.Windows.Forms.Label();
            this.LOGO = new System.Windows.Forms.PictureBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.Print = new System.Windows.Forms.Label();
            this.print_krs = new System.Windows.Forms.PictureBox();
            this.panel_print_KRS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOGO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.print_krs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_print_KRS
            // 
            this.panel_print_KRS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_print_KRS.Controls.Add(this.dataGridView1);
            this.panel_print_KRS.Controls.Add(this.Program_studi);
            this.panel_print_KRS.Controls.Add(this.Nama);
            this.panel_print_KRS.Controls.Add(this.NIM);
            this.panel_print_KRS.Controls.Add(this.Semester);
            this.panel_print_KRS.Controls.Add(this.Tahun_ajaran);
            this.panel_print_KRS.Controls.Add(this.label_program_studi);
            this.panel_print_KRS.Controls.Add(this.label_nama);
            this.panel_print_KRS.Controls.Add(this.label_nim);
            this.panel_print_KRS.Controls.Add(this.label_semester);
            this.panel_print_KRS.Controls.Add(this.label_tahun_ajar);
            this.panel_print_KRS.Controls.Add(this.label_KRS);
            this.panel_print_KRS.Controls.Add(this.LOGO);
            this.panel_print_KRS.Location = new System.Drawing.Point(3, 103);
            this.panel_print_KRS.Name = "panel_print_KRS";
            this.panel_print_KRS.Size = new System.Drawing.Size(1088, 1000);
            this.panel_print_KRS.TabIndex = 0;
            this.panel_print_KRS.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_print_KRS_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(41, 581);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(722, 234);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Program_studi
            // 
            this.Program_studi.AutoSize = true;
            this.Program_studi.Location = new System.Drawing.Point(292, 451);
            this.Program_studi.Name = "Program_studi";
            this.Program_studi.Size = new System.Drawing.Size(41, 13);
            this.Program_studi.TabIndex = 11;
            this.Program_studi.Text = "label11";
            // 
            // Nama
            // 
            this.Nama.AutoSize = true;
            this.Nama.Location = new System.Drawing.Point(292, 424);
            this.Nama.Name = "Nama";
            this.Nama.Size = new System.Drawing.Size(41, 13);
            this.Nama.TabIndex = 10;
            this.Nama.Text = "label10";
            // 
            // NIM
            // 
            this.NIM.AutoSize = true;
            this.NIM.Location = new System.Drawing.Point(292, 399);
            this.NIM.Name = "NIM";
            this.NIM.Size = new System.Drawing.Size(35, 13);
            this.NIM.TabIndex = 9;
            this.NIM.Text = "label9";
            // 
            // Semester
            // 
            this.Semester.AutoSize = true;
            this.Semester.Location = new System.Drawing.Point(292, 375);
            this.Semester.Name = "Semester";
            this.Semester.Size = new System.Drawing.Size(35, 13);
            this.Semester.TabIndex = 8;
            this.Semester.Text = "label8";
            // 
            // Tahun_ajaran
            // 
            this.Tahun_ajaran.AutoSize = true;
            this.Tahun_ajaran.Location = new System.Drawing.Point(292, 351);
            this.Tahun_ajaran.Name = "Tahun_ajaran";
            this.Tahun_ajaran.Size = new System.Drawing.Size(35, 13);
            this.Tahun_ajaran.TabIndex = 7;
            this.Tahun_ajaran.Text = "label7";
            // 
            // label_program_studi
            // 
            this.label_program_studi.AutoSize = true;
            this.label_program_studi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_program_studi.Location = new System.Drawing.Point(38, 449);
            this.label_program_studi.Name = "label_program_studi";
            this.label_program_studi.Size = new System.Drawing.Size(121, 15);
            this.label_program_studi.TabIndex = 6;
            this.label_program_studi.Text = "PROGRAM STUDI";
            // 
            // label_nama
            // 
            this.label_nama.AutoSize = true;
            this.label_nama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_nama.Location = new System.Drawing.Point(38, 422);
            this.label_nama.Name = "label_nama";
            this.label_nama.Size = new System.Drawing.Size(129, 15);
            this.label_nama.TabIndex = 5;
            this.label_nama.Text = "NAMA MAHASISWA";
            // 
            // label_nim
            // 
            this.label_nim.AutoSize = true;
            this.label_nim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_nim.Location = new System.Drawing.Point(38, 397);
            this.label_nim.Name = "label_nim";
            this.label_nim.Size = new System.Drawing.Size(33, 15);
            this.label_nim.TabIndex = 4;
            this.label_nim.Text = "NIM";
            // 
            // label_semester
            // 
            this.label_semester.AutoSize = true;
            this.label_semester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_semester.Location = new System.Drawing.Point(38, 373);
            this.label_semester.Name = "label_semester";
            this.label_semester.Size = new System.Drawing.Size(82, 15);
            this.label_semester.TabIndex = 3;
            this.label_semester.Text = "SEMESTER";
            // 
            // label_tahun_ajar
            // 
            this.label_tahun_ajar.AutoSize = true;
            this.label_tahun_ajar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tahun_ajar.Location = new System.Drawing.Point(38, 349);
            this.label_tahun_ajar.Name = "label_tahun_ajar";
            this.label_tahun_ajar.Size = new System.Drawing.Size(108, 15);
            this.label_tahun_ajar.TabIndex = 2;
            this.label_tahun_ajar.Text = "TAHUN AJARAN";
            // 
            // label_KRS
            // 
            this.label_KRS.AutoSize = true;
            this.label_KRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_KRS.Location = new System.Drawing.Point(217, 249);
            this.label_KRS.Name = "label_KRS";
            this.label_KRS.Size = new System.Drawing.Size(365, 29);
            this.label_KRS.TabIndex = 1;
            this.label_KRS.Text = "KARTU RENCANA STUDI (KRS)";
            // 
            // LOGO
            // 
            this.LOGO.Image = ((System.Drawing.Image)(resources.GetObject("LOGO.Image")));
            this.LOGO.Location = new System.Drawing.Point(23, 82);
            this.LOGO.Name = "LOGO";
            this.LOGO.Size = new System.Drawing.Size(389, 84);
            this.LOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LOGO.TabIndex = 0;
            this.LOGO.TabStop = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Print
            // 
            this.Print.AutoSize = true;
            this.Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print.Location = new System.Drawing.Point(940, 1124);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(0, 13);
            this.Print.TabIndex = 2;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // print_krs
            // 
            this.print_krs.Image = ((System.Drawing.Image)(resources.GetObject("print_krs.Image")));
            this.print_krs.Location = new System.Drawing.Point(870, 68);
            this.print_krs.Name = "print_krs";
            this.print_krs.Size = new System.Drawing.Size(35, 29);
            this.print_krs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.print_krs.TabIndex = 3;
            this.print_krs.TabStop = false;
            this.print_krs.Click += new System.EventHandler(this.print_krs_Click);
            // 
            // Riwayat_krs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.print_krs);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.panel_print_KRS);
            this.Name = "Riwayat_krs";
            this.Size = new System.Drawing.Size(1104, 533);
            this.Load += new System.EventHandler(this.Riwayat_krs_Load);
            this.panel_print_KRS.ResumeLayout(false);
            this.panel_print_KRS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOGO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.print_krs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_print_KRS;
        private System.Windows.Forms.PictureBox LOGO;
        private System.Windows.Forms.Label label_semester;
        private System.Windows.Forms.Label label_tahun_ajar;
        private System.Windows.Forms.Label label_KRS;
        private System.Windows.Forms.Label label_nama;
        private System.Windows.Forms.Label label_nim;
        private System.Windows.Forms.Label Program_studi;
        private System.Windows.Forms.Label Nama;
        private System.Windows.Forms.Label NIM;
        private System.Windows.Forms.Label Semester;
        private System.Windows.Forms.Label Tahun_ajaran;
        private System.Windows.Forms.Label label_program_studi;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label Print;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox print_krs;
    }
}
