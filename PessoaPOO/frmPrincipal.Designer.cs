
namespace PessoaPOO
{
    partial class frmPrincipal
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
            this.btnPessoaPOO = new System.Windows.Forms.Button();
            this.btnUsuarioPOO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPessoaPOO
            // 
            this.btnPessoaPOO.Location = new System.Drawing.Point(9, 10);
            this.btnPessoaPOO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPessoaPOO.Name = "btnPessoaPOO";
            this.btnPessoaPOO.Size = new System.Drawing.Size(206, 44);
            this.btnPessoaPOO.TabIndex = 0;
            this.btnPessoaPOO.Text = "PessoaPOO";
            this.btnPessoaPOO.UseVisualStyleBackColor = true;
            this.btnPessoaPOO.Click += new System.EventHandler(this.btnPessoaPOO_Click);
            // 
            // btnUsuarioPOO
            // 
            this.btnUsuarioPOO.Location = new System.Drawing.Point(9, 58);
            this.btnUsuarioPOO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUsuarioPOO.Name = "btnUsuarioPOO";
            this.btnUsuarioPOO.Size = new System.Drawing.Size(206, 44);
            this.btnUsuarioPOO.TabIndex = 1;
            this.btnUsuarioPOO.Text = "UsuarioPOO";
            this.btnUsuarioPOO.UseVisualStyleBackColor = true;
            this.btnUsuarioPOO.Click += new System.EventHandler(this.btnPessoaPOOModificado_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 111);
            this.Controls.Add(this.btnUsuarioPOO);
            this.Controls.Add(this.btnPessoaPOO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPessoaPOO;
        private System.Windows.Forms.Button btnUsuarioPOO;
    }
}