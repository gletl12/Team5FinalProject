using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class PopupBaseForm : Form
    {
        public PopupBaseForm()
        {
            InitializeComponent();
        }

        protected void PopupBaseForm_Load(object sender, EventArgs e)
        {
            //폼 실행
            Program.Log.WriteInfo("CompanyManager_FrmMain 시작");

        }

        protected void PopupBaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //폼 종료 로그
            Program.Log.WriteInfo("CompanyManager_FrmMain 종료");
        }
    }
}
