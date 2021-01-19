using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP
{
    public partial class frmLogin : Form
    {
        // 직접 입력 버튼 클릭 여부
        private bool direct = false;
        // 직접 입력 버튼 클릭시 바뀌는 폼 높이
        private const int D_HEIGHT = 285;

        public frmLogin()
        {
            InitializeComponent();
        }

        // 폼 로드 이벤트 컨트롤 상태 변경
        private void frmLogin_Load(object sender, EventArgs e)
        {
            UpdateControls();
        }

        // 직접 입력 버튼 클릭시 발생하는 이벤트 컨트롤 상태 변경, 폼 크기 조정
        private void btnDirect_Click(object sender, EventArgs e)
        {
            direct = true;
            UpdateControls();
            this.Height = D_HEIGHT;
        }

        // 컨트롤 상태 변경 메서드
        private void UpdateControls()
        {
            panDirectLogin.Visible = panDirectLogin.Enabled = direct;
            panBarCode.Visible = panBarCode.Enabled = !direct;
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
