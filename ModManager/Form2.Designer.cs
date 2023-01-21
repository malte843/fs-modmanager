namespace ModManager
{
    partial class Form2
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
            this.textBox1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBox2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnSModFolder = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnSModPacks = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.textBox3 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.btnSave = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnShow = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnReload = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnLoad = new MaterialSkin.Controls.MaterialFlatButton();
            this.progressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bgwCreatePack = new System.ComponentModel.BackgroundWorker();
            this.bgwLoadPack = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblLoading = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Depth = 0;
            this.textBox1.Enabled = false;
            this.textBox1.Hint = "";
            this.textBox1.Location = new System.Drawing.Point(12, 90);
            this.textBox1.MaxLength = 32767;
            this.textBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.Size = new System.Drawing.Size(509, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.UseSystemPasswordChar = false;
            // 
            // textBox2
            // 
            this.textBox2.Depth = 0;
            this.textBox2.Enabled = false;
            this.textBox2.Hint = "";
            this.textBox2.Location = new System.Drawing.Point(12, 138);
            this.textBox2.MaxLength = 32767;
            this.textBox2.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.Size = new System.Drawing.Size(509, 23);
            this.textBox2.TabIndex = 2;
            this.textBox2.TabStop = false;
            this.textBox2.UseSystemPasswordChar = false;
            // 
            // btnSModFolder
            // 
            this.btnSModFolder.AutoSize = true;
            this.btnSModFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSModFolder.Depth = 0;
            this.btnSModFolder.Icon = null;
            this.btnSModFolder.Location = new System.Drawing.Point(532, 77);
            this.btnSModFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSModFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSModFolder.Name = "btnSModFolder";
            this.btnSModFolder.Primary = false;
            this.btnSModFolder.Size = new System.Drawing.Size(69, 36);
            this.btnSModFolder.TabIndex = 3;
            this.btnSModFolder.Text = "Select";
            this.btnSModFolder.UseVisualStyleBackColor = true;
            this.btnSModFolder.Click += new System.EventHandler(this.btnSModFolder_Click);
            // 
            // btnSModPacks
            // 
            this.btnSModPacks.AutoSize = true;
            this.btnSModPacks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSModPacks.Depth = 0;
            this.btnSModPacks.Icon = null;
            this.btnSModPacks.Location = new System.Drawing.Point(532, 125);
            this.btnSModPacks.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSModPacks.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSModPacks.Name = "btnSModPacks";
            this.btnSModPacks.Primary = false;
            this.btnSModPacks.Size = new System.Drawing.Size(69, 36);
            this.btnSModPacks.TabIndex = 4;
            this.btnSModPacks.Text = "Select";
            this.btnSModPacks.UseVisualStyleBackColor = true;
            this.btnSModPacks.Click += new System.EventHandler(this.btnSModPacks_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 68);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(85, 19);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "Mod Folder";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 116);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(125, 19);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "Modpacks Folder";
            // 
            // textBox3
            // 
            this.textBox3.Depth = 0;
            this.textBox3.Hint = "";
            this.textBox3.Location = new System.Drawing.Point(396, 189);
            this.textBox3.MaxLength = 32767;
            this.textBox3.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.SelectedText = "";
            this.textBox3.SelectionLength = 0;
            this.textBox3.SelectionStart = 0;
            this.textBox3.Size = new System.Drawing.Size(202, 23);
            this.textBox3.TabIndex = 7;
            this.textBox3.TabStop = false;
            this.textBox3.UseSystemPasswordChar = false;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(396, 167);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(86, 19);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "Pack Name";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Depth = 0;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(397, 221);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = false;
            this.btnSave.Size = new System.Drawing.Size(143, 36);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Create new Pack";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnShow
            // 
            this.btnShow.AutoSize = true;
            this.btnShow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShow.Depth = 0;
            this.btnShow.Enabled = false;
            this.btnShow.Icon = null;
            this.btnShow.Location = new System.Drawing.Point(396, 259);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnShow.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnShow.Name = "btnShow";
            this.btnShow.Primary = false;
            this.btnShow.Size = new System.Drawing.Size(148, 36);
            this.btnShow.TabIndex = 10;
            this.btnShow.Text = "Show in Explorer";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.Depth = 0;
            this.btnDelete.Enabled = false;
            this.btnDelete.Icon = null;
            this.btnDelete.Location = new System.Drawing.Point(396, 296);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Primary = false;
            this.btnDelete.Size = new System.Drawing.Size(138, 36);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReload
            // 
            this.btnReload.AutoSize = true;
            this.btnReload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReload.Depth = 0;
            this.btnReload.Icon = null;
            this.btnReload.Location = new System.Drawing.Point(529, 334);
            this.btnReload.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReload.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReload.Name = "btnReload";
            this.btnReload.Primary = false;
            this.btnReload.Size = new System.Drawing.Size(72, 36);
            this.btnReload.TabIndex = 13;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.AutoSize = true;
            this.btnLoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoad.Depth = 0;
            this.btnLoad.Enabled = false;
            this.btnLoad.Icon = null;
            this.btnLoad.Location = new System.Drawing.Point(396, 334);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLoad.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Primary = false;
            this.btnLoad.Size = new System.Drawing.Size(125, 36);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "Load Selected";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Depth = 0;
            this.progressBar1.Location = new System.Drawing.Point(12, 391);
            this.progressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(586, 5);
            this.progressBar1.TabIndex = 14;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 171);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(377, 184);
            this.listBox1.TabIndex = 15;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // bgwCreatePack
            // 
            this.bgwCreatePack.WorkerReportsProgress = true;
            this.bgwCreatePack.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCreatePack_DoWork);
            this.bgwCreatePack.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCreatePack_ProgressChanged);
            this.bgwCreatePack.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCreatePack_RunWorkerCompleted);
            // 
            // bgwLoadPack
            // 
            this.bgwLoadPack.WorkerReportsProgress = true;
            this.bgwLoadPack.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadPack_DoWork);
            this.bgwLoadPack.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwLoadPack_ProgressChanged);
            this.bgwLoadPack.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoadPack_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Depth = 0;
            this.lblLoading.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblLoading.ForeColor = System.Drawing.Color.Lime;
            this.lblLoading.Location = new System.Drawing.Point(12, 358);
            this.lblLoading.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(74, 19);
            this.lblLoading.TabIndex = 16;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 408);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.btnSModPacks);
            this.Controls.Add(this.btnSModFolder);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.Text = "FS ModManager";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField textBox1;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBox2;
        private MaterialSkin.Controls.MaterialFlatButton btnSModFolder;
        private MaterialSkin.Controls.MaterialFlatButton btnSModPacks;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBox3;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialFlatButton btnSave;
        private MaterialSkin.Controls.MaterialFlatButton btnShow;
        private MaterialSkin.Controls.MaterialFlatButton btnDelete;
        private MaterialSkin.Controls.MaterialFlatButton btnReload;
        private MaterialSkin.Controls.MaterialFlatButton btnLoad;
        private MaterialSkin.Controls.MaterialProgressBar progressBar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.ComponentModel.BackgroundWorker bgwCreatePack;
        private System.ComponentModel.BackgroundWorker bgwLoadPack;
        private System.Windows.Forms.Timer timer1;
        private MaterialSkin.Controls.MaterialLabel lblLoading;
    }
}