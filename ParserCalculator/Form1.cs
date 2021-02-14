using System;                                                                               /*___________________________________*/
using System.Collections.Generic;                                                           /*|---Calculator with Math Parser---|*/
using System.ComponentModel;                                                                /*|_________________________________|*/
using System.Data;                                                                          /*| Parse mathematical expressions, |*/
using System.Drawing;                                                                       /*| use various functions or        |*/
using System.Linq;                                                                          /*| just punch in some numbers!     |*/
using System.Text;                                                                          /*|---------------------------------|*/
using System.Threading.Tasks;                                                               /*| 2021.02.14 - Michael Häfliger   |*/
using System.Runtime.InteropServices;                                                       /*|---------------------------------|*/
using System.Windows.Forms;                                                                 /*| mXparser@http://mathparser.org/ |*/
using org.mariuszgromada.math.mxparser;                                                     /*|_________________________________|*/

namespace ParserCalculator                                                                  /*___________________________________*/
{                                                                                           /**/
    public partial class SmartCalculator : Form                                             /*Form Class                         */
    {                                                                                       /**/
        [DllImport("user32.dll")]                                                           /*Draggable window                   */
        private static extern bool ReleaseCapture();                                        /**/
        [DllImport("user32.dll")]                                                           /**/
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wp, int lp);        /**/
        protected override void OnMouseDown(MouseEventArgs e)                               /**/
        {                                                                                   /**/
            base.OnMouseDown(e);                                                            /**/
            if (e.Button == MouseButtons.Left) {                                            /**/
                ReleaseCapture();                                                           /**/
                SendMessage(Handle, 161, 2, 0);                                             /**/
            }                                                                               /**/
        }                                                                                   /**/
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]                         /*___________________________________*/
        private static extern IntPtr CreateRoundRectRgn                                     /*Rounded corners on main form       */
            (                                                                               /**/
                int nLeftRect,                                                              /**/
                int nTopRect,                                                               /**/
                int nRightRect,                                                             /**/
                int nBottomRect,                                                            /**/
                int nWidthEllipse,                                                          /**/
                int nHeightEllipse                                                          /**/
            );                                                                              /*___________________________________*/
        private static readonly Timer Timer = new Timer();                                  /* Timer for Welcome Message         */
        public SmartCalculator()                                                            /*INIT                               */
        {                                                                                   /**/
            InitializeComponent();                                                          /**/
            this.FormBorderStyle = FormBorderStyle.None;                                    /**/
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));/**/
            Timer.Tick += TimerEventProcessor;                                              /**/
            Timer.Interval = 3000;                                                          /**/
            Timer.Start();                                                                  /**/
            String welcomeMsg = "Hello :)@Click the face!";                                 /*Timed welcome message              */
            welcomeMsg = welcomeMsg.Replace("@", System.Environment.NewLine);               /**/
            txtScreen.Text = welcomeMsg;                                                    /**/
        }                                                                                   /*___________________________________*/
        private void TimerEventProcessor(object myObject, EventArgs myEventArgs)            /* Timed screen wipe                 */
        {                                                                                   /**/
            Timer.Stop();                                                                   /**/
            txtScreen.Text = "";                                                            /**/
        }                                                                                   /*___________________________________*/
        public void Enter_Click(object sender, EventArgs e)                                 /*Buttons and stuff                  */
        {                                                                                   /*___________________________________*/
            Expression e1 = new Expression(txtScreen.Text);                                 /*Enter                              */
            double Resultat = e1.calculate();                                               /**/
            txtScreen.Text = Resultat.ToString();                                           /**/
        }                                                                                   /*___________________________________*/
        private void btnOne_Click(object sender, EventArgs e)                               /*One                                */
        {                                                                                   /**/
            double Eins = 1;                                                                /**/
            txtScreen.Text += Eins.ToString();                                              /**/
        }                                                                                   /*___________________________________*/
        private void btnTwo_Click(object sender, EventArgs e)                               /*Two                                */
        {                                                                                   /**/
            double Zwei = 2;                                                                /**/
            txtScreen.Text += Zwei.ToString();                                              /**/
        }                                                                                   /*___________________________________*/
        private void btnThree_Click(object sender, EventArgs e)                             /*Three                              */
        {                                                                                   /**/
            double Drei = 3;                                                                /**/
            txtScreen.Text += Drei.ToString();                                              /**/
        }                                                                                   /*___________________________________*/
        private void btnFour_Click(object sender, EventArgs e)                              /*Four                               */
        {                                                                                   /**/
            double Vier = 4;                                                                /**/
            txtScreen.Text += Vier.ToString();                                              /**/
        }                                                                                   /*___________________________________*/
        private void btnFive_Click(object sender, EventArgs e)                              /*Five                               */
        {                                                                                   /**/
            double Fuenf = 5;                                                               /**/
            txtScreen.Text += Fuenf.ToString();                                             /**/
        }                                                                                   /*___________________________________*/
        private void btnSix_Click(object sender, EventArgs e)                               /*Six                                */
        {                                                                                   /**/
            double Sechs = 6;                                                               /**/
            txtScreen.Text += Sechs.ToString();                                             /**/
        }                                                                                   /*___________________________________*/
        private void btnSeven_Click(object sender, EventArgs e)                             /*Seven                              */
        {                                                                                   /**/
            double Sieben = 7;                                                              /**/
            txtScreen.Text += Sieben.ToString();                                            /**/
        }                                                                                   /*___________________________________*/
        private void btnEight_Click(object sender, EventArgs e)                             /*Eight                              */
        {                                                                                   /**/
            double Acht = 8;                                                                /**/
            txtScreen.Text += Acht.ToString();                                              /**/
        }                                                                                   /*___________________________________*/
        private void btnNine_Click(object sender, EventArgs e)                              /*Nine                               */
        {                                                                                   /**/
            double Neun = 9;                                                                /**/
            txtScreen.Text += Neun.ToString();                                              /**/
        }                                                                                   /*___________________________________*/
        private void btnZero_Click(object sender, EventArgs e)                              /*Zero                               */
        {                                                                                   /**/
            double Null = 0;                                                                /**/
            txtScreen.Text += Null.ToString();                                              /**/
        }                                                                                   /*___________________________________*/
        private void btnDot_Click(object sender, EventArgs e)                               /*Period                             */
        {                                                                                   /**/
            String Dot = ".";                                                               /**/
            txtScreen.Text += Dot;                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnX_Click(object sender, EventArgs e)                                 /*X-Button                           */
        {                                                                                   /**/
            String CharX = "x";                                                             /**/
            txtScreen.Text += CharX;                                                        /**/
        }                                                                                   /*___________________________________*/
        private void btnDelete_Click(object sender, EventArgs e)                            /*Clear screen                       */
        {                                                                                   /**/
            txtScreen.Text = "";                                                            /**/
        }                                                                                   /*___________________________________*/
        private void btnBack_Click(object sender, EventArgs e)                              /*Delete last character              */
        {                                                                                   /**/
            if (!String.IsNullOrEmpty(txtScreen.Text)) {                                    /**/
                String txtScreenMinus1 = txtScreen.Text.Remove(txtScreen.Text.Length - 1, 1);/**/
                txtScreen.Text = txtScreenMinus1;                                           /**/
            }                                                                               /**/
        }                                                                                   /*___________________________________*/
        private void btnDivide_Click(object sender, EventArgs e)                            /*Divide                             */
        {                                                                                   /**/
            String Divider = "/";                                                           /**/
            txtScreen.Text += Divider;                                                      /**/
        }                                                                                   /*___________________________________*/
        private void btnMultiply_Click(object sender, EventArgs e)                          /*Multiply                           */
        {                                                                                   /**/
            String Multiply = "*";                                                          /**/
            txtScreen.Text += Multiply;                                                     /**/
        }                                                                                   /*___________________________________*/
        private void btnMinus_Click(object sender, EventArgs e)                             /*Subtract                           */
        {                                                                                   /**/
            String Minus = "-";                                                             /**/
            txtScreen.Text += Minus;                                                        /**/
        }                                                                                   /*___________________________________*/
        private void btnPlus_Click(object sender, EventArgs e)                              /*Add                                */
        {                                                                                   /**/
            String Plus = "+";                                                              /**/
            txtScreen.Text += Plus;                                                         /**/
        }                                                                                   /*___________________________________*/
        private void btnOBracket_Click(object sender, EventArgs e)                          /*OpenBracket                        */
        {                                                                                   /**/
            String OBracket = "(";                                                          /**/
            txtScreen.Text += OBracket;                                                     /**/
        }                                                                                   /*___________________________________*/
        private void btnCBracket_Click(object sender, EventArgs e)                          /*CloseBracket                       */
        {                                                                                   /**/
            String CBracket = ")";                                                          /**/
            txtScreen.Text += CBracket;                                                     /**/
        }                                                                                   /*___________________________________*/
        private void btnSmartFace_Click(object sender, EventArgs e)                         /*open "Command List" subform        */
        {                                                                                   /**/
            var form = Application.OpenForms.OfType<formPopup>().FirstOrDefault();          /**/
            if (form != null) {                                                             /**/
                form.Activate();                                                            /**/
            }                                                                               /**/
            else {                                                                          /**/
                var formPopup = new formPopup();                                            /**/
                formPopup.Show();                                                           /**/
            }                                                                               /**/
        }                                                                                   /*___________________________________*/
        private void btnExit_Click(object sender, EventArgs e)                              /*exit button*/
        {                                                                                   /**/
            this.Close();                                                                   /**/
        }                                                                                   /*___________________________________*/
        private void btnMinimize_Click(object sender, EventArgs e)                          /*minimize button*/
        {                                                                                   /**/
            this.WindowState = FormWindowState.Minimized;                                   /**/
        }                                                                                   /*___________________________________*/
        private void updateCursor(object sender, EventArgs e)                               /*move cursor to end position*/
        {                                                                                   /**/
            txtScreen.Select(txtScreen.Text.Length, 0);                                     /**/
        }                                                                                   /*___________________________________*/
        private void EnterPress(object sender, KeyEventArgs e)                              /*Enable enter key for calculation   */
        {                                                                                   /**/
            if (e.KeyCode == Keys.Return) {                                                 /**/
                Expression e1 = new Expression(txtScreen.Text);                             /**/
                double Resultat = e1.calculate();                                           /**/
                txtScreen.Text = Resultat.ToString();                                       /**/
                txtScreen.Select(txtScreen.Text.Length, 0);                                 /*____________________________________*/
            }
        }
    }
}