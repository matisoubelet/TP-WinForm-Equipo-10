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
            this.btnBusca = new System.Windows.Forms.Button();
            this.pnlLista = new System.Windows.Forms.Panel();
            this.flpLista = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.artPreview = new System.Windows.Forms.Panel();
            this.pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.artPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtBoxBuscarArticulo
            // 
            this.TxtBoxBuscarArticulo.AccessibleName = "TxtBoxBuscarArticulo";
            this.TxtBoxBuscarArticulo.Location = new System.Drawing.Point(60, 24);
            this.TxtBoxBuscarArticulo.Name = "TxtBoxBuscarArticulo";
            this.TxtBoxBuscarArticulo.Size = new System.Drawing.Size(173, 20);
            this.TxtBoxBuscarArticulo.TabIndex = 0;
            // 
            // LblArticulo
            // 
            this.LblArticulo.AccessibleName = "LblArticulo";
            this.LblArticulo.AutoSize = true;
            this.LblArticulo.Location = new System.Drawing.Point(12, 27);
            this.LblArticulo.Name = "LblArticulo";
            this.LblArticulo.Size = new System.Drawing.Size(42, 13);
            this.LblArticulo.TabIndex = 1;
            this.LblArticulo.Text = "Articulo";
            // 
            // btnBusca
            // 
            this.btnBusca.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnBusca.Location = new System.Drawing.Point(239, 24);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(56, 22);
            this.btnBusca.TabIndex = 3;
            this.btnBusca.Text = "Buscar";
            this.btnBusca.UseVisualStyleBackColor = true;
            // 
            // pnlLista
            // 
            this.pnlLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLista.Controls.Add(this.flpLista);
            this.pnlLista.Location = new System.Drawing.Point(15, 51);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Size = new System.Drawing.Size(773, 486);
            this.pnlLista.TabIndex = 5;
            // 
            // flpLista
            // 
            this.flpLista.AutoScroll = true;
            this.flpLista.AutoSize = true;
            this.flpLista.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLista.Location = new System.Drawing.Point(0, 0);
            this.flpLista.Name = "flpLista";
            this.flpLista.Size = new System.Drawing.Size(771, 484);
            this.flpLista.TabIndex = 0;
            this.flpLista.SizeChanged += new System.EventHandler(this.flpLista_SizeChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnAgregar.Location = new System.Drawing.Point(731, 24);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(56, 22);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnEliminar.Location = new System.Drawing.Point(669, 24);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(56, 22);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 113);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(5, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(83, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // artPreview
            // 
            this.artPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.artPreview.Controls.Add(this.label2);
            this.artPreview.Controls.Add(this.label1);
            this.artPreview.Controls.Add(this.pictureBox1);
            this.artPreview.Location = new System.Drawing.Point(466, 12);
            this.artPreview.Name = "artPreview";
            this.artPreview.Padding = new System.Windows.Forms.Padding(5);
            this.artPreview.Size = new System.Drawing.Size(125, 125);
            this.artPreview.TabIndex = 0;
            this.artPreview.Visible = false;
            // 
            // Form1
            // 
            this.AccessibleName = "FormPrincipal";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.artPreview);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pnlLista);
            this.Controls.Add(this.btnBusca);
            this.Controls.Add(this.LblArticulo);
            this.Controls.Add(this.TxtBoxBuscarArticulo);
            this.MinimumSize = new System.Drawing.Size(195, 250);
            this.Name = "Form1";
            this.Text = "Actividad 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlLista.ResumeLayout(false);
            this.pnlLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.artPreview.ResumeLayout(false);
            this.artPreview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBoxBuscarArticulo;
        private System.Windows.Forms.Label LblArticulo;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.Panel pnlLista;
        private System.Windows.Forms.FlowLayoutPanel flpLista;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel artPreview;
    }
}

