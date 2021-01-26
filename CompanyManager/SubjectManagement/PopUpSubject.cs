using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VO;
using System.Linq;
namespace CompanyManager
{
    public partial class PopUpSubject : CompanyManager.PopupBaseForm
    {
        public List<CodeVO> CodeAllList { get; set; }

        public SubjectVO InsertInfo { get; set; } //등록 할 정보 


        public PopUpSubject()
        {
            InitializeComponent();
        }

        private void PopUpSubject_Load(object sender, EventArgs e)
        {
            popupTitleBar1.HeaderText = "품목";

            //콤보박스 바인딩
            BindCombobox();
            cbotype.DisplayMember = "name";
            cbounit.DisplayMember = "name";
            cboinware.DisplayMember = "name";
            cbooutware.DisplayMember = "name";
            cboorder.DisplayMember = "name";
            cbosupply.DisplayMember = "name";
            cboimport.DisplayMember = "name";
            cboprocess.DisplayMember = "name";
            cboshipment.DisplayMember = "name";
            cbofreecharge.DisplayMember = "name";
            cbouse.DisplayMember = "name";
            cboextinction.DisplayMember = "name";
            cbomanager.DisplayMember = "name";

            cbotype.ValueMember = "code";
            cbounit.ValueMember = "code";
            cboinware.ValueMember = "code";
            cbooutware.ValueMember = "code";
            cboorder.ValueMember = "code";
            cbosupply.ValueMember = "code";
            cboimport.ValueMember = "code";
            cboprocess.ValueMember = "code";
            cboshipment.ValueMember = "code";
            cbofreecharge.ValueMember = "code";
            cbouse.ValueMember = "code";
            cboextinction.ValueMember = "code";
            cbomanager.ValueMember = "code";
        }

        //콤보박스 바인딩
        private void BindCombobox()
        {
            List<CodeVO> temp;
            CodeVO co = new CodeVO { code = "", name = "" };

            //품목 유형
            temp = (from code in CodeAllList
                    where code.category.Equals("ITEM_TYPE")
                    select code).ToList();
            temp.Insert(0, co);
            cbotype.DataSource = temp;

            //단위
            temp = (from code in CodeAllList
                    where code.category.Equals("ITEM_UNIT")
                    select code).ToList();
            temp.Insert(0, co);
            cbounit.DataSource = temp;

            //단위
            temp = (from code in CodeAllList
                    where code.category.Equals("employee")
                    select code).ToList();
            temp.Insert(0, co);
            cbomanager.DataSource = temp;

            //입고창고, 출고창고
            temp = (from code in CodeAllList
                    where code.category.Equals("warehouse")
                    select code).ToList();
            temp.Insert(0, co);
            cboinware.DataSource = temp;
            cbooutware.DataSource = temp.ConvertAll(p => p);

            //납품업체, 발주업체
            temp = (from code in CodeAllList
                    where code.category.Equals("company")
                    select code).ToList();
            temp.Insert(0, co);
            cboorder.DataSource = temp;
            cbosupply.DataSource = temp.ConvertAll(p => p);


            //수입검사여부, 공정검사 여부 출하검사여부, 유무상구분, 사용유무, 단종유무
            temp = (from code in CodeAllList
                    where code.category.Equals("USE_FLAG")
                    select code).ToList();
            temp.Insert(0, co);
            cboimport.DataSource = temp;
            cboprocess.DataSource = temp.ConvertAll(p => p);
            cboshipment.DataSource = temp.ConvertAll(p => p);
            cbofreecharge.DataSource = temp.ConvertAll(p => p);
            cbouse.DataSource = temp.ConvertAll(p => p);
            cboextinction.DataSource = temp.ConvertAll(p => p);
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //유효성 검사
            Validation();


            //입력정보 저장
            SubjectVO vo = new SubjectVO
            {
                Item_id = txtID.Text,
                Item_type = cbotype.SelectedValue.ToString(),
                Item_name = txtname.Text,
                Item_unit = cbounit.SelectedValue.ToString(),
                Item_unit_qty = Convert.ToInt32(txtunitqty.Text),
                Import_inspection = cboimport.SelectedValue.ToString(),
                Process_inspection = cboprocess.SelectedValue.ToString(),
                Shipment_inspection = cboshipment.SelectedValue.ToString(),
                Free_of_charge = cbofreecharge.SelectedValue.ToString(),
                Order_company = cboorder.SelectedValue.ToString(),
                Supply_company = cbosupply.SelectedValue.ToString(),
                Item_leadtime = Convert.ToInt32(txtleadtime.Text),
                Item_lorder_qty = Convert.ToInt32(txtlorder.Text),
                Item_safety_qty = Convert.ToInt32(txtsaftyqty.Text),
                Item_delivery_qty = Convert.ToInt32(txtdeliveryqty.Text),
                Item_grade = cbograde.SelectedValue.ToString(),
                Item_manager = cbomanager.SelectedValue.ToString(),
                Item_use = cbouse.SelectedValue.ToString(),
                Item_comment = txtComment.Text,
                Up_date = Convert.ToDateTime(txtupdate.Text),
                Up_emp = txtupemployee.Text,
                In_warehouse = cboinware.SelectedValue.ToString(),
                Out_warehouse = cbooutware.SelectedValue.ToString(),
                Extinction = cboextinction.SelectedValue.ToString()
            };
            
        }

        //유효성 검사 필수 입력값에 대해서만
        private void Validation()
        {
            //유효성 검사
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("품목을 입력해주세요");
                return;
            }
            if (string.IsNullOrEmpty(txtname.Text))
            {
                MessageBox.Show("품명을 입력해주세요");
                return;
            }
            if (cbotype.SelectedIndex == 0)
            {
                MessageBox.Show("품목유형을 선택해주세요");
                return;
            }
            if (cbounit.SelectedIndex == 0)
            {
                MessageBox.Show("단위를 선택해주세요");
                return;
            }
            if (cboimport.SelectedIndex == 0)
            {
                MessageBox.Show("수입검사여부를 선택해주세요");
                return;
            }
            if (cboprocess.SelectedIndex == 0)
            {
                MessageBox.Show("공정검사여부를 선택해주세요");
                return;
            }
            if (cboshipment.SelectedIndex == 0)
            {
                MessageBox.Show("출하검사여부를 선택해주세요");
                return;
            }
            if (cbouse.SelectedIndex == 0)
            {
                MessageBox.Show("사용유무를 선택해주세요");
                return;
            }
            if (cboextinction.SelectedIndex == 0)
            {
                MessageBox.Show("단종유무를 선택해주세요");
                return;
            }
        }

        private void limit20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).Text.Length > 19)
            {
                if (e.KeyChar == 8)
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void limit30_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).Text.Length > 29)
            {
                if (e.KeyChar == 8)
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void OnlyNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!int.TryParse(e.KeyChar.ToString(), out int temp))
            {
                if (e.KeyChar == 8)
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}
