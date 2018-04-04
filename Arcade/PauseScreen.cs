using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcade
{
    public partial class PauseScreen : Form
    {
        Timer timer;
        Color textColor, formColor, titleColor;

        public PauseScreen(Timer _timer, Color _textColor, Color _formColor, Color _titleColor)
        {
            InitializeComponent();

            timer = _timer;
            textColor = _textColor;
            formColor = _formColor;
            titleColor = _titleColor;

            pauseLabel.ForeColor = titleColor;
            continueLabel.ForeColor = textColor;
            exitLabel.ForeColor = textColor;

            pauseLabel.BackColor = formColor;
            continueLabel.BackColor = formColor;
            exitLabel.BackColor = formColor;

            this.BackColor = formColor;
        }

        private void PauseScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.Space:
                    timer.Start();
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void PauseScreen_Paint(object sender, PaintEventArgs e)
        {
            Graphics formGraphics = e.Graphics;
            Pen drawPen = new Pen(textColor, 2);
            formGraphics.DrawRectangle(drawPen, 5, 5, this.Width - 10, this.Height - 10);
        }
    }
}
