using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class FrmBOM : CompanyManager.MDIBaseForm
    {
        public FrmBOM()
        {
            InitializeComponent();
        }

        private void FrmBOM_Load(object sender, EventArgs e)
        {
            Image img = Properties.Resources.Edit_16x16;
            Util.CommonUtil.SetDGVDesign_Num(dataGridView1);
            Util.CommonUtil.AddGridCheckColumn(dataGridView1, "", 20);
            Util.CommonUtil.AddGridImageColumn(dataGridView1, img, "Edit", 40);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "상위품목", "", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품목", "", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품명", "", 300);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품목유형", "", 90);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "단위", "", 90);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "소요량", "", 90);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "BOM레벨", "", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "시작일", "", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "종료일", "", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "사용여부", "", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "소요계획", "", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "자동차감", "", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "설비", "", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "설비명", "", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "규격", "", 220);
            


            dataGridView1.Rows.Add(null, null, "-", "📂CHAIR2_01", "나무 1인용 의자 B타입", "제품", "갯수", "1", "1", "2018-10-04", "2018-10-04", "사용", "사용", "사용", "F_SSY_02", "최종조립2반", "5 x 12 x 14 inch");
            dataGridView1.Rows.Add(null, null, "CHAIR2_01", "  └BACK_a02", "  └등받이", "반제품", "갯수", "1", "2", "2018-10-04", "2018-10-04", "사용", "사용", "사용", "OS", "AW 외주 작업장", "5 x 12 inch");

        }

        private void button13_Click(object sender, EventArgs e)
        {
            PopUpBOM popup = new PopUpBOM();
            popup.ShowDialog();
        }
    }
}
