namespace WinForm
{
    partial class AddArticle
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
            this.Agregar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxDesc = new System.Windows.Forms.TextBox();
            this.tbxPrice = new System.Windows.Forms.TextBox();
            this.cboxBrand = new System.Windows.Forms.ComboBox();
            this.cboxCat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnImg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Agregar
            // 
            this.Agregar.AccessibleName = "btnAdd";
            this.Agregar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Agregar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Agregar.Location = new System.Drawing.Point(105, 396);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(94, 45);
            this.Agregar.TabIndex = 0;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = false;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // button2
            // 
            this.button2.AccessibleName = "btnCancel";
            this.button2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.Location = new System.Drawing.Point(225, 396);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // tbxCode
            // 
            this.tbxCode.AccessibleName = "tbxCode";
            this.tbxCode.Location = new System.Drawing.Point(37, 66);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(162, 20);
            this.tbxCode.TabIndex = 2;
            // 
            // tbxName
            // 
            this.tbxName.AccessibleName = "tbxName";
            this.tbxName.Location = new System.Drawing.Point(225, 66);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(162, 20);
            this.tbxName.TabIndex = 3;
            // 
            // tbxDesc
            // 
            this.tbxDesc.AccessibleName = "txbDesc";
            this.tbxDesc.Location = new System.Drawing.Point(37, 147);
            this.tbxDesc.Name = "tbxDesc";
            this.tbxDesc.Size = new System.Drawing.Size(162, 20);
            this.tbxDesc.TabIndex = 4;
            // 
            // tbxPrice
            // 
            this.tbxPrice.AccessibleName = "tbxPrice";
            this.tbxPrice.Location = new System.Drawing.Point(225, 147);
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.Size = new System.Drawing.Size(162, 20);
            this.tbxPrice.TabIndex = 5;
            // 
            // cboxBrand
            // 
            this.cboxBrand.AccessibleName = "cboxBrand";
            this.cboxBrand.FormattingEnabled = true;
            this.cboxBrand.Location = new System.Drawing.Point(37, 235);
            this.cboxBrand.Name = "cboxBrand";
            this.cboxBrand.Size = new System.Drawing.Size(162, 21);
            this.cboxBrand.TabIndex = 6;
            // 
            // cboxCat
            // 
            this.cboxCat.AccessibleName = "cboxCat";
            this.cboxCat.FormattingEnabled = true;
            this.cboxCat.Location = new System.Drawing.Point(225, 235);
            this.cboxCat.Name = "cboxCat";
            this.cboxCat.Size = new System.Drawing.Size(162, 21);
            this.cboxCat.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AccessibleName = "lblCode";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AccessibleName = "lblName";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AccessibleName = "lblDesc";
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Descripción";
            // 
            // label4
            // 
            this.label4.AccessibleName = "lblPrice";
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AccessibleName = "lblBrand";
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Marca";
            // 
            // label6
            // 
            this.label6.AccessibleName = "lblCategory";
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(288, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Categoria";
            // 
            // btnImg
            // 
            this.btnImg.AccessibleName = "btnImg";
            this.btnImg.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImg.Location = new System.Drawing.Point(149, 305);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(134, 30);
            this.btnImg.TabIndex = 14;
            this.btnImg.Text = "Agregar Imagen";
            this.btnImg.UseVisualStyleBackColor = false;
            // 
            // AddArticle
            // 
            this.AccessibleName = "AddArt";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(452, 476);
            this.Controls.Add(this.btnImg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxCat);
            this.Controls.Add(this.cboxBrand);
            this.Controls.Add(this.tbxPrice);
            this.Controls.Add(this.tbxDesc);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.tbxCode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Agregar);
            this.Name = "AddArticle";
            this.Text = "AddArticle";
            this.Load += new System.EventHandler(this.AddArticle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxDesc;
        private System.Windows.Forms.TextBox tbxPrice;
        private System.Windows.Forms.ComboBox cboxBrand;
        private System.Windows.Forms.ComboBox cboxCat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnImg;
    }
}