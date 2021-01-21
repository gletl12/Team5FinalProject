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
        }

        private void GetMachineGrade()
        {
            CommonUtil.SetDGVDesign(dgvMachineGrade);

            CommonUtil.AddGridCheckColumn(dgvMachineGrade, "");
            CommonUtil.AddGridImageColumn(dgvMachineGrade, Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "설비군 코드", "mgrade_code");
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "설비군 명", "mgrade_name");
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "사용유무", "mgrade_use",80);
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "수정자", "up_emp", 120);
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "수정시간", "up_date",161);
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
        }
    }
}
