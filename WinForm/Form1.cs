using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        private int previewArtSize = 125;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AgregarArticulo();
            AgregarArticulo();
            AgregarArticulo();
            AgregarArticulo();
            UpdateFlpListaArticle();
        }

        private void AgregarArticulo()
        {
            PictureBox pBox = new PictureBox()
            {
                Anchor = AnchorStyles.None,
                BackColor = Color.Thistle,
                MinimumSize = new Size(previewArtSize, previewArtSize),
                Size = new Size(previewArtSize, previewArtSize),
            };
            flpLista.SuspendLayout();
            flpLista.Controls.Add(pBox);
            flpLista.ResumeLayout(true);
            UpdateFlpListaArticle();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarArticulo();
        }

        private void flpLista_SizeChanged(object sender, EventArgs e)
        {
            UpdateFlpListaArticle();

        }

        private void UpdateFlpListaArticle()
        {
            int calculatedWidth = (flpLista.Size.Width - 25);
            float widthItemAmount = calculatedWidth / previewArtSize;

            for (int i = 0; i < flpLista.Controls.Count; i++)
            {
                if (calculatedWidth < flpLista.Controls.Count * previewArtSize)
                {
                    flpLista.Controls[i].Size = new Size(calculatedWidth / (int)Math.Floor(widthItemAmount), 125);
                    Debug.WriteLine(flpLista.Controls[i].Size);
                }
                else
                {
                    flpLista.Controls[i].Size = new Size(previewArtSize, previewArtSize);
                }
            }
        }
    }
}
