namespace Cortex
{
    partial class Form_Main
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
            this.Pnl_Header = new System.Windows.Forms.Panel();
            this.Txt_Search = new System.Windows.Forms.TextBox();
            this.Btn_Back = new System.Windows.Forms.Button();
            this.Btn_Forward = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Pnl_ToolBar = new System.Windows.Forms.Panel();
            this.Btn_New_Folder = new System.Windows.Forms.Button();
            this.Btn_Duplicate = new System.Windows.Forms.Button();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.Btn_Rename = new System.Windows.Forms.Button();
            this.Btn_Cut = new System.Windows.Forms.Button();
            this.Btn_Paste = new System.Windows.Forms.Button();
            this.Btn_Copy = new System.Windows.Forms.Button();
            this.Btn_New_File = new System.Windows.Forms.Button();
            this.Pnl_SideBar = new System.Windows.Forms.Panel();
            this.Pnl_Drives = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Thread_monitor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Videos = new System.Windows.Forms.Button();
            this.Btn_Music = new System.Windows.Forms.Button();
            this.Btn_Pictures = new System.Windows.Forms.Button();
            this.Btn_Documents = new System.Windows.Forms.Button();
            this.Btn_Download = new System.Windows.Forms.Button();
            this.Btn_Desktop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Pnl_Content = new System.Windows.Forms.Panel();
            this.Lvw_Content = new System.Windows.Forms.ListView();
            this.Clm_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Clm_Date_Modified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Clm_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Clm_Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Clm_Attributes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Pnl_Header.SuspendLayout();
            this.Pnl_ToolBar.SuspendLayout();
            this.Pnl_SideBar.SuspendLayout();
            this.Pnl_Content.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pnl_Header
            // 
            this.Pnl_Header.Controls.Add(this.Txt_Search);
            this.Pnl_Header.Controls.Add(this.Btn_Back);
            this.Pnl_Header.Controls.Add(this.Btn_Forward);
            this.Pnl_Header.Controls.Add(this.label2);
            this.Pnl_Header.Controls.Add(this.label1);
            this.Pnl_Header.Location = new System.Drawing.Point(13, 13);
            this.Pnl_Header.Name = "Pnl_Header";
            this.Pnl_Header.Size = new System.Drawing.Size(1394, 50);
            this.Pnl_Header.TabIndex = 0;
            // 
            // Txt_Search
            // 
            this.Txt_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.Txt_Search.Font = new System.Drawing.Font("Segoe UI Semibold", 7.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(237)))));
            this.Txt_Search.Location = new System.Drawing.Point(131, 15);
            this.Txt_Search.Name = "Txt_Search";
            this.Txt_Search.Size = new System.Drawing.Size(998, 24);
            this.Txt_Search.TabIndex = 3;
            // 
            // Btn_Back
            // 
            this.Btn_Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Back.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(237)))));
            this.Btn_Back.Location = new System.Drawing.Point(17, 3);
            this.Btn_Back.Name = "Btn_Back";
            this.Btn_Back.Size = new System.Drawing.Size(43, 43);
            this.Btn_Back.TabIndex = 1;
            this.Btn_Back.Text = "❮ ";
            this.Btn_Back.UseVisualStyleBackColor = false;
            this.Btn_Back.Click += new System.EventHandler(this.Btn_Back_Click);
            // 
            // Btn_Forward
            // 
            this.Btn_Forward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Forward.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Forward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(237)))));
            this.Btn_Forward.Location = new System.Drawing.Point(66, 3);
            this.Btn_Forward.Name = "Btn_Forward";
            this.Btn_Forward.Size = new System.Drawing.Size(44, 43);
            this.Btn_Forward.TabIndex = 0;
            this.Btn_Forward.Text = "❯";
            this.Btn_Forward.UseVisualStyleBackColor = false;
            this.Btn_Forward.Click += new System.EventHandler(this.Btn_Forward_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(235)))), ((int)(((byte)(145)))));
            this.label2.Location = new System.Drawing.Point(1135, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "CORTEX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(221)))), ((int)(((byte)(217)))));
            this.label1.Location = new System.Drawing.Point(1235, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Manager";
            // 
            // Pnl_ToolBar
            // 
            this.Pnl_ToolBar.Controls.Add(this.Btn_New_Folder);
            this.Pnl_ToolBar.Controls.Add(this.Btn_Duplicate);
            this.Pnl_ToolBar.Controls.Add(this.Btn_Delete);
            this.Pnl_ToolBar.Controls.Add(this.Btn_Rename);
            this.Pnl_ToolBar.Controls.Add(this.Btn_Cut);
            this.Pnl_ToolBar.Controls.Add(this.Btn_Paste);
            this.Pnl_ToolBar.Controls.Add(this.Btn_Copy);
            this.Pnl_ToolBar.Controls.Add(this.Btn_New_File);
            this.Pnl_ToolBar.Location = new System.Drawing.Point(12, 69);
            this.Pnl_ToolBar.Name = "Pnl_ToolBar";
            this.Pnl_ToolBar.Size = new System.Drawing.Size(1394, 38);
            this.Pnl_ToolBar.TabIndex = 1;
            // 
            // Btn_New_Folder
            // 
            this.Btn_New_Folder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_New_Folder.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_New_Folder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(237)))));
            this.Btn_New_Folder.Location = new System.Drawing.Point(117, 3);
            this.Btn_New_Folder.Name = "Btn_New_Folder";
            this.Btn_New_Folder.Size = new System.Drawing.Size(118, 32);
            this.Btn_New_Folder.TabIndex = 7;
            this.Btn_New_Folder.Text = "＋  New Folder";
            this.Btn_New_Folder.UseVisualStyleBackColor = false;
            // 
            // Btn_Duplicate
            // 
            this.Btn_Duplicate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Duplicate.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Duplicate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(237)))));
            this.Btn_Duplicate.Location = new System.Drawing.Point(671, 3);
            this.Btn_Duplicate.Name = "Btn_Duplicate";
            this.Btn_Duplicate.Size = new System.Drawing.Size(107, 32);
            this.Btn_Duplicate.TabIndex = 6;
            this.Btn_Duplicate.Text = "⧉ Duplicate";
            this.Btn_Duplicate.UseVisualStyleBackColor = false;
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Delete.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(237)))));
            this.Btn_Delete.Location = new System.Drawing.Point(576, 3);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(89, 32);
            this.Btn_Delete.TabIndex = 5;
            this.Btn_Delete.Text = "✖ Delete";
            this.Btn_Delete.UseVisualStyleBackColor = false;
            // 
            // Btn_Rename
            // 
            this.Btn_Rename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Rename.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Rename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(237)))));
            this.Btn_Rename.Location = new System.Drawing.Point(484, 3);
            this.Btn_Rename.Name = "Btn_Rename";
            this.Btn_Rename.Size = new System.Drawing.Size(86, 32);
            this.Btn_Rename.TabIndex = 4;
            this.Btn_Rename.Text = "✎ Rename";
            this.Btn_Rename.UseVisualStyleBackColor = false;
            // 
            // Btn_Cut
            // 
            this.Btn_Cut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Cut.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(237)))));
            this.Btn_Cut.Location = new System.Drawing.Point(403, 3);
            this.Btn_Cut.Name = "Btn_Cut";
            this.Btn_Cut.Size = new System.Drawing.Size(75, 32);
            this.Btn_Cut.TabIndex = 3;
            this.Btn_Cut.Text = "✂ Cut";
            this.Btn_Cut.UseVisualStyleBackColor = false;
            // 
            // Btn_Paste
            // 
            this.Btn_Paste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Paste.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Paste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(237)))));
            this.Btn_Paste.Location = new System.Drawing.Point(322, 3);
            this.Btn_Paste.Name = "Btn_Paste";
            this.Btn_Paste.Size = new System.Drawing.Size(75, 32);
            this.Btn_Paste.TabIndex = 2;
            this.Btn_Paste.Text = "▣ Paste";
            this.Btn_Paste.UseVisualStyleBackColor = false;
            // 
            // Btn_Copy
            // 
            this.Btn_Copy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Copy.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Copy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(237)))));
            this.Btn_Copy.Location = new System.Drawing.Point(241, 3);
            this.Btn_Copy.Name = "Btn_Copy";
            this.Btn_Copy.Size = new System.Drawing.Size(75, 32);
            this.Btn_Copy.TabIndex = 1;
            this.Btn_Copy.Text = "▢   Copy";
            this.Btn_Copy.UseVisualStyleBackColor = false;
            // 
            // Btn_New_File
            // 
            this.Btn_New_File.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_New_File.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_New_File.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(237)))));
            this.Btn_New_File.Location = new System.Drawing.Point(3, 3);
            this.Btn_New_File.Name = "Btn_New_File";
            this.Btn_New_File.Size = new System.Drawing.Size(108, 32);
            this.Btn_New_File.TabIndex = 0;
            this.Btn_New_File.Text = "＋  New File";
            this.Btn_New_File.UseVisualStyleBackColor = false;
            // 
            // Pnl_SideBar
            // 
            this.Pnl_SideBar.AutoScroll = true;
            this.Pnl_SideBar.Controls.Add(this.Pnl_Drives);
            this.Pnl_SideBar.Controls.Add(this.label5);
            this.Pnl_SideBar.Controls.Add(this.Btn_Thread_monitor);
            this.Pnl_SideBar.Controls.Add(this.label4);
            this.Pnl_SideBar.Controls.Add(this.Btn_Videos);
            this.Pnl_SideBar.Controls.Add(this.Btn_Music);
            this.Pnl_SideBar.Controls.Add(this.Btn_Pictures);
            this.Pnl_SideBar.Controls.Add(this.Btn_Documents);
            this.Pnl_SideBar.Controls.Add(this.Btn_Download);
            this.Pnl_SideBar.Controls.Add(this.Btn_Desktop);
            this.Pnl_SideBar.Controls.Add(this.label3);
            this.Pnl_SideBar.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pnl_SideBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(227)))), ((int)(((byte)(106)))));
            this.Pnl_SideBar.Location = new System.Drawing.Point(1193, 127);
            this.Pnl_SideBar.Name = "Pnl_SideBar";
            this.Pnl_SideBar.Size = new System.Drawing.Size(212, 603);
            this.Pnl_SideBar.TabIndex = 2;
            // 
            // Pnl_Drives
            // 
            this.Pnl_Drives.AutoScroll = true;
            this.Pnl_Drives.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pnl_Drives.Location = new System.Drawing.Point(5, 425);
            this.Pnl_Drives.Name = "Pnl_Drives";
            this.Pnl_Drives.Size = new System.Drawing.Size(200, 172);
            this.Pnl_Drives.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(201)))), ((int)(((byte)(196)))));
            this.label5.Location = new System.Drawing.Point(110, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "This PC";
            // 
            // Btn_Thread_monitor
            // 
            this.Btn_Thread_monitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Thread_monitor.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Thread_monitor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(227)))), ((int)(((byte)(106)))));
            this.Btn_Thread_monitor.Location = new System.Drawing.Point(5, 54);
            this.Btn_Thread_monitor.Name = "Btn_Thread_monitor";
            this.Btn_Thread_monitor.Size = new System.Drawing.Size(203, 33);
            this.Btn_Thread_monitor.TabIndex = 9;
            this.Btn_Thread_monitor.Text = "Thread Monitor⏱";
            this.Btn_Thread_monitor.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(201)))), ((int)(((byte)(196)))));
            this.label4.Location = new System.Drawing.Point(72, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Monitoring";
            // 
            // Btn_Videos
            // 
            this.Btn_Videos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Videos.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Videos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(227)))), ((int)(((byte)(106)))));
            this.Btn_Videos.Location = new System.Drawing.Point(28, 342);
            this.Btn_Videos.Name = "Btn_Videos";
            this.Btn_Videos.Size = new System.Drawing.Size(163, 33);
            this.Btn_Videos.TabIndex = 7;
            this.Btn_Videos.Text = "Videos 🎬";
            this.Btn_Videos.UseVisualStyleBackColor = false;
            this.Btn_Videos.Click += new System.EventHandler(this.Btn_Videos_Click);
            // 
            // Btn_Music
            // 
            this.Btn_Music.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Music.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Music.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(227)))), ((int)(((byte)(106)))));
            this.Btn_Music.Location = new System.Drawing.Point(28, 303);
            this.Btn_Music.Name = "Btn_Music";
            this.Btn_Music.Size = new System.Drawing.Size(163, 33);
            this.Btn_Music.TabIndex = 6;
            this.Btn_Music.Text = "Music 🎵";
            this.Btn_Music.UseVisualStyleBackColor = false;
            this.Btn_Music.Click += new System.EventHandler(this.Btn_Music_Click);
            // 
            // Btn_Pictures
            // 
            this.Btn_Pictures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Pictures.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Pictures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(227)))), ((int)(((byte)(106)))));
            this.Btn_Pictures.Location = new System.Drawing.Point(28, 264);
            this.Btn_Pictures.Name = "Btn_Pictures";
            this.Btn_Pictures.Size = new System.Drawing.Size(163, 33);
            this.Btn_Pictures.TabIndex = 5;
            this.Btn_Pictures.Text = "Pictures 🖼";
            this.Btn_Pictures.UseVisualStyleBackColor = false;
            this.Btn_Pictures.Click += new System.EventHandler(this.Btn_Pictures_Click);
            // 
            // Btn_Documents
            // 
            this.Btn_Documents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Documents.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Documents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(227)))), ((int)(((byte)(106)))));
            this.Btn_Documents.Location = new System.Drawing.Point(28, 225);
            this.Btn_Documents.Name = "Btn_Documents";
            this.Btn_Documents.Size = new System.Drawing.Size(163, 33);
            this.Btn_Documents.TabIndex = 4;
            this.Btn_Documents.Text = "Documents 📄";
            this.Btn_Documents.UseVisualStyleBackColor = false;
            this.Btn_Documents.Click += new System.EventHandler(this.Btn_Documents_Click);
            // 
            // Btn_Download
            // 
            this.Btn_Download.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Download.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Download.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(227)))), ((int)(((byte)(106)))));
            this.Btn_Download.Location = new System.Drawing.Point(28, 186);
            this.Btn_Download.Name = "Btn_Download";
            this.Btn_Download.Size = new System.Drawing.Size(163, 33);
            this.Btn_Download.TabIndex = 3;
            this.Btn_Download.Text = "Downloads ⬇";
            this.Btn_Download.UseVisualStyleBackColor = false;
            this.Btn_Download.Click += new System.EventHandler(this.Btn_Download_Click);
            // 
            // Btn_Desktop
            // 
            this.Btn_Desktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Btn_Desktop.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Desktop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(227)))), ((int)(((byte)(106)))));
            this.Btn_Desktop.Location = new System.Drawing.Point(28, 147);
            this.Btn_Desktop.Name = "Btn_Desktop";
            this.Btn_Desktop.Size = new System.Drawing.Size(163, 33);
            this.Btn_Desktop.TabIndex = 2;
            this.Btn_Desktop.Text = "Desktop🖥";
            this.Btn_Desktop.UseVisualStyleBackColor = false;
            this.Btn_Desktop.Click += new System.EventHandler(this.Btn_Desktop_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(201)))), ((int)(((byte)(196)))));
            this.label3.Location = new System.Drawing.Point(56, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Quick Access";
            // 
            // Pnl_Content
            // 
            this.Pnl_Content.Controls.Add(this.Lvw_Content);
            this.Pnl_Content.Controls.Add(this.panel1);
            this.Pnl_Content.Location = new System.Drawing.Point(13, 127);
            this.Pnl_Content.Name = "Pnl_Content";
            this.Pnl_Content.Size = new System.Drawing.Size(1174, 603);
            this.Pnl_Content.TabIndex = 3;
            // 
            // Lvw_Content
            // 
            this.Lvw_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.Lvw_Content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Lvw_Content.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Clm_Name,
            this.Clm_Date_Modified,
            this.Clm_Type,
            this.Clm_Size,
            this.Clm_Attributes});
            this.Lvw_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lvw_Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lvw_Content.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(227)))), ((int)(((byte)(106)))));
            this.Lvw_Content.FullRowSelect = true;
            this.Lvw_Content.HideSelection = false;
            this.Lvw_Content.Location = new System.Drawing.Point(0, 0);
            this.Lvw_Content.Name = "Lvw_Content";
            this.Lvw_Content.Size = new System.Drawing.Size(1174, 603);
            this.Lvw_Content.TabIndex = 12;
            this.Lvw_Content.UseCompatibleStateImageBehavior = false;
            this.Lvw_Content.View = System.Windows.Forms.View.Details;
            this.Lvw_Content.DoubleClick += new System.EventHandler(this.Lvw_Content_DoubleClick_1);
            // 
            // Clm_Name
            // 
            this.Clm_Name.Text = "Name";
            this.Clm_Name.Width = 300;
            // 
            // Clm_Date_Modified
            // 
            this.Clm_Date_Modified.Text = "Date Modified";
            this.Clm_Date_Modified.Width = 200;
            // 
            // Clm_Type
            // 
            this.Clm_Type.Text = "Type";
            this.Clm_Type.Width = 150;
            // 
            // Clm_Size
            // 
            this.Clm_Size.Text = "Size";
            this.Clm_Size.Width = 150;
            // 
            // Clm_Attributes
            // 
            this.Clm_Attributes.Text = "Attributes";
            this.Clm_Attributes.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1185, 434);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 166);
            this.panel1.TabIndex = 11;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1419, 742);
            this.Controls.Add(this.Pnl_Content);
            this.Controls.Add(this.Pnl_SideBar);
            this.Controls.Add(this.Pnl_ToolBar);
            this.Controls.Add(this.Pnl_Header);
            this.Name = "Form_Main";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.Pnl_Header.ResumeLayout(false);
            this.Pnl_Header.PerformLayout();
            this.Pnl_ToolBar.ResumeLayout(false);
            this.Pnl_SideBar.ResumeLayout(false);
            this.Pnl_SideBar.PerformLayout();
            this.Pnl_Content.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Pnl_Header;
        private System.Windows.Forms.Panel Pnl_ToolBar;
        private System.Windows.Forms.Panel Pnl_SideBar;
        private System.Windows.Forms.Panel Pnl_Content;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Forward;
        private System.Windows.Forms.Button Btn_Back;
        private System.Windows.Forms.TextBox Txt_Search;
        private System.Windows.Forms.Button Btn_New_File;
        private System.Windows.Forms.Button Btn_Duplicate;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Button Btn_Rename;
        private System.Windows.Forms.Button Btn_Cut;
        private System.Windows.Forms.Button Btn_Paste;
        private System.Windows.Forms.Button Btn_Copy;
        private System.Windows.Forms.Button Btn_New_Folder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_Documents;
        private System.Windows.Forms.Button Btn_Download;
        private System.Windows.Forms.Button Btn_Desktop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Videos;
        private System.Windows.Forms.Button Btn_Music;
        private System.Windows.Forms.Button Btn_Pictures;
        private System.Windows.Forms.Button Btn_Thread_monitor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Pnl_Drives;
        private System.Windows.Forms.ListView Lvw_Content;
        private System.Windows.Forms.ColumnHeader Clm_Name;
        private System.Windows.Forms.ColumnHeader Clm_Date_Modified;
        private System.Windows.Forms.ColumnHeader Clm_Type;
        private System.Windows.Forms.ColumnHeader Clm_Size;
        private System.Windows.Forms.ColumnHeader Clm_Attributes;
    }
}