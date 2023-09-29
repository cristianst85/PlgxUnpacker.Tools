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
            this.tabPageIntegration = new System.Windows.Forms.TabPage();
            this.groupBoxShellContextMenu = new System.Windows.Forms.GroupBox();
            this.checkBoxShowOpenFileMenuItem = new System.Windows.Forms.CheckBox();
            this.checkBoxShowUnpackFileHereMenuItem = new System.Windows.Forms.CheckBox();
            this.checkBoxShowIcons = new System.Windows.Forms.CheckBox();
            this.groupBoxFileAssociation = new System.Windows.Forms.GroupBox();
            this.checkBoxAssociateWithPlgxFiles = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageIntegration.SuspendLayout();
            this.groupBoxShellContextMenu.SuspendLayout();
            this.groupBoxFileAssociation.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(232, 226);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(151, 226);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // tabPageIntegration
            // 
            this.tabPageIntegration.Controls.Add(this.groupBoxShellContextMenu);
            this.tabPageIntegration.Controls.Add(this.groupBoxFileAssociation);
            this.tabPageIntegration.Location = new System.Drawing.Point(4, 22);
            this.tabPageIntegration.Name = "tabPageIntegration";
            this.tabPageIntegration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIntegration.Size = new System.Drawing.Size(287, 182);
            this.tabPageIntegration.TabIndex = 0;
            this.tabPageIntegration.Text = "Integration";
            this.tabPageIntegration.UseVisualStyleBackColor = true;
            // 
            // groupBoxShellContextMenu
            // 
            this.groupBoxShellContextMenu.Controls.Add(this.checkBoxShowOpenFileMenuItem);
            this.groupBoxShellContextMenu.Controls.Add(this.checkBoxShowUnpackFileHereMenuItem);
            this.groupBoxShellContextMenu.Controls.Add(this.checkBoxShowIcons);
            this.groupBoxShellContextMenu.Location = new System.Drawing.Point(3, 3);
            this.groupBoxShellContextMenu.Name = "groupBoxShellContextMenu";
            this.groupBoxShellContextMenu.Size = new System.Drawing.Size(280, 105);
            this.groupBoxShellContextMenu.TabIndex = 1;
            this.groupBoxShellContextMenu.TabStop = false;
            this.groupBoxShellContextMenu.Text = "Shell Context Menu";
            // 
            // checkBoxShowOpenFileMenuItem
            // 
            this.checkBoxShowOpenFileMenuItem.AutoSize = true;
            this.checkBoxShowOpenFileMenuItem.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxShowOpenFileMenuItem.Location = new System.Drawing.Point(19, 19);
            this.checkBoxShowOpenFileMenuItem.Name = "checkBoxShowOpenFileMenuItem";
            this.checkBoxShowOpenFileMenuItem.Size = new System.Drawing.Size(165, 17);
            this.checkBoxShowOpenFileMenuItem.TabIndex = 2;
            this.checkBoxShowOpenFileMenuItem.Text = "Show \'Open File...\' menu item";
            this.checkBoxShowOpenFileMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxShowOpenFileMenuItem.ThreeState = true;
            this.checkBoxShowOpenFileMenuItem.UseVisualStyleBackColor = true;
            this.checkBoxShowOpenFileMenuItem.CheckStateChanged += new System.EventHandler(this.CheckBoxShowOpenFileMenuItem_CheckStateChanged);
            // 
            // checkBoxShowUnpackFileHereMenuItem
            // 
            this.checkBoxShowUnpackFileHereMenuItem.AutoSize = true;
            this.checkBoxShowUnpackFileHereMenuItem.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxShowUnpackFileHereMenuItem.Location = new System.Drawing.Point(19, 42);
            this.checkBoxShowUnpackFileHereMenuItem.Name = "checkBoxShowUnpackFileHereMenuItem";
            this.checkBoxShowUnpackFileHereMenuItem.Size = new System.Drawing.Size(194, 17);
            this.checkBoxShowUnpackFileHereMenuItem.TabIndex = 3;
            this.checkBoxShowUnpackFileHereMenuItem.Text = "Show \'Unpack File Here\' menu item";
            this.checkBoxShowUnpackFileHereMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxShowUnpackFileHereMenuItem.ThreeState = true;
            this.checkBoxShowUnpackFileHereMenuItem.UseVisualStyleBackColor = true;
            this.checkBoxShowUnpackFileHereMenuItem.CheckStateChanged += new System.EventHandler(this.CheckBoxShowUnpackFileHereMenuItem_CheckStateChanged);
            // 
            // checkBoxShowIcons
            // 
            this.checkBoxShowIcons.AutoSize = true;
            this.checkBoxShowIcons.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxShowIcons.Location = new System.Drawing.Point(19, 65);
            this.checkBoxShowIcons.Name = "checkBoxShowIcons";
            this.checkBoxShowIcons.Size = new System.Drawing.Size(228, 17);
            this.checkBoxShowIcons.TabIndex = 4;
            this.checkBoxShowIcons.Text = "Show icons (only in Windows Vista or later)";
            this.checkBoxShowIcons.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxShowIcons.ThreeState = true;
            this.checkBoxShowIcons.UseVisualStyleBackColor = true;
            // 
            // groupBoxFileAssociation
            // 
            this.groupBoxFileAssociation.Controls.Add(this.checkBoxAssociateWithPlgxFiles);
            this.groupBoxFileAssociation.Location = new System.Drawing.Point(3, 112);
            this.groupBoxFileAssociation.Name = "groupBoxFileAssociation";
            this.groupBoxFileAssociation.Size = new System.Drawing.Size(280, 64);
            this.groupBoxFileAssociation.TabIndex = 5;
            this.groupBoxFileAssociation.TabStop = false;
            this.groupBoxFileAssociation.Text = "File Association";
            // 
            // checkBoxAssociateWithPlgxFiles
            // 
            this.checkBoxAssociateWithPlgxFiles.AutoSize = true;
            this.checkBoxAssociateWithPlgxFiles.Location = new System.Drawing.Point(19, 19);
            this.checkBoxAssociateWithPlgxFiles.Name = "checkBoxAssociateWithPlgxFiles";
            this.checkBoxAssociateWithPlgxFiles.Size = new System.Drawing.Size(146, 17);
            this.checkBoxAssociateWithPlgxFiles.TabIndex = 6;
            this.checkBoxAssociateWithPlgxFiles.Text = "Associate with PLGX files";
            this.checkBoxAssociateWithPlgxFiles.ThreeState = true;
            this.checkBoxAssociateWithPlgxFiles.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageIntegration);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(295, 208);
            this.tabControl.TabIndex = 0;
            // 
            // FormOptions
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(319, 261);
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
            this.tabPageIntegration.ResumeLayout(false);
            this.groupBoxShellContextMenu.ResumeLayout(false);
            this.groupBoxShellContextMenu.PerformLayout();
            this.groupBoxFileAssociation.ResumeLayout(false);
            this.groupBoxFileAssociation.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TabPage tabPageIntegration;
        private System.Windows.Forms.GroupBox groupBoxShellContextMenu;
        private System.Windows.Forms.CheckBox checkBoxShowOpenFileMenuItem;
        private System.Windows.Forms.CheckBox checkBoxShowUnpackFileHereMenuItem;
        private System.Windows.Forms.CheckBox checkBoxShowIcons;
        private System.Windows.Forms.GroupBox groupBoxFileAssociation;
        private System.Windows.Forms.CheckBox checkBoxAssociateWithPlgxFiles;
        private System.Windows.Forms.TabControl tabControl;
    }
}