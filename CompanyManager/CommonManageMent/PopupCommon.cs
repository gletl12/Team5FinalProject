using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VO;

namespace CompanyManager
{
    public partial class PopupCommon : CompanyManager.PopupBaseForm
    {

        List<MenuVO> menuAllList;

        TreeNode selectedNdoe = null;
        public PopupCommon()
        {
            InitializeComponent();
            popupTitleBar1.HeaderText = "공통관리";
        }

        private void PopupCommon_Load(object sender, EventArgs e)
        {
            //메뉴관리
            LoadMenuList();
            

            LoadFormList();

            //공통코드관리

            Image img = Properties.Resources.Edit_16x16;
            Util.CommonUtil.SetDGVDesign_Num(dataGridView1);
            Util.CommonUtil.AddGridCheckColumn(dataGridView1, "", 20);
            Util.CommonUtil.AddGridImageColumn(dataGridView1, img, "Edit", 40);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "코드", "", 80);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "카테고리", "", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "코드명", "", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "pCode", "", 80);


            dataGridView1.Rows.Add(null, null, "-", "📂CHAIR2_01", "나무 1인용 의자 B타입", "제품", "갯수", "1", "1", "2018-10-04", "2018-10-04", "사용", "사용", "사용", "F_SSY_02", "최종조립2반", "5 x 12 x 14 inch");


        }

        private void LoadFormList()
        {
            List<string> temp = new List<string>();
            foreach (var item in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                string formName = item.ToString().Split('.')[1];
                if (formName.ToLower().StartsWith("frm"))
                {
                    temp.Add(formName);
                }
            }
            listBox1.DataSource = temp;
        }

        //메뉴리스트 불러오기
        private void LoadMenuList()
        {
            treeView1.Nodes.Clear();

            Service.MenuService service = new Service.MenuService();
            menuAllList = service.GetMenus();

            menuAllList.ForEach(p =>
            {
                TreeNode tn = null;
                if (p.INFO.Trim().StartsWith("▶"))
                {
                    tn = new TreeNode(p.INFO.Trim().Substring(1));
                    treeView1.Nodes.Add(tn);
                }

                menuAllList.ForEach(T =>
                {
                    //현재 메뉴버튼의 소메뉴이면 
                    if (T.INFO.Trim().StartsWith("L") && T.SortName.StartsWith(p.INFO.Trim().Substring(1)))
                    {
                        TreeNode tnc;
                        string[] names = T.SortName.Split('>');
                        tnc = new TreeNode(T.INFO.Trim().Substring(1));
                        tnc.Name = names[names.Length - 1];
                        if (names.Length == 2)
                            tn.Nodes.Add(tnc);
                        else
                        {
                            TreeNode ptn = treeView1.Nodes.Find(names[names.Length - 2], true)[0];
                            ptn.Nodes.Add(tnc);
                        }
                    }
                });
            });

            treeView1.ExpandAll();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.Size = new Size(874, 548);
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                this.Size = new Size(594, 608);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            //이전 노드 색상 원래대로
            if (selectedNdoe != null)
            {
                selectedNdoe.ForeColor = Color.Black;
                selectedNdoe.BackColor = Color.White;
            }

            selectedNdoe = e.Node;
            e.Node.BackColor = SystemColors.MenuHighlight;
            e.Node.ForeColor = Color.White;
        }

        //대메뉴 추가
        private void btnLargeMenu_Click(object sender, EventArgs e)
        {
            PopupMenu pop = new PopupMenu();
            if (pop.ShowDialog() == DialogResult.OK)
            {
                Service.MenuService service = new Service.MenuService();
                if (service.AddLargeMenu(pop.MenuName))
                    MessageBox.Show("메뉴가 등록되었습니다.");
                else
                    MessageBox.Show("이미 존재하는 메뉴명입니다.");
            }

            LoadMenuList();
            
        }

        //소메뉴 추가
        private void btnSmallMenu_Click(object sender, EventArgs e)
        {

            //메뉴 선택
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("메뉴를 선택해주세요");
                return;
            }

            PopupMenu pop = new PopupMenu();
            if (pop.ShowDialog() == DialogResult.OK)
            {
                Service.MenuService service = new Service.MenuService();
                if (service.AddSmallMenu(pop.MenuName, treeView1.SelectedNode.Text.Trim()))
                    MessageBox.Show("메뉴가 등록되었습니다.");
                else
                    MessageBox.Show("이미 존재하는 메뉴명입니다.");
            }
            LoadMenuList();

        }

        //메뉴 삭제
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //대메뉴 삭제시도시 소메뉴가 있으면 못하게 막아야함
            if (treeView1.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show("메뉴 삭제 전 하위 메뉴를 모두 삭제해야 합니다.");
                return;
            }

            Service.MenuService service = new Service.MenuService();
            if (service.DeleteMenu(treeView1.SelectedNode.Text.Trim()))
                MessageBox.Show("메뉴가 삭제되었습니다.");
            else
                MessageBox.Show("존재하지 않는 메뉴입니다.");

            LoadMenuList();
        }
    }
}
