namespace PlgxUnpacker
{
    partial class FormOptions {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxShowOpenFileMenuItem = new System.Windows.Forms.CheckBox();
            this.checkBoxShowUnpackFileHereMenuItem = new System.Windows.Forms.CheckBox();
            this.checkBoxShowIcons = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableWindowsShellIntegration = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxAssociateWithPlgxFiles = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(232, 261);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOK.Location = new System.Drawing.Point(151, 261);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(287, 217);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Integration";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxShowOpenFileMenuItem);
            this.groupBox1.Controls.Add(this.checkBoxShowUnpackFileHereMenuItem);
            this.groupBox1.Controls.Add(this.checkBoxShowIcons);
            this.groupBox1.Controls.Add(this.checkBoxEnableWindowsShellIntegration);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 113);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shell Context Menu";
            // 
            // checkBoxShowOpenFileMenuItem
            // 
            this.checkBoxShowOpenFileMenuItem.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxShowOpenFileMenuItem.Location = new System.Drawing.Point(30, 42);
            this.checkBoxShowOpenFileMenuItem.Name = "checkBoxShowOpenFileMenuItem";
            this.checkBoxShowOpenFileMenuItem.Size = new System.Drawing.Size(158, 17);
            this.checkBoxShowOpenFileMenuItem.TabIndex = 3;
            this.checkBoxShowOpenFileMenuItem.Text = "Show \'Open File\' menu item";
            this.checkBoxShowOpenFileMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxShowOpenFileMenuItem.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowUnpackFileHereMenuItem
            // 
            this.checkBoxShowUnpackFileHereMenuItem.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxShowUnpackFileHereMenuItem.Location = new System.Drawing.Point(30, 65);
            this.checkBoxShowUnpackFileHereMenuItem.Name = "checkBoxShowUnpackFileHereMenuItem";
            this.checkBoxShowUnpackFileHereMenuItem.Size = new System.Drawing.Size(197, 17);
            this.checkBoxShowUnpackFileHereMenuItem.TabIndex = 4;
            this.checkBoxShowUnpackFileHereMenuItem.Text = "Show \'Unpack File Here\' menu item";
            this.checkBoxShowUnpackFileHereMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxShowUnpackFileHereMenuItem.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowIcons
            // 
            this.checkBoxShowIcons.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxShowIcons.Location = new System.Drawing.Point(30, 88);
            this.checkBoxShowIcons.Name = "checkBoxShowIcons";
            this.checkBoxShowIcons.Size = new System.Drawing.Size(240, 19);
            this.checkBoxShowIcons.TabIndex = 5;
            this.checkBoxShowIcons.Text = "Show icons (only in Windows Vista or later)";
            this.checkBoxShowIcons.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxShowIcons.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableWindowsShellIntegration
            // 
            this.checkBoxEnableWindowsShellIntegration.AutoSize = true;
            this.checkBoxEnableWindowsShellIntegration.Location = new System.Drawing.Point(12, 19);
            this.checkBoxEnableWindowsShellIntegration.Name = "checkBoxEnableWindowsShellIntegration";
            this.checkBoxEnableWindowsShellIntegration.Size = new System.Drawing.Size(176, 17);
            this.checkBoxEnableWindowsShellIntegration.TabIndex = 2;
            this.checkBoxEnableWindowsShellIntegration.Text = "Enable cascaded context menu";
            this.checkBoxEnableWindowsShellIntegration.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxAssociateWithPlgxFiles);
            this.groupBox2.Location = new System.Drawing.Point(6, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 87);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Association";
            // 
            // checkBoxAssociateWithPlgxFiles
            // 
            this.checkBoxAssociateWithPlgxFiles.AutoSize = true;
            this.checkBoxAssociateWithPlgxFiles.Location = new System.Drawing.Point(29, 19);
            this.checkBoxAssociateWithPlgxFiles.Name = "checkBoxAssociateWithPlgxFiles";
            this.checkBoxAssociateWithPlgxFiles.Size = new System.Drawing.Size(146, 17);
            this.checkBoxAssociateWithPlgxFiles.TabIndex = 7;
            this.checkBoxAssociateWithPlgxFiles.Text = "Associate with PLGX files";
            this.checkBoxAssociateWithPlgxFiles.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(295, 243);
            this.tabControl.TabIndex = 0;
            // 
            // FormOptions
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(319, 296);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxShowOpenFileMenuItem;
        private System.Windows.Forms.CheckBox checkBoxShowUnpackFileHereMenuItem;
        private System.Windows.Forms.CheckBox checkBoxShowIcons;
        private System.Windows.Forms.CheckBox checkBoxEnableWindowsShellIntegration;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxAssociateWithPlgxFiles;
        private System.Windows.Forms.TabControl tabControl;
    }
}