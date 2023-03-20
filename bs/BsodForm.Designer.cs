using System.Drawing;

namespace bs
{
	partial class BsodForm
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
            this.Smiley = new System.Windows.Forms.Label();
            this.errorText1 = new System.Windows.Forms.Label();
            this.error2 = new System.Windows.Forms.Label();
            this.qrcode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.qrcode)).BeginInit();
            this.SuspendLayout();
            // 
            // Smiley
            // 
            this.Smiley.AutoSize = true;
            this.Smiley.Font = new System.Drawing.Font("Segoe UI", 82F);
            this.Smiley.ForeColor = System.Drawing.Color.White;
            this.Smiley.Location = new System.Drawing.Point(0, 0);
            this.Smiley.Name = "Smiley";
            this.Smiley.Size = new System.Drawing.Size(148, 182);
            this.Smiley.TabIndex = 1;
            this.Smiley.Text = ":(";
            this.Smiley.Click += new System.EventHandler(this.label1_Click);
            // 
            // errorText1
            // 
            this.errorText1.AutoEllipsis = true;
            this.errorText1.AutoSize = true;
            this.errorText1.ForeColor = System.Drawing.Color.White;
            this.errorText1.Location = new System.Drawing.Point(15, 239);
            this.errorText1.Name = "errorText1";
            this.errorText1.Size = new System.Drawing.Size(676, 48);
            this.errorText1.TabIndex = 2;
            this.errorText1.Text = "Your PC ran into a problem and needs to restart. We\'re just collecting some error" +
    " info, and then we\'ll restart for you.\n\n0% complete";
            // 
            // error2
            // 
            this.error2.AutoSize = true;
            
            this.error2.ForeColor = System.Drawing.Color.White;
            this.error2.Location = new System.Drawing.Point(84, 322);
            this.error2.Name = "error2";
            this.error2.Size = new System.Drawing.Size(681, 83);
            this.error2.TabIndex = 3;
            this.error2.Text = "For more information about this issue and possible fixes, visit http://windows.co" +
    "m/stopcode \n\nIf you call a support person, give them this info:\nStop code: CRITI" +
    "CAL_PROCESS_DIED";
            // 
            // qrcode
            // 
            this.qrcode.BackgroundImage = global::bs.Properties.Resources.bsod_qr_code;
            this.qrcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.qrcode.ErrorImage = global::bs.Properties.Resources.bsod_qr_code;
            this.qrcode.InitialImage = global::bs.Properties.Resources.bsod_qr_code;
            this.qrcode.Location = new System.Drawing.Point(-21, 312);
            this.qrcode.Name = "qrcode";
            this.qrcode.Size = new System.Drawing.Size(99, 93);
            this.qrcode.TabIndex = 4;
            this.qrcode.TabStop = false;
            // 
            // BsodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(111)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(1339, 1130);
            this.ControlBox = false;
            this.Controls.Add(this.qrcode);
            this.Controls.Add(this.error2);
            this.Controls.Add(this.errorText1);
            this.Controls.Add(this.Smiley);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BsodForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.qrcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Label Smiley;
        private System.Windows.Forms.Label errorText1;
        private System.Windows.Forms.Label error2;
        private System.Windows.Forms.PictureBox qrcode;
    }
}

