using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelDomain;
using DBAccess;

namespace WinForm
{
    public partial class AddArticle : Form
    {

        public AddArticle()
        {
            InitializeComponent();
        }

        ArticleDBAccess dbAccess = new ArticleDBAccess();
        public Article newArticle = new Article();
        public Img newImage = new Img();

        public void Agregar_Click(object sender, EventArgs e)
        { 

            //Toma todos los valores ingresados y los pone en el nuevo Articulo creado

            newArticle.code = tbxCode.Text;
            newArticle.name = tbxName.Text;
            newArticle.desc = tbxDesc.Text;
            newArticle.price = float.Parse(tbxPrice.Text);
            newArticle.idBrand = ((Brand)cboxBrand.SelectedItem).GetID();
            newArticle.idCategory = ((Category)cboxCat.SelectedItem).GetID();
            newImage.articleID = dbAccess.GetLastArticleId() + 1;
            this.Close();
        }

        private void AddArticle_Load(object sender, EventArgs e)
        {
            newArticle.code = null;

            foreach (Category category in dbAccess.ListCategories())
            {
                cboxCat.Items.Add(category);
            }
            foreach (Brand brand in dbAccess.ListBrands())
            {
                cboxBrand.Items.Add(brand);
            }

            cboxCat.SelectedIndex = 0; //selecciona la primera opcion por defecto
            cboxBrand.SelectedIndex = 0; //selecciona la primera opcion por defecto
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            //Guarda una imagen (de momento una sola, pero tienen que ser varias, o se podrian
            //añadir al editar el articulo)

            //AUN NO GUARDA LA IMAGEN EN NINGUN LADO!!!!!

            try
            {   //Pide que se ingrese la ubicacion de la imagen que se esta buscando, y especifica el tipo de archivo que acepta
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files|*.png| All files(*.*)|*.*";

                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Si todo esta bien, toma la img y la guarda en el PictureBox
                    newImage.imageUrl = dialog.FileName;
                    pctrBox.ImageLocation = newImage.imageUrl;
                }
            }
            catch (Exception) 
            { 
                //En caso de error, enseña estos textos en lugar de romper
                MessageBox.Show("Ocurrio un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
