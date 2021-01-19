using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class CustomTab : TabControl
    {
        public CustomTab()
        {
            InitializeComponent();

            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            
            try
            {
                Rectangle r = e.Bounds;
                r = this.GetTabRect(e.Index);
                r.Offset(2,2);

                //선택된 탭의 백그라운드색상은 흰색 (나머지 탭은 기본값)
                if (this.SelectedIndex == e.Index)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(233, 236, 239)), e.Bounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                }

                //탭의 글씨
                Brush titleBrush;
                string title = this.TabPages[e.Index].Text;
                Font f = this.Font;

                if (this.SelectedIndex == e.Index)
                {
                   titleBrush = new SolidBrush(Color.Black);
                }
                else
                {
                    titleBrush = new SolidBrush(Color.Black);
                }

                
                e.Graphics.DrawString(title, f, titleBrush, new Point(r.X, r.Y));

            }
            catch
            {

            }
            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

        }
    }
}
