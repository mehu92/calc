using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;

namespace ParserCalculator
{
    public partial class SmartCalculator : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wp, int lp);
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, 161, 2, 0);
            }
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
            );
        public SmartCalculator()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

        }
            
        private void Enter_Click(object sender, EventArgs e)
        {
            Expression e1 = new Expression(txtScreen.Text);
            double Resultat = e1.calculate();
            txtScreen.Text = Resultat.ToString();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            double Eins = 1;
            txtScreen.Text += Eins.ToString();
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            double Zwei = 2;
            txtScreen.Text += Zwei.ToString();
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            double Drei = 3;
            txtScreen.Text += Drei.ToString();
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            double Vier = 4;
            txtScreen.Text += Vier.ToString();
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            double Fuenf = 5;
            txtScreen.Text += Fuenf.ToString();
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            double Sechs = 6;
            txtScreen.Text += Sechs.ToString();
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            double Sieben = 7;
            txtScreen.Text += Sieben.ToString();
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            double Acht = 8;
            txtScreen.Text += Acht.ToString();
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            double Neun = 9;
            txtScreen.Text += Neun.ToString();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            double Null = 0;
            txtScreen.Text += Null.ToString();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            String Dot = ".";
            txtScreen.Text += Dot;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            String CharX = "x";
            txtScreen.Text += CharX;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtScreen.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtScreen.Text)) {
                String txtScreenMinus1 = txtScreen.Text.Remove(txtScreen.Text.Length - 1, 1);
                txtScreen.Text = txtScreenMinus1;
            }

        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            String Divider = "/";
            txtScreen.Text += Divider;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            String Multiply = "*";
            txtScreen.Text += Multiply;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            String Minus = "-";
            txtScreen.Text += Minus;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            String Plus = "+";
            txtScreen.Text += Plus;
        }

        private void btnOBracket_Click(object sender, EventArgs e)
        {
            String OBracket = "(";
            txtScreen.Text += OBracket;
        }

        private void btnCBracket_Click(object sender, EventArgs e)
        {
            String CBracket = ")";
            txtScreen.Text += CBracket;
        }

        private void btnSmartFace_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<formPopup>().FirstOrDefault();
            if (form != null) {
                form.Activate();
            }
            else {
                var formPopup = new formPopup();
                formPopup.Show();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
