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
    public partial class statusbar : UserControl
    {
        public string anyText
        {
            get { return lbl_anyText.Text; }
            set { lbl_anyText.Text = value; }
        }

        public statusbar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(DateTime.Now.Minute<10)
                lbl_time.Text = DateTime.Now.Hour.ToString() + ":0" + DateTime.Now.Minute.ToString();
            else
                lbl_time.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
        }
    }
}
