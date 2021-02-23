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
    public partial class SmartCalculator : Form                                             /*form class                         */
    {                                                                                       /**/
        [DllImport("user32.dll")]                                                           /*draggable window                   */
        private static extern bool ReleaseCapture();                                        /**/
        [DllImport("user32.dll")]                                                           /**/
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wp, int lp);        /**/
        protected override void OnMouseDown(MouseEventArgs e)                               /**/
        {                                                                                   /**/
            base.OnMouseDown(e);                                                            /**/
            if (e.Button == MouseButtons.Left)                                              /**/
            {                                                                               /**/
                ReleaseCapture();                                                           /**/
                SendMessage(Handle, 161, 2, 0);                                             /**/
            }                                                                               /**/
        }                                                                                   /**/
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]                         /*___________________________________*/
        private static extern IntPtr CreateRoundRectRgn(                                     /*rounded corners on main form       */
                int nLeftRect,                                                              /**/
                int nTopRect,                                                               /**/
                int nRightRect,                                                             /**/
                int nBottomRect,                                                            /**/
                int nWidthEllipse,                                                          /**/
                int nHeightEllipse                                                          /**/
            );                                                                              /*___________________________________*/                                                                                      
        private static readonly Timer Timer = new Timer();                                  /*timer for welcome message         */
        public SmartCalculator()                                                            /*INIT                               */
        {                                                                                   /**/
            InitializeComponent();                                                          /**/
            FormBorderStyle = FormBorderStyle.None;                                         /**/
            Region = Region.FromHrgn(                                                       /**/
                CreateRoundRectRgn(                                                         /**/
                    0, 0,                                                                   /**/
                    Width, Height,                                                          /**/
                    10, 10                                                                  /**/
                    )                                                                       /**/
                );                                                                          /**/
            Timer.Tick += TimerEventProcessor;                                              /**/
            Timer.Interval = 3000;                                                          /**/
            Timer.Start();                                                                  /**/
            txtScreen.Text = "Hello :)"+Environment.NewLine+"Click the face!";              /**/
        }                                                                                   /*___________________________________*/
        private void TimerEventProcessor(object myObject, EventArgs myEventArgs)            /*timed screen wipe                 */
        {                                                                                   /**/
            Timer.Stop();                                                                   /**/
            txtScreen.Text = "";                                                            /**/
        }                                                                                   /*___________________________________*/
        public void Enter_Click(object sender, EventArgs e)                                 /*buttons and stuff                  */
        {                                                                                   /*___________________________________*/
            Expression e1 = new Expression(txtScreen.Text);                                 /*enter                              */
            txtScreen.Text = e1.calculate().ToString();                                     /**/
        }                                                                                   /*___________________________________*/
        private void btnOne_Click(object sender, EventArgs e)                               /*one                                */
        {                                                                                   /**/                                                                /**/
            txtScreen.Text += '1';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnTwo_Click(object sender, EventArgs e)                               /*two                                */
        {                                                                                   /**/
            txtScreen.Text += '2';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnThree_Click(object sender, EventArgs e)                             /*three                              */
        {                                                                                   /**/
            txtScreen.Text += '3';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnFour_Click(object sender, EventArgs e)                              /*four                               */
        {                                                                                   /**/
            txtScreen.Text += '4';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnFive_Click(object sender, EventArgs e)                              /*five                               */
        {                                                                                   /**/
            txtScreen.Text += '5';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnSix_Click(object sender, EventArgs e)                               /*six                                */
        {                                                                                   /**/
            txtScreen.Text += '6';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnSeven_Click(object sender, EventArgs e)                             /*seven                              */
        {                                                                                   /**/
            txtScreen.Text += '7';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnEight_Click(object sender, EventArgs e)                             /*eight                              */
        {                                                                                   /**/
            txtScreen.Text += '8';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnNine_Click(object sender, EventArgs e)                              /*nine                               */
        {                                                                                   /**/
            txtScreen.Text += '9';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnZero_Click(object sender, EventArgs e)                              /*zero                               */
        {                                                                                   /**/
            txtScreen.Text += '0';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnDot_Click(object sender, EventArgs e)                               /*period                             */
        {                                                                                   /**/
            txtScreen.Text += '.';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnX_Click(object sender, EventArgs e)                                 /*x-button                           */
        {                                                                                   /**/
            txtScreen.Text += 'x';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnDivide_Click(object sender, EventArgs e)                            /*divide                             */
        {                                                                                   /**/
            txtScreen.Text += '/';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnMultiply_Click(object sender, EventArgs e)                          /*multiply                           */
        {                                                                                   /**/
            txtScreen.Text += '*';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnMinus_Click(object sender, EventArgs e)                             /*subtract                           */
        {                                                                                   /**/
            txtScreen.Text += '-';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnPlus_Click(object sender, EventArgs e)                              /*add                                */
        {                                                                                   /**/
            txtScreen.Text += '+';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnOBracket_Click(object sender, EventArgs e)                          /*openBracket                        */
        {                                                                                   /**/
            txtScreen.Text += '(';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnCBracket_Click(object sender, EventArgs e)                          /*closeBracket                       */
        {                                                                                   /**/
            txtScreen.Text += '(';                                                          /**/
        }                                                                                   /*___________________________________*/
        private void btnSmartFace_Click(object sender, EventArgs e)                         /*open "Command List" subform        */
        {                                                                                   /**/
            var form = Application.OpenForms.OfType<formPopup>().FirstOrDefault();          /**/
            if (form != null) {                                                             /**/
                form.Activate();                                                            /**/
            } else {                                                                        /**/
                var formPopup = new formPopup();                                            /**/
                formPopup.Show();                                                           /**/
            }                                                                               /**/
        }                                                                                   /*___________________________________*/
        private void btnDelete_Click(object sender, EventArgs e)                            /*clear screen                       */
        {                                                                                   /**/
            txtScreen.Text = "";                                                            /**/
        }                                                                                   /*___________________________________*/
        private void btnBack_Click(object sender, EventArgs e)                              /*delete last character              */
        {                                                                                   /**/
            if (!String.IsNullOrEmpty(txtScreen.Text)) {                                    /**/
                txtScreen.Text = txtScreen.Text.Substring(0, txtScreen.Text.Length - 1);    /**/
            }                                                                               /**/
        }                                                                                   /*___________________________________*/
        private void btnExit_Click(object sender, EventArgs e)                              /*exit button*/
        {                                                                                   /**/
            Close();                                                                        /**/
        }                                                                                   /*___________________________________*/
        private void btnMinimize_Click(object sender, EventArgs e)                          /*minimize button*/
        {                                                                                   /**/
            WindowState = FormWindowState.Minimized;                                        /**/
        }                                                                                   /*___________________________________*/
        private void updateCursor(object sender, EventArgs e)                               /*move cursor to end position*/
        {                                                                                   /**/
            txtScreen.Select(txtScreen.Text.Length, 0);                                     /**/
        }                                                                                   /*___________________________________*/
        private void EnterPress(object sender, KeyEventArgs e)                              /*enable enter key for calculation   */
        {                                                                                   /**/
            if (e.KeyCode == Keys.Return) {                                                 /**/
                Expression e1 = new Expression(txtScreen.Text);                             /**/
                txtScreen.Text = e1.calculate().ToString();                                 /**/
                updateCursor(null, null);                                                   /*____________________________________*/
            }
        }
    }
}