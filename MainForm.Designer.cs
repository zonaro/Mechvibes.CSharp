namespace Mechvibes.CSharp
{
	partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlCaptionBar = new System.Windows.Forms.Panel();
            this.picMinimizeToSystemTray = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblSoundPack = new System.Windows.Forms.Label();
            this.cmbSelectedSoundPack = new System.Windows.Forms.ComboBox();
            this.btnReloadSoundPacks = new System.Windows.Forms.Button();
            this.btnShowSoundPackFolder = new System.Windows.Forms.Button();
            this.btnOpenSoundEditor = new System.Windows.Forms.Button();
            this.lblGitHubAccount = new System.Windows.Forms.Label();
            this.lblGitHubRepository = new System.Windows.Forms.Label();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.numVolume = new System.Windows.Forms.NumericUpDown();
            this.trckVolume = new System.Windows.Forms.TrackBar();
            this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.picSeparator2 = new System.Windows.Forms.PictureBox();
            this.picSeparator1 = new System.Windows.Forms.PictureBox();
            this.picCaptionBarSeparator = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlCaptionBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizeToSystemTray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptionBarSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCaptionBar
            // 
            this.pnlCaptionBar.Controls.Add(this.picMinimizeToSystemTray);
            this.pnlCaptionBar.Controls.Add(this.picMinimize);
            this.pnlCaptionBar.Controls.Add(this.picClose);
            this.pnlCaptionBar.Controls.Add(this.lblTitle);
            this.pnlCaptionBar.Controls.Add(this.picIcon);
            this.pnlCaptionBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaptionBar.Location = new System.Drawing.Point(0, 0);
            this.pnlCaptionBar.Name = "pnlCaptionBar";
            this.pnlCaptionBar.Size = new System.Drawing.Size(426, 44);
            this.pnlCaptionBar.TabIndex = 0;
            this.pnlCaptionBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm);
            // 
            // picMinimizeToSystemTray
            // 
            this.picMinimizeToSystemTray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimizeToSystemTray.Location = new System.Drawing.Point(324, 6);
            this.picMinimizeToSystemTray.Name = "picMinimizeToSystemTray";
            this.picMinimizeToSystemTray.Size = new System.Drawing.Size(32, 32);
            this.picMinimizeToSystemTray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMinimizeToSystemTray.TabIndex = 5;
            this.picMinimizeToSystemTray.TabStop = false;
            this.tooltip.SetToolTip(this.picMinimizeToSystemTray, "Minimize the window to the system tray");
            this.picMinimizeToSystemTray.Click += new System.EventHandler(this.MinimizeToSystemTray);
            this.picMinimizeToSystemTray.MouseEnter += new System.EventHandler(this.MinimizeSysTray_MouseEnter);
            this.picMinimizeToSystemTray.MouseLeave += new System.EventHandler(this.MinimizeSysTray_MouseLeave);
            // 
            // picMinimize
            // 
            this.picMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimize.Location = new System.Drawing.Point(356, 6);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(32, 32);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMinimize.TabIndex = 4;
            this.picMinimize.TabStop = false;
            this.tooltip.SetToolTip(this.picMinimize, "Minimize the window");
            this.picMinimize.Click += new System.EventHandler(this.MinimizeWindow);
            this.picMinimize.MouseEnter += new System.EventHandler(this.Minimize_MouseEnter);
            this.picMinimize.MouseLeave += new System.EventHandler(this.Minimize_MouseLeave);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Location = new System.Drawing.Point(388, 6);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(32, 32);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 2;
            this.picClose.TabStop = false;
            this.tooltip.SetToolTip(this.picClose, "Exit the window");
            this.picClose.Click += new System.EventHandler(this.CloseWindow);
            this.picClose.MouseEnter += new System.EventHandler(this.Close_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.Close_MouseLeave);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(40, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Mechvibes Portable Remake";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm);
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(6, 6);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(32, 32);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            this.picIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm);
            // 
            // lblSoundPack
            // 
            this.lblSoundPack.AutoSize = true;
            this.lblSoundPack.Location = new System.Drawing.Point(12, 59);
            this.lblSoundPack.Name = "lblSoundPack";
            this.lblSoundPack.Size = new System.Drawing.Size(79, 19);
            this.lblSoundPack.TabIndex = 2;
            this.lblSoundPack.Text = "SoundPack:";
            // 
            // cmbSelectedSoundPack
            // 
            this.cmbSelectedSoundPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedSoundPack.FormattingEnabled = true;
            this.cmbSelectedSoundPack.Location = new System.Drawing.Point(97, 56);
            this.cmbSelectedSoundPack.Name = "cmbSelectedSoundPack";
            this.cmbSelectedSoundPack.Size = new System.Drawing.Size(317, 25);
            this.cmbSelectedSoundPack.TabIndex = 3;
            this.tooltip.SetToolTip(this.cmbSelectedSoundPack, "The currently loaded soundpacks in the application");
            this.cmbSelectedSoundPack.SelectedIndexChanged += new System.EventHandler(this.cmbSelectedSoundPack_SelectedIndexChanged);
            // 
            // btnReloadSoundPacks
            // 
            this.btnReloadSoundPacks.Location = new System.Drawing.Point(6, 251);
            this.btnReloadSoundPacks.Name = "btnReloadSoundPacks";
            this.btnReloadSoundPacks.Size = new System.Drawing.Size(143, 37);
            this.btnReloadSoundPacks.TabIndex = 5;
            this.btnReloadSoundPacks.Text = "Reload SoundPacks";
            this.tooltip.SetToolTip(this.btnReloadSoundPacks, "Reloads the soundpack list to prevent the use of deleted soundpacks or to load ne" +
        "w soundpacks without restarting the application");
            this.btnReloadSoundPacks.UseVisualStyleBackColor = true;
            this.btnReloadSoundPacks.Click += new System.EventHandler(this.ReloadSoundPacks);
            // 
            // btnShowSoundPackFolder
            // 
            this.btnShowSoundPackFolder.Location = new System.Drawing.Point(6, 208);
            this.btnShowSoundPackFolder.Name = "btnShowSoundPackFolder";
            this.btnShowSoundPackFolder.Size = new System.Drawing.Size(141, 37);
            this.btnShowSoundPackFolder.TabIndex = 6;
            this.btnShowSoundPackFolder.Text = "Show SoundPacks";
            this.tooltip.SetToolTip(this.btnShowSoundPackFolder, "Opens the soundpack folder in File Explorer");
            this.btnShowSoundPackFolder.UseVisualStyleBackColor = true;
            this.btnShowSoundPackFolder.Click += new System.EventHandler(this.OpenSoundPackFolder);
            // 
            // btnOpenSoundEditor
            // 
            this.btnOpenSoundEditor.Location = new System.Drawing.Point(153, 251);
            this.btnOpenSoundEditor.Name = "btnOpenSoundEditor";
            this.btnOpenSoundEditor.Size = new System.Drawing.Size(106, 37);
            this.btnOpenSoundEditor.TabIndex = 7;
            this.btnOpenSoundEditor.Text = "Sound Editor";
            this.tooltip.SetToolTip(this.btnOpenSoundEditor, "Opens the sound editor for making custom soundpacks");
            this.btnOpenSoundEditor.UseVisualStyleBackColor = true;
            this.btnOpenSoundEditor.Click += new System.EventHandler(this.OpenSoundEditor);
            // 
            // lblGitHubAccount
            // 
            this.lblGitHubAccount.AutoSize = true;
            this.lblGitHubAccount.ForeColor = System.Drawing.Color.Blue;
            this.lblGitHubAccount.Location = new System.Drawing.Point(9, 318);
            this.lblGitHubAccount.Name = "lblGitHubAccount";
            this.lblGitHubAccount.Size = new System.Drawing.Size(96, 19);
            this.lblGitHubAccount.TabIndex = 9;
            this.lblGitHubAccount.Text = "github/zonaro";
            this.tooltip.SetToolTip(this.lblGitHubAccount, "My GitHub Account");
            this.lblGitHubAccount.Click += new System.EventHandler(this.GitHubAccount_Click);
            this.lblGitHubAccount.MouseEnter += new System.EventHandler(this.GitHubAccount_MouseEnter);
            this.lblGitHubAccount.MouseLeave += new System.EventHandler(this.GitHubAccount_MouseLeave);
            // 
            // lblGitHubRepository
            // 
            this.lblGitHubRepository.AutoSize = true;
            this.lblGitHubRepository.ForeColor = System.Drawing.Color.Blue;
            this.lblGitHubRepository.Location = new System.Drawing.Point(202, 318);
            this.lblGitHubRepository.Name = "lblGitHubRepository";
            this.lblGitHubRepository.Size = new System.Drawing.Size(213, 19);
            this.lblGitHubRepository.TabIndex = 10;
            this.lblGitHubRepository.Text = "github/zonaro/Mechvibes.CSharp";
            this.tooltip.SetToolTip(this.lblGitHubRepository, "The GitHub repository that stores the source code for this application");
            this.lblGitHubRepository.Click += new System.EventHandler(this.GitHubRepository_Click);
            this.lblGitHubRepository.MouseEnter += new System.EventHandler(this.GitHubRepository_MouseEnter);
            this.lblGitHubRepository.MouseLeave += new System.EventHandler(this.GitHubRepository_MouseLeave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(261, 37);
            this.button1.TabIndex = 17;
            this.button1.Text = "Download SoundPacks";
            this.tooltip.SetToolTip(this.button1, "Navigate to Mechvibes Sheet with many packs ready to download");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numVolume
            // 
            this.numVolume.Location = new System.Drawing.Point(16, 111);
            this.numVolume.Name = "numVolume";
            this.numVolume.Size = new System.Drawing.Size(75, 25);
            this.numVolume.TabIndex = 13;
            this.numVolume.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numVolume.ValueChanged += new System.EventHandler(this.VolumeChanged);
            // 
            // trckVolume
            // 
            this.trckVolume.Location = new System.Drawing.Point(97, 111);
            this.trckVolume.Maximum = 100;
            this.trckVolume.Name = "trckVolume";
            this.trckVolume.Size = new System.Drawing.Size(318, 45);
            this.trckVolume.TabIndex = 14;
            this.trckVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trckVolume.Value = 50;
            this.trckVolume.ValueChanged += new System.EventHandler(this.VolumeChanged);
            // 
            // trayicon
            // 
            this.trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.Icon")));
            this.trayicon.Text = "Mechvibes.CSharp";
            this.trayicon.Visible = true;
            this.trayicon.DoubleClick += new System.EventHandler(this.UnminimizeWindowToNormal);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox1.Location = new System.Drawing.Point(97, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(317, 25);
            this.textBox1.TabIndex = 15;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // picSeparator2
            // 
            this.picSeparator2.BackColor = System.Drawing.Color.Silver;
            this.picSeparator2.Location = new System.Drawing.Point(0, 313);
            this.picSeparator2.Name = "picSeparator2";
            this.picSeparator2.Size = new System.Drawing.Size(427, 1);
            this.picSeparator2.TabIndex = 12;
            this.picSeparator2.TabStop = false;
            // 
            // picSeparator1
            // 
            this.picSeparator1.BackColor = System.Drawing.Color.Silver;
            this.picSeparator1.Location = new System.Drawing.Point(0, 201);
            this.picSeparator1.Name = "picSeparator1";
            this.picSeparator1.Size = new System.Drawing.Size(427, 1);
            this.picSeparator1.TabIndex = 4;
            this.picSeparator1.TabStop = false;
            // 
            // picCaptionBarSeparator
            // 
            this.picCaptionBarSeparator.BackColor = System.Drawing.Color.Silver;
            this.picCaptionBarSeparator.Location = new System.Drawing.Point(0, 44);
            this.picCaptionBarSeparator.Name = "picCaptionBarSeparator";
            this.picCaptionBarSeparator.Size = new System.Drawing.Size(427, 1);
            this.picCaptionBarSeparator.TabIndex = 1;
            this.picCaptionBarSeparator.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Test:";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Filter = "*";
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "installed";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(102, 173);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(163, 23);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Random pack on start";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(265, 251);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 37);
            this.button2.TabIndex = 20;
            this.button2.Text = "Add to Startup";
            this.tooltip.SetToolTip(this.button2, "Create a shortcut on startup foler");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(426, 346);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.numVolume);
            this.Controls.Add(this.picSeparator2);
            this.Controls.Add(this.lblGitHubRepository);
            this.Controls.Add(this.lblGitHubAccount);
            this.Controls.Add(this.btnOpenSoundEditor);
            this.Controls.Add(this.btnShowSoundPackFolder);
            this.Controls.Add(this.btnReloadSoundPacks);
            this.Controls.Add(this.picSeparator1);
            this.Controls.Add(this.cmbSelectedSoundPack);
            this.Controls.Add(this.lblSoundPack);
            this.Controls.Add(this.picCaptionBarSeparator);
            this.Controls.Add(this.pnlCaptionBar);
            this.Controls.Add(this.trckVolume);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mechvibes.CSharp";
            this.TopMost = true;
            this.pnlCaptionBar.ResumeLayout(false);
            this.pnlCaptionBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizeToSystemTray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptionBarSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlCaptionBar;
		private System.Windows.Forms.PictureBox picIcon;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.PictureBox picMinimize;
		private System.Windows.Forms.PictureBox picClose;
		private System.Windows.Forms.PictureBox picCaptionBarSeparator;
		private System.Windows.Forms.Label lblSoundPack;
		private System.Windows.Forms.ComboBox cmbSelectedSoundPack;
		private System.Windows.Forms.PictureBox picSeparator1;
		private System.Windows.Forms.Button btnReloadSoundPacks;
		private System.Windows.Forms.Button btnShowSoundPackFolder;
		private System.Windows.Forms.Button btnOpenSoundEditor;
		private System.Windows.Forms.Label lblGitHubAccount;
		private System.Windows.Forms.Label lblGitHubRepository;
		private System.Windows.Forms.ToolTip tooltip;
		private System.Windows.Forms.PictureBox picSeparator2;
		private System.Windows.Forms.NumericUpDown numVolume;
		private System.Windows.Forms.TrackBar trckVolume;
		private System.Windows.Forms.PictureBox picMinimizeToSystemTray;
		private System.Windows.Forms.NotifyIcon trayicon;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        internal System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
    }
}

