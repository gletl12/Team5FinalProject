using Service;
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
    public partial class FrmShiftMent : CompanyManager.MDIBaseForm
    {
        public FrmShiftMent()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        #region 그리드뷰 컬럼2개
        private void dataGridView2_Paint(object sender, PaintEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;

            string[] strHeaders = { "헤더1", "헤더2" };

            StringFormat format = new StringFormat();

            format.Alignment = StringAlignment.Center;

            format.LineAlignment = StringAlignment.Center;



            // Category Painting

            {

                Rectangle r1 = gv.GetCellDisplayRectangle(0, -1, false);

                int width1 = gv.GetCellDisplayRectangle(1, -1, false).Width;

                int width2 = gv.GetCellDisplayRectangle(2, -1, false).Width;



                r1.X += 1;

                r1.Y += 1;

                r1.Width = r1.Width + width1 + width2 - 2;

                r1.Height = (r1.Height / 2) - 2;

                e.Graphics.DrawRectangle(new Pen(gv.BackgroundColor), r1);

                e.Graphics.FillRectangle(new SolidBrush(gv.ColumnHeadersDefaultCellStyle.BackColor),

                    r1);



                e.Graphics.DrawString(strHeaders[0],

                    gv.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(gv.ColumnHeadersDefaultCellStyle.ForeColor),

                    r1,

                    format);

            }



            // Projection Painting

            {

                Rectangle r2 = gv.GetCellDisplayRectangle(3, -1, false);

                int width = gv.GetCellDisplayRectangle(4, -1, false).Width;

                r2.X += 1;

                r2.Y += 1;

                r2.Width = r2.Width + width - 2;

                r2.Height = (r2.Height / 2) - 2;

                e.Graphics.DrawRectangle(new Pen(gv.BackgroundColor), r2);

                e.Graphics.FillRectangle(new SolidBrush(gv.ColumnHeadersDefaultCellStyle.BackColor),

                    r2);



                e.Graphics.DrawString(strHeaders[1],

                    gv.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(gv.ColumnHeadersDefaultCellStyle.ForeColor),

                    r2,

                    format);

            }




        }

        private void dataGridView2_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;

            Rectangle rtHeader = gv.DisplayRectangle;

            rtHeader.Height = gv.ColumnHeadersHeight / 2;

            gv.Invalidate(rtHeader);



      
        }

        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;

            Rectangle rtHeader = gv.DisplayRectangle;

            rtHeader.Height = gv.ColumnHeadersHeight / 2;

            gv.Invalidate(rtHeader);



       
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)

            {

                Rectangle r = e.CellBounds;

                r.Y += e.CellBounds.Height / 2;

                r.Height = e.CellBounds.Height / 2;



                e.PaintBackground(r, true);



                e.PaintContent(r);

                e.Handled = true;

            }



       
        }
        #endregion

        private void FrmShiftMent_Load(object sender, EventArgs e)
        {
            #region 그리드뷰 컬럼2개
            for (int i = 0; i < 5; i++)
            {


                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.HeaderText = $"헤더{i}";
                col.Name = $"헤더{i}";
                col.DataPropertyName = $"헤더{i}";
                col.Width = 150;
              
                
                dataGridView2.Columns.Add(col);
            }



            dataGridView2.Rows.Add("1", "1-1", "1-2", "1-3", "1-4");
            dataGridView2.Rows.Add("2", "2-2", "2-3", "2-5", "2");
            #endregion


        }

        private void button14_Click(object sender, EventArgs e)
        {
            ShiftService service = new ShiftService();


        }
    }
}
