using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class PopUpSubject : CompanyManager.PopupBaseForm
    {
        public PopUpSubject()
        {
            InitializeComponent();
        }

        private void PopUpSubject_Load(object sender, EventArgs e)
        {
            popupTitleBar1.HeaderText = "품목";
        }
    }
}
