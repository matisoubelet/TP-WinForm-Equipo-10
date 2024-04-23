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

        public Article newArticle = new Article();

        public void Agregar_Click(object sender, EventArgs e)
        { 

            //Toma todos los valores ingresados y los pone en el nuevo Articulo creado

            newArticle.code = tbxCode.Text;
            newArticle.name = tbxName.Text;
            newArticle.desc = tbxDesc.Text;
            newArticle.price = float.Parse(tbxPrice.Text);
            newArticle.idBrand = int.Parse(cboxBrand.SelectedItem.ToString());
            newArticle.idCategory = int.Parse(cboxCat.SelectedItem.ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            newArticle.code = null;
            this.Close();
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            //Guarda una imagen (de momento una sola, pero tienen que ser varias, o se podrian
            //añadir al editar el articulo)

            //AUN NO GUARDA LA IMAGEN EN NINGUN LADO!!!!!

            string imageLocation = "";
            try
            {   //Pide que se ingrese la ubicacion de la imagen que se esta buscando, y especifica el tipo de archivo que acepta
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files|*.png| All files(*.*)|*.*";

                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Si todo esta bien, toma la img y la guarda en el PictureBox
                    imageLocation = dialog.FileName;
                    pctrBox.ImageLocation = imageLocation;
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
