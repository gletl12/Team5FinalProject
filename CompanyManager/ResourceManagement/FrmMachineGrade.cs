using CompanyManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;

namespace CompanyManager
{
    public partial class FrmMachineGrade : CompanyManager.MDIBaseForm
    {
        public FrmMachineGrade()
        {
            InitializeComponent();
        }

        private void FrmMachineGrade_Load(object sender, EventArgs e)
        {
            GetMachine();
            GetMachineGrade();
            txtUpEmp.Text = ((FrmMain)this.MdiParent).LoginInfo.emp_id.ToString();
        }

        private void GetMachineGrade()
        {
            CommonUtil.SetDGVDesign_Num(dgvMachineGrade);

            CommonUtil.AddGridImageColumn(dgvMachineGrade, Resources.Edit_16x16, "Edit", 30);
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "설비군 코드", "mgrade_code");
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "설비군 명", "mgrade_name");
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "사용유무", "mgrade_use",80);
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "수정자", "up_emp", 80);
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "수정시간", "up_date",181);

            dgvMachineGrade.Rows.Add(null, "ASSEMBLY", "조립", "사용","관리자", "2021-01-22");
            dgvMachineGrade.Rows.Add(null, "PROCESSING", "가공","사용", "관리자", "2021-01-22");
            dgvMachineGrade.Rows.Add(null, "OUTSOURCING", "외주", "사용", "관리자", "2021-01-22");

            dgvMachineGrade.AutoGenerateColumns = false;
            dgvMachineGrade.AllowUserToAddRows = false;
        }
        private void GetMachine()
        {
            CommonUtil.SetDGVDesign_Num(dgvMachine);

            CommonUtil.AddGridCheckColumn(dgvMachine, "");
            CommonUtil.AddGridImageColumn(dgvMachine, Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dgvMachine, "설비 명", "machine_name");
            CommonUtil.AddGridTextColumn(dgvMachine, "소진창고", "use_warehouse_id");
            CommonUtil.AddGridTextColumn(dgvMachine, "양품창고", "ok_warehouse_id");
            CommonUtil.AddGridTextColumn(dgvMachine, "불량창고", "ng_warehouse_id");
            CommonUtil.AddGridTextColumn(dgvMachine, "외주여부", "m_os_use");
            CommonUtil.AddGridTextColumn(dgvMachine, "특이사항 및 비고", "machine_comment", 160);
            CommonUtil.AddGridTextColumn(dgvMachine, "사용유무", "machine_use");
            CommonUtil.AddGridTextColumn(dgvMachine, "수정자", "up_emp");
            CommonUtil.AddGridTextColumn(dgvMachine, "수정시간", "up_date", 169);

            dgvMachine.Rows.Add(null, null, "F_ASSEMBLY_01", "최종조립 1팀", "자재창고", "제품창고", "", "미사용", "", "사용", "관리자", "2021-01-22");
            dgvMachine.Rows.Add(null, null, "F_ASSEMBLY_02", "최종조립 2팀", "자재창고", "제품창고", "", "미사용", "", "사용", "관리자", "2021-01-22");
            dgvMachine.Rows.Add(null, null, "H_ASSEMBLY_04", "의자다리A 조립팀", "자재창고", "제품창고", "", "미사용", "", "사용", "관리자", "2021-01-22");

            dgvMachine.AutoGenerateColumns = false;
            dgvMachine.AllowUserToAddRows = false;
        }

        //private void LoadCombobox()
        //{
        //    CodeService service = new CodeService();
        //    List<CodeVO> combobox = service.GetAllCommonCode();

        //    cboFGrade.DisplayMember = "name";
        //    cboFGrade.ValueMember = "name";
        //    List<CodeVO> temp = (from code in combobox
        //                         where code.category == "FACTORY_GRADE"
        //                         select code).ToList();
        //    temp.Insert(0, new CodeVO { code = "", name = "" });
        //    cboFGrade.DataSource = temp;
        //}

        private void btnRegister_Click(object sender, EventArgs e)
        {
            pnlMGrade.Visible = true;
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            txtMGCode.Text = txtMGName.Text = txtComment.Text = "";
            cboUse.SelectedIndex = 0;
            pnlMGrade.Visible = false;
        }
    }
}
