using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinForm
{
    public partial class Form1 : Form
    {
        static private int previewArtSize = 125;
        
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
        }

        private void AgregarArticulo()
        {
            Article article = new Article();
            Panel previewPanel = new Panel();
            ArticlePreview artPreview = new ArticlePreview(article, ref previewPanel);

            flpLista.SuspendLayout();
            flpLista.Controls.Add(previewPanel);
            flpLista.ResumeLayout(true);
            UpdateFlpListaArticle();
        }

        private void EliminarArticulo()
        {
            flpLista.SuspendLayout();
            flpLista.Controls.RemoveAt(0);
            flpLista.ResumeLayout(true);
            UpdateFlpListaArticle();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarArticulo();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarArticulo();
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
                    int stretchToFitValue = calculatedWidth / (int)Math.Floor(widthItemAmount);
                    flpLista.Controls[i].Size = new Size(stretchToFitValue, stretchToFitValue);
                }
                else
                {
                    flpLista.Controls[i].Size = new Size(previewArtSize, previewArtSize);
                }
            }
            
        }
    }
}
