using DBAccess;
using ModelDomain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        static private int previewArtSize = 125;
        ArticleDBAccess dbAccess = new ArticleDBAccess();

        string searchFilter = "";
        bool brandFilter = false;
        bool categoryFilter = false;
        int brandIndex = 0;
        int categoryIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //inicializa los filter dropdowns
            LoadDBBrandsCategories();
        }

        private void LoadDBBrandsCategories ()
        {
            CmbBrand.Items.Clear();
            CmbCategory.Items.Clear();
            CmbBrand.Items.Add("Todas"); //esta opcion desactiva el filtro
            CmbCategory.Items.Add("Todas"); //esta opcion desactiva el filtro

            foreach (Brand brand in dbAccess.ListBrands())
            {
                CmbBrand.Items.Add(brand);
            }
            foreach (Category category in dbAccess.ListCategories())
            {
                CmbCategory.Items.Add(category);
            }

            CmbBrand.SelectedIndex = 0; //selecciona la primera opcion por defecto
            CmbCategory.SelectedIndex = 0; //selecciona la primera opcion por defecto
        }

        private void LoadDBArticles()
        {
            List<Article> listArticles = dbAccess.ListArticles();
            List<Img> listImages = dbAccess.ListImages();
            Img previewPic = new Img();
            bool filtered = true;

            flpLista.Visible = false;
            flpLista.SuspendLayout();
            flpLista.Controls.Clear();

            foreach (Article article in listArticles)
            {
                filtered = true;
                if (brandFilter && brandIndex != article.idBrand)
                {
                    filtered = false;
                }
                if (categoryFilter && categoryIndex != article.idCategory)
                {
                    filtered = false;
                }
                if (searchFilter != "" && !article.name.ToUpperInvariant().Contains(searchFilter.ToUpperInvariant()))
                {
                    filtered = false;
                }

                if (filtered)
                {
                    foreach (Img img in listImages)
                    {
                        if (article.id == img.articleID)
                        {
                            previewPic = img;
                            break;
                        }
                    }

                    EventHandler clickEvent;
                    clickEvent = (sender, EventArgs) => { ArticleDetails(sender, EventArgs, article.id); };

                    Panel previewPanel = new Panel();
                    ArticlePreview artPreview = new ArticlePreview(article, previewPic, ref previewPanel, clickEvent);
                    flpLista.Controls.Add(previewPanel);
                }
            }
            UpdateFlpListaArticle();
            flpLista.ResumeLayout(true);
            flpLista.Visible = true;
        }

        private void ArticleDetails(object sender, EventArgs e, int id)
        {
            ArticleDetails articleDetails = new ArticleDetails(id);
            //cuando form corra su load, buscara en dbaccess el articulo
            articleDetails.ShowDialog();
            LoadDBArticles();
        }

        private void AddNewArticle()
        {
            //crea la ventana con el nuevo articulo
            AddArticle addArticle = new AddArticle();
            addArticle.ShowDialog();

            //si el articulo es nulo, es porque cancelamos la creacion del articulo
            if (addArticle.newArticle.code != null)
            {
                //si no es asi, creamos un nuevo panel, y una preview de articulo
                //para vincular un articulo en la base de datos con un panel en la lista
                EventHandler clickEvent;
                clickEvent = (sender, EventArgs) => { ArticleDetails(sender, EventArgs, addArticle.newArticle.id); };

                Panel previewPanel = new Panel();
                ArticlePreview artPreview = new ArticlePreview(addArticle.newArticle, addArticle.newImages[0], ref previewPanel, clickEvent);
                //al crear la preview, se encarga de vincular el articleID con el panel en lista

                flpLista.SuspendLayout();
                flpLista.Controls.Add(previewPanel);
                LoadDBArticles();
                UpdateFlpListaArticle();
                flpLista.ResumeLayout(true);

                dbAccess.InsertArticle(addArticle.newArticle, addArticle.newImages);

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AddNewArticle();
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
            if (CmbBrand.SelectedIndex == 0)
            {
                brandFilter = false;
            }
            else
            {
                brandFilter = true;
                brandIndex = CmbBrand.SelectedIndex;
            }
            LoadDBArticles();
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCategory.SelectedIndex == 0)
            {
                categoryFilter = false;
            }
            else
            {
                categoryFilter = true;
                categoryIndex = CmbCategory.SelectedIndex;
            }
            LoadDBArticles();
        }

        private void TxtBoxSearchForArticle_TextChanged(object sender, EventArgs e)
        {
            searchFilter = TxtBoxSearchForArticle.Text;
            LoadDBArticles();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Config configForm = new Config();
            configForm.ShowDialog();
            LoadDBBrandsCategories();
        }
    }
}