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
        FactoryVO vo = new FactoryVO();
        bool upflag = false;

        public PopFactoryCRUD(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        public PopFactoryCRUD(int id, FactoryVO vo, bool flag)
        {
            InitializeComponent();
            this.id = id;
            this.vo = vo;
            upflag = flag;
        }

        private void PopFactoryCRUD_Load(object sender, EventArgs e)
        {
            
            txtUpEmp.Text = id.ToString();
            LoadCombobox();
            if (upflag)
            {
                SetUpdateData();           
            }
        }

        private void SetUpdateData()
        {
            cboFGrade.SelectedValue = vo.factory_grade;
            txtFParent.Text = vo.factory_parent;
            cboFType.SelectedValue = vo.factory_type;
            txtFName.Text = vo.factory_name;
            if (vo.factory_use == "U0001")
            {
                cboFUse.SelectedValue = "사용";
            }
            else
                cboFUse.SelectedValue = "미사용";
            txtComment.Text = vo.factory_comment;
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
                MessageBox.Show("필수 입력 정보를 확인해주세요.");
                return;
            }
            FactoryVO fvo = new FactoryVO
            {
                factory_grade = cboFGrade.SelectedValue.ToString(),
                factory_parent = txtFParent.Text,
                factory_name = txtFName.Text,
                up_emp = id,
                up_date = DateTime.Now,
                factory_id = vo.factory_id
            };
            if (txtComment.Text.Length < 1)
                fvo.factory_comment = "";
            else
                fvo.factory_comment = txtComment.Text;

            if (cboFUse.SelectedValue.ToString() == "사용")
            {
                fvo.factory_use = "U0001";
            }
            else
                fvo.factory_use = "U0002";

            if (cboFType.Enabled)
                fvo.factory_type = cboFType.SelectedValue.ToString();
            else
                fvo.factory_type = "";


            if (upflag)
            {
                FactoryService service = new FactoryService();
                if(service.UpdateFactory(fvo))
                {
                    MessageBox.Show("수정에 성공하였습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("수정에 실패하였습니다.");
                }
            }
            else
            {
                FactoryService service = new FactoryService();
                if (service.AddFactory(fvo))
                {
                    MessageBox.Show("등록이 성공하였습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("등록이 실패하였습니다.");
                }
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
