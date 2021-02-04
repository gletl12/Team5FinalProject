
namespace POP
{
    partial class FrmAllStatusBoard
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
            this.machineControl1 = new POP.MachineControl();
            this.machineControl2 = new POP.MachineControl();
            this.machineControl3 = new POP.MachineControl();
            this.machineControl4 = new POP.MachineControl();
            this.machineControl5 = new POP.MachineControl();
            this.machineControl6 = new POP.MachineControl();
            this.SuspendLayout();
            // 
            // machineControl1
            // 
            this.machineControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.machineControl1.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.machineControl1.Location = new System.Drawing.Point(33, 40);
            this.machineControl1.Margin = new System.Windows.Forms.Padding(5);
            this.machineControl1.Name = "machineControl1";
            this.machineControl1.Size = new System.Drawing.Size(320, 392);
            this.machineControl1.TabIndex = 1;
            // 
            // machineControl2
            // 
            this.machineControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.machineControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.machineControl2.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.machineControl2.Location = new System.Drawing.Point(394, 40);
            this.machineControl2.Margin = new System.Windows.Forms.Padding(5);
            this.machineControl2.Name = "machineControl2";
            this.machineControl2.Size = new System.Drawing.Size(320, 392);
            this.machineControl2.TabIndex = 1;
            // 
            // machineControl3
            // 
            this.machineControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.machineControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.machineControl3.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.machineControl3.Location = new System.Drawing.Point(794, 40);
            this.machineControl3.Margin = new System.Windows.Forms.Padding(5);
            this.machineControl3.Name = "machineControl3";
            this.machineControl3.Size = new System.Drawing.Size(320, 392);
            this.machineControl3.TabIndex = 1;
            // 
            // machineControl4
            // 
            this.machineControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.machineControl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.machineControl4.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.machineControl4.Location = new System.Drawing.Point(33, 494);
            this.machineControl4.Margin = new System.Windows.Forms.Padding(5);
            this.machineControl4.Name = "machineControl4";
            this.machineControl4.Size = new System.Drawing.Size(320, 392);
            this.machineControl4.TabIndex = 1;
            // 
            // machineControl5
            // 
            this.machineControl5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.machineControl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.machineControl5.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.machineControl5.Location = new System.Drawing.Point(394, 494);
            this.machineControl5.Margin = new System.Windows.Forms.Padding(5);
            this.machineControl5.Name = "machineControl5";
            this.machineControl5.Size = new System.Drawing.Size(320, 392);
            this.machineControl5.TabIndex = 1;
            // 
            // machineControl6
            // 
            this.machineControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.machineControl6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.machineControl6.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.machineControl6.Location = new System.Drawing.Point(1159, 40);
            this.machineControl6.Margin = new System.Windows.Forms.Padding(5);
            this.machineControl6.Name = "machineControl6";
            this.machineControl6.Size = new System.Drawing.Size(320, 392);
            this.machineControl6.TabIndex = 1;
            // 
            // FrmAllStatusBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1493, 900);
            this.Controls.Add(this.machineControl6);
            this.Controls.Add(this.machineControl5);
            this.Controls.Add(this.machineControl4);
            this.Controls.Add(this.machineControl3);
            this.Controls.Add(this.machineControl2);
            this.Controls.Add(this.machineControl1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmAllStatusBoard";
            this.ResumeLayout(false);

        }

        #endregion

        private MachineControl machineControl1;
        private MachineControl machineControl2;
        private MachineControl machineControl3;
        private MachineControl machineControl4;
        private MachineControl machineControl5;
        private MachineControl machineControl6;
    }
}
