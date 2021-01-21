using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class FrmSubjectManagement : CompanyManager.MDIBaseForm
    {
        public FrmSubjectManagement()
        {
            InitializeComponent();
        }

        private void FrmSubjectManagement_Load(object sender, EventArgs e)
        {
           
            Image img = Properties.Resources.Edit_16x16;
            Util.CommonUtil.SetDGVDesign_Num(dataGridView1);
            Util.CommonUtil.AddGridCheckColumn(dataGridView1, "", 20);
            Util.CommonUtil.AddGridImageColumn(dataGridView1, img, "Edit",40);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"품목유형","",100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"품목","",150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"품명","",300);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"규격","",150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"단위","",100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"단위수량","",100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"환산단위","",100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"환산수량","",100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"수입검사여부","",100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"공정검사여부","",100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"출하검사여부","",100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"단종유무","",100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"유무상구분","",120);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"납품업체","",150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"발주업체","",150);


            dataGridView1.Rows.Add(null, null, "반제품", "BACK_a02", "등받이", "5 x 12 inch", "EA", "0", null, null, "미사용", "미사용", "미사용", "미사용", null, "(주)에이더블유", "(주)에이더블유");


        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
