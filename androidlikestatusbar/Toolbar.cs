using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace androidlikestatusbar
{
    public partial class Toolbar : UserControl
    {
        public event EventHandler menuButtonClicked;

        public string titleText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public Toolbar()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.menuButtonClicked != null)
                this.menuButtonClicked(this,e);
        }
    }
}
