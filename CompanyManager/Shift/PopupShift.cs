using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class PopupShift : CompanyManager.PopupBaseForm
    {
        public enum OpenMode { Insert, Update }
        List<ShiftVO> shift;
        List<CodeVO> code;

        List<MachineVO> machine;
        public PopupShift(OpenMode mode)
        {
            InitializeComponent();
            if (mode == OpenMode.Insert)
            {
                
            }
            else
            {
                
            }
        }
        private void PopupShift_Load(object sender, EventArgs e)
        {
            MachineService service = new MachineService();
            machine = service.GetMachine();
            machine.Insert(0, new MachineVO { machine_name = "" });
            CommonUtil.BindingComboBox(cboMachine, machine, "machine_id", "machine_name");    

            CodeService service1 = new CodeService();
            code = service1.GetAllCommonCode();
            var code1 = (from All in code where All.category == "shift_type" select All).ToList();
            code1.Insert(0, new CodeVO { name = "" });
            CommonUtil.BindingComboBox(cboShift, code1, "code", "name");

            var code2 = (from All in code where All.category == "USE_FLAG" select All).ToList();
            code2.Insert(0, new CodeVO { name = "" });
            CommonUtil.BindingComboBox(cboUse, code2, "code", "name");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {

           
            //if (e.KeyChar == Convert.ToChar(Keys.Back))
            //{
            //    e.Handled = true;
                
            //}
            //if (((TextBox)sender).Text.Length == 7)
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    if (!(char.IsDigit(e.KeyChar)))//숫자만 입력
            //    {
            //        e.Handled = true;

            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
            //}

          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cboMachine.SelectedIndex <0|| cboShift.SelectedIndex<0||txtStime.Text.Length<0||txtEtime.Text.Length<0||dtpEday.Value==null||dtpSday.Value==null)
            {
                MessageBox.Show("주황글씨는 필수입력입니다.");
                return;
            }
            ShiftVO emp = new ShiftVO();
            emp.machine_id = cboMachine.SelectedIndex;
            emp.shift_type = cboShift.Text;
            emp.shift_stime = txtStime.Text;
            emp.shift_etime = txtEtime.Text;
            emp.shift_sdate = dtpSday.Value;
            emp.shift_edate = dtpEday.Value;
            emp.shift_use = cboUse.Text;

            emp.Directly_Input_Person = "DDDD";
            emp.Indirect_Input_Person = "DDDD";
            emp.Nomal_Direct_WorkTime = "DDDD";
            emp.Nomal_indirect_WorkTime = "DDDD";
            emp.Overtime_Directly_WorkTime = "DDDD";
            emp.Overtime_Indirect_WorkTime = "DDDD";
            emp.Overtime_Directly_Input_Person = "DDDD";
            emp.Overtime_Indirect_Input_Person = "DDDD";
            emp.Directly_Accident_WorkTime = "DDDD";
            emp.Indirect_Accident_WorkTime = "DDDD";
            emp.Overtime_Directly_Accident_Time = "DDDD";
            emp.Overtime_Indirect_Accident_Time = "DDDD";

            emp.shift_comment =                                    "DDDD";
                                                                 
            emp.ins_date =                                         dtpSday.Value;
            emp.ins_emp = "DDDD";
            emp.up_date =                                          dtpSday.Value;
            emp.up_emp = "DDDD";

            ShiftService service = new ShiftService();
            bool bFlag = service.AddShift(emp);

            if(bFlag)
            {
                MessageBox.Show("저장되었습니다.");
            }
            else
                MessageBox.Show("저장 중 오류가 발생하였습니다.");

        }

        private void dtpEday_ValueChanged(object sender, EventArgs e)
        {
            if (dtpSday.Value > dtpEday.Value)
            {
                MessageBox.Show("날짜를 다시 입력해주세요");
                return;
            }
        }
    }
}
