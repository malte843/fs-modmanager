using ModManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ModManager
{
    public partial class Form1 : Form
    {
        private string modFolderPath = "";
        private string modPacksPath = "";
        private Boolean startup = true;
        private string selectedItem;
        private Boolean running = false;
        private Boolean reload = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (startup)
            {
                Settings.Default.Save();
                Settings.Default.Upgrade();
                Settings.Default.Reload();
                ReloadSettings();
                textBox1.Text = modFolderPath;
                textBox2.Text = modPacksPath;
                ReloadModpacks();
                startup = false;
                timer1.Start();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() != "")
            {
                running = true;
                textBox3.Enabled = false;
                bgwCreatePack.RunWorkerAsync();
            } else
            {
                MessageBox.Show("Name cant be empty");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            running = true;
            bgwLoadPack.RunWorkerAsync();
        }

        private void ReloadSettings()
        {
            modFolderPath = Settings.Default.modFolderPath;
            modPacksPath = Settings.Default.modPacksPath;
            if (modPacksPath == "undefined" || modPacksPath.Trim() == "")
            {
                modPacksPath = Application.StartupPath + "\\modpacks";
                SaveSettings();
            }

            if (modFolderPath == "undefined" || modFolderPath.Trim() == "")
            {
                modFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\FarmingSimulator2022\\mods";
                SaveSettings();
            }
        }

        private void SaveSettings()
        {
            Settings.Default.modFolderPath = modFolderPath;
            Settings.Default.modPacksPath = modPacksPath;
            Settings.Default.Save();
            Settings.Default.Upgrade();
            Settings.Default.Reload();
        }

        private void setModFolder(string path)
        {
            modFolderPath = path;
            textBox1.Text = path;
            SaveSettings();
        }

        private void setModPacks(string path)
        {
            modPacksPath = path;
            textBox2.Text = path;
            SaveSettings();
        }

        private void ReloadModpacks()
        {
            if (!Directory.Exists(modPacksPath))
            {
                Directory.CreateDirectory(modPacksPath);
            }
            listBox1.Items.Clear();
            foreach (string dir in Directory.GetDirectories(modPacksPath))
            {
                listBox1.Items.Add(dir.Replace(modPacksPath + "\\", ""));
            }
        }

        private void btnSModfolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = modFolderPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                setModFolder(dialog.FileName);
            }
        }

        private void btnSModPacks_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = modPacksPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                setModPacks(dialog.FileName);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReloadModpacks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectedPackPath = modPacksPath + "\\" + selectedItem;

            if (Directory.Exists(selectedPackPath))
            {
                DirectoryInfo directory = new DirectoryInfo(selectedPackPath);
                foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
                foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
                Directory.Delete(selectedPackPath);

                reload = true;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string selectedPackPath = modPacksPath + "\\" + selectedItem;
            if (Directory.Exists(selectedPackPath))
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Arguments = selectedPackPath,
                        FileName = "explorer.exe"
                    };
                    Process.Start(startInfo);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                selectedItem = listBox1.SelectedItem.ToString();
                btnLoad.Enabled = true;
                btnDelete.Enabled = true;
                btnShow.Enabled = true;
            } else
            {
                selectedItem = "";
                btnLoad.Enabled = false;
                btnDelete.Enabled = false;
                btnShow.Enabled = false;
            }
        }

        int tickCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (reload)
            {
                ReloadModpacks();
                reload = false;
            }
                

            // Loading... | / - \ 
            if (running)
            {
                label4.Visible = true;
                if (tickCount == 0)
                {
                    label4.Text = "Copying Files... |";
                    tickCount = 1;
                }
                else if (tickCount == 1)
                {
                    label4.Text = "Copying Files... /";
                    tickCount = 2;
                }
                else if (tickCount == 2)
                {
                    label4.Text = "Copying Files... -";
                    tickCount = 3;
                } else
                {
                    label4.Text = "Copying Files... \\";
                    tickCount = 0;
                }
            } else
            {
                label4.Visible = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.modFolderPath = modFolderPath;
            Settings.Default.modPacksPath = modPacksPath;
            Settings.Default.Save();
            Settings.Default.Upgrade();
            Settings.Default.Reload();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || char.IsControl(e.KeyChar))
            {
                // These characters may pass
                e.Handled = false;
            }
            else
            {
                // Everything that is not a letter, nor a backspace nor a space will be blocked
                e.Handled = true;
            }
        }


        long totalCopied = 1;
        long totalSize = 0;
        private long GetDirectorySize(DirectoryInfo source)
        {
            long size = 0;
            foreach (FileInfo fi in source.GetFiles())
            {
                size += fi.Length;
            }
            foreach (DirectoryInfo diFi in source.GetDirectories())
            {
                size += GetDirectorySize(diFi);
            }

            return size;
        }

        private void CopyDirCreatePack(DirectoryInfo source, DirectoryInfo target)
        {
            string selectedPackPath = modPacksPath + "\\" + selectedItem;
            // Check if the target directory exists, if not, create it.
            if (!Directory.Exists(target.FullName))
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
                totalCopied += fi.Length;
                bgwCreatePack.ReportProgress((int)(totalCopied * 100 / totalSize));
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDirCreatePack(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void CopyDirLoadPack(DirectoryInfo source, DirectoryInfo target)
        {

            // Check if the target directory exists, if not, create it.
            if (!Directory.Exists(target.FullName))
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
                totalCopied += fi.Length;
                bgwLoadPack.ReportProgress((int)(totalCopied * 100 / totalSize));
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDirLoadPack(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void bgwCopyTest_DoWork(object sender, DoWorkEventArgs e)
        {
            string selectedPackPath = modPacksPath + "\\" + selectedItem;
            DirectoryInfo source = new DirectoryInfo(selectedPackPath);
            DirectoryInfo target = new DirectoryInfo(modFolderPath);
            totalSize = GetDirectorySize(source);
            CopyDirLoadPack(source, target);
        }

        private void bgwCopyTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100)
            {
                totalCopied = 0;
                progressBar1.Value = 0;
                MessageBox.Show("Loaded Pack " + selectedItem);
            }
        }

        private void bgwCreatePack_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo source = new DirectoryInfo(modFolderPath);
            DirectoryInfo target = new DirectoryInfo(modPacksPath + "\\" + textBox3.Text);
            totalSize = GetDirectorySize(source);
            CopyDirCreatePack(source, target);
        }

        private void bgwLoadPack_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!Directory.Exists(modFolderPath))
                Directory.CreateDirectory(modFolderPath);
            string selectedPackPath = modPacksPath + "\\" + selectedItem;
            DirectoryInfo source = new DirectoryInfo(selectedPackPath);
            DirectoryInfo target = new DirectoryInfo(modFolderPath);
            totalSize = GetDirectorySize(source);
            foreach (System.IO.FileInfo file in target.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in target.GetDirectories()) subDirectory.Delete(true);
            CopyDirLoadPack(source, target);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgwCopyTest.RunWorkerAsync();
        }

        private void bgwLoadPack_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwCreatePack_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwLoadPack_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            running = false;
            totalCopied = 1;
            progressBar1.Value = 0;
            MessageBox.Show("Loaded Pack " + selectedItem);
        }

        private void bgwCreatePack_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            running = false;
            reload = true;
            totalCopied = 1;
            progressBar1.Value = 0;
            textBox3.Enabled = true;
        }
    }
}
