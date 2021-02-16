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

        
        public int performance_id { get; set; }
        public int wo_id { get; set; }
        public string item_id { get; set; }
        public int performance_qty { get; set; }
        public string ins_emp { get; set; }
        public int bad_qty { get; set; }
        public DateTime wo_sdate { get; set; }
        
        private void FrmPOPpopup_Load(object sender, EventArgs e)
        {
            textBox1.Text = bad_qty.ToString();
            CodeService service = new CodeService();

            List<CodeVO> list = service.GetAllCommonCode();
            var list1 = (from All in list
                         where All.category == "BadType"
                         select All).ToList();

            list1.Insert(0, new CodeVO { name = " " });
            CommonUtil.BindingComboBoxPart(comboBox2, list1, "name");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            CheckVO vo = new CheckVO();
            vo.item_id = item_id;
            vo.ch_qty = wo_id;
            vo.good_qty = performance_qty;
            vo.bad_qty =int.Parse(textBox1.Text);
            vo.emp =ins_emp;

            CheckService service = new CheckService();

            int chid= service.GetChID(vo);

            if(chid >0)
            {
                PerformanceService service1 = new PerformanceService();
                bool bFlag = service1.PerformanceCh_idUpdate(performance_id,chid);

                if (bFlag)
                {
                    MessageBox.Show("검사등록");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("검사실패");
                    return;
                }
            }
            else
            {
                MessageBox.Show("검사실패");
                return;
            }
        }
    }
}
