using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net.Filter;
using System.Security.Cryptography.X509Certificates;

namespace CompanyManager.CustomControl
{   
    public partial class CustomTabControl : UserControl
    {
        private Dictionary<string, string> OpenForms; //메뉴이름, 폼이름

        public Button selectedButton;
        public CustomTabControl()
        {
            InitializeComponent();
            OpenForms = new Dictionary<string, string>();
            //메인으로 나오는 폼 하나 추가
            OpenForms.Add("Home", null);
        }

        //새로운 폼 열림
        public void InsertTab(string menuName, string formName)
        {
            OpenForms.Add(menuName,formName);

            //열리지 않은 폼이면
            CreateTab(menuName, formName);

            //열린폼이면


        } 

        private void CreateTab(string menuName, string formName)
        {
            Button btn = new Button();
            btn.Text = menuName;
            btn.Tag = formName;

            
            btn.Location = new Point(4 + (74 * (OpenForms.Count - 1)), 2);


            btn.Size = new Size(73, 25);
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(216, 220, 227);
            btn.FlatAppearance.BorderColor = Color.FromArgb(154, 161, 169);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(216, 220, 227);
            btn.TextAlign = ContentAlignment.MiddleLeft;

            btn.Click += button_Click;
            pnlTab.Controls.Add(btn);

            Button cBtn = new Button();
            cBtn.Text = "X";
            cBtn.FlatStyle = FlatStyle.Flat;
            cBtn.BackColor = Color.FromArgb(216, 220, 227);
            cBtn.FlatAppearance.BorderSize = 0;
            cBtn.Cursor = Cursors.Hand;
            
            cBtn.Location = new Point(4 + (74 * (OpenForms.Count - 1)) + 51, 3);
            cBtn.Size = new Size(19, 20);
            cBtn.BringToFront();
            pnlTab.Controls.Add(cBtn);

        }

        //텝버튼 클릭시 해당 버튼 화면 활성화
        private void button_Click(object sender, EventArgs e)
        {
            //파란색 위치 조정
            lblSelect.Location = new Point(((Button)sender).Location.X, lblSelect.Location.Y);
            lblSelect.Size = new Size(((Button)sender).Size.Width, lblSelect.Size.Height);


            //아래 검은색 맨위로 올리기
            label3.BringToFront();
            ((Button)sender).BringToFront();
            foreach (Control item in pnlTab.Controls)
            {
                if (item is Button)
                {
                    if (item.Location.X > (((Button)sender)).Location.X
                        && item.Location.X < (((Button)sender)).Location.X + (((Button)sender)).Size.Width)
                    {
                        item.BringToFront();
                    }
                }
            }
            lblSelect.BringToFront();
        }



    }
}
