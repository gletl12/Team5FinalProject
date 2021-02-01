using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VO;

namespace CompanyManager
{
    public partial class PopFactoryCRUD : CompanyManager.PopupBaseForm
    {
        int id;
        bool useFlag;
        public PopFactoryCRUD(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void PopFactoryCRUD_Load(object sender, EventArgs e)
        {
            txtUpEmp.Text = id.ToString();
            LoadCombobox();
        }

        private void LoadCombobox()
        {
            CodeService service = new CodeService();
            List<CodeVO> combobox = service.GetAllCommonCode();

            cboFGrade.DisplayMember = "name";
            cboFGrade.ValueMember = "name";
            List<CodeVO> temp = (from code in combobox
                                 where code.category == "FACTORY_GRADE"
                                 select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "" });
            cboFGrade.DataSource = temp;

            cboFType.DisplayMember = "name";
            cboFType.ValueMember = "name";
            temp = (from code in combobox
                    where code.category == "FACILITY_TYPE"
                    select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "" });
            cboFType.DataSource = temp;

            cboFUse.DisplayMember = "name";
            cboFUse.ValueMember = "name";
            temp = (from code in combobox
                    where code.category == "USE_FLAG"
                    select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "" });
            cboFUse.DataSource = temp;
        }

        private void btnCRU_Click(object sender, EventArgs e)
        {
            if(cboFGrade.SelectedIndex < 1 || cboFType.SelectedIndex < 1 || cboFUse.SelectedIndex < 1 || txtFParent.Text.Length < 1 || txtFName.Text.Length < 1)
            {
                MessageBox.Show("필수 입력 데이터를 다시 확인해주세요.");
                return;
            }
            FactoryVO vo = new FactoryVO
            {
                factory_grade = cboFGrade.SelectedValue.ToString(),
                factory_parent = txtFParent.Text,
                factory_name = txtFName.Text,
                up_emp = id,
                up_date = DateTime.Now
            };
            if (txtComment.Text.Length < 1)
                vo.factory_comment = "";
            else
                vo.factory_comment = txtComment.Text;

            if (cboFUse.SelectedValue.ToString() == "사용")
            {
                vo.factory_use = true;
            }
            else
                vo.factory_use = false;

            if (cboFType.Enabled)
                vo.factory_type = cboFType.SelectedValue.ToString();
            else
                vo.factory_type = "";

            
                
            FactoryService service = new FactoryService();
            if(service.AddFactory(vo))
            {
                MessageBox.Show("저장에 성공하였습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                
                MessageBox.Show("저장에 실패하였습니다.");
            }

    }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboFGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboFGrade.SelectedValue.ToString() == "창고")
            {
                cboFType.Enabled = true;
            }
            else
            {
                
                cboFType.Enabled = false;
            }
        }
    }
}
