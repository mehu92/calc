using System;                                                                                           /*___________________________________*/
using System.Collections.Generic;                                                                       /*|---Calculator with Math Parser---|*/
using System.ComponentModel;                                                                            /*|_________________________________|*/
using System.Data;                                                                                      /*| Parse mathematical expressions, |*/
using System.Drawing;                                                                                   /*| use various functions or        |*/
using System.Linq;                                                                                      /*| just punch in some numbers!     |*/
using System.Text;                                                                                      /*|---------------------------------|*/
using System.Threading.Tasks;                                                                           /*| 2021.02.14 - Michael Häfliger   |*/
using System.Runtime.InteropServices;                                                                   /*|---------------------------------|*/
using System.Windows.Forms;                                                                             /*| mXparser@http://mathparser.org/ |*/
                                                                                                        /*|_________________________________|*/
namespace ParserCalculator                                                                              /*___________________________________*/
{                                                                                                       /**/
    public partial class formPopup : Form                                                               /*Form Class                         */
    {                                                                                                   /**/
        [DllImport("user32.dll")]                                                                       /*Draggable window                   */
        private static extern bool ReleaseCapture();                                                    /**/
                                                                                                        /**/
        [DllImport("user32.dll")]                                                                       /**/
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wp, int lp);                    /**/
        protected override void OnMouseDown(MouseEventArgs e)                                           /**/
        {                                                                                               /**/
            base.OnMouseDown(e);                                                                        /**/
            if (e.Button == MouseButtons.Left) {                                                        /**/
                ReleaseCapture();                                                                       /**/
                SendMessage(Handle, 161, 2, 0);                                                         /**/
            }                                                                                           /**/
        }                                                                                               /*___________________________________*/
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]                                     /*Rounded corners on main form       */
        private static extern IntPtr CreateRoundRectRgn                                                 /**/
            (                                                                                           /**/
                int nLeftRect,                                                                          /**/
                int nTopRect,                                                                           /**/
                int nRightRect,                                                                         /**/
                int nBottomRect,                                                                        /**/
                int nWidthEllipse,                                                                      /**/
                int nHeightEllipse                                                                      /*___________________________________*/
            );                                                                                          /**/
        public formPopup()                                                                              /*INIT                               */
        {                                                                                               /**/
            InitializeComponent();                                                                      /**/
            this.FormBorderStyle = FormBorderStyle.None;                                                /**/
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));   /**/
        }                                                                                               /**/
                                                                                                        /**/
        private void btnExit_Click2(object sender, EventArgs e)                                         /*Exit button*/
        {                                                                                               /**/
            this.Close();                                                                               /**/
        }                                                                                               /*___________________________________*/
    }
}
