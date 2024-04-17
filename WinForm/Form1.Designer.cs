namespace WinForm
{
    partial class Form1
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
            this.TxtBoxBuscarArticulo = new System.Windows.Forms.TextBox();
            this.LblArticulo = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtBoxBuscarArticulo
            // 
            this.TxtBoxBuscarArticulo.AccessibleName = "TxtBoxBuscarArticulo";
            this.TxtBoxBuscarArticulo.Location = new System.Drawing.Point(542, 24);
            this.TxtBoxBuscarArticulo.Name = "TxtBoxBuscarArticulo";
            this.TxtBoxBuscarArticulo.Size = new System.Drawing.Size(173, 20);
            this.TxtBoxBuscarArticulo.TabIndex = 0;
            // 
            // LblArticulo
            // 
            this.LblArticulo.AccessibleName = "LblArticulo";
            this.LblArticulo.AutoSize = true;
            this.LblArticulo.Location = new System.Drawing.Point(494, 27);
            this.LblArticulo.Name = "LblArticulo";
            this.LblArticulo.Size = new System.Drawing.Size(42, 13);
            this.LblArticulo.TabIndex = 1;
            this.LblArticulo.Text = "Articulo";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.AccessibleName = "BtnBuscar";
            this.BtnBuscar.Enabled = false;
            this.BtnBuscar.Location = new System.Drawing.Point(721, 22);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(56, 23);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AccessibleName = "FormPrincipal";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 539);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.LblArticulo);
            this.Controls.Add(this.TxtBoxBuscarArticulo);
            this.Name = "Form1";
            this.Text = "Actividad 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBoxBuscarArticulo;
        private System.Windows.Forms.Label LblArticulo;
        private System.Windows.Forms.Button BtnBuscar;
    }
}

