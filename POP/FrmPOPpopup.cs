using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;
using VO;

namespace POP
{
    public partial class FrmPOPpopup : Form
    {
        public FrmPOPpopup()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FrmPOPpopup_Load(object sender, EventArgs e)
        {
            CodeService service = new CodeService();

            List<CodeVO> list = service.GetAllCommonCode();
            var list1 = (from All in list
                         where All.category == "BadType"
                         select All).ToList();

            list1.Insert(0, new CodeVO { name = " " });
            CommonUtil.BindingComboBoxPart(comboBox2, list1, "name");
        }
    }
}
