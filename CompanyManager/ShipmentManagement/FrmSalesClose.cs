using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class FrmSalesClose : CompanyManager.MDIBaseForm
    {
        List<SOVO> list = new List<SOVO>();
        List<SOVO> chklist = new List<SOVO>();

        public FrmSalesClose()
        {
            InitializeComponent();

        }

        private void GetSO()
        {
            CommonUtil.SetInitGridView(dgvSO);
            CommonUtil.SetDGVDesign_Num(dgvSO);
            CommonUtil.AddGridCheckColumn(dgvSO, "");
            CommonUtil.AddGridTextColumn(dgvSO, "SO ID", "so_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "PO ID", "po_id", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "고객사", "company_name", 120);
            CommonUtil.AddGridTextColumn(dgvSO, "도착지", "company_name", 120);
            CommonUtil.AddGridTextColumn(dgvSO, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvSO, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvSO, "주문수량", "so_o_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "출하수량", "so_s_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "취소수량", "so_c_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "매출확정수량", "s_cf_qty", 90, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "매출확정금액", "s_cf_price", 90, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "마감일자", "due_date", 80, true, DataGridViewContentAlignment.MiddleCenter);

            checkBox1.Location = new Point(dgvSO.Location.X + 54, dgvSO.Location.Y + 5);
            SOListRoad();
        }

        private void SOListRoad()
        {
            SalesOrderService service = new SalesOrderService();
            list = service.GetSOList();

            dgvSO.DataSource = list;
            dgvSO.ClearSelection();

        }

        private void FrmSalesClose_Load(object sender, EventArgs e)
        {
            GetSO();
        }

        private void btnMaGam_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSO.RowCount; i++)
            {
                if (dgvSO[0, i].Value != null && (bool)dgvSO[0, i].Value)
                {
                    chklist.Add(list[i]);
                    chklist[i].up_emp = ((FrmMain)this.MdiParent).LoginInfo.up_emp;
                    chklist[i].up_date = DateTime.Now;
                }
                else
                {
                    var temp = chklist.Find(p => p.so_id == list[i].so_id);
                    chklist.Remove(temp);
                }
            }

            if(chklist.Count < 1)
            {
                MessageBox.Show("마감처리할 데이터를 선택해주세요.");
                return;
            }
            

            if(MessageBox.Show("선택한 데이터를 마감 처리하시겠습니까?","마감",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SalesOrderService service = new SalesOrderService();
                if(service.MaGamProcess(chklist))
                {
                    MessageBox.Show("마감처리 완료되었습니다.");
                    SOListRoad();
                }
            }
        }
        private void RoadCombobox()
        {
            //CodeService service = new CodeService();
            //List<CodeVO> combobox = service.GetAllCommonCode();

            //cboFGrade.DisplayMember = "name";
            //cboFGrade.ValueMember = "name";
            //List<CodeVO> temp = (from code in combobox
            //                     where code.category == "FACTORY_GRADE"
            //                     select code).ToList();
            //temp.Insert(0, new CodeVO { code = "", name = "전체" });
            //cboFGrade.DataSource = temp;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (txtCodeName.Text.Length < 1 && cboFGrade.SelectedIndex == 0)
            //{
            //    DataRoad();
            //}
            //else if (txtCodeName.Text.Length > 0 && cboFGrade.SelectedIndex != 0)
            //{
            //    var sResult = (from factory_grade
            //                   in list
            //                   where
            //                   factory_grade.factory_name.Contains(txtCodeName.Text) && factory_grade.factory_grade.Equals(cboFGrade.SelectedValue)
            //                   select factory_grade).ToList();
            //    dgvFactory.DataSource = null;
            //    dgvFactory.DataSource = sResult;
            //}
            //else if (txtCodeName.Text.Length > 0 && cboFGrade.SelectedIndex == 0)
            //{
            //    var sResult = (from factory_grade
            //                in list
            //                   where
            //                   factory_grade.factory_name.Contains(txtCodeName.Text)
            //                   select factory_grade).ToList();
            //    dgvFactory.DataSource = null;
            //    dgvFactory.DataSource = sResult;
            //}
            //else
            //{
            //    var sResult = (from factory_grade
            //                   in list
            //                   where
            //                   factory_grade.factory_grade.Equals(cboFGrade.SelectedValue)
            //                   select factory_grade).ToList();
            //    dgvFactory.DataSource = null;
            //    dgvFactory.DataSource = sResult;
            //}
        }
    }
}
