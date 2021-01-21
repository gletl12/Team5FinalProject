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
    public partial class FrmCompanyList : CompanyManager.MDIBaseForm
    {
        public FrmCompanyList()
        {
            InitializeComponent();
        }

        private void FrmCompanyList_Load(object sender, EventArgs e)
        {
            GetCompany();
        }

        private void GetCompany()
        {
            CommonUtil.SetDGVDesign_Num(dgvCompany);

            CommonUtil.AddGridCheckColumn(dgvCompany, "");
            CommonUtil.AddGridImageColumn(dgvCompany, Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dgvCompany, "업체명", "company_name");
            CommonUtil.AddGridTextColumn(dgvCompany, "업체타입명", "company_type");
            CommonUtil.AddGridTextColumn(dgvCompany, "대표자명", "company_ceo");
            CommonUtil.AddGridTextColumn(dgvCompany, "사업자등록번호", "company_bnum");
            CommonUtil.AddGridTextColumn(dgvCompany, "업종", "company_btype");
            CommonUtil.AddGridTextColumn(dgvCompany, "담당자", "company_manager");
            CommonUtil.AddGridTextColumn(dgvCompany, "이메일", "company_email");
            CommonUtil.AddGridTextColumn(dgvCompany, "전화번호", "company_phone");
            CommonUtil.AddGridTextColumn(dgvCompany, "팩스", "company_faxnum");
            CommonUtil.AddGridTextColumn(dgvCompany, "사용유무", "company_use");
            CommonUtil.AddGridTextColumn(dgvCompany, "업체정보", "company_comment");
            CommonUtil.AddGridTextColumn(dgvCompany, "수정자", "up_date");
            CommonUtil.AddGridTextColumn(dgvCompany, "수정시간", "up_emp");

        }
    }
}
