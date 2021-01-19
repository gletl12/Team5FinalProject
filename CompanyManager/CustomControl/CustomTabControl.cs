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
        public Dictionary<string,Form> OpenForms { get; set; }

        public Button selectedButton;
        public CustomTabControl()
        {
            InitializeComponent();
        }

        //텝버튼 클릭시 해당 버튼 화면 활성화
        private void button_Click(object sender, EventArgs e)
        {
            //파란색 위치 조정
            lblSelect.Location = new Point(((Button)sender).Location.X, lblSelect.Location.Y);
            //아래 검은색 맨위로 올리기
            label3.BringToFront();
            ((Button)sender).BringToFront();
            lblSelect.BringToFront();

        }



    }
}
