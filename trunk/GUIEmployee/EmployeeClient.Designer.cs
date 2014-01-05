namespace GUIEmployee
{
    partial class EmployeeClient
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
            this.reservationTab = new System.Windows.Forms.TabPage();
            this.dateTxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.DelResBtn = new System.Windows.Forms.Button();
            this.UpdResBtn = new System.Windows.Forms.Button();
            this.CrtResBtn = new System.Windows.Forms.Button();
            this.statusTxt = new System.Windows.Forms.TextBox();
            this.priceTxt = new System.Windows.Forms.TextBox();
            this.noOfSeatsTxt = new System.Windows.Forms.TextBox();
            this.sessionIdTxt = new System.Windows.Forms.TextBox();
            this.custLNameTxt = new System.Windows.Forms.TextBox();
            this.custFNameTxt = new System.Windows.Forms.TextBox();
            this.rezervationIdTxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gridReservation = new System.Windows.Forms.DataGridView();
            this.customerAdminTab = new System.Windows.Forms.TabPage();
            this.DelCustBtn = new System.Windows.Forms.Button();
            this.UpdCustBtn = new System.Windows.Forms.Button();
            this.CrtCustBtn = new System.Windows.Forms.Button();
            this.gridCustomer = new System.Windows.Forms.DataGridView();
            this.phoneNoTxt = new System.Windows.Forms.TextBox();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.addressTxt = new System.Windows.Forms.TextBox();
            this.cityTxt = new System.Windows.Forms.TextBox();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.lnametxt = new System.Windows.Forms.TextBox();
            this.fnametxt = new System.Windows.Forms.TextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.movieTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.movieIdTxt = new System.Windows.Forms.TextBox();
            this.lenghtTxt = new System.Windows.Forms.TextBox();
            this.genreTxt = new System.Windows.Forms.TextBox();
            this.ageLimitTxt = new System.Windows.Forms.TextBox();
            this.dltMovieBtn = new System.Windows.Forms.Button();
            this.UpdMovieBtn = new System.Windows.Forms.Button();
            this.crtMovieBtn = new System.Windows.Forms.Button();
            this.gridMovie = new System.Windows.Forms.DataGridView();
            this.sessAdminTab = new System.Windows.Forms.TabPage();
            this.gridSession = new System.Windows.Forms.DataGridView();
            this.txtSesId = new System.Windows.Forms.TextBox();
            this.txtSesMovId = new System.Windows.Forms.TextBox();
            this.txtEnterTime = new System.Windows.Forms.TextBox();
            this.txtExitTime = new System.Windows.Forms.TextBox();
            this.txtSesDate = new System.Windows.Forms.TextBox();
            this.txtSesPrice = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnDelSes = new System.Windows.Forms.Button();
            this.brnUpdSes = new System.Windows.Forms.Button();
            this.btnCrtSes = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.reservationTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReservation)).BeginInit();
            this.customerAdminTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomer)).BeginInit();
            this.movieTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovie)).BeginInit();
            this.sessAdminTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSession)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.reservationTab);
            this.tabControl1.Controls.Add(this.customerAdminTab);
            this.tabControl1.Controls.Add(this.movieTab);
            this.tabControl1.Controls.Add(this.sessAdminTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(943, 465);
            this.tabControl1.TabIndex = 0;
            // 
            // reservationTab
            // 
            this.reservationTab.Controls.Add(this.dateTxt);
            this.reservationTab.Controls.Add(this.label13);
            this.reservationTab.Controls.Add(this.DelResBtn);
            this.reservationTab.Controls.Add(this.UpdResBtn);
            this.reservationTab.Controls.Add(this.CrtResBtn);
            this.reservationTab.Controls.Add(this.statusTxt);
            this.reservationTab.Controls.Add(this.priceTxt);
            this.reservationTab.Controls.Add(this.noOfSeatsTxt);
            this.reservationTab.Controls.Add(this.sessionIdTxt);
            this.reservationTab.Controls.Add(this.custLNameTxt);
            this.reservationTab.Controls.Add(this.custFNameTxt);
            this.reservationTab.Controls.Add(this.rezervationIdTxt);
            this.reservationTab.Controls.Add(this.label12);
            this.reservationTab.Controls.Add(this.label11);
            this.reservationTab.Controls.Add(this.label10);
            this.reservationTab.Controls.Add(this.label9);
            this.reservationTab.Controls.Add(this.label8);
            this.reservationTab.Controls.Add(this.label7);
            this.reservationTab.Controls.Add(this.label6);
            this.reservationTab.Controls.Add(this.gridReservation);
            this.reservationTab.Location = new System.Drawing.Point(4, 22);
            this.reservationTab.Name = "reservationTab";
            this.reservationTab.Padding = new System.Windows.Forms.Padding(3);
            this.reservationTab.Size = new System.Drawing.Size(935, 439);
            this.reservationTab.TabIndex = 1;
            this.reservationTab.Text = "Rezervation Admin";
            this.reservationTab.UseVisualStyleBackColor = true;
            // 
            // dateTxt
            // 
            this.dateTxt.Location = new System.Drawing.Point(284, 94);
            this.dateTxt.Name = "dateTxt";
            this.dateTxt.Size = new System.Drawing.Size(100, 20);
            this.dateTxt.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(244, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "date";
            // 
            // DelResBtn
            // 
            this.DelResBtn.Location = new System.Drawing.Point(627, 33);
            this.DelResBtn.Name = "DelResBtn";
            this.DelResBtn.Size = new System.Drawing.Size(120, 50);
            this.DelResBtn.TabIndex = 17;
            this.DelResBtn.Text = "Delete";
            this.DelResBtn.UseVisualStyleBackColor = true;
            // 
            // UpdResBtn
            // 
            this.UpdResBtn.Location = new System.Drawing.Point(470, 70);
            this.UpdResBtn.Name = "UpdResBtn";
            this.UpdResBtn.Size = new System.Drawing.Size(120, 57);
            this.UpdResBtn.TabIndex = 16;
            this.UpdResBtn.Text = "Update";
            this.UpdResBtn.UseVisualStyleBackColor = true;
            // 
            // CrtResBtn
            // 
            this.CrtResBtn.Location = new System.Drawing.Point(470, 4);
            this.CrtResBtn.Name = "CrtResBtn";
            this.CrtResBtn.Size = new System.Drawing.Size(122, 56);
            this.CrtResBtn.TabIndex = 15;
            this.CrtResBtn.Text = "Create";
            this.CrtResBtn.UseVisualStyleBackColor = true;
            // 
            // statusTxt
            // 
            this.statusTxt.Location = new System.Drawing.Point(284, 67);
            this.statusTxt.Name = "statusTxt";
            this.statusTxt.Size = new System.Drawing.Size(100, 20);
            this.statusTxt.TabIndex = 14;
            // 
            // priceTxt
            // 
            this.priceTxt.Location = new System.Drawing.Point(284, 40);
            this.priceTxt.Name = "priceTxt";
            this.priceTxt.Size = new System.Drawing.Size(100, 20);
            this.priceTxt.TabIndex = 13;
            // 
            // noOfSeatsTxt
            // 
            this.noOfSeatsTxt.Location = new System.Drawing.Point(284, 11);
            this.noOfSeatsTxt.Name = "noOfSeatsTxt";
            this.noOfSeatsTxt.Size = new System.Drawing.Size(100, 20);
            this.noOfSeatsTxt.TabIndex = 12;
            // 
            // sessionIdTxt
            // 
            this.sessionIdTxt.Location = new System.Drawing.Point(103, 90);
            this.sessionIdTxt.Name = "sessionIdTxt";
            this.sessionIdTxt.Size = new System.Drawing.Size(100, 20);
            this.sessionIdTxt.TabIndex = 11;
            // 
            // custLNameTxt
            // 
            this.custLNameTxt.Location = new System.Drawing.Point(103, 67);
            this.custLNameTxt.Name = "custLNameTxt";
            this.custLNameTxt.Size = new System.Drawing.Size(100, 20);
            this.custLNameTxt.TabIndex = 10;
            // 
            // custFNameTxt
            // 
            this.custFNameTxt.Location = new System.Drawing.Point(103, 40);
            this.custFNameTxt.Name = "custFNameTxt";
            this.custFNameTxt.Size = new System.Drawing.Size(100, 20);
            this.custFNameTxt.TabIndex = 9;
            // 
            // rezervationIdTxt
            // 
            this.rezervationIdTxt.Location = new System.Drawing.Point(103, 14);
            this.rezervationIdTxt.Name = "rezervationIdTxt";
            this.rezervationIdTxt.Size = new System.Drawing.Size(100, 20);
            this.rezervationIdTxt.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(237, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "status";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(242, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "price";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(219, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "NoOfSeats";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "sessionId";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "custLName";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "custFName";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "rezervationId";
            // 
            // gridReservation
            // 
            this.gridReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReservation.Location = new System.Drawing.Point(3, 137);
            this.gridReservation.Name = "gridReservation";
            this.gridReservation.Size = new System.Drawing.Size(893, 302);
            this.gridReservation.TabIndex = 0;
            this.gridReservation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridReservation_CellClick);
            // 
            // customerAdminTab
            // 
            this.customerAdminTab.Controls.Add(this.DelCustBtn);
            this.customerAdminTab.Controls.Add(this.UpdCustBtn);
            this.customerAdminTab.Controls.Add(this.CrtCustBtn);
            this.customerAdminTab.Controls.Add(this.gridCustomer);
            this.customerAdminTab.Controls.Add(this.phoneNoTxt);
            this.customerAdminTab.Controls.Add(this.emailTxt);
            this.customerAdminTab.Controls.Add(this.addressTxt);
            this.customerAdminTab.Controls.Add(this.cityTxt);
            this.customerAdminTab.Controls.Add(this.usernameTxt);
            this.customerAdminTab.Controls.Add(this.lnametxt);
            this.customerAdminTab.Controls.Add(this.fnametxt);
            this.customerAdminTab.Controls.Add(this.passwordTxt);
            this.customerAdminTab.Controls.Add(this.label21);
            this.customerAdminTab.Controls.Add(this.label20);
            this.customerAdminTab.Controls.Add(this.label19);
            this.customerAdminTab.Controls.Add(this.label18);
            this.customerAdminTab.Controls.Add(this.label17);
            this.customerAdminTab.Controls.Add(this.label16);
            this.customerAdminTab.Controls.Add(this.label15);
            this.customerAdminTab.Controls.Add(this.label14);
            this.customerAdminTab.Location = new System.Drawing.Point(4, 22);
            this.customerAdminTab.Name = "customerAdminTab";
            this.customerAdminTab.Size = new System.Drawing.Size(935, 439);
            this.customerAdminTab.TabIndex = 2;
            this.customerAdminTab.Text = "Customer Admin";
            this.customerAdminTab.UseVisualStyleBackColor = true;
            // 
            // DelCustBtn
            // 
            this.DelCustBtn.Location = new System.Drawing.Point(602, 103);
            this.DelCustBtn.Name = "DelCustBtn";
            this.DelCustBtn.Size = new System.Drawing.Size(135, 51);
            this.DelCustBtn.TabIndex = 19;
            this.DelCustBtn.Text = "Delete";
            this.DelCustBtn.UseVisualStyleBackColor = true;
            // 
            // UpdCustBtn
            // 
            this.UpdCustBtn.Location = new System.Drawing.Point(676, 27);
            this.UpdCustBtn.Name = "UpdCustBtn";
            this.UpdCustBtn.Size = new System.Drawing.Size(155, 55);
            this.UpdCustBtn.TabIndex = 18;
            this.UpdCustBtn.Text = "Update";
            this.UpdCustBtn.UseVisualStyleBackColor = true;
            // 
            // CrtCustBtn
            // 
            this.CrtCustBtn.Location = new System.Drawing.Point(528, 27);
            this.CrtCustBtn.Name = "CrtCustBtn";
            this.CrtCustBtn.Size = new System.Drawing.Size(128, 55);
            this.CrtCustBtn.TabIndex = 17;
            this.CrtCustBtn.Text = "Create";
            this.CrtCustBtn.UseVisualStyleBackColor = true;
            // 
            // gridCustomer
            // 
            this.gridCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomer.Location = new System.Drawing.Point(4, 179);
            this.gridCustomer.Name = "gridCustomer";
            this.gridCustomer.Size = new System.Drawing.Size(928, 257);
            this.gridCustomer.TabIndex = 16;
            this.gridCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCustomer_CellClick);
            // 
            // phoneNoTxt
            // 
            this.phoneNoTxt.Location = new System.Drawing.Point(347, 119);
            this.phoneNoTxt.Name = "phoneNoTxt";
            this.phoneNoTxt.Size = new System.Drawing.Size(100, 20);
            this.phoneNoTxt.TabIndex = 15;
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(347, 93);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(100, 20);
            this.emailTxt.TabIndex = 14;
            // 
            // addressTxt
            // 
            this.addressTxt.Location = new System.Drawing.Point(347, 66);
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(100, 20);
            this.addressTxt.TabIndex = 13;
            // 
            // cityTxt
            // 
            this.cityTxt.Location = new System.Drawing.Point(347, 40);
            this.cityTxt.Name = "cityTxt";
            this.cityTxt.Size = new System.Drawing.Size(100, 20);
            this.cityTxt.TabIndex = 12;
            // 
            // usernameTxt
            // 
            this.usernameTxt.Location = new System.Drawing.Point(107, 93);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(100, 20);
            this.usernameTxt.TabIndex = 11;
            // 
            // lnametxt
            // 
            this.lnametxt.Location = new System.Drawing.Point(107, 67);
            this.lnametxt.Name = "lnametxt";
            this.lnametxt.Size = new System.Drawing.Size(100, 20);
            this.lnametxt.TabIndex = 10;
            // 
            // fnametxt
            // 
            this.fnametxt.Location = new System.Drawing.Point(107, 41);
            this.fnametxt.Name = "fnametxt";
            this.fnametxt.Size = new System.Drawing.Size(100, 20);
            this.fnametxt.TabIndex = 9;
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(107, 119);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(100, 20);
            this.passwordTxt.TabIndex = 8;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(300, 96);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 13);
            this.label21.TabIndex = 7;
            this.label21.Text = "e-mail";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(290, 122);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "phoneNo";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(60, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 5;
            this.label19.Text = "FName";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(60, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "LName";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(46, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "userName";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(297, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "address";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(311, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "city";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(46, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "password";
            // 
            // movieTab
            // 
            this.movieTab.Controls.Add(this.label5);
            this.movieTab.Controls.Add(this.label4);
            this.movieTab.Controls.Add(this.label3);
            this.movieTab.Controls.Add(this.label2);
            this.movieTab.Controls.Add(this.label1);
            this.movieTab.Controls.Add(this.nameTxt);
            this.movieTab.Controls.Add(this.movieIdTxt);
            this.movieTab.Controls.Add(this.lenghtTxt);
            this.movieTab.Controls.Add(this.genreTxt);
            this.movieTab.Controls.Add(this.ageLimitTxt);
            this.movieTab.Controls.Add(this.dltMovieBtn);
            this.movieTab.Controls.Add(this.UpdMovieBtn);
            this.movieTab.Controls.Add(this.crtMovieBtn);
            this.movieTab.Controls.Add(this.gridMovie);
            this.movieTab.Location = new System.Drawing.Point(4, 22);
            this.movieTab.Name = "movieTab";
            this.movieTab.Padding = new System.Windows.Forms.Padding(3);
            this.movieTab.Size = new System.Drawing.Size(935, 439);
            this.movieTab.TabIndex = 0;
            this.movieTab.Text = "Movie Admin";
            this.movieTab.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "MovieId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Lenght";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Genre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "AgeLimit";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(150, 130);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(100, 20);
            this.nameTxt.TabIndex = 8;
            // 
            // movieIdTxt
            // 
            this.movieIdTxt.Location = new System.Drawing.Point(150, 104);
            this.movieIdTxt.Name = "movieIdTxt";
            this.movieIdTxt.Size = new System.Drawing.Size(100, 20);
            this.movieIdTxt.TabIndex = 7;
            // 
            // lenghtTxt
            // 
            this.lenghtTxt.Location = new System.Drawing.Point(150, 78);
            this.lenghtTxt.Name = "lenghtTxt";
            this.lenghtTxt.Size = new System.Drawing.Size(100, 20);
            this.lenghtTxt.TabIndex = 6;
            // 
            // genreTxt
            // 
            this.genreTxt.Location = new System.Drawing.Point(150, 52);
            this.genreTxt.Name = "genreTxt";
            this.genreTxt.Size = new System.Drawing.Size(100, 20);
            this.genreTxt.TabIndex = 5;
            // 
            // ageLimitTxt
            // 
            this.ageLimitTxt.Location = new System.Drawing.Point(150, 26);
            this.ageLimitTxt.Name = "ageLimitTxt";
            this.ageLimitTxt.Size = new System.Drawing.Size(100, 20);
            this.ageLimitTxt.TabIndex = 4;
            // 
            // dltMovieBtn
            // 
            this.dltMovieBtn.Location = new System.Drawing.Point(196, 319);
            this.dltMovieBtn.Name = "dltMovieBtn";
            this.dltMovieBtn.Size = new System.Drawing.Size(169, 101);
            this.dltMovieBtn.TabIndex = 3;
            this.dltMovieBtn.Text = "Delete";
            this.dltMovieBtn.UseVisualStyleBackColor = true;
            // 
            // UpdMovieBtn
            // 
            this.UpdMovieBtn.Location = new System.Drawing.Point(196, 199);
            this.UpdMovieBtn.Name = "UpdMovieBtn";
            this.UpdMovieBtn.Size = new System.Drawing.Size(164, 74);
            this.UpdMovieBtn.TabIndex = 2;
            this.UpdMovieBtn.Text = "Update";
            this.UpdMovieBtn.UseVisualStyleBackColor = true;
            // 
            // crtMovieBtn
            // 
            this.crtMovieBtn.Location = new System.Drawing.Point(19, 261);
            this.crtMovieBtn.Name = "crtMovieBtn";
            this.crtMovieBtn.Size = new System.Drawing.Size(147, 74);
            this.crtMovieBtn.TabIndex = 1;
            this.crtMovieBtn.Text = "Create";
            this.crtMovieBtn.UseVisualStyleBackColor = true;
            // 
            // gridMovie
            // 
            this.gridMovie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMovie.Location = new System.Drawing.Point(387, 6);
            this.gridMovie.Name = "gridMovie";
            this.gridMovie.Size = new System.Drawing.Size(545, 427);
            this.gridMovie.TabIndex = 0;
            this.gridMovie.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMovie_CellClick);
            // 
            // sessAdminTab
            // 
            this.sessAdminTab.Controls.Add(this.gridSession);
            this.sessAdminTab.Controls.Add(this.txtSesId);
            this.sessAdminTab.Controls.Add(this.txtSesMovId);
            this.sessAdminTab.Controls.Add(this.txtEnterTime);
            this.sessAdminTab.Controls.Add(this.txtExitTime);
            this.sessAdminTab.Controls.Add(this.txtSesDate);
            this.sessAdminTab.Controls.Add(this.txtSesPrice);
            this.sessAdminTab.Controls.Add(this.label27);
            this.sessAdminTab.Controls.Add(this.label26);
            this.sessAdminTab.Controls.Add(this.label25);
            this.sessAdminTab.Controls.Add(this.label24);
            this.sessAdminTab.Controls.Add(this.label23);
            this.sessAdminTab.Controls.Add(this.label22);
            this.sessAdminTab.Controls.Add(this.btnDelSes);
            this.sessAdminTab.Controls.Add(this.brnUpdSes);
            this.sessAdminTab.Controls.Add(this.btnCrtSes);
            this.sessAdminTab.Location = new System.Drawing.Point(4, 22);
            this.sessAdminTab.Name = "sessAdminTab";
            this.sessAdminTab.Size = new System.Drawing.Size(935, 439);
            this.sessAdminTab.TabIndex = 4;
            this.sessAdminTab.Text = "Session Admin";
            this.sessAdminTab.UseVisualStyleBackColor = true;
            // 
            // gridSession
            // 
            this.gridSession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSession.Location = new System.Drawing.Point(323, 29);
            this.gridSession.Name = "gridSession";
            this.gridSession.Size = new System.Drawing.Size(604, 224);
            this.gridSession.TabIndex = 15;
            this.gridSession.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSession_CellClick);
            // 
            // txtSesId
            // 
            this.txtSesId.Location = new System.Drawing.Point(110, 29);
            this.txtSesId.Name = "txtSesId";
            this.txtSesId.Size = new System.Drawing.Size(100, 20);
            this.txtSesId.TabIndex = 14;
            // 
            // txtSesMovId
            // 
            this.txtSesMovId.Location = new System.Drawing.Point(110, 55);
            this.txtSesMovId.Name = "txtSesMovId";
            this.txtSesMovId.Size = new System.Drawing.Size(100, 20);
            this.txtSesMovId.TabIndex = 13;
            // 
            // txtEnterTime
            // 
            this.txtEnterTime.Location = new System.Drawing.Point(110, 79);
            this.txtEnterTime.Name = "txtEnterTime";
            this.txtEnterTime.Size = new System.Drawing.Size(100, 20);
            this.txtEnterTime.TabIndex = 12;
            // 
            // txtExitTime
            // 
            this.txtExitTime.Location = new System.Drawing.Point(110, 105);
            this.txtExitTime.Name = "txtExitTime";
            this.txtExitTime.Size = new System.Drawing.Size(100, 20);
            this.txtExitTime.TabIndex = 11;
            // 
            // txtSesDate
            // 
            this.txtSesDate.Location = new System.Drawing.Point(110, 131);
            this.txtSesDate.Name = "txtSesDate";
            this.txtSesDate.Size = new System.Drawing.Size(100, 20);
            this.txtSesDate.TabIndex = 10;
            // 
            // txtSesPrice
            // 
            this.txtSesPrice.Location = new System.Drawing.Point(110, 157);
            this.txtSesPrice.Name = "txtSesPrice";
            this.txtSesPrice.Size = new System.Drawing.Size(100, 20);
            this.txtSesPrice.TabIndex = 9;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(71, 160);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(31, 13);
            this.label27.TabIndex = 8;
            this.label27.Text = "Price";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(74, 134);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(30, 13);
            this.label26.TabIndex = 7;
            this.label26.Text = "Date";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(57, 108);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 13);
            this.label25.TabIndex = 6;
            this.label25.Text = "ExitTime";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(49, 82);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 13);
            this.label24.TabIndex = 5;
            this.label24.Text = "EnterTime";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(57, 58);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(45, 13);
            this.label23.TabIndex = 4;
            this.label23.Text = "MovieId";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(51, 32);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 13);
            this.label22.TabIndex = 3;
            this.label22.Text = "SessionId";
            // 
            // btnDelSes
            // 
            this.btnDelSes.Location = new System.Drawing.Point(213, 290);
            this.btnDelSes.Name = "btnDelSes";
            this.btnDelSes.Size = new System.Drawing.Size(188, 77);
            this.btnDelSes.TabIndex = 2;
            this.btnDelSes.Text = "Delete";
            this.btnDelSes.UseVisualStyleBackColor = true;
            // 
            // brnUpdSes
            // 
            this.brnUpdSes.Location = new System.Drawing.Point(8, 336);
            this.brnUpdSes.Name = "brnUpdSes";
            this.brnUpdSes.Size = new System.Drawing.Size(188, 77);
            this.brnUpdSes.TabIndex = 1;
            this.brnUpdSes.Text = "Update";
            this.brnUpdSes.UseVisualStyleBackColor = true;
            // 
            // btnCrtSes
            // 
            this.btnCrtSes.Location = new System.Drawing.Point(8, 241);
            this.btnCrtSes.Name = "btnCrtSes";
            this.btnCrtSes.Size = new System.Drawing.Size(188, 81);
            this.btnCrtSes.TabIndex = 0;
            this.btnCrtSes.Text = "Create";
            this.btnCrtSes.UseVisualStyleBackColor = true;
            // 
            // EmployeeClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 464);
            this.Controls.Add(this.tabControl1);
            this.Name = "EmployeeClient";
            this.Text = "EmployeeClient";
            this.Load += new System.EventHandler(this.EmployeeClient_Load);
            this.tabControl1.ResumeLayout(false);
            this.reservationTab.ResumeLayout(false);
            this.reservationTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReservation)).EndInit();
            this.customerAdminTab.ResumeLayout(false);
            this.customerAdminTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomer)).EndInit();
            this.movieTab.ResumeLayout(false);
            this.movieTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovie)).EndInit();
            this.sessAdminTab.ResumeLayout(false);
            this.sessAdminTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSession)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage movieTab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.TextBox movieIdTxt;
        private System.Windows.Forms.TextBox lenghtTxt;
        private System.Windows.Forms.TextBox genreTxt;
        private System.Windows.Forms.TextBox ageLimitTxt;
        private System.Windows.Forms.Button dltMovieBtn;
        private System.Windows.Forms.Button UpdMovieBtn;
        private System.Windows.Forms.Button crtMovieBtn;
        private System.Windows.Forms.DataGridView gridMovie;
        private System.Windows.Forms.TabPage reservationTab;
        private System.Windows.Forms.TabPage customerAdminTab;
        private System.Windows.Forms.TabPage sessAdminTab;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView gridReservation;
        private System.Windows.Forms.Button DelResBtn;
        private System.Windows.Forms.Button UpdResBtn;
        private System.Windows.Forms.Button CrtResBtn;
        private System.Windows.Forms.TextBox statusTxt;
        private System.Windows.Forms.TextBox priceTxt;
        private System.Windows.Forms.TextBox noOfSeatsTxt;
        private System.Windows.Forms.TextBox sessionIdTxt;
        private System.Windows.Forms.TextBox custLNameTxt;
        private System.Windows.Forms.TextBox custFNameTxt;
        private System.Windows.Forms.TextBox rezervationIdTxt;
        private System.Windows.Forms.TextBox dateTxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView gridCustomer;
        private System.Windows.Forms.TextBox phoneNoTxt;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.TextBox addressTxt;
        private System.Windows.Forms.TextBox cityTxt;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.TextBox lnametxt;
        private System.Windows.Forms.TextBox fnametxt;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button DelCustBtn;
        private System.Windows.Forms.Button UpdCustBtn;
        private System.Windows.Forms.Button CrtCustBtn;
        private System.Windows.Forms.DataGridView gridSession;
        private System.Windows.Forms.TextBox txtSesId;
        private System.Windows.Forms.TextBox txtSesMovId;
        private System.Windows.Forms.TextBox txtEnterTime;
        private System.Windows.Forms.TextBox txtExitTime;
        private System.Windows.Forms.TextBox txtSesDate;
        private System.Windows.Forms.TextBox txtSesPrice;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnDelSes;
        private System.Windows.Forms.Button brnUpdSes;
        private System.Windows.Forms.Button btnCrtSes;
    }
}