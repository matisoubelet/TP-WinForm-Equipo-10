using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBAccess;
using ModelDomain;

namespace WinForm
{
    public partial class Config : Form
    {
        ArticleDBAccess dbAccess = new ArticleDBAccess();
        List<Brand> brands = new List<Brand>();
        List<Category> categories = new List<Category>();
        int selectedBrandIndex = 0;
        int selectedCategoryIndex = 0;

        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            brands = dbAccess.ListBrands();
            categories = dbAccess.ListCategories();

            foreach (Brand brand in brands)
            {
                lbxBrands.Items.Add(brand.name);
            }
            foreach (Category category in categories)
            {
                lbxCategories.Items.Add(category.name);
            }
        }

        private void lbxBrands_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbxBrand.Text = lbxBrands.SelectedItem.ToString();
            selectedBrandIndex = lbxBrands.SelectedIndex + 1;
            btnSaveBrand.Text = "Guardar";
        }

        private void lbxCategories_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbxCategory.Text = lbxCategories.SelectedItem.ToString();
            selectedCategoryIndex = lbxCategories.SelectedIndex + 1;
            btnSaveCategory.Text = "Guardar";
        }

        private void btnSaveBrand_Click(object sender, EventArgs e)
        {
            bool anySelected = false;

            for (int i = 0; i < lbxBrands.Items.Count; i++)
            {
                if (lbxBrands.GetSelected(i))
                {
                    anySelected = true;
                    break;
                }
            }
            
            if (!anySelected)
            {
                lbxBrands.Items.Add(tbxBrand.Text);
                dbAccess.InsertBrand(tbxBrand.Text);
                lbxBrands.ClearSelected();
            }
            else
            {
                Brand modifiedBrand = new Brand();
                modifiedBrand.name = tbxBrand.Text;
                modifiedBrand.id = selectedBrandIndex;

                lbxBrands.Items[selectedBrandIndex - 1] = tbxBrand.Text;
                dbAccess.ModifyBrand(modifiedBrand);
                lbxBrands.ClearSelected();
                btnSaveBrand.Text = "Agregar";
            }
        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            bool anySelected = false;

            for (int i = 0; i < lbxCategories.Items.Count; i++)
            {
                if (lbxCategories.GetSelected(i))
                {
                    anySelected = true;
                    break;
                }
            }

            if (!anySelected)
            {
                lbxCategories.Items.Add(tbxCategory.Text);
                dbAccess.InsertCategory(tbxCategory.Text);
                lbxCategories.ClearSelected();
            }
            else
            {
                Category modifiedCategory = new Category();
                modifiedCategory.name = tbxCategory.Text;
                modifiedCategory.id = selectedBrandIndex;

                lbxCategories.Items[selectedCategoryIndex - 1] = tbxCategory.Text;
                dbAccess.ModifyCategory(modifiedCategory);
                lbxCategories.ClearSelected();
                btnSaveCategory.Text = "Agregar";
            }
        }

        private void btnDeleteBrand_Click(object sender, EventArgs e)
        {
            bool anySelected = false;

            for (int i = 0; i < lbxBrands.Items.Count; i++)
            {
                if (lbxBrands.GetSelected(i))
                {
                    anySelected = true;
                    break;
                }
            }

            if (anySelected && selectedBrandIndex > 0)
            {
                bool articlesBelongToBrand = false;
                foreach (Article article in dbAccess.ListArticles())
                {
                    if (article.idBrand == selectedBrandIndex)
                    {
                        articlesBelongToBrand = true;
                        break;
                    }
                }
                if (articlesBelongToBrand)
                {
                    MessageBox.Show("Esta marca está en uso por uno o más artículos.", "Marca en uso", MessageBoxButtons.OK);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Estás seguro de que querés eliminar esta marca?", "Eliminar marca", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        tbxBrand.Text = "";
                        Debug.WriteLine(selectedBrandIndex);
                        dbAccess.DeleteBrand(selectedBrandIndex);
                        lbxBrands.Items.Remove(lbxBrands.SelectedItem);
                        lbxBrands.ClearSelected();
                        btnSaveBrand.Text = "Agregar";
                    }
                }
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            bool anySelected = false;

            for (int i = 0; i < lbxCategories.Items.Count; i++)
            {
                if (lbxCategories.GetSelected(i))
                {
                    anySelected = true;
                    break;
                }
            }

            if (anySelected && selectedCategoryIndex > 0)
            {
                bool articlesBelongToCategory = false;
                foreach (Article article in dbAccess.ListArticles())
                {
                    if (article.idCategory == selectedCategoryIndex)
                    {
                        articlesBelongToCategory = true;
                        break;
                    }
                }
                if (articlesBelongToCategory)
                {
                    MessageBox.Show("Esta categoría está en uso por uno o más artículos.", "Categoría en uso", MessageBoxButtons.OK);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Estás seguro de que querés eliminar esta categoría?", "Eliminar categoría", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        tbxCategory.Text = "";
                        Debug.WriteLine(selectedCategoryIndex);
                        dbAccess.DeleteCategory(selectedCategoryIndex);
                        lbxCategories.Items.Remove(lbxCategories.SelectedItem);
                        lbxCategories.ClearSelected();
                        btnSaveCategory.Text = "Agregar";
                    }
                }
            }
        }
    }
}
