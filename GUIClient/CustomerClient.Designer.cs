namespace GUIClient
{
    partial class CustomerClient
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblNrSeats = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ReserveBtn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.OkSesBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OkMovBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1259, 519);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblNrSeats);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.ReserveBtn);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Controls.Add(this.OkSesBtn);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.OkMovBtn);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1251, 493);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Number Seats";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblNrSeats
            // 
            this.lblNrSeats.AutoSize = true;
            this.lblNrSeats.Location = new System.Drawing.Point(908, 26);
            this.lblNrSeats.Name = "lblNrSeats";
            this.lblNrSeats.Size = new System.Drawing.Size(74, 13);
            this.lblNrSeats.TabIndex = 8;
            this.lblNrSeats.Text = "Number Seats";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(988, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // ReserveBtn
            // 
            this.ReserveBtn.Location = new System.Drawing.Point(1094, 20);
            this.ReserveBtn.Name = "ReserveBtn";
            this.ReserveBtn.Size = new System.Drawing.Size(75, 23);
            this.ReserveBtn.TabIndex = 1;
            this.ReserveBtn.Text = "Reserve";
            this.ReserveBtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(783, 148);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(444, 336);
            this.dataGridView2.TabIndex = 6;
            // 
            // OkSesBtn
            // 
            this.OkSesBtn.Location = new System.Drawing.Point(85, 119);
            this.OkSesBtn.Name = "OkSesBtn";
            this.OkSesBtn.Size = new System.Drawing.Size(45, 23);
            this.OkSesBtn.TabIndex = 5;
            this.OkSesBtn.Text = "Ok";
            this.OkSesBtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 336);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // OkMovBtn
            // 
            this.OkMovBtn.Location = new System.Drawing.Point(177, 6);
            this.OkMovBtn.Name = "OkMovBtn";
            this.OkMovBtn.Size = new System.Drawing.Size(35, 21);
            this.OkMovBtn.TabIndex = 3;
            this.OkMovBtn.Text = "Ok";
            this.OkMovBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sessions";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(49, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(648, 82);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movie";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CustomerClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 518);
            this.Controls.Add(this.tabControl1);
            this.Name = "CustomerClient";
            this.Text = "CustomerClient";
            this.Load += new System.EventHandler(this.CustomerClient_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button OkSesBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button OkMovBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ReserveBtn;
        private System.Windows.Forms.Label lblNrSeats;
    }
}