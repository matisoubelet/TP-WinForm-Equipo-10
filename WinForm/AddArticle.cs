using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class AddArticle : Form
    {

        public AddArticle()
        {
            InitializeComponent();
        }

        public Article newArticle = new Article();

        public void Agregar_Click(object sender, EventArgs e)
        { 

            //Toma todos los valores ingresados y los pone en el nuevo Articulo creado

            newArticle.code = tbxCode.Text;
            newArticle.name = tbxName.Text;
            newArticle.desc = tbxDesc.Text;
            newArticle.price = float.Parse(tbxPrice.Text);
            newArticle.brand.setId(int.Parse(cboxBrand.SelectedItem.ToString()));
            newArticle.category.setId(int.Parse(cboxCat.SelectedItem.ToString()));
            this.Close();
        }

        private void AddArticle_Load(object sender, EventArgs e)
        {
            //Todo esto va a ser reemplazado por los datos de la Base de Datos
           
            cboxCat.Items.Add(1);
            cboxCat.Items.Add(2);
            cboxCat.Items.Add(3);
            cboxCat.Items.Add(4);
            cboxCat.Items.Add(5);

            cboxBrand.Items.Add(1);
            cboxBrand.Items.Add(2);
            cboxBrand.Items.Add(3);
            cboxBrand.Items.Add(4);
            cboxBrand.Items.Add(5);
        }

    }
}
