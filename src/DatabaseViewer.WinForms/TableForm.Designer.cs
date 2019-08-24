namespace DatabaseViewer.WinForms
{
    partial class TableForm
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
            this.tableTreeView = new Aga.Controls.Tree.TreeViewAdv();
            this.SuspendLayout();
            // 
            // tableTreeView
            // 
            this.tableTreeView.BackColor = System.Drawing.SystemColors.Window;
            this.tableTreeView.DefaultToolTipProvider = null;
            this.tableTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTreeView.DragDropMarkColor = System.Drawing.Color.Black;
            this.tableTreeView.LineColor = System.Drawing.SystemColors.ControlDark;
            this.tableTreeView.Location = new System.Drawing.Point(0, 0);
            this.tableTreeView.Model = null;
            this.tableTreeView.Name = "tableTreeView";
            this.tableTreeView.SelectedNode = null;
            this.tableTreeView.Size = new System.Drawing.Size(682, 453);
            this.tableTreeView.TabIndex = 0;
            this.tableTreeView.Text = "tableTreeView";
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.tableTreeView);
            this.MinimumSize = new System.Drawing.Size(600, 100);
            this.Name = "TableForm";
            this.Text = "DatabaseViewer";
            this.Load += new System.EventHandler(this.TableForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Aga.Controls.Tree.TreeViewAdv tableTreeView;
    }
}

