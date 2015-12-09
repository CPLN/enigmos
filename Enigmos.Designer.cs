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
            this.bottomLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.btnHint = new System.Windows.Forms.Button();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.bottomLayout.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxAnswer
            // 
            this.tbxAnswer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbxAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.tbxAnswer.Location = new System.Drawing.Point(435, 30);
            this.tbxAnswer.Margin = new System.Windows.Forms.Padding(0, 0, 3, 12);
            this.tbxAnswer.Name = "tbxAnswer";
            this.tbxAnswer.Size = new System.Drawing.Size(512, 44);
            this.tbxAnswer.TabIndex = 0;
            // 
            // bottomLayout
            // 
            this.bottomLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomLayout.AutoSize = true;
            this.bottomLayout.ColumnCount = 5;
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomLayout.Controls.Add(this.btnSkip, 0, 0);
            this.bottomLayout.Controls.Add(this.tbxAnswer, 3, 0);
            this.bottomLayout.Controls.Add(this.btnValidate, 4, 0);
            this.bottomLayout.Controls.Add(this.lblId, 2, 0);
            this.bottomLayout.Controls.Add(this.btnHint, 1, 0);
            this.bottomLayout.Location = new System.Drawing.Point(3, 423);
            this.bottomLayout.Name = "bottomLayout";
            this.bottomLayout.RowCount = 1;
            this.bottomLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomLayout.Size = new System.Drawing.Size(1089, 86);
            this.bottomLayout.TabIndex = 1;
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSkip.AutoSize = true;
            this.btnSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.btnSkip.Location = new System.Drawing.Point(12, 27);
            this.btnSkip.Margin = new System.Windows.Forms.Padding(12, 0, 3, 12);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(126, 47);
            this.btnSkip.TabIndex = 2;
            this.btnSkip.Text = "Passer";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.Skip);
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnValidate.AutoSize = true;
            this.btnValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.btnValidate.Location = new System.Drawing.Point(950, 27);
            this.btnValidate.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(127, 47);
            this.btnValidate.TabIndex = 1;
            this.btnValidate.Text = "Valider";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.Validate);
            // 
            // lblId
            // 
            this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lblId.ForeColor = System.Drawing.Color.White;
            this.lblId.Location = new System.Drawing.Point(288, 0);
            this.lblId.Margin = new System.Windows.Forms.Padding(0, 0, 3, 12);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(144, 74);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "[Aucune énigme]";
            // 
            // btnHint
            // 
            this.btnHint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnHint.AutoSize = true;
            this.btnHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.btnHint.Location = new System.Drawing.Point(141, 27);
            this.btnHint.Margin = new System.Windows.Forms.Padding(0, 0, 3, 12);
            this.btnHint.Name = "btnHint";
            this.btnHint.Size = new System.Drawing.Size(44, 47);
            this.btnHint.TabIndex = 3;
            this.btnHint.Text = "?";
            this.btnHint.UseVisualStyleBackColor = true;
            this.btnHint.Click += new System.EventHandler(this.Hint);
            // 
            // mainLayout
            // 
            this.mainLayout.AutoSize = true;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.bottomLayout, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.Size = new System.Drawing.Size(1095, 512);
            this.mainLayout.TabIndex = 2;
            this.mainLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.mainLayout_Paint);
            // 
            // Enigmos
            // 
            this.AcceptButton = this.btnValidate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1095, 512);
            this.Controls.Add(this.mainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1095, 512);
            this.Name = "Enigmos";
            this.Text = "Enigmos";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.bottomLayout.ResumeLayout(false);
            this.bottomLayout.PerformLayout();
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxAnswer;
        private System.Windows.Forms.TableLayoutPanel bottomLayout;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Button btnHint;

    }
}

