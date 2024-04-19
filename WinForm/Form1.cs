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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            CmbCategory.Items.Add("Celular");
            CmbCategory.Items.Add("TV");
            CmbCategory.Items.Add("Ventilador");
            CmbBrand.Items.Add("Samsung");
            CmbBrand.Items.Add("Sony");
            CmbBrand.Items.Add("Ken Brown");

     
        }

        private void AgregarArticulo()
        {
            AddArticle addArticle = new AddArticle();
            addArticle.ShowDialog();

            if (addArticle.newArticle.code != null)
            {
                Panel previewPanel = new Panel();
                ArticlePreview artPreview = new ArticlePreview(addArticle.newArticle, ref previewPanel);

                flpLista.SuspendLayout();
                flpLista.Controls.Add(previewPanel);
                flpLista.ResumeLayout(true);
                UpdateFlpListaArticle();
            }
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

        private void CmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Article article = new Article();

            string brandName = article.brand.getName();

            int index = CmbBrand.SelectedIndex;


            if (CmbBrand.Items[index].ToString() == brandName)
            {
                //Logica para mostrar el cuadro del producto
            }
           
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Article article = new Article();
            string categoryName = article.category.getName();

            int index = CmbCategory.SelectedIndex;


            if (CmbCategory.Items[index].ToString() == categoryName)
            {
                //Logica para mostrar el cuadro del producto
            }
        }
    }
}
