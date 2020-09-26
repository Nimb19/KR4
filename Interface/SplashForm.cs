using System;
using System.Drawing;
using System.Windows.Forms;

namespace Interface
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            startTimer.Start();
        }

        private void endTimer_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.19;
            if (Opacity == 0)
            {
                this.Close();
                return;
            }
        }

        private void startTimer_Tick(object sender, EventArgs e)
        {
            startTimer.Stop();
            endTimer.Start();
        }

        private Point mouseOffset;
        private bool isMouseDown = false;

        private void frmTest_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                    SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void frmTest_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void frmTest_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
    }
}
