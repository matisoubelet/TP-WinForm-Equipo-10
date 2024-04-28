using DBAccess;
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
using System.Diagnostics;
using System.Security.Policy;

namespace WinForm
{
    public partial class ArticleDetails : Form
    {
        int articleID;
        ArticleDBAccess dbAccess = new ArticleDBAccess();
        Article article = new Article();
        List<Img> images = new List<Img>();
        bool editMode = false;
        int currentImg = 0;



        public ArticleDetails(int artId)
        {
            InitializeComponent();
            articleID = artId;
        }




        private void ArticleDetails_Load(object sender, EventArgs e)
        {
            List<Article> listArticles = new List<Article>();
            listArticles = dbAccess.ListArticles();
            List<Img> imgList = new List<Img>();
            imgList = dbAccess.ListImages();

            foreach (Img img in imgList)
            {
                if (img.articleID == articleID)
                {
                    images.Add(img);
                }
            }

            foreach (Category category in dbAccess.ListCategories())
            {
                cboxCat.Items.Add(category);
            }
            foreach (Brand brand in dbAccess.ListBrands())
            {
                cboxBrand.Items.Add(brand);
            }

            foreach (Article article in listArticles)
            {

                if (article.id == articleID)
                {

                    this.article = article;

                    tbxCode.Text = this.article.code;
                    tbxName.Text = this.article.name;
                    tbxDesc.Text = this.article.desc;
                    tbxPrice.Text = this.article.price.ToString();

                    cboxBrand.SelectedIndex = this.article.idBrand - 1;
                    cboxCat.SelectedIndex = this.article.idCategory - 1;

                    tbxImg.Text = images[0].imageUrl;

                    try
                    {
                        pctrBox.Load(tbxImg.Text);
                    }
                    catch
                    {

                    }
                }
            }
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


        private void btnNextImg_Click(object sender, EventArgs e)
        {
            if (currentImg < images.Count - 1)
            {
                currentImg++;
            }
            else
            {
                currentImg = 0;
            }

            if (images.Count != 0)
            {
                tbxImg.Text = images[currentImg].imageUrl;
            }
        }

        private void btnPrevImg_Click(object sender, EventArgs e)
        {
            if (currentImg > 0 && images.Count != 0)
            {
                currentImg--;
            }
            else
            {
                currentImg = images.Count - 1;
            }

            if (images.Count != 0)
            {
                tbxImg.Text = images[currentImg].imageUrl;
            }
        }

        private void tbxImg_TextChanged_1(object sender, EventArgs e)
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
                images.Add(newImg);
                currentImg = images.Count - 1;
            }
            else
            {
                images.Remove(images[currentImg]);
            }

            tbxImg.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                DialogResult result = MessageBox.Show("Estás seguro de que querés eliminar este artículo?", "Eliminar artículo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dbAccess.DeleteArticle(article, images);
                    this.Close();
                }
                
            }
            else
            {
                this.Close();
            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            editMode = !editMode;
            Check_EditMode();

        }

        private void Check_EditMode()
        {
            if (editMode)
            {

                btnAdd.Text = "Guardar";
                btnBack.Text = "Eliminar";

                tbxName.Enabled = true;
                tbxCode.Enabled = true;
                tbxDesc.Enabled = true;
                tbxImg.Enabled = true;
                tbxPrice.Enabled = true;
                cboxBrand.Enabled = true;
                cboxCat.Enabled = true;

                btnAddImg.Enabled = true;

            }
            else
            {

                btnAdd.Text = "Editar";
                btnBack.Text = "Volver";

                tbxImg.Text = images[currentImg].imageUrl;

                tbxName.Enabled = false;
                tbxCode.Enabled = false;
                tbxDesc.Enabled = false;
                tbxImg.Enabled = false;
                tbxPrice.Enabled = false;
                cboxBrand.Enabled = false;
                cboxCat.Enabled = false;

                btnAddImg.Enabled = false;
                
                
                article.code = tbxCode.Text;
                article.name = tbxName.Text;
                article.desc = tbxDesc.Text;

                try
                {
                    article.price = float.Parse(tbxPrice.Text);
                }
                catch
                {
                    article.price = 0;
                    tbxPrice.Text = "0";
                }

                article.idBrand = ((Brand)cboxBrand.SelectedItem).GetID();
                article.idCategory = ((Category)cboxCat.SelectedItem).GetID();

                dbAccess.ModifyArticle(article, images);  


            }
        }
    }      
}

