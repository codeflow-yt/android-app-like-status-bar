using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace androidlikestatusbar
{
    public partial class Form1 : Form
    {
        androidlikestatusbar.Toolbar tb = new androidlikestatusbar.Toolbar();
        androidlikestatusbar.Navbar nb = new androidlikestatusbar.Navbar();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nb.Location = new Point(-240, 20);
            this.Controls.Add(nb);
            tb.titleText = "My App";
            tb.Location = new Point(0,20);
            this.Controls.Add(tb);
            addNew("");
            tb.menuButtonClicked += new EventHandler(menu_Clicked);
            nb.backButtonClicked += new EventHandler(back_Clicked);
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void menu_Clicked(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public androidlikestatusbar.statusbar addNew(string val)
        {
            androidlikestatusbar.statusbar st = new androidlikestatusbar.statusbar();
            st.anyText = val;
            this.Controls.Add(st);
            st.Location = new Point(0,0);
            return st;
        }

        int step = 10; bool showed = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (showed == false)
            {
                nb.Location = new Point(nb.Location.X + step, nb.Location.Y);
                if (nb.Location.X > 0)
                {
                    timer1.Stop();
                    nb.Location = new Point(0, nb.Location.Y);
                    showed = true;
                }
            }
            else
            {
                nb.Location = new Point(nb.Location.X - step, nb.Location.Y);
                if (nb.Location.X < -240)
                {
                    timer1.Stop();
                    nb.Location = new Point(-240, nb.Location.Y);
                    showed = false;
                }
            }
        }
    }
}
