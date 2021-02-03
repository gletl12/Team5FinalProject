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
    public partial class PopUpBOM : CompanyManager.PopupBaseForm
    {
        List<Control> validation = new List<Control>(); //유효성 검사할 컨트롤

        public List<CodeVO> codeAllList { get; set; } //콤보박스 바인딩 데이터
        public EmployeeVO LoginInfo { get; set; }
        public List<BOMVO> InsertList { get; set; } 

        public PopUpBOM()
        {
            InitializeComponent();
            validation.Add(cboParentsubject);
            validation.Add(cbosubject);
            validation.Add(txtuseqty);
            validation.Add(cbouse);
            validation.Add(cboauto);
            validation.Add(cboplan);
        }
        //유효성 검사
        private void Validation()
        {
            foreach (Control item in validation)
            {
                if (string.IsNullOrEmpty(item.Text))
                {
                    throw new Exception(item.Tag.ToString());
                }
            }
        }
        private void PopUpBOM_Load(object sender, EventArgs e)
        {
            //콤보박스 바인딩 기본값 설정
            cboParentsubject.DisplayMember = "name";
            cbosubject.DisplayMember = "name";
            cbouse.DisplayMember = "name";
            cboauto.DisplayMember = "name";
            cboplan.DisplayMember = "name";

            cboParentsubject.ValueMember = "code";
            cbosubject.ValueMember = "code";
            cbouse.ValueMember = "code";
            cboauto.ValueMember = "code";
            cboplan.ValueMember = "code";

            CodeVO co = new CodeVO { code = "", name = "" };
            List<CodeVO> temp = (from code in codeAllList
                                 where code.category.Equals("item")
                                 select code).ToList();
            temp.Insert(0, co);
            cboParentsubject.DataSource = temp.ConvertAll(p => p);
            cbosubject.DataSource = temp.ConvertAll(p => p);

            temp = (from code in codeAllList
                                 where code.category.Equals("USE_FLAG")
                                 select code).ToList();
            temp.Insert(0, co);
            cbouse.DataSource = temp.ConvertAll(p => p);
            cboauto.DataSource = temp.ConvertAll(p => p);
            cboplan.DataSource = temp.ConvertAll(p => p);

            dtpend.Value = dtpstart.Value.AddYears(2);
            txtupemp.Text = LoginInfo.emp_name;
            txtupdate.Text = DateTime.Now.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //유효성 검사
            try
            {
                Validation();
                if (DateTime.Compare(dtpstart.Value, dtpend.Value) > 1)
                {
                    MessageBox.Show("종료일은 시작일보다 늦어야합니다.");
                    return;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }

            BOMVO vo = new BOMVO();
            vo.bom_parent_id = cboParentsubject.SelectedValue.ToString();
            vo.item_id = cbosubject.SelectedValue.ToString();
            vo.bom_use_qty = Convert.ToInt32(txtuseqty.Text);
            vo.start_date = dtpstart.Value;
            vo.end_date = dtpend.Value;
            vo.bom_use = cbouse.SelectedValue.ToString();
            vo.auto_deduction = cboauto.SelectedValue.ToString();
            vo.plan_use = cboplan.SelectedValue.ToString();
            vo.ins_emp = LoginInfo.emp_id;
            vo.ins_date = DateTime.Now;

            InsertList.Add(vo);
        }

       
    }
}
