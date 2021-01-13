using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
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

            //메뉴 리스트 가져오기
            MenuService service = new MenuService();
            menuAllList = service.GetMenus();

            //메뉴 생성
            CreatMenu();

        }

        //메뉴 생성
        private void CreatMenu()
        {
            //빈값 생성
            selectedBtn = new Button(); 

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
            ////메뉴 중복선택 확인
            //if (selectedBtn == ((Button)sender))
            //    return;

            //메뉴 위치 복구 (이미 선택된 메뉴가 있다면)
            foreach (Control ctrl in pnlMenu.Controls)
            {
                if (ctrl is TreeView)
                {
                    pnlMenu.Controls.Remove(ctrl);

                    foreach (Control btn in pnlMenu.Controls)
                    {
                        if (btn is Button)
                        {
                            if (btn.Location.Y > selectedBtn.Location.Y)
                            {
                                btn.Location = new Point(-1, btn.Location.Y - 300);
                            }
                        }
                    }
                    //메뉴 중복선택 확인
                    if (selectedBtn == ((Button)sender))
                        return;

                    break;
                }
            }

            
            selectedBtn = ((Button)sender);

            //메뉴 위치 변경
            foreach (Control btn in pnlMenu.Controls)
            {
                if (btn is Button)
                {
                    if (btn.Location.Y > selectedBtn.Location.Y)
                    {
                        btn.Location = new Point(-1, btn.Location.Y + 300);
                    }
                }
            }



            //트리뷰 생성
            TreeView tv = new TreeView();
            tv.BorderStyle = BorderStyle.None;
            tv.Location = new Point(-1, selectedBtn.Location.Y+48);
            tv.Size = new Size(180, 300);
            tv.ImageList = imageList1;
            tv.DoubleClick += treeView_Click;
            pnlMenu.Controls.Add(tv);

            TreeNode tn = new TreeNode(selectedBtn.Text);
            tn.Tag = selectedBtn.Tag;
            tv.Nodes.Add(tn);
            TreeNode tnc;
            menuAllList.ForEach(p =>
            {
                //현재 메뉴버튼의 소메뉴이면 
                if (p.INFO.Trim().StartsWith("L") && p.SortName.StartsWith(selectedBtn.Text))
                {
                    tnc = new TreeNode(p.INFO.Trim().Substring(1));
                    tnc.Tag = p.FormName;
                    tn.Nodes.Add(tnc);
                }
            });

            tv.ExpandAll();

        }


        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //메인폼 종료 로그
            Program.Log.WriteInfo("CompanyManager_FrmMain 종료");
            Program.Log.WriteInfo("프로그램 종료");
        }

        //폼 열기
       
        private void treeView_Click(object sender, EventArgs e)
        {
            if (((TreeView)sender).SelectedNode.Tag != null)
            {
                string formName = ((TreeView)sender).SelectedNode.Tag.ToString();
                string appName = Assembly.GetEntryAssembly().GetName().Name;
                Type frmType = Type.GetType($"{appName}.{formName}");

                Util.CommonUtil.OpenCreateForm(this, frmType);
            }
        }
    }
}
