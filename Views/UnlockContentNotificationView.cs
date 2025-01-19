using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektStatki.Views
{
    public partial class UnlockContentNotificationView : Form
    {
        public UnlockContentNotificationView(string contentName)
        {
            InitializeComponent();
            label1.Text = $"Odblokowałeś: {contentName}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
