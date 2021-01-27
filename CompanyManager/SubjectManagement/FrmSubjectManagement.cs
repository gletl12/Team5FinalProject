using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using VO;

namespace CompanyManager
{
    public partial class FrmSubjectManagement : CompanyManager.MDIBaseForm
    {
        List<CodeVO> codeAllList; //콤보박스 바인딩 데이터
        List<SubjectVO> subjectAllList;
        public FrmSubjectManagement()
        {
            InitializeComponent();
        }

        private void FrmSubjectManagement_Load(object sender, EventArgs e)
        {

            //콤보박스 설정


            cboOrderC.ValueMember = "code";
            cboWarehouseIN.ValueMember = "code";
            cboWarehouseOUT.ValueMember = "code";
            cboSubjectType.ValueMember = "code";
            cboUse.ValueMember = "code";
            cboDeliveryC.ValueMember = "code";
            cboOrderC.DisplayMember = "Name";
            cboWarehouseIN.DisplayMember = "Name";
            cboWarehouseOUT.DisplayMember = "Name";
            cboSubjectType.DisplayMember = "Name";
            cboUse.DisplayMember = "Name";
            cboDeliveryC.DisplayMember = "Name";
            LoadCombobox();


            // 그리드 뷰 설정
            Image img = Properties.Resources.Edit_16x16;
            Util.CommonUtil.SetDGVDesign_Num(dataGridView1);
            Util.CommonUtil.AddGridCheckColumn(dataGridView1, "", 20);
            Util.CommonUtil.AddGridImageColumn(dataGridView1, img, "Edit", 40);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품목유형", "Item_type", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품목", "Item_id", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품명", "Item_name", 300);
            //Util.CommonUtil.AddGridTextColumn(dataGridView1, "규격", "", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "단위", "Item_unit", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "단위수량", "Item_unit_qty", 100);
            //Util.CommonUtil.AddGridTextColumn(dataGridView1, "환산단위", "", 100);
            //Util.CommonUtil.AddGridTextColumn(dataGridView1, "환산수량", "", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "수입검사여부", "Import_inspection", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "공정검사여부", "Process_inspection", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "출하검사여부", "Shipment_inspection", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "단종유무", "Extinction", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "유무상구분", "Free_of_charge", 120);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "납품업체", "Supply_company", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "발주업체", "Order_company", 150);
            LoadSubjectList();

            //dataGridView1.Rows.Add(null, null, "반제품", "BACK_a02", "등받이", "5 x 12 inch", "EA", "0", null, null, "미사용", "미사용", "미사용", "미사용", null, "(주)에이더블유", "(주)에이더블유");


        }

        private void LoadSubjectList()
        {
            Service.SubjectService service = new Service.SubjectService();
            subjectAllList = service.GetSubjectList();

            dataGridView1.DataSource = subjectAllList;
        }

        //콤보박스 바인딩
        private void LoadCombobox()
        {
            Service.SubjectService service = new Service.SubjectService();
            codeAllList = service.GetSubjectCode();

            List<CodeVO> temp;
            CodeVO co = new CodeVO { code = "", name = "" };

            //발주업체, 납품업체
            temp = (from code in codeAllList
                    where code.category.Equals("company")
                    select code).ToList();
            temp.Insert(0, co);
            cboOrderC.DataSource = temp;
            cboDeliveryC.DataSource = temp.ConvertAll(p => p);

            //입고창고
            temp = (from code in codeAllList
                    where code.category.Equals("warehouse")
                    select code).ToList();
            temp.Insert(0, co);
            cboWarehouseIN.DataSource = temp;

            //출고창고
            temp = (from code in codeAllList
                    where code.category.Equals("warehouse")
                    select code).ToList();
            temp.Insert(0, co);
            cboWarehouseOUT.DataSource = temp;

            //품목유형
            temp = (from code in codeAllList
                    where code.category.Equals("ITEM_TYPE")
                    select code).ToList();
            temp.Insert(0, co);
            cboSubjectType.DataSource = temp;

            //사용유무
            temp = (from code in codeAllList
                    where code.category.Equals("USE_FLAG")
                    select code).ToList();
            temp.Insert(0, co);
            cboUse.DataSource = temp;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            PopUpSubject popup = new PopUpSubject();
            popup.CodeAllList = codeAllList;
            popup.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                Service.SubjectService service = new Service.SubjectService();
                List<SubjectVO> temp = new List<SubjectVO>();
                temp.Add(popup.InsertInfo);
                if (!service.AddSubject(temp))
                {
                    MessageBox.Show("품목등록 중 오류가 발생하였습니다.");
                }
                else
                {
                    LoadSubjectList();
                }
                
            }
           
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (btnDown.Text == "ᐱ")
            {
                btnDown.Text = "V";
                int size = this.Size.Height;
                btnDown.Location = new Point(btnDown.Location.X, 71);
                btnSearch.Location = new Point(btnSearch.Location.X, 70);



                pnlSearch.Size = new Size(pnlSearch.Size.Width, 114);
                splitContainer1.SplitterDistance = splitContainer1.SplitterDistance + 38;

            }
            else
            {
                btnDown.Text = "ᐱ";

                btnDown.Location = new Point(btnDown.Location.X, 38);
                btnSearch.Location = new Point(btnSearch.Location.X, 37);
                pnlSearch.Size = new Size(pnlSearch.Size.Width, pnlSearch.Size.Height * 2 / 3);


                splitContainer1.SplitterDistance = splitContainer1.SplitterDistance - 38;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                EditCode(e);
            }
        }
        private void EditCode(DataGridViewCellEventArgs e)
        {
            //수정할 코드 정보 팝업창에 로드


            //해당 행의 정보를찾아서 팝업창에 등록
            var temp = subjectAllList.Find(p => p.Item_id == dataGridView1[3, e.RowIndex].Value.ToString());
            PopUpSubject pop = new PopUpSubject();
            pop.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo;
            pop.CodeAllList = codeAllList;
            pop.InsertInfo = temp;

            //수정할 값 가져ㅑ와서 수정
            if (pop.ShowDialog() == DialogResult.OK)
            {
                Service.SubjectService service = new Service.SubjectService();

                if (!service.EditSubject(pop.InsertInfo))
                {
                    MessageBox.Show("코드수정 중 오류가 발생하였습니다.");
                }
                else
                {
                    LoadSubjectList();
                }
            }

        }
    }
}
