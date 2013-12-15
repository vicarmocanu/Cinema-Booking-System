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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ManualRzvBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MovOkBtn = new System.Windows.Forms.Button();
            this.lblNrSeats = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ReserveAutoBtn = new System.Windows.Forms.Button();
            this.gridSeats = new System.Windows.Forms.DataGridView();
            this.OkSesBtn = new System.Windows.Forms.Button();
            this.gridSession = new System.Windows.Forms.DataGridView();
            this.OkMovBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sessionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionBindingSource)).BeginInit();
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
            this.tabPage1.Controls.Add(this.ManualRzvBtn);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.MovOkBtn);
            this.tabPage1.Controls.Add(this.lblNrSeats);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.ReserveAutoBtn);
            this.tabPage1.Controls.Add(this.gridSeats);
            this.tabPage1.Controls.Add(this.OkSesBtn);
            this.tabPage1.Controls.Add(this.gridSession);
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
            // ManualRzvBtn
            // 
            this.ManualRzvBtn.Location = new System.Drawing.Point(988, 56);
            this.ManualRzvBtn.Name = "ManualRzvBtn";
            this.ManualRzvBtn.Size = new System.Drawing.Size(75, 23);
            this.ManualRzvBtn.TabIndex = 12;
            this.ManualRzvBtn.Text = "ManualRzv";
            this.ManualRzvBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(918, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Rezervation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(790, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Seats";
            // 
            // MovOkBtn
            // 
            this.MovOkBtn.Location = new System.Drawing.Point(830, 119);
            this.MovOkBtn.Name = "MovOkBtn";
            this.MovOkBtn.Size = new System.Drawing.Size(75, 23);
            this.MovOkBtn.TabIndex = 9;
            this.MovOkBtn.Text = "Ok";
            this.MovOkBtn.UseVisualStyleBackColor = true;
            this.MovOkBtn.Click += new System.EventHandler(this.button1_Click);
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
            // ReserveAutoBtn
            // 
            this.ReserveAutoBtn.Location = new System.Drawing.Point(1094, 20);
            this.ReserveAutoBtn.Name = "ReserveAutoBtn";
            this.ReserveAutoBtn.Size = new System.Drawing.Size(75, 23);
            this.ReserveAutoBtn.TabIndex = 1;
            this.ReserveAutoBtn.Text = "AutomaticRzv";
            this.ReserveAutoBtn.UseVisualStyleBackColor = true;
            // 
            // gridSeats
            // 
            this.gridSeats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSeats.Location = new System.Drawing.Point(804, 148);
            this.gridSeats.Name = "gridSeats";
            this.gridSeats.Size = new System.Drawing.Size(444, 284);
            this.gridSeats.TabIndex = 6;
            this.gridSeats.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSeats_CellContentClick);
            // 
            // OkSesBtn
            // 
            this.OkSesBtn.Location = new System.Drawing.Point(85, 119);
            this.OkSesBtn.Name = "OkSesBtn";
            this.OkSesBtn.Size = new System.Drawing.Size(45, 23);
            this.OkSesBtn.TabIndex = 5;
            this.OkSesBtn.Text = "Ok";
            this.OkSesBtn.UseVisualStyleBackColor = true;
            this.OkSesBtn.Click += new System.EventHandler(this.OkSesBtn_Click);
            // 
            // gridSession
            // 
            this.gridSession.AllowUserToOrderColumns = true;
            this.gridSession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSession.Location = new System.Drawing.Point(33, 148);
            this.gridSession.Name = "gridSession";
            this.gridSession.Size = new System.Drawing.Size(644, 336);
            this.gridSession.TabIndex = 4;
            this.gridSession.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSession_CellContentClick);
            // 
            // OkMovBtn
            // 
            this.OkMovBtn.Location = new System.Drawing.Point(184, 33);
            this.OkMovBtn.Name = "OkMovBtn";
            this.OkMovBtn.Size = new System.Drawing.Size(35, 21);
            this.OkMovBtn.TabIndex = 3;
            this.OkMovBtn.Text = "Ok";
            this.OkMovBtn.UseVisualStyleBackColor = true;
            this.OkMovBtn.Click += new System.EventHandler(this.OkMovBtn_Click);
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
            this.listBox1.Size = new System.Drawing.Size(129, 82);
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
            // sessionBindingSource
            // 
            this.sessionBindingSource.DataSource = typeof(GUIClient.SessionSrv.Session);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridSeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gridSeats;
        private System.Windows.Forms.Button OkSesBtn;
        private System.Windows.Forms.DataGridView gridSession;
        private System.Windows.Forms.Button OkMovBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ReserveAutoBtn;
        private System.Windows.Forms.Label lblNrSeats;
        private System.Windows.Forms.Button MovOkBtn;
        private System.Windows.Forms.Button ManualRzvBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource sessionBindingSource;
    }
}