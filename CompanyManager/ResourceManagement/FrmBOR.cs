﻿using System;
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
    public partial class FrmBOR : CompanyManager.MDIBaseForm
    {

        List<CodeVO> codeAllList;
        public FrmBOR()
        {
            InitializeComponent();
        }

        private void FrmBOR_Load(object sender, EventArgs e)
        {
            Image img = Properties.Resources.Edit_16x16;
            Util.CommonUtil.SetDGVDesign_Num(dataGridView1);
            Util.CommonUtil.AddGridCheckColumn(dataGridView1, "", 20);
            Util.CommonUtil.AddGridImageColumn(dataGridView1, img, "Edit", 40);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품목", "", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품명", "", 300);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "공정", "", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "공정명", "", 120);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "설비", "", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "설비명", "", 120);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "Tact Time(Sec)", "", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "우선순위", "", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "공정선행일(Day)", "", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "수율", "", 80);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "사용유무", "", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "비고", "", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "수정자", "", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "수정일", "", 300);
            

            

            dataGridView1.Rows.Add(null, null, "CHAIR_01", "나무 1인용 의자", "B-ASSY", "조립공정", "F_ASSY_01", "최종조립1반", "180", "1", null, null,"사용",null, "관리자","2018-10-28 09:08:16");

            //품목리스트, 공정리스트, 설비리스트, 공통코드

            Service.BORService service = new Service.BORService();
            codeAllList = service.GetBORCode();

            cboRoute.DisplayMember = "name";
            cboRoute.ValueMember = "code";
            List < CodeVO > temp = (from code in codeAllList
                                   where code.category == "machine"
                                   select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "" });
            cboRoute.DataSource = temp;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PopUpBOR popup = new PopUpBOR();
            popup.CodeAllList = codeAllList;
            popup.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                Service.BORService service = new Service.BORService();
                if (service.AddBORList())
                {

                }


            }
            
        }
    }
}
