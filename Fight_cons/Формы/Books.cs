using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fight_cons.Формы
{
    /// <summary>
    /// Эта форма должна открывать и показывать кнопки
    /// которые будут открывать формы с книгами
    /// </summary>
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
            Button button = new Button();
        }

        private void Books_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
