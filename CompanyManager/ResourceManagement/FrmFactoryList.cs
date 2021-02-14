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
        FactoryVO fvo = new FactoryVO();
        public FrmFactoryList()
        {
            InitializeComponent();
        }

        private void FrmFactoryList_Load(object sender, EventArgs e)
        {
            GetdgvColumn();
            DataRoad();
            RoadCombobox();
        }

        private void GetdgvColumn()
        {
            CommonUtil.SetDGVDesign_Num(dgvFactory);

            CommonUtil.SetDGVDesign_CheckBox(dgvFactory);
            CommonUtil.AddGridImageColumn(dgvFactory, Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dgvFactory, "시설군", "factory_grade");
            CommonUtil.AddGridTextColumn(dgvFactory, "시설구분", "factory_type");
            CommonUtil.AddGridTextColumn(dgvFactory, "시설명", "factory_name", 120);
            CommonUtil.AddGridTextColumn(dgvFactory, "상위시설", "factory_parent", 120);
            CommonUtil.AddGridTextColumn(dgvFactory, "시설설명", "factory_comment", 150);
            CommonUtil.AddGridTextColumn(dgvFactory, "사용유무", "factory_use");
            CommonUtil.AddGridTextColumn(dgvFactory, "수정자", "up_emp", 120);
            CommonUtil.AddGridTextColumn(dgvFactory, "수정시간", "up_date", 160);
            CommonUtil.AddGridTextColumn(dgvFactory, "id", "factory_id", 100, false);

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

        private void RoadCombobox()
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

        private void dgvFactory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                fvo.factory_id = list[e.RowIndex].factory_id;
                fvo.factory_grade = list[e.RowIndex].factory_grade;
                fvo.factory_type = list[e.RowIndex].factory_type;
                fvo.factory_name = list[e.RowIndex].factory_name;
                fvo.factory_parent = list[e.RowIndex].factory_parent;
                fvo.factory_comment = list[e.RowIndex].factory_comment;
                fvo.factory_use = list[e.RowIndex].factory_use;
                fvo.codename = list[e.RowIndex].codename;
                if (e.ColumnIndex == 1)
                {
                    if(list[e.RowIndex].codename == "공장")
                    {
                        PopFactoryCRUD pop = new PopFactoryCRUD(((FrmMain)this.MdiParent).LoginInfo.emp_id, fvo, true);
                        if (pop.ShowDialog() == DialogResult.OK)
                        {
                            DataRoad();
                        }
                    }
                    else
                    {
                        PopFactoryCRUD pop = new PopFactoryCRUD(((FrmMain)this.MdiParent).LoginInfo.emp_id, fvo, true, true);
                        if (pop.ShowDialog() == DialogResult.OK)
                        {
                            DataRoad();
                        }
                    }
                    
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(fvo.factory_grade))
            {
                MessageBox.Show("삭제할 데이터를 선택해주세요");
                return;
            }
            if (MessageBox.Show($"정말로 삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (fvo.codename == "공장")
                {
                    FactoryService service = new FactoryService();
                    if (service.DeleteFactory(fvo.factory_id))
                    {
                        MessageBox.Show("삭제되었습니다.");
                        DataRoad();
                    }
                    else
                        MessageBox.Show("삭제에 실패하였습니다.");
                }
                else
                {
                    FactoryService service = new FactoryService();
                    if (service.DeleteWareHouse(fvo.factory_id))
                    {
                        MessageBox.Show("삭제되었습니다.");
                        DataRoad();
                    }
                    else
                        MessageBox.Show("삭제에 실패하였습니다.");
                }
            }
        }
    }
}
