namespace DatabaseViewer.WinForms
{
    partial class SelectConnStringForm
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
            this.connStrCb = new System.Windows.Forms.ComboBox();
            this.connStrLabel = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connStrCb
            // 
            this.connStrCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.connStrCb.FormattingEnabled = true;
            this.connStrCb.Location = new System.Drawing.Point(136, 9);
            this.connStrCb.Name = "connStrCb";
            this.connStrCb.Size = new System.Drawing.Size(334, 24);
            this.connStrCb.TabIndex = 0;
            // 
            // connStrLabel
            // 
            this.connStrLabel.AutoSize = true;
            this.connStrLabel.Location = new System.Drawing.Point(12, 12);
            this.connStrLabel.Name = "connStrLabel";
            this.connStrLabel.Size = new System.Drawing.Size(122, 17);
            this.connStrLabel.TabIndex = 1;
            this.connStrLabel.Text = "Connection string:";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(314, 41);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 2;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(395, 41);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 3;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // SelectConnStringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 73);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.connStrLabel);
            this.Controls.Add(this.connStrCb);
            this.MaximizeBox = false;
            this.Name = "SelectConnStringForm";
            this.Text = "DatabaseViewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox connStrCb;
        private System.Windows.Forms.Label connStrLabel;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button CloseBtn;
    }
}