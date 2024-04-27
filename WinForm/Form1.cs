﻿using DBAccess;
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

        //TODO: Carga los articulos filtrados.
        private void LoadFilteredDBArticles(List<Article> list)
        {
            List<Img> image = dbAccess.ListImages();
            Img placeholder = new Img();
            flpLista.SuspendLayout();

            foreach (Article article in list)
            {
                foreach (Img img in image)
                {
                    if (article.id == img.articleID)
                    {
                        placeholder = img;
                    }
                }
                Panel previewPanel = new Panel();
                ArticlePreview artPreview = new ArticlePreview(article, placeholder, ref previewPanel);
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

        //TODO: Filtro del comboBox de Marca.
        private void CmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Brand> BrandList = dbAccess.ListBrands(); // Obtener la lista de categorías
            string selectedBrandName = CmbBrand.Text;

            if (selectedBrandName == "Todas")
            {
                // Si se selecciona "Todas", cargar todos los artículos sin filtrar por categoría
                flpLista.Controls.Clear();
                LoadDBArticles();
            }
            else
            {
                // Buscar la categoría seleccionada en la lista de categorías
                Brand selectedBrand = BrandList.Find(b => b.name == selectedBrandName);

                if (selectedBrand != null)
                {
                    // Obtener el ID de la categoría seleccionada
                    int selectedBrandId = selectedBrand.id;

                    // Obtener la lista de artículos filtrados por la categoría seleccionada
                    List<Article> filteredArticles = dbAccess.ListArticles().FindAll(article => article.idBrand == selectedBrandId);

                    // Cargar los artículos filtrados
                    flpLista.Controls.Clear();
                    LoadFilteredDBArticles(filteredArticles);
                }
            }

            UpdateFlpListaArticle();
        }

        //TODO: Filtro del comboBox de Categoria.
        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Category> categoryList = dbAccess.ListCategories(); // Obtener la lista de categorías
            string selectedCategoryName = CmbCategory.Text;

            if (selectedCategoryName == "Todas")
            {
                // Si se selecciona "Todas", cargar todos los artículos sin filtrar por categoría
                flpLista.Controls.Clear();
                LoadDBArticles();
            }
            else
            {
                // Buscar la categoría seleccionada en la lista de categorías
                Category selectedCategory = categoryList.Find(c => c.name == selectedCategoryName);

                if (selectedCategory != null)
                {
                    // Obtener el ID de la categoría seleccionada
                    int selectedCategoryId = selectedCategory.id;

                    // Obtener la lista de artículos filtrados por la categoría seleccionada
                    List<Article> filteredArticles = dbAccess.ListArticles().FindAll(article => article.idCategory == selectedCategoryId);

                    // Cargar los artículos filtrados
                    flpLista.Controls.Clear();
                    LoadFilteredDBArticles(filteredArticles);
                }
            }
            UpdateFlpListaArticle();
        }

            //TODO: Filtra rapido a medida que se escribe.
            private void TxtBoxSearchForArticle_TextChanged(object sender, EventArgs e)
        {
            List<Article> artList = dbAccess.ListArticles(); //Trae de la db la lista completa de articulos
            List<Article> filterList; //Crea una lista de articulos
            string filter = TxtBoxSearchForArticle.Text; //Guarda el texto de la txtBox en la cadena filtro

            //Si tiene datos aplica el filtro, sino muestra todos los artículos
            flpLista.Controls.Clear(); //Limpia la pantalla de los paneles
            filterList = artList.FindAll(x => (x.name.ToUpperInvariant().Contains(filter.ToUpperInvariant()))); //Guarda los articulos que coincidan con lo que se escribe en la txtBox
            LoadFilteredDBArticles(filterList); //Muestra los paneles de articulo en pantalla
        }
    }
}
