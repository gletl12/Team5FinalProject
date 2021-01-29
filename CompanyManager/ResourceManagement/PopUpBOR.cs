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
    public partial class PopUpBOR : CompanyManager.PopupBaseForm
    {
        List<Control> validation = new List<Control>(); //유효성 검사할 컨트롤

        public List<BORVO> InsertInfoList { get; set; }  //등록할 정보 리스트
        public List<CodeVO> CodeAllList { get; set; } //콤보박스에 바인딩할 코드리스트

        public EmployeeVO LoginInfo { get; set; } //로그인 정보
        public PopUpBOR()
        {
            InitializeComponent();
            popupTitleBar1.HeaderText = "BOR";

            //유효성 검사할 컨트롤들 집어넣기
            validation.Add(cboItem);
            validation.Add(cboMacine);
            validation.Add(cboRoute);
            validation.Add(cboUse);
            validation.Add(txtCompletion);
            validation.Add(txtPriority);
            validation.Add(txtTact);
        }
        private void PopUpBOR_Load(object sender, EventArgs e)
        {
            //콤보박스 설정
            cboItem.DisplayMember = "name";
            cboRoute.DisplayMember = "name";
            cboMacine.DisplayMember = "name";
            cboUse.DisplayMember = "name";

            cboItem.ValueMember = "code";
            cboRoute.ValueMember = "code";
            cboMacine.ValueMember = "code";
            cboUse.ValueMember = "code";

            BindCbo();
        }

        private void BindCbo()
        {
            List<CodeVO> temp;
            if (CodeAllList != null)
            {
                //품목
                temp = (from code in CodeAllList
                        where code.category == "item"
                        select code).ToList();
                temp.Insert(0, new CodeVO { code = "", name = "" });
                cboItem.DataSource = temp;

                //공정
                temp = (from code in CodeAllList
                        where code.category == "ROUTE"
                        select code).ToList();
                temp.Insert(0, new CodeVO { code = "", name = "" });
                cboRoute.DataSource = temp;

                //공정
                temp = (from code in CodeAllList
                        where code.category == "machine"
                        select code).ToList();
                temp.Insert(0, new CodeVO { code = "", name = "" });
                cboMacine.DataSource = temp;

                //공정
                temp = (from code in CodeAllList
                        where code.category == "USE_FLAG"
                        select code).ToList();
                temp.Insert(0, new CodeVO { code = "", name = "" });
                cboUse.DataSource = temp;



            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //유효성 검사;
                Validation();
                List<BORVO> list = new List<BORVO>();

                BORVO vo = new BORVO();
                vo.Item_id = Convert.ToInt32(cboItem.SelectedValue.ToString());
                vo.Bor_route = cboRoute.SelectedValue.ToString();
                vo.Machine_id = Convert.ToInt32(cboMacine.SelectedValue.ToString());
                vo.Tacktime = Convert.ToInt32(txtTact.Text);
                vo.preceding_days = txtpreceding.Text == "" ? 0 : Convert.ToInt32(txtpreceding.Text);
                vo.Priority = Convert.ToInt32(txtPriority.Text);
                vo.Completion_rate = Convert.ToDecimal(txtCompletion.Text);
                vo.Bor_use = cboUse.SelectedValue.ToString();
                vo.Bor_comment = txtComment.Text;

                vo.Ins_date = DateTime.Now;
                vo.Ins_emp = Convert.ToInt32(LoginInfo.emp_id);

                list.Add(vo);

                InsertInfoList = list;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message+"의 정보가 존재하지 않습니다.");
            }


        }

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
