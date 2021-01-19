using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            //this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {

            base.OnDrawItem(e);
            
            //try
            //{
            //    Rectangle r = e.Bounds;
            //    r = this.GetTabRect(e.Index);
            //    r.Offset(2, 2);

            //    //this.Appearance = TabAppearance.FlatButtons;

            //    //선택된 탭의 백그라운드색상은 흰색 (나머지 탭은 기본값)
            //    if (this.SelectedIndex == e.Index)
            //    {
            //        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(216, 220, 227)), e.Bounds);
            //    }
            //    else
            //    {
            //        e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            //    }

            //    //탭의 글씨
            //    Brush titleBrush;
            //    string title = this.TabPages[e.Index].Text;
            //    Font f = this.Font;

            //    if (this.SelectedIndex == e.Index)
            //    {
            //        titleBrush = new SolidBrush(Color.Black);
            //    }
            //    else
            //    {
            //        titleBrush = new SolidBrush(Color.Black);
            //    }


            //    e.Graphics.DrawString(title, f, titleBrush, new Point(r.X, r.Y));

            //}
            //catch
            //{

            //}

        }

        protected void PaintTransparentBackground(Graphics graphics, Rectangle clipRect)
        {
            //graphics.Clear(Color.Transparent);
            //if ((this.Parent != null))
            //{
            //    clipRect.Offset(this.Location);
            //    PaintEventArgs e = new PaintEventArgs(graphics, clipRect);
            //    GraphicsState state = graphics.Save();
            //    graphics.SmoothingMode = SmoothingMode.HighSpeed;
            //    try
            //    {
            //        graphics.TranslateTransform((float)-this.Location.X, (float)-this.Location.Y);
            //        this.InvokePaintBackground(this.Parent, e);
            //        this.InvokePaint(this.Parent, e);
            //    }
            //    finally
            //    {
            //        graphics.Restore(state);
            //        clipRect.Offset(-this.Location.X, -this.Location.Y);
            //    }
            //}

        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.Clear(Color.Transparent);
            if ((this.Parent != null))
            {
                pe.ClipRectangle.Offset(this.Location);
                PaintEventArgs e = new PaintEventArgs(pe.Graphics, pe.ClipRectangle);
                GraphicsState state = pe.Graphics.Save();
                pe.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                try
                {
                    pe.Graphics.TranslateTransform((float)-this.Location.X, (float)-this.Location.Y);
                    this.InvokePaintBackground(this.Parent, e);
                    this.InvokePaint(this.Parent, e);
                }
                finally
                {
                    pe.Graphics.Restore(state);
                    pe.ClipRectangle.Offset(-this.Location.X, -this.Location.Y);
                }
            }
        }
    }
}
