using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Cortex
{
    public partial class Form_Main : Form
    {
        private string CurrentPath;
        private List<string> BackHistory = new List<string>();
        private List<string> ForwardHistory = new List<string>();
        private void Load_Drives()
        {
            DriveInfo[] Drives = DriveInfo.GetDrives();
            foreach (DriveInfo Drive in Drives)
            {
                if (Drive.IsReady)
                {
                    Button Btn_Drive = new Button();
                    Btn_Drive.Text = Drive.Name;
                    Btn_Drive.Width = 130;
                    Btn_Drive.Height = 30;
                    Btn_Drive.Tag = Drive.Name;
                    string DriveName = string.IsNullOrWhiteSpace(Drive.VolumeLabel) ? "Local Disk" : Drive.VolumeLabel;
                    Btn_Drive.Text = $"{DriveName} ({Drive.Name.TrimEnd('\\')})";
                    Btn_Drive.Click += Btn_Drive_Click;
                    Btn_Drive.Location = new Point(10, Pnl_Drives.Controls.Count * 35);
                    Pnl_Drives.Controls.Add(Btn_Drive);
                }
            }
        }

        private void Load_Directory(string Path)
        {
            Lvw_Content.Items.Clear();
            CurrentPath = Path;
            Txt_Search.Text = Path;
            try
            {
                // Load Folders
                foreach (string Folder in Directory.GetDirectories(Path))
                {
                    DirectoryInfo Info = new DirectoryInfo(Folder);
                    ListViewItem Item = new ListViewItem(Info.Name);
                    Item.SubItems.Add(Info.LastWriteTime.ToString());
                    Item.SubItems.Add("File Folder");
                    Item.SubItems.Add("");
                    Item.SubItems.Add(Info.Attributes.ToString());
                    Item.Tag = Folder;
                    if (Info.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        Item.ForeColor = ColorTranslator.FromHtml("#9B7BB5");
                        Item.Tag = null;
                    }
                    Lvw_Content.Items.Add(Item);
                }
                // Load Files
                foreach (string File in Directory.GetFiles(Path))
                {
                    FileInfo Info = new FileInfo(File);
                    ListViewItem Item = new ListViewItem(Info.Name);
                    Item.SubItems.Add(Info.LastWriteTime.ToString());
                    Item.SubItems.Add(Info.Extension.ToUpper() + " File");
                    Item.SubItems.Add(Format_Size(Info.Length));
                    Item.SubItems.Add(Info.Attributes.ToString());
                    Item.Tag = File;
                    if (Info.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        Item.ForeColor = ColorTranslator.FromHtml("#9B7BB5");
                        Item.Tag = null;
                    }
                    Lvw_Content.Items.Add(Item);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access Denied!");
            }
            catch (IOException)
            {
                MessageBox.Show("Unable to access this directory.");
            }
        }
        private string Format_Size(long Bytes)
        {
            string[] Units = { "B", "KB", "MB", "GB", "TB" };
            double Size = Bytes;
            int Unit = 0;
            while (Size >= 1024 && Unit < Units.Length - 1)
            {
                Size /= 1024;
                Unit++;
            }
            return $"{Size:F2} {Units[Unit]}";
        }

        private void Navigate_To(string Path)
        {
            if (Path == CurrentPath)
                return;
            if (!string.IsNullOrEmpty(CurrentPath))
                BackHistory.Add(CurrentPath);
            ForwardHistory.Clear();
            Load_Directory(Path);
            Update_Navigation_Buttons();
        }

        private void Update_Navigation_Buttons()
        {
            Btn_Back.Enabled = BackHistory.Count > 0;
            Btn_Forward.Enabled = ForwardHistory.Count > 0;
        }
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            Load_Drives();
            Update_Navigation_Buttons();
        }

        private void Btn_Drive_Click(object sender, EventArgs e)
        {
            Button Btn_Drive = (Button)sender;
            string DrivePath = Btn_Drive.Tag.ToString();
            Navigate_To(DrivePath);
        }

        private void Lvw_Content_DoubleClick_1(object sender, EventArgs e)
        {
            if (Lvw_Content.SelectedItems.Count == 0 || Lvw_Content.SelectedItems[0].Tag == null)
                return;
            string SelectedPath = Lvw_Content.SelectedItems[0].Tag.ToString();
            if (Directory.Exists(SelectedPath))
            {
                Navigate_To(SelectedPath);
            }
            else if (File.Exists(SelectedPath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = SelectedPath,
                        UseShellExecute = true
                    });
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(
               $"Unable to open file.\n{Ex.Message}");
                }
            }
        }
        private void Btn_Back_Click(object sender, EventArgs e)
        {
            if (BackHistory.Count == 0)
                return;
            ForwardHistory.Add(CurrentPath);
            string PreviousPath = BackHistory[BackHistory.Count - 1];
            BackHistory.RemoveAt(BackHistory.Count - 1);
            Load_Directory(PreviousPath);
            Update_Navigation_Buttons();
        }

        private void Btn_Forward_Click(object sender, EventArgs e)
        {
            if (ForwardHistory.Count == 0)
                return;
            BackHistory.Add(CurrentPath);
            string NextPath = ForwardHistory[ForwardHistory.Count - 1];
            ForwardHistory.RemoveAt(ForwardHistory.Count - 1);
            Load_Directory(NextPath);
            Update_Navigation_Buttons();
        }

        private void Btn_Desktop_Click(object sender, EventArgs e)
        {
            Navigate_To(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }

        private void Btn_Download_Click(object sender, EventArgs e)
        {
            Navigate_To(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads");
        }

        private void Btn_Documents_Click(object sender, EventArgs e)
        {
            Navigate_To(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }

        private void Btn_Pictures_Click(object sender, EventArgs e)
        {
            Navigate_To(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
        }

        private void Btn_Music_Click(object sender, EventArgs e)
        {
            Navigate_To(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
        }

        private void Btn_Videos_Click(object sender, EventArgs e)
        {
            Navigate_To(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
        }
        private void Form2_FormClosing(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
