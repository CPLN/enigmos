namespace Cpln.Enigmos
{
    partial class Enigmos
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
            this.tbxAnswer = new System.Windows.Forms.TextBox();
            this.lyAnswer = new System.Windows.Forms.TableLayoutPanel();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.lyAnswer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxAnswer
            // 
            this.tbxAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.tbxAnswer.Location = new System.Drawing.Point(0, 0);
            this.tbxAnswer.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tbxAnswer.Name = "tbxAnswer";
            this.tbxAnswer.Size = new System.Drawing.Size(512, 44);
            this.tbxAnswer.TabIndex = 0;
            // 
            // lyAnswer
            // 
            this.lyAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lyAnswer.ColumnCount = 2;
            this.lyAnswer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.lyAnswer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.lyAnswer.Controls.Add(this.tbxAnswer, 0, 0);
            this.lyAnswer.Controls.Add(this.btnValidate, 1, 0);
            this.lyAnswer.Location = new System.Drawing.Point(372, 453);
            this.lyAnswer.Name = "lyAnswer";
            this.lyAnswer.RowCount = 1;
            this.lyAnswer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lyAnswer.Size = new System.Drawing.Size(640, 44);
            this.lyAnswer.TabIndex = 1;
            // 
            // btnValidate
            // 
            this.btnValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.btnValidate.Location = new System.Drawing.Point(515, 0);
            this.btnValidate.Margin = new System.Windows.Forms.Padding(0);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(125, 44);
            this.btnValidate.TabIndex = 1;
            this.btnValidate.Text = "Valider";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.Validate);
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.btnSkip.Location = new System.Drawing.Point(12, 455);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(125, 45);
            this.btnSkip.TabIndex = 2;
            this.btnSkip.Text = "Passer";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.Skip);
            // 
            // Enigmos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 512);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.lyAnswer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Enigmos";
            this.Text = "Enigmos";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.lyAnswer.ResumeLayout(false);
            this.lyAnswer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxAnswer;
        private System.Windows.Forms.TableLayoutPanel lyAnswer;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnSkip;

    }
}

