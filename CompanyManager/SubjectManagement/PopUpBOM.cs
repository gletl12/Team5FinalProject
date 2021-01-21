using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class PopUpBOM : CompanyManager.PopupBaseForm
    {
        public PopUpBOM()
        {
            InitializeComponent();
        }

        private void PopUpBOM_Load(object sender, EventArgs e)
        {
            popupTitleBar1.HeaderText = "BOM";
        }
    }
}
