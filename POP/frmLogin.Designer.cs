namespace POP
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.panBarCode = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDirect = new System.Windows.Forms.Button();
            this.panDirectLogin = new System.Windows.Forms.Panel();
            this.txtPassWord = new POP.PlaceholderTextBox();
            this.txtID = new POP.PlaceholderTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.titleBar1 = new POP.TitleBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panBarCode.SuspendLayout();
            this.panDirectLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panBarCode
            // 
            this.panBarCode.Controls.Add(this.label1);
            this.panBarCode.Controls.Add(this.btnDirect);
            this.panBarCode.Location = new System.Drawing.Point(16, 146);
            this.panBarCode.Name = "panBarCode";
            this.panBarCode.Size = new System.Drawing.Size(358, 49);
            this.panBarCode.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "바코드를 입력하여 주십시오.";
            // 
            // btnDirect
            // 
            this.btnDirect.BackColor = System.Drawing.SystemColors.Control;
            this.btnDirect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDirect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDirect.Location = new System.Drawing.Point(283, 3);
            this.btnDirect.Name = "btnDirect";
            this.btnDirect.Size = new System.Drawing.Size(72, 42);
            this.btnDirect.TabIndex = 13;
            this.btnDirect.Text = "직접 입력";
            this.btnDirect.UseVisualStyleBackColor = false;
            this.btnDirect.Click += new System.EventHandler(this.btnDirect_Click);
            // 
            // panDirectLogin
            // 
            this.panDirectLogin.Controls.Add(this.txtPassWord);
            this.panDirectLogin.Controls.Add(this.txtID);
            this.panDirectLogin.Controls.Add(this.button1);
            this.panDirectLogin.Location = new System.Drawing.Point(12, 148);
            this.panDirectLogin.Name = "panDirectLogin";
            this.panDirectLogin.Size = new System.Drawing.Size(378, 113);
            this.panDirectLogin.TabIndex = 20;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtPassWord.Location = new System.Drawing.Point(4, 38);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PlaceholderText = "비밀번호";
            this.txtPassWord.Size = new System.Drawing.Size(355, 31);
            this.txtPassWord.TabIndex = 17;
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtID.Location = new System.Drawing.Point(4, 5);
            this.txtID.Name = "txtID";
            this.txtID.PlaceholderText = "ID";
            this.txtID.Size = new System.Drawing.Size(355, 31);
            this.txtID.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(4, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(355, 36);
            this.button1.TabIndex = 16;
            this.button1.Text = "로그인";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // titleBar1
            // 
            this.titleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.titleBar1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titleBar1.HeaderText = "HeaderText";
            this.titleBar1.Location = new System.Drawing.Point(0, 0);
            this.titleBar1.Name = "titleBar1";
            this.titleBar1.Size = new System.Drawing.Size(386, 33);
            this.titleBar1.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POP.Properties.Resources.team5_Logo_수정;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 198);
            this.Controls.Add(this.titleBar1);
            this.Controls.Add(this.panBarCode);
            this.Controls.Add(this.panDirectLogin);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.Text = "로그인";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panBarCode.ResumeLayout(false);
            this.panBarCode.PerformLayout();
            this.panDirectLogin.ResumeLayout(false);
            this.panDirectLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDirect;
        private System.Windows.Forms.Panel panDirectLogin;
        private System.Windows.Forms.Button button1;
        private PlaceholderTextBox txtPassWord;
        private PlaceholderTextBox txtID;
        private TitleBar titleBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}