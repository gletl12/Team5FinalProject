
namespace POP
{
    partial class FrmMain2
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.titleBar1 = new POP.TitleBar();
            this.lblSelect3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.lblSelect2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lblSelect1 = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1496, 64);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // titleBar1
            // 
            this.titleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.titleBar1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titleBar1.HeaderText = "POP";
            this.titleBar1.Location = new System.Drawing.Point(0, 0);
            this.titleBar1.Name = "titleBar1";
            this.titleBar1.Size = new System.Drawing.Size(1496, 33);
            this.titleBar1.TabIndex = 2;
            // 
            // lblSelect3
            // 
            this.lblSelect3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(107)))), ((int)(((byte)(180)))));
            this.lblSelect3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelect3.Location = new System.Drawing.Point(151, 38);
            this.lblSelect3.Name = "lblSelect3";
            this.lblSelect3.Size = new System.Drawing.Size(67, 2);
            this.lblSelect3.TabIndex = 15;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(161)))), ((int)(((byte)(169)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(151, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 25);
            this.button4.TabIndex = 14;
            this.button4.Text = "공정이름";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // lblSelect2
            // 
            this.lblSelect2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(107)))), ((int)(((byte)(180)))));
            this.lblSelect2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelect2.Location = new System.Drawing.Point(81, 39);
            this.lblSelect2.Name = "lblSelect2";
            this.lblSelect2.Size = new System.Drawing.Size(67, 2);
            this.lblSelect2.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(161)))), ((int)(((byte)(169)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(81, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 25);
            this.button3.TabIndex = 12;
            this.button3.Text = "설비 관리";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblSelect1
            // 
            this.lblSelect1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(107)))), ((int)(((byte)(180)))));
            this.lblSelect1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelect1.Location = new System.Drawing.Point(12, 39);
            this.lblSelect1.Name = "lblSelect1";
            this.lblSelect1.Size = new System.Drawing.Size(67, 2);
            this.lblSelect1.TabIndex = 11;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(161)))), ((int)(((byte)(169)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(12, 39);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(67, 25);
            this.btnHome.TabIndex = 10;
            this.btnHome.Text = "메인화면";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // FrmMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.ClientSize = new System.Drawing.Size(1496, 900);
            this.Controls.Add(this.lblSelect3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lblSelect2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblSelect1);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.titleBar1);
            this.Controls.Add(this.splitter1);
            this.IsMdiContainer = true;
            this.Name = "FrmMain2";
            this.Load += new System.EventHandler(this.FrmMain2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private TitleBar titleBar1;
        private System.Windows.Forms.Label lblSelect3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblSelect2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblSelect1;
        private System.Windows.Forms.Button btnHome;
    }
}
