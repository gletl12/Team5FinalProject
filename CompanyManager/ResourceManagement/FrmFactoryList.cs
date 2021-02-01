using CompanyManager.Properties;
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
    public partial class FrmFactoryList : CompanyManager.MDIBaseForm
    {
        List<FactoryVO> list = new List<FactoryVO>();
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

            CommonUtil.SetDGVDesign_CheckBox(dgvFactory);
            CommonUtil.AddGridImageColumn(dgvFactory, Resources.Edit_16x16, "Edit", 30);
            CommonUtil.AddGridTextColumn(dgvFactory, "시설군", "factory_grade");
            CommonUtil.AddGridTextColumn(dgvFactory, "시설구분", "factory_type");
            CommonUtil.AddGridTextColumn(dgvFactory, "시설명", "factory_name", 120);
            CommonUtil.AddGridTextColumn(dgvFactory, "상위시설", "factory_parent", 120);
            CommonUtil.AddGridTextColumn(dgvFactory, "시설설명", "factory_comment", 150);
            CommonUtil.AddGridTextColumn(dgvFactory, "사용유무", "factory_use");
            CommonUtil.AddGridTextColumn(dgvFactory, "수정자", "up_emp", 120);
            CommonUtil.AddGridTextColumn(dgvFactory, "수정시간", "up_date", 170);

            DataRoad();
            LoadCombobox();
            dgvFactory.AutoGenerateColumns = false;
            dgvFactory.AllowUserToAddRows = false;
        }

        private void DataRoad()
        {
            FactoryService service = new FactoryService();

            list = service.GetFactory();

            dgvFactory.DataSource = list;
            dgvFactory.ClearSelection();
        }

        private void LoadCombobox()
        {
            CodeService service = new CodeService();
            List<CodeVO> combobox = service.GetAllCommonCode();

            cboFGrade.DisplayMember = "name";
            cboFGrade.ValueMember = "name";
            List<CodeVO> temp = (from code in combobox
                                 where code.category == "FACTORY_GRADE"
                                 select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "" });
            cboFGrade.DataSource = temp;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            PopFactoryCRUD pop = new PopFactoryCRUD(((FrmMain)this.MdiParent).LoginInfo.emp_id);
            if (pop.ShowDialog() == DialogResult.OK)
            {
                DataRoad();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtCodeName.Text.Length < 1 && cboFGrade.SelectedIndex == 0)
            {
                DataRoad();
            }
            else if (txtCodeName.Text.Length > 0 && cboFGrade.SelectedIndex != 0)
            {
                var sResult = (from factory_grade
                               in list
                               where
                               factory_grade.factory_name.Contains(txtCodeName.Text) && factory_grade.factory_grade.Equals(cboFGrade.SelectedValue)
                               select factory_grade).ToList();
                dgvFactory.DataSource = null;
                dgvFactory.DataSource = sResult;
            }
            else if(txtCodeName.Text.Length > 0 && cboFGrade.SelectedIndex == 0)
            {
                var sResult = (from factory_grade
                            in list
                                where
                                factory_grade.factory_name.Contains(txtCodeName.Text)
                                select factory_grade).ToList();
                dgvFactory.DataSource = null;
                dgvFactory.DataSource = sResult;
            }
            else
            {
                var sResult = (from factory_grade
                               in list
                               where
                               factory_grade.factory_grade.Equals(cboFGrade.SelectedValue)
                               select factory_grade).ToList();
                dgvFactory.DataSource = null;
                dgvFactory.DataSource = sResult;
            }

        }
    }
}
