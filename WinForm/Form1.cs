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
        List<ArticlePreview> artPreviews = new List<ArticlePreview>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //inicializa los filter dropdowns

            CmbCategory.Items.Add("Todas"); //esta opcion desactiva el filtro
            CmbBrand.Items.Add("Todas"); //esta opcion desactiva el filtro

            foreach (Category category in dbAccess.ListCategories())
            {
                CmbCategory.Items.Add(category);
            }            
            foreach (Brand brand in dbAccess.ListBrands())
            {
                CmbBrand.Items.Add(brand);
            }

            CmbCategory.SelectedIndex = 0; //selecciona la primera opcion por defecto
            CmbBrand.SelectedIndex = 0; //selecciona la primera opcion por defecto

        
        }

        private void LoadDBArticles()
        {
            List<Article> listArticles = dbAccess.ListArticles();
            List<Img> listImages = dbAccess.ListImages();
            Img image = new Img();
            flpLista.SuspendLayout();

            foreach (Article article in listArticles)
            {
                foreach (Img img in listImages)
                {
                    if (article.id == img.articleID)
                    {
                        image = img;  
                    }
                }
                Panel previewPanel = new Panel();
                ArticlePreview artPreview = new ArticlePreview(article, image, ref previewPanel);
                artPreviews.Add(artPreview);
                flpLista.Controls.Add(previewPanel);
            }
            

            flpLista.ResumeLayout(true);
            UpdateFlpListaArticle();
        }

        private void ArticleDetails(object sender, EventArgs e, int id)
        {
            //instanciar form
            //setea la variable publica del form del id
            //cuando form corra su load, buscara en dbaccess el articulo
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
                Panel previewPanel = new Panel();
                ArticlePreview artPreview = new ArticlePreview(addArticle.newArticle, addArticle.newImages[0], ref previewPanel);
                previewPanel.Click += (sender, EventArgs) => { ArticleDetails(sender, EventArgs, addArticle.newArticle.id); };
                //al crear la preview, se encarga de vincular el articleID con el panel en lista

                flpLista.SuspendLayout();
                flpLista.Controls.Add(previewPanel);
                flpLista.ResumeLayout(true);

                dbAccess.InsertArticle(addArticle.newArticle, addArticle.newImages);

                UpdateFlpListaArticle();

                //por aca deberiamos agregar el articulo creado a la base de datos, no solo en la app
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

            if (CmbBrand.Text == "Todas")
            {
                flpLista.Controls.Clear();
                LoadDBArticles();
            }
            else
            {
                List<Article> list = dbAccess.ListArticles();
                List<Img> image = dbAccess.ListImages();
                Img placeholder = new Img();

                flpLista.Controls.Clear();
                flpLista.SuspendLayout();

                foreach (Brand brand in dbAccess.ListBrands()) // recorre la lista db de marcas 
                {
                    if (brand.name == CmbBrand.Text) //compara los nombres de marcas con el indice de combobox
                    {
                        foreach (Article article in list) //itera la lista de articulos de la DB
                        {
                            if (brand.id == article.id) //Compara los id de articulo y marca
                            {
                                foreach (Img img in image) //itera la lista de Imagenes de la DB
                                {
                                    if (article.id == img.articleID) //Pregunta si hay coincidencia en el id del articulo y el id de la imagen
                                    {
                                        placeholder = img; //guarda la imagen de esa coincidencia en el articulo
                                    }
                                }
                                Panel previewPanel = new Panel();
                                ArticlePreview artPreview = new ArticlePreview(article, placeholder, ref previewPanel);
                                artPreviews.Add(artPreview);
                                flpLista.Controls.Add(previewPanel);
                            }
                        }

                    }

                }
                flpLista.ResumeLayout(true);
                UpdateFlpListaArticle();
            }
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CmbCategory.Text == "Todas")
            {
                flpLista.Controls.Clear();
                LoadDBArticles();
            }
            else
            {
                List<Article> list = dbAccess.ListArticles();
                List<Img> image = dbAccess.ListImages();
                Img placeholder = new Img();

                flpLista.Controls.Clear();
                flpLista.SuspendLayout();

                foreach (Category category in dbAccess.ListCategories()) // recorre la lista db de categorias
                {
                    if (category.name == CmbCategory.Text) //compara los nombres de las categorias con el indice de combobox
                    {
                        foreach (Article article in list) //itera la lista de articulos de la DB
                        {
                            if (category.id == article.id) //Compara los id de articulo y categoria
                            {
                                foreach (Img img in image) //itera la lista de Imagenes de la DB
                                {
                                    if (article.id == img.articleID) //Pregunta si hay coincidencia en el id del articulo y el id de la imagen
                                    {
                                        placeholder = img; //guarda la imagen de esa coincidencia en el articulo
                                    }
                                }
                                Panel previewPanel = new Panel();
                                ArticlePreview artPreview = new ArticlePreview(article, placeholder, ref previewPanel);
                                artPreviews.Add(artPreview);
                                flpLista.Controls.Add(previewPanel);
                            }
                        }

                    }

                }
                flpLista.ResumeLayout(true);
                UpdateFlpListaArticle();
            }
        }
    }
}
