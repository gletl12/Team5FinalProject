using CompanyManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;

namespace CompanyManager
{
    public partial class FrmFactoryList : CompanyManager.MDIBaseForm
    {
        public FrmFactoryList()
        {
            InitializeComponent();
        }

        private void FrmFactoryList_Load(object sender, EventArgs e)
        {
            GetdgvColumn();
        }

        private void GetdgvColumn()
        {
            CommonUtil.SetDGVDesign_Num(dgvFactory);

            CommonUtil.AddGridCheckColumn(dgvFactory, "");
            CommonUtil.AddGridImageColumn(dgvFactory, Resources.Edit_16x16,"Edit", 30);
            CommonUtil.AddGridTextColumn(dgvFactory, "시설군", "factory_grade");
            CommonUtil.AddGridTextColumn(dgvFactory, "시설구분", "factory_type");
            CommonUtil.AddGridTextColumn(dgvFactory, "시설명", "factory_name", 120);
            CommonUtil.AddGridTextColumn(dgvFactory, "상위시설", "factory_parent", 120);
            CommonUtil.AddGridTextColumn(dgvFactory, "시설설명", "factory_comment", 150);
            CommonUtil.AddGridTextColumn(dgvFactory, "사용유무", "factory_use");
            CommonUtil.AddGridTextColumn(dgvFactory, "수정자", "up_emp", 120);
            CommonUtil.AddGridTextColumn(dgvFactory, "수정시간", "up_date",170);
        }
    }
}
