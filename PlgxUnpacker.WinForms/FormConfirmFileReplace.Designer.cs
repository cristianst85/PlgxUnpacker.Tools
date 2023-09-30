namespace PlgxUnpacker
{
    partial class FormConfirmFileReplace
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonYes = new System.Windows.Forms.Button();
            this.buttonYesAll = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.buttonNoAll = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(257, 106);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.Location = new System.Drawing.Point(33, 77);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(75, 23);
            this.buttonYes.TabIndex = 3;
            this.buttonYes.Text = "&Yes";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.ButtonYes_Click);
            // 
            // buttonYesAll
            // 
            this.buttonYesAll.Location = new System.Drawing.Point(114, 77);
            this.buttonYesAll.Name = "buttonYesAll";
            this.buttonYesAll.Size = new System.Drawing.Size(75, 23);
            this.buttonYesAll.TabIndex = 4;
            this.buttonYesAll.Text = "Yes to &All";
            this.buttonYesAll.UseVisualStyleBackColor = true;
            this.buttonYesAll.Click += new System.EventHandler(this.ButtonYesAll_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.Location = new System.Drawing.Point(33, 106);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(75, 23);
            this.buttonNo.TabIndex = 5;
            this.buttonNo.Text = "&No";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.ButtonNo_Click);
            // 
            // buttonNoAll
            // 
            this.buttonNoAll.Location = new System.Drawing.Point(114, 106);
            this.buttonNoAll.Name = "buttonNoAll";
            this.buttonNoAll.Size = new System.Drawing.Size(75, 23);
            this.buttonNoAll.TabIndex = 6;
            this.buttonNoAll.Text = "No to A&ll";
            this.buttonNoAll.UseVisualStyleBackColor = true;
            this.buttonNoAll.Click += new System.EventHandler(this.ButtonNoAll_Click);
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(30, 17);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(302, 48);
            this.label.TabIndex = 2;
            this.label.Text = "The destination already has a file named \"{0}\". Would you like to replace the exi" +
    "sting file?";
            // 
            // pictureBoxStatus
            // 
            this.pictureBoxStatus.ErrorImage = null;
            this.pictureBoxStatus.Image = global::PlgxUnpacker.Properties.Resources.error_error;
            this.pictureBoxStatus.Location = new System.Drawing.Point(13, 16);
            this.pictureBoxStatus.Name = "pictureBoxStatus";
            this.pictureBoxStatus.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxStatus.TabIndex = 13;
            this.pictureBoxStatus.TabStop = false;
            // 
            // FormConfirmFileReplace
            // 
            this.AcceptButton = this.buttonYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(344, 141);
            this.Controls.Add(this.pictureBoxStatus);
            this.Controls.Add(this.label);
            this.Controls.Add(this.buttonNoAll);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonYesAll);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfirmFileReplace";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirm File Replace";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button buttonYesAll;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Button buttonNoAll;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBoxStatus;
    }
}