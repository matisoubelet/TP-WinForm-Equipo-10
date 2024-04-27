using System;
using System.Collections.Generic;
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
    internal class ArticlePreview
    {
        public int artID;
        public Panel panel;
        public string name;
        public float price;
        public string url;
        EventHandler clickEvent;

        public ArticlePreview(Article article, Img image, ref Panel panel, EventHandler click)
        {
            artID = article.id;
            this.panel = panel;
            name = article.name;
            price = article.price;
            url = image.imageUrl;
            clickEvent = click;

            

            ConfigPreview();
        }

        public ArticlePreview()
        {
              
        }

        private void ConfigPreview()
        {
            panel.SuspendLayout();

            panel.Anchor = AnchorStyles.Left;
            panel.Anchor = AnchorStyles.Top;

            PictureBox previewPic = new PictureBox()
            {
                Anchor = AnchorStyles.None,
                BackColor = Color.Thistle,
                Dock = DockStyle.Fill,
                Size = new Size(500, 500),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            try
            {
                previewPic.Load(url);
            }
            catch(Exception ex)
            {
                //throw ex;
            }
            

            Label artName = new Label();
            Label artPrice = new Label();

            panel.Size = new Size(125, 125);
            panel.Padding = new Padding(5, 5, 5, 5);
            panel.BorderStyle = BorderStyle.FixedSingle;

            artName.TextAlign = ContentAlignment.BottomLeft;
            artName.AutoSize = true;
            artName.Text = name;
            artName.Dock = DockStyle.Bottom;
            artName.Location = new System.Drawing.Point(5, 105);

            artPrice.TextAlign = ContentAlignment.TopRight;
            artPrice.AutoSize = true;
            artPrice.RightToLeft = RightToLeft.Yes;
            artPrice.Text = price.ToString();
            artPrice.Dock = DockStyle.Right;
            artPrice.Location = new System.Drawing.Point(83, 5);

            panel.Controls.Add(previewPic);
            panel.Controls.Add(artName);
            panel.Controls.Add(artPrice);

            artName.BringToFront();
            artPrice.BringToFront();
            previewPic.SendToBack();

            panel.Click += clickEvent;
            previewPic.Click += clickEvent;
            artName.Click += clickEvent;
            artPrice.Click += clickEvent;

            panel.ResumeLayout(true);
        }
    }
}
