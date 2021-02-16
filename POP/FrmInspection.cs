using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace POP
{
    public partial class FrmInspection : POP.BaseForm
    {
        public FrmInspection()
        {
            InitializeComponent();
        }

        
        List<PerformanceVO> list;
      
        private void FrmInspection_Load(object sender, EventArgs e)
        {
            SetGridview();
            DataLoad();
           
        }

        private void SetGridview()
        {
            CommonUtil.SetDGVDesign_Num(dataGridView1);
            dataGridView1.ColumnHeadersHeight = 50;
            
            

            CommonUtil.AddGridTextColumn(dataGridView1, "실적번호", "performance_id", 370,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "지시번호", "wo_id", 370, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "품목", "item_id", 370, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "양품수량", "performance_qty", 370, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "작업자", "ins_emp", 370, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "bad_qty", "bad_qty", 130,false);
            CommonUtil.AddGridTextColumn(dataGridView1, "wo_sdate", "wo_sdate", 130,false);

            //CommonUtil.AddGridTextColumn(dataGridView1, "machine_id", "machine_id", 445, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "machine_name", "machine_name", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "item_name", "item_name", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "wo_state", "wo_state", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "good_wh", "good_wh", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "bad_wh", "bad_wh", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "wo_qty", "wo_qty", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "good_qty", "good_qty", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "Rqty", "Rqty", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "good_wh", "good_wh", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "bad_wh", "bad_wh", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "wo_qty", "wo_qty", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "good_qty", "good_qty", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "Rqty", "Rqty", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "performance_qty", "performance_qty", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "p_state", "p_state", 130, false);
            //CommonUtil.AddGridTextColumn(dataGridView1, "ch_id", "ch_id", 130, false);
            
        }

        private void DataLoad()
        {
            PerformanceService service = new PerformanceService();
            list = service.GetPerformance();
            dataGridView1.DataSource = list;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #region 페이징
        List<PerformanceVO> Templist;
        private int CurrentPage = 1;
        int PagesCount = 1;
        int PageRows = 5;

        private void FrmPerformance_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton ToolStripButton = ((ToolStripButton)sender);

                //Determining the current page
                if (ToolStripButton == btnBackward)
                    CurrentPage--;
                else if (ToolStripButton == btnForward)
                    CurrentPage++;
                else if (ToolStripButton == btnLast)
                    CurrentPage = PagesCount;
                else if (ToolStripButton == btnFirst)
                    CurrentPage = 1;
                else
                    CurrentPage = Convert.ToInt32(ToolStripButton.Text, CultureInfo.InvariantCulture);

                if (CurrentPage < 1)
                    CurrentPage = 1;
                else if (CurrentPage > PagesCount)
                    CurrentPage = PagesCount;

                //Rebind the Datagridview with the data.
                RebindGridForPageChange();

                //Change the pagiantions buttons according to page number
                RefreshPagination();
            }
            catch (Exception) { }
        }
        private void RefreshPagination()
        {
            ToolStripButton[] items = new ToolStripButton[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 };

            //pageStartIndex contains the first button number of pagination.
            int pageStartIndex = 1;

            if (PagesCount > 5 && CurrentPage > 2)
                pageStartIndex = CurrentPage - 2;

            if (PagesCount > 5 && CurrentPage > PagesCount - 2)
                pageStartIndex = PagesCount - 4;

            for (int i = pageStartIndex; i < pageStartIndex + 5; i++)
            {
                if (i > PagesCount)
                {
                    items[i - pageStartIndex].Visible = false;
                }
                else
                {
                    //Changing the page numbers
                    items[i - pageStartIndex].Text = i.ToString(CultureInfo.InvariantCulture);

                    //Setting the Appearance of the page number buttons
                    if (i == CurrentPage)
                    {
                        items[i - pageStartIndex].BackColor = Color.Black;
                        items[i - pageStartIndex].ForeColor = Color.White;
                    }
                    else
                    {
                        items[i - pageStartIndex].BackColor = Color.White;
                        items[i - pageStartIndex].ForeColor = Color.Black;
                    }
                }
            }

            //Enabling or Disalbing pagination first, last, previous , next buttons
            if (CurrentPage == 1)
                btnBackward.Enabled = btnFirst.Enabled = false;
            else
                btnBackward.Enabled = btnFirst.Enabled = true;

            if (CurrentPage == PagesCount)
                btnForward.Enabled = btnLast.Enabled = false;

            else
                btnForward.Enabled = btnLast.Enabled = true;
        }
        private void RebindGridForPageChange()
        {
            //Rebinding the Datagridview with data
            int datasourcestartIndex = (CurrentPage - 1) * PageRows;
            Templist = new List<PerformanceVO>(); 
            for (int i = datasourcestartIndex; i < datasourcestartIndex + PageRows; i++)
            {
                if (i >= list.Count)
                    break;

                Templist.Add(list[i]);
            }

            dataGridView1.DataSource = Templist;
            dataGridView1.Refresh();
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmPOPpopup frm = new FrmPOPpopup();
            frm.Show();
        }
    }
}
