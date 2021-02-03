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
    public partial class FrmBOM : CompanyManager.MDIBaseForm
    {
        List<CodeVO> codeAllList;
        public FrmBOM()
        {
            InitializeComponent();
        }

        private void FrmBOM_Load(object sender, EventArgs e)
        {
            //콤보박스 바인딩
            cboSubject.ValueMember = "code";
            cboUse.ValueMember = "code";
            cbodeployment.ValueMember = "code";

            cboSubject.DisplayMember = "name";
            cboUse.DisplayMember = "name";
            cbodeployment.DisplayMember = "name";

            Service.BOMService service = new Service.BOMService();
            codeAllList = service.GetBOMCode();

            CodeVO co = new CodeVO { code = "", name = ""};
            List<CodeVO> temp = (from code in codeAllList
                                 where code.category.Equals("item")
                                 select code).ToList();
            temp.Insert(0, co);
            cboSubject.DataSource = temp.ConvertAll(p => p);

            temp = (from code in codeAllList
                                 where code.category.Equals("USE_FLAG")
                                 select code).ToList();
            temp.Insert(0, co);
            cboUse.DataSource = temp.ConvertAll(p => p);
            cbodeployment.SelectedIndex = 0;

            Image img = Properties.Resources.Edit_16x16;
            Util.CommonUtil.SetDGVDesign_Num(dataGridView1);
            Util.CommonUtil.AddGridCheckColumn(dataGridView1, "", 20);
            Util.CommonUtil.AddGridImageColumn(dataGridView1, img, "Edit", 40);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "상위품목", "bom_parent_name", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품목", "item", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품명", "item_name", 300);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품목유형", "item_type", 90);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "단위", "item_unit", 90);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "소요량", "bom_use_qty", 90);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "BOM레벨", "bom_level", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "시작일", "start_date", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "종료일", "end_date", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "사용여부", "bom_use", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "소요계획", "plan_use", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "자동차감", "auto_deduction", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "설비", "machine_id", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "설비명", "machine_name", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "비고", "bom_comment", 220);
            


            dataGridView1.Rows.Add(null, null, "-", "📂CHAIR2_01", "나무 1인용 의자 B타입", "제품", "갯수", "1", "1", "2018-10-04", "2018-10-04", "사용", "사용", "사용", "F_SSY_02", "최종조립2반", "5 x 12 x 14 inch");
            dataGridView1.Rows.Add(null, null, "CHAIR2_01", "  └BACK_a02", "  └등받이", "반제품", "갯수", "1", "2", "2018-10-04", "2018-10-04", "사용", "사용", "사용", "OS", "AW 외주 작업장", "5 x 12 inch");

            

            //MessageBox.Show(dataGridView1.Columns[0].Index.ToString()); 
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PopUpBOM popup = new PopUpBOM();
            popup.codeAllList = codeAllList;
            popup.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo; //로그인정보 전달
            if (popup.ShowDialog() == DialogResult.OK)
            {
                Service.BOMService service = new Service.BOMService();
                if (service.AddBOM(popup.InsertList))
                {

                }
            }
            
        }
    }
}
