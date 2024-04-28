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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Diagnostics;

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
        public List<Img> newImages = new List<Img>();
        int currentImg = 0;

        public void Agregar_Click(object sender, EventArgs e)
        { 

            //Toma todos los valores ingresados y los pone en el nuevo Articulo creado

            newArticle.code = tbxCode.Text;
            newArticle.name = tbxName.Text;
            newArticle.desc = tbxDesc.Text;

            try
            {
                newArticle.price = float.Parse(tbxPrice.Text);
            }
            catch
            {
                newArticle.price = 0;
            }

            newArticle.idBrand = ((Brand)cboxBrand.SelectedItem).GetID();
            newArticle.idCategory = ((Category)cboxCat.SelectedItem).GetID();
            foreach (Img img in newImages)
            {
                img.articleID = dbAccess.GetLastArticleId() + 1;
            }
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

        private void tbxImg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pctrBox.Load(tbxImg.Text);
            }
            catch
            {
                pctrBox.Load("https://static-00.iconduck.com/assets.00/no-image-icon-512x512-lfoanl0w.png");
            }
        }

        private void btnAddImg_Click(object sender, EventArgs e)
        {
            Img newImg = new Img();
            bool validURL;
            Uri uriResult;
            validURL = Uri.TryCreate(tbxImg.Text, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (validURL)
            {
                newImg.imageUrl = tbxImg.Text;
                newImages.Add(newImg);
                currentImg = newImages.Count - 1;
            }
            tbxImg.Text = "";
        }

        private void btnPrevImg_Click(object sender, EventArgs e)
        {
            if (currentImg > 0 && newImages.Count != 0)
            {
                currentImg--;
            }
            else
            {
                currentImg = newImages.Count - 1;
            }

            if (newImages.Count != 0)
            {
                tbxImg.Text = newImages[currentImg].imageUrl;
            }
        }

        private void btnNextImg_Click(object sender, EventArgs e)
        {
            if (currentImg < newImages.Count - 1)
            {
                currentImg++;
            }
            else
            {
                currentImg = 0;
            }

            if (newImages.Count != 0)
            {
                tbxImg.Text = newImages[currentImg].imageUrl;
            }
        
        }
    }
}
