﻿namespace UAS_PBO.Mahasiswa_add
{
    partial class Pengisian_KRS
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Simpan_datagridview1 = new System.Windows.Forms.Button();
            this.Simpan_krs = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Batal_ambil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1100, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(96, 338);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(1100, 150);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Simpan_datagridview1
            // 
            this.Simpan_datagridview1.Location = new System.Drawing.Point(96, 264);
            this.Simpan_datagridview1.Name = "Simpan_datagridview1";
            this.Simpan_datagridview1.Size = new System.Drawing.Size(157, 44);
            this.Simpan_datagridview1.TabIndex = 2;
            this.Simpan_datagridview1.Text = "Simpan";
            this.Simpan_datagridview1.UseVisualStyleBackColor = true;
            this.Simpan_datagridview1.Click += new System.EventHandler(this.Simpan_datagridview1_Click);
            // 
            // Simpan_krs
            // 
            this.Simpan_krs.Location = new System.Drawing.Point(96, 537);
            this.Simpan_krs.Name = "Simpan_krs";
            this.Simpan_krs.Size = new System.Drawing.Size(157, 44);
            this.Simpan_krs.TabIndex = 3;
            this.Simpan_krs.Text = "Simpan KRS";
            this.Simpan_krs.UseVisualStyleBackColor = true;
            this.Simpan_krs.Click += new System.EventHandler(this.Simpan_krs_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(96, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 150);
            this.panel1.TabIndex = 4;
            // 
            // Batal_ambil
            // 
            this.Batal_ambil.Location = new System.Drawing.Point(283, 537);
            this.Batal_ambil.Name = "Batal_ambil";
            this.Batal_ambil.Size = new System.Drawing.Size(157, 44);
            this.Batal_ambil.TabIndex = 6;
            this.Batal_ambil.Text = "Batal";
            this.Batal_ambil.UseVisualStyleBackColor = true;
            this.Batal_ambil.Click += new System.EventHandler(this.Batal_ambil_Click);
            // 
            // Pengisian_KRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.Batal_ambil);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Simpan_krs);
            this.Controls.Add(this.Simpan_datagridview1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "Pengisian_KRS";
            this.Size = new System.Drawing.Size(1240, 488);
            this.Load += new System.EventHandler(this.Pengisian_KRS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button Simpan_datagridview1;
        private System.Windows.Forms.Button Simpan_krs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Batal_ambil;
    }
}
