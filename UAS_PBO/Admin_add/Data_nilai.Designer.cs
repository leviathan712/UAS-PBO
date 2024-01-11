namespace UAS_PBO.Admin_add
{
    partial class Data_nilai
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
            this.dataGridView_Mahasiswa = new System.Windows.Forms.DataGridView();
            this.dataGridView_Nilai_mahasiswa = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Input_nilai = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Kode_mk = new System.Windows.Forms.TextBox();
            this.textBox_Nama_mk = new System.Windows.Forms.TextBox();
            this.textBox_Nilai_uas = new System.Windows.Forms.TextBox();
            this.textBox_Nilai_uts = new System.Windows.Forms.TextBox();
            this.textBox_Nilai_tugas_individu = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Mahasiswa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Nilai_mahasiswa)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Mahasiswa
            // 
            this.dataGridView_Mahasiswa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Mahasiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Mahasiswa.Location = new System.Drawing.Point(75, 78);
            this.dataGridView_Mahasiswa.Name = "dataGridView_Mahasiswa";
            this.dataGridView_Mahasiswa.Size = new System.Drawing.Size(979, 211);
            this.dataGridView_Mahasiswa.TabIndex = 0;
            this.dataGridView_Mahasiswa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Mahasiswa_CellContentClick);
            // 
            // dataGridView_Nilai_mahasiswa
            // 
            this.dataGridView_Nilai_mahasiswa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Nilai_mahasiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Nilai_mahasiswa.Location = new System.Drawing.Point(75, 371);
            this.dataGridView_Nilai_mahasiswa.Name = "dataGridView_Nilai_mahasiswa";
            this.dataGridView_Nilai_mahasiswa.Size = new System.Drawing.Size(979, 237);
            this.dataGridView_Nilai_mahasiswa.TabIndex = 1;
            this.dataGridView_Nilai_mahasiswa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Nilai_mahasiswa_CellClick);
            this.dataGridView_Nilai_mahasiswa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Nilai_mahasiswa_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 659);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kode Mata Kuliah";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 701);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nama Mata Kuliah";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 659);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nilai UAS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 702);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nilai UTS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(625, 659);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nilai Tugas Individu";
            // 
            // button_Input_nilai
            // 
            this.button_Input_nilai.Location = new System.Drawing.Point(75, 781);
            this.button_Input_nilai.Name = "button_Input_nilai";
            this.button_Input_nilai.Size = new System.Drawing.Size(100, 30);
            this.button_Input_nilai.TabIndex = 8;
            this.button_Input_nilai.Text = "Input Nilai ";
            this.button_Input_nilai.UseVisualStyleBackColor = true;
            this.button_Input_nilai.Click += new System.EventHandler(this.button_Edit_nilai_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(860, 903);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 9;
            // 
            // textBox_Kode_mk
            // 
            this.textBox_Kode_mk.Location = new System.Drawing.Point(190, 652);
            this.textBox_Kode_mk.Name = "textBox_Kode_mk";
            this.textBox_Kode_mk.Size = new System.Drawing.Size(174, 20);
            this.textBox_Kode_mk.TabIndex = 10;
            // 
            // textBox_Nama_mk
            // 
            this.textBox_Nama_mk.Location = new System.Drawing.Point(190, 694);
            this.textBox_Nama_mk.Name = "textBox_Nama_mk";
            this.textBox_Nama_mk.Size = new System.Drawing.Size(174, 20);
            this.textBox_Nama_mk.TabIndex = 11;
            // 
            // textBox_Nilai_uas
            // 
            this.textBox_Nilai_uas.Location = new System.Drawing.Point(494, 655);
            this.textBox_Nilai_uas.Name = "textBox_Nilai_uas";
            this.textBox_Nilai_uas.Size = new System.Drawing.Size(56, 20);
            this.textBox_Nilai_uas.TabIndex = 12;
            // 
            // textBox_Nilai_uts
            // 
            this.textBox_Nilai_uts.Location = new System.Drawing.Point(494, 695);
            this.textBox_Nilai_uts.Name = "textBox_Nilai_uts";
            this.textBox_Nilai_uts.Size = new System.Drawing.Size(56, 20);
            this.textBox_Nilai_uts.TabIndex = 13;
            // 
            // textBox_Nilai_tugas_individu
            // 
            this.textBox_Nilai_tugas_individu.Location = new System.Drawing.Point(782, 652);
            this.textBox_Nilai_tugas_individu.Name = "textBox_Nilai_tugas_individu";
            this.textBox_Nilai_tugas_individu.Size = new System.Drawing.Size(57, 20);
            this.textBox_Nilai_tugas_individu.TabIndex = 14;
            // 
            // Data_nilai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.textBox_Nilai_tugas_individu);
            this.Controls.Add(this.textBox_Nilai_uts);
            this.Controls.Add(this.textBox_Nilai_uas);
            this.Controls.Add(this.textBox_Nama_mk);
            this.Controls.Add(this.textBox_Kode_mk);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_Input_nilai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Nilai_mahasiswa);
            this.Controls.Add(this.dataGridView_Mahasiswa);
            this.Name = "Data_nilai";
            this.Size = new System.Drawing.Size(1138, 448);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Mahasiswa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Nilai_mahasiswa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Mahasiswa;
        private System.Windows.Forms.DataGridView dataGridView_Nilai_mahasiswa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Input_nilai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Kode_mk;
        private System.Windows.Forms.TextBox textBox_Nama_mk;
        private System.Windows.Forms.TextBox textBox_Nilai_uas;
        private System.Windows.Forms.TextBox textBox_Nilai_uts;
        private System.Windows.Forms.TextBox textBox_Nilai_tugas_individu;
    }
}
