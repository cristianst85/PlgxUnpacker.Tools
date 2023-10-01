namespace PlgxUnpacker
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFileInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.buttonUnpack = new PlgxUnpacker.Controls.ButtonEx();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.labelPostBuildCommand = new System.Windows.Forms.Label();
            this.textBoxPostBuildCommand = new PlgxUnpacker.Controls.ViewOnlyTextBox();
            this.textBoxPreBuildCommand = new PlgxUnpacker.Controls.ViewOnlyTextBox();
            this.labelPreBuildCommand = new System.Windows.Forms.Label();
            this.textBoxToolName = new PlgxUnpacker.Controls.ViewOnlyTextBox();
            this.labelToolName = new System.Windows.Forms.Label();
            this.textBoxCreationDate = new PlgxUnpacker.Controls.ViewOnlyTextBox();
            this.labelCreationDate = new System.Windows.Forms.Label();
            this.textBoxPluginName = new PlgxUnpacker.Controls.ViewOnlyTextBox();
            this.labelPluginName = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(370, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::PlgxUnpacker.Properties.Resources.folder_page_white;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::PlgxUnpacker.Properties.Resources.door_out;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyFileInfoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // copyFileInfoToolStripMenuItem
            // 
            this.copyFileInfoToolStripMenuItem.Enabled = false;
            this.copyFileInfoToolStripMenuItem.Name = "copyFileInfoToolStripMenuItem";
            this.copyFileInfoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyFileInfoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.copyFileInfoToolStripMenuItem.Text = "Copy File Info";
            this.copyFileInfoToolStripMenuItem.Click += new System.EventHandler(this.CopyFileInfoToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::PlgxUnpacker.Properties.Resources.wrench;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Image = global::PlgxUnpacker.Properties.Resources.world;
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdatesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::PlgxUnpacker.Properties.Resources.information;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 259);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(346, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 12;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 320);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(370, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.Stretch = false;
            this.statusStrip.TabIndex = 9;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(355, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "{status}";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Enabled = false;
            this.buttonOpenFolder.Location = new System.Drawing.Point(172, 288);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(90, 23);
            this.buttonOpenFolder.TabIndex = 13;
            this.buttonOpenFolder.Text = "Open &Folder...";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.ButtonOpenFolder_Click);
            // 
            // buttonUnpack
            // 
            this.buttonUnpack.Location = new System.Drawing.Point(268, 288);
            this.buttonUnpack.Name = "buttonUnpack";
            this.buttonUnpack.Size = new System.Drawing.Size(90, 23);
            this.buttonUnpack.TabIndex = 14;
            this.buttonUnpack.Tag = "";
            this.buttonUnpack.Text = "&Unpack...";
            this.buttonUnpack.TextToggle = "&Cancel";
            this.buttonUnpack.UseVisualStyleBackColor = true;
            this.buttonUnpack.Click += new System.EventHandler(this.ButtonUnpack_Click);
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.labelPostBuildCommand);
            this.groupBox.Controls.Add(this.textBoxPostBuildCommand);
            this.groupBox.Controls.Add(this.textBoxPreBuildCommand);
            this.groupBox.Controls.Add(this.labelPreBuildCommand);
            this.groupBox.Controls.Add(this.textBoxToolName);
            this.groupBox.Controls.Add(this.labelToolName);
            this.groupBox.Controls.Add(this.textBoxCreationDate);
            this.groupBox.Controls.Add(this.labelCreationDate);
            this.groupBox.Controls.Add(this.textBoxPluginName);
            this.groupBox.Controls.Add(this.labelPluginName);
            this.groupBox.Location = new System.Drawing.Point(12, 27);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(346, 226);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "File Info";
            // 
            // labelPostBuildCommand
            // 
            this.labelPostBuildCommand.AutoSize = true;
            this.labelPostBuildCommand.Location = new System.Drawing.Point(6, 161);
            this.labelPostBuildCommand.Name = "labelPostBuildCommand";
            this.labelPostBuildCommand.Size = new System.Drawing.Size(106, 13);
            this.labelPostBuildCommand.TabIndex = 10;
            this.labelPostBuildCommand.Text = "Post-build Command:";
            // 
            // textBoxPostBuildCommand
            // 
            this.textBoxPostBuildCommand.Location = new System.Drawing.Point(118, 158);
            this.textBoxPostBuildCommand.Multiline = true;
            this.textBoxPostBuildCommand.Name = "textBoxPostBuildCommand";
            this.textBoxPostBuildCommand.ReadOnly = true;
            this.textBoxPostBuildCommand.ShortcutsEnabled = false;
            this.textBoxPostBuildCommand.Size = new System.Drawing.Size(216, 60);
            this.textBoxPostBuildCommand.TabIndex = 11;
            // 
            // textBoxPreBuildCommand
            // 
            this.textBoxPreBuildCommand.Location = new System.Drawing.Point(118, 92);
            this.textBoxPreBuildCommand.Multiline = true;
            this.textBoxPreBuildCommand.Name = "textBoxPreBuildCommand";
            this.textBoxPreBuildCommand.ReadOnly = true;
            this.textBoxPreBuildCommand.ShortcutsEnabled = false;
            this.textBoxPreBuildCommand.Size = new System.Drawing.Size(216, 60);
            this.textBoxPreBuildCommand.TabIndex = 9;
            // 
            // labelPreBuildCommand
            // 
            this.labelPreBuildCommand.AutoSize = true;
            this.labelPreBuildCommand.Location = new System.Drawing.Point(11, 95);
            this.labelPreBuildCommand.Name = "labelPreBuildCommand";
            this.labelPreBuildCommand.Size = new System.Drawing.Size(101, 13);
            this.labelPreBuildCommand.TabIndex = 8;
            this.labelPreBuildCommand.Text = "Pre-build Command:";
            // 
            // textBoxToolName
            // 
            this.textBoxToolName.Location = new System.Drawing.Point(118, 66);
            this.textBoxToolName.Name = "textBoxToolName";
            this.textBoxToolName.ReadOnly = true;
            this.textBoxToolName.ShortcutsEnabled = false;
            this.textBoxToolName.Size = new System.Drawing.Size(216, 20);
            this.textBoxToolName.TabIndex = 7;
            // 
            // labelToolName
            // 
            this.labelToolName.AutoSize = true;
            this.labelToolName.Location = new System.Drawing.Point(50, 69);
            this.labelToolName.Name = "labelToolName";
            this.labelToolName.Size = new System.Drawing.Size(62, 13);
            this.labelToolName.TabIndex = 6;
            this.labelToolName.Text = "Tool Name:";
            // 
            // textBoxCreationDate
            // 
            this.textBoxCreationDate.Location = new System.Drawing.Point(118, 40);
            this.textBoxCreationDate.Name = "textBoxCreationDate";
            this.textBoxCreationDate.ReadOnly = true;
            this.textBoxCreationDate.ShortcutsEnabled = false;
            this.textBoxCreationDate.Size = new System.Drawing.Size(216, 20);
            this.textBoxCreationDate.TabIndex = 5;
            // 
            // labelCreationDate
            // 
            this.labelCreationDate.AutoSize = true;
            this.labelCreationDate.Location = new System.Drawing.Point(37, 43);
            this.labelCreationDate.Name = "labelCreationDate";
            this.labelCreationDate.Size = new System.Drawing.Size(75, 13);
            this.labelCreationDate.TabIndex = 4;
            this.labelCreationDate.Text = "Creation Date:";
            // 
            // textBoxPluginName
            // 
            this.textBoxPluginName.Location = new System.Drawing.Point(118, 15);
            this.textBoxPluginName.Name = "textBoxPluginName";
            this.textBoxPluginName.ReadOnly = true;
            this.textBoxPluginName.ShortcutsEnabled = false;
            this.textBoxPluginName.Size = new System.Drawing.Size(216, 20);
            this.textBoxPluginName.TabIndex = 3;
            // 
            // labelPluginName
            // 
            this.labelPluginName.AutoSize = true;
            this.labelPluginName.Location = new System.Drawing.Point(42, 18);
            this.labelPluginName.Name = "labelPluginName";
            this.labelPluginName.Size = new System.Drawing.Size(70, 13);
            this.labelPluginName.TabIndex = 2;
            this.labelPluginName.Text = "Plugin Name:";
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 342);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.buttonUnpack);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlgxUnpacker {version}";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.Button buttonOpenFolder;
        private Controls.ButtonEx buttonUnpack;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label labelPostBuildCommand;
        private Controls.ViewOnlyTextBox textBoxPostBuildCommand;
        private Controls.ViewOnlyTextBox textBoxPreBuildCommand;
        private System.Windows.Forms.Label labelPreBuildCommand;
        private Controls.ViewOnlyTextBox textBoxToolName;
        private System.Windows.Forms.Label labelToolName;
        private Controls.ViewOnlyTextBox textBoxCreationDate;
        private System.Windows.Forms.Label labelCreationDate;
        private Controls.ViewOnlyTextBox textBoxPluginName;
        private System.Windows.Forms.Label labelPluginName;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFileInfoToolStripMenuItem;
    }
}

