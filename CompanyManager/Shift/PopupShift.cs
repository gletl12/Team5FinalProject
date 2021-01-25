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

        private void txtStime_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
