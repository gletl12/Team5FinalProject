using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VO;

namespace CompanyManager
{
    public partial class FrmMain : Form
    {
        List<MenuVO> menuAllList;
        Color buttonColor = Color.FromArgb(142, 160, 185);
        Color selectedColor = Color.Blue;

        public FrmMain()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            MenuService service = new MenuService();
            menuAllList = service.GetMenus();

            CreatMenu();

        }

        //메뉴 생성
        private void CreatMenu()
        {
            int count = 0;
            menuAllList.ForEach(p =>
            {
                //▶로 시작하는 메뉴는 대메뉴 버튼 생성
                if (p.INFO.Trim().StartsWith("▶"))
                {
                    Button btn = new Button();
                    btn.Name = p.INFO.Trim().Substring(1);
                    btn.Text = btn.Name;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = buttonColor;
                    btn.Location = new Point(-1, -1+ (42 * count));
                    btn.Size = new Size(180, 45);
                    btn.Click += Btn_Click;
                    pnlMenu.Controls.Add(btn);
                    count++;
                }
            });
        }

        //메뉴버튼 클릭 이벤트
        //소메뉴 생성
        private void Btn_Click(object sender, EventArgs e)
        {
           
        }
    }
}
