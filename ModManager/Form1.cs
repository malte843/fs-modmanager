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
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                setModFolder(dialog.SelectedPath);
            }
        }

        private void btnSModPacks_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                setModPacks(dialog.SelectedPath);
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

        private void bgwCreatePack_DoWork(object sender, DoWorkEventArgs e)
        {
            if (textBox3.Text.Trim() != "")
            {
                Directory.CreateDirectory(modPacksPath + "\\" + textBox3.Text);
                new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(modFolderPath, modPacksPath + "\\" + textBox3.Text);
                reload = true;
            }
        }

        private void bgwLoadPack_DoWork(object sender, DoWorkEventArgs e)
        {
            string selectedPackPath = modPacksPath + "\\" + selectedItem;
            if (Directory.Exists(selectedPackPath))
            {
                if (!Directory.Exists(modFolderPath))
                    Directory.CreateDirectory(modFolderPath);

                DirectoryInfo directory = new DirectoryInfo(modFolderPath);
                foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
                foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);

                new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(selectedPackPath, modFolderPath);
                MessageBox.Show("Loaded Pack " + selectedItem);
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

        private void bgwLoadPack_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            running = false;
        }

        private void bgwCreatePack_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            running = false;
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
    }
}
