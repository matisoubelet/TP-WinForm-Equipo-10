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
            //inicializa los filter dropdowns; deberia leerlos desde la base de datos

            CmbCategory.Items.Add("Ninguna"); //esta opcion desactiva el filtro
            CmbCategory.Items.Add("Celular");
            CmbCategory.Items.Add("TV");
            CmbCategory.Items.Add("Ventilador");
            CmbCategory.SelectedIndex = 0; //selecciona la primera opcion por defecto

            CmbBrand.Items.Add("Ninguna"); //esta opcion desactiva el filtro
            CmbBrand.Items.Add("Samsung");
            CmbBrand.Items.Add("Sony");
            CmbBrand.Items.Add("Ken Brown");
            CmbBrand.SelectedIndex = 0; //selecciona la primera opcion por defecto
        }

        private void AgregarArticulo()
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
                ArticlePreview artPreview = new ArticlePreview(addArticle.newArticle, ref previewPanel);
                //al crear la preview, se encarga de vincular el articleID con el panel en lista

                flpLista.SuspendLayout();
                flpLista.Controls.Add(previewPanel);
                flpLista.ResumeLayout(true);
                UpdateFlpListaArticle();

                //por aca deberiamos agregar el articulo creado a la base de datos, no solo en la app
            }
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

            //este codigo deberia cambiar un bool brandFilter = true si ->
            //(cmbbrand.items[cmbbrand.selectedindex].tostring() == "Ninguna")
            //y llamamos a actualizar la lista (func)
            //si no, brandFilter = false y llamamos a actualizar la lista (func)

            //actualizar la lista remueve (?) todos los items y los agrega de la base de datos segun ->
            //brandFilter = false -> agrega todos los articulos
            //brandFilter = true -> agrega solo los articulos que comparten brand con selectedindex
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

            //este codigo deberia cambiar un bool categoryFilter = true si ->
            //(cmbcategory.items[cmbcategory.selectedindex].tostring() == "Ninguna")
            //y llamamos a actualizar la lista (func)
            //si no, categoryFilter = false y llamamos a actualizar la lista (func)

            //actualizar la lista remueve (?) todos los items y los agrega de la base de datos segun ->
            //categoryFilter = false -> agrega todos los articulos
            //categoryFilter = true -> agrega solo los articulos que comparten category con selectedindex
        }
    }
}
