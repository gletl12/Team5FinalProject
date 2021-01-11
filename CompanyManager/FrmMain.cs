using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;
using VO;

namespace CompanyManager
{
    public partial class FrmMain : Form
    {
        List<MenuVO> menuAllList;
        Color buttonColor = Color.FromArgb(142, 160, 185);
        Color selectedColor = Color.Blue;
        Button selectedBtn;
        
        public string Admin { get; set; }

        public FrmMain()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //메인폼 실행
            Program.Log.WriteInfo("CompanyManager_FrmMain 시작");


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
                    btn.Tag = p.FormName;
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
            //메뉴
            Button menuBtn = ((Button)sender);

            //트리뷰 생성
            TreeView tv = new TreeView();
            tv.Location = new Point(500, 500);
            tv.Size = new Size(180, 326);
            tv.ImageList = imageList1;
            this.Controls.(tv);

            TreeNode tn = new TreeNode(menuBtn.Text);
            tn.Tag = menuBtn.Tag;
            tv.Nodes.Add(tn);
            TreeNode tnc;
            menuAllList.ForEach(p =>
            {
                //현재 메뉴버튼의 소메뉴이면 
                if (p.INFO.Trim().StartsWith("L") && p.SortName.StartsWith(menuBtn.Text))
                {
                    tnc = new TreeNode(p.INFO.Trim().Substring(1));
                    tnc.Tag = p.FormName;
                    tn.Nodes.Add(tnc);
                }
            });
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //메인폼 종료
            Program.Log.WriteInfo("CompanyManager_FrmMain 종료");
        }
    }
}
