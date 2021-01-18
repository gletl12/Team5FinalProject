using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyManager.CustomControl
{
    public partial class CustomTabControl : UserControl
    {
        public int MyProperty { get; set; }

        public CustomTabControl()
        {
            InitializeComponent();
        }
    }
}
