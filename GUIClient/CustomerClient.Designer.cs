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
            this.label3 = new System.Windows.Forms.Label();
            this.lblNrSeats = new System.Windows.Forms.Label();
            this.noOfSeatsTxt = new System.Windows.Forms.TextBox();
            this.ReserveAutoBtn = new System.Windows.Forms.Button();
            this.gridSeats = new System.Windows.Forms.DataGridView();
            this.OkSesBtn = new System.Windows.Forms.Button();
            this.gridSession = new System.Windows.Forms.DataGridView();
            this.OkMovBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLogOut = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSession)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1101, 519);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblLogOut);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lblNrSeats);
            this.tabPage1.Controls.Add(this.noOfSeatsTxt);
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
            this.tabPage1.Size = new System.Drawing.Size(1093, 493);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Number Seats";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            // 
            // lblNrSeats
            // 
            this.lblNrSeats.AutoSize = true;
            this.lblNrSeats.Location = new System.Drawing.Point(647, 119);
            this.lblNrSeats.Name = "lblNrSeats";
            this.lblNrSeats.Size = new System.Drawing.Size(74, 13);
            this.lblNrSeats.TabIndex = 8;
            this.lblNrSeats.Text = "Number Seats";
            // 
            // noOfSeatsTxt
            // 
            this.noOfSeatsTxt.Location = new System.Drawing.Point(727, 114);
            this.noOfSeatsTxt.Name = "noOfSeatsTxt";
            this.noOfSeatsTxt.Size = new System.Drawing.Size(100, 20);
            this.noOfSeatsTxt.TabIndex = 7;
            // 
            // ReserveAutoBtn
            // 
            this.ReserveAutoBtn.Location = new System.Drawing.Point(833, 111);
            this.ReserveAutoBtn.Name = "ReserveAutoBtn";
            this.ReserveAutoBtn.Size = new System.Drawing.Size(75, 23);
            this.ReserveAutoBtn.TabIndex = 1;
            this.ReserveAutoBtn.Text = "AutomaticRzv";
            this.ReserveAutoBtn.UseVisualStyleBackColor = true;
            this.ReserveAutoBtn.Click += new System.EventHandler(this.ReserveAutoBtn_Click);
            // 
            // gridSeats
            // 
            this.gridSeats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSeats.Location = new System.Drawing.Point(650, 145);
            this.gridSeats.Name = "gridSeats";
            this.gridSeats.Size = new System.Drawing.Size(444, 348);
            this.gridSeats.TabIndex = 6;
            // 
            // OkSesBtn
            // 
            this.OkSesBtn.Location = new System.Drawing.Point(565, 114);
            this.OkSesBtn.Name = "OkSesBtn";
            this.OkSesBtn.Size = new System.Drawing.Size(45, 23);
            this.OkSesBtn.TabIndex = 5;
            this.OkSesBtn.Text = "Set";
            this.OkSesBtn.UseVisualStyleBackColor = true;
            this.OkSesBtn.Click += new System.EventHandler(this.OkSesBtn_Click);
            // 
            // gridSession
            // 
            this.gridSession.AllowUserToOrderColumns = true;
            this.gridSession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSession.Location = new System.Drawing.Point(0, 145);
            this.gridSession.Name = "gridSession";
            this.gridSession.Size = new System.Drawing.Size(644, 348);
            this.gridSession.TabIndex = 4;
            this.gridSession.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSession_CellClick);
            // 
            // OkMovBtn
            // 
            this.OkMovBtn.Location = new System.Drawing.Point(184, 33);
            this.OkMovBtn.Name = "OkMovBtn";
            this.OkMovBtn.Size = new System.Drawing.Size(35, 21);
            this.OkMovBtn.TabIndex = 3;
            this.OkMovBtn.Text = "Set";
            this.OkMovBtn.UseVisualStyleBackColor = true;
            this.OkMovBtn.Click += new System.EventHandler(this.OkMovBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 119);
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
            // 
            // lblLogOut
            // 
            this.lblLogOut.AutoSize = true;
            this.lblLogOut.Location = new System.Drawing.Point(1055, 3);
            this.lblLogOut.Name = "lblLogOut";
            this.lblLogOut.Size = new System.Drawing.Size(35, 13);
            this.lblLogOut.TabIndex = 10;
            this.lblLogOut.Text = "label4";
            this.lblLogOut.Click += new System.EventHandler(this.lblLogOut_Click);
            // 
            // CustomerClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 518);
            this.Controls.Add(this.tabControl1);
            this.Name = "CustomerClient";
            this.Text = "CustomerClient";
            this.Load += new System.EventHandler(this.CustomerClient_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSession)).EndInit();
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
        private System.Windows.Forms.TextBox noOfSeatsTxt;
        private System.Windows.Forms.Button ReserveAutoBtn;
        private System.Windows.Forms.Label lblNrSeats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLogOut;
    }
}