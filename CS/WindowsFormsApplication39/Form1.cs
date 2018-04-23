using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Controls;

namespace WindowsFormsApplication39 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.MouseMove += Form1_MouseMove;
            this.Paint += Form1_Paint;
            bar1.VisibleChanged += bar1_VisibleChanged;

            bar1.Visible = false;
        }

        void bar1_VisibleChanged(object sender, EventArgs e) {
            if(bar1.Visible) {
                CustomBarControl control = bar1.GetBarControl();
                control.MouseLeave += control_MouseLeave;
            }
        }

        void Form1_MouseMove(object sender, MouseEventArgs e) {
            Rectangle rect = this.ClientRectangle;
            rect.Width = 20;
            if(rect.Contains(e.Location)) {
                ShowBar();
            }
        }
        void control_MouseLeave(object sender, EventArgs e) {
            HideBar();
        }

        private void ShowBar() {
            bar1.Visible = true;
        }

        private void HideBar() {
            bar1.Visible = false;
        }

        void Form1_Paint(object sender, PaintEventArgs e) {
            Rectangle rect = this.ClientRectangle;
            rect.Width = 20;
            e.Graphics.FillRectangle(Brushes.AliceBlue, rect);

            string drawString = "Hover this region to show Bar";

            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat(StringFormatFlags.DirectionVertical);
            e.Graphics.DrawString(drawString, this.Font, drawBrush, 3, 3, drawFormat);
        }
    }
}
