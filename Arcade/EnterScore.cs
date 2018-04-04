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
    public partial class EnterScore : Form
    {
        int currentIndex;
        int charSelect = 1;
        Label[] labels = new Label[30];
        
        string newName = "";
        int newScore;

        Color textColor, formColor;

        public EnterScore(int _newScore, Color _textColor, Color _formColor, Color _titleColor)
        {
            InitializeComponent();

            newScore = _newScore;
            textColor = _textColor;
            formColor = _formColor;

            #region place buttons in List

            currentIndex = 0;
            labels[0] = aChar;
            labels[1] = bChar;
            labels[2] = cChar;
            labels[3] = dChar;
            labels[4] = eChar;
            labels[5] = fChar;
            labels[6] = gChar;
            labels[7] = hChar;
            labels[8] = iChar;
            labels[9] = jChar;
            labels[10] = kChar;
            labels[11] = lChar;
            labels[12] = mChar;
            labels[13] = nChar;
            labels[14] = oChar;
            labels[15] = pChar;
            labels[16] = qChar;
            labels[17] = rChar;
            labels[18] = sChar;
            labels[19] = tChar;
            labels[20] = uChar;
            labels[21] = vChar;
            labels[22] = wChar;
            labels[23] = xChar;
            labels[24] = yChar;
            labels[25] = zChar;
            labels[26] = extraChar;
            labels[27] = extra2Char;
            labels[28] = extra3Char;
            labels[29] = extra4Char;

            #endregion

            #region set colors

            for (int i = 0; i < labels.Count(); i++)
            {
                labels[i].BackColor = formColor;
                labels[i].ForeColor = textColor;
            }

            nameChar1.BackColor = formColor;
            nameChar2.BackColor = formColor;
            nameChar3.BackColor = formColor;

            nameChar1.ForeColor = textColor;
            nameChar2.ForeColor = textColor;
            nameChar3.ForeColor = textColor;

            scoreLabel.ForeColor = _titleColor;
            enterLabel.ForeColor = _titleColor;

            this.BackColor = formColor;

            currentIndex = 0;
            labels[currentIndex].BackColor = textColor;
            labels[currentIndex].ForeColor = formColor;

            #endregion

            TopMost = true;
            this.Focus();
        }

        private void EnterScore_KeyUp(object sender, KeyEventArgs e)
        {
            labels[currentIndex].BackColor = formColor;
            labels[currentIndex].ForeColor = textColor;

            #region set active button or select letter

            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (currentIndex > 19)
                    {
                        currentIndex -= 20;
                    }
                    else
                    {
                        currentIndex += 10;
                    }
                    break;
                case Keys.Up:
                    if (currentIndex < 10)
                    {
                        currentIndex += 20;
                    }
                    else
                    {
                        currentIndex -= 10;
                    }
                    break;
                case Keys.Right:
                    if (currentIndex == 9 || currentIndex == 19 || currentIndex == 29)
                    {
                        currentIndex -= 9;
                    }
                    else
                    {
                        currentIndex++;
                    }
                    break;
                case Keys.Left:
                    if (currentIndex == 0 || currentIndex == 10 || currentIndex == 20)
                    {
                        currentIndex += 9;
                    }
                    else
                    {
                        currentIndex--;
                    }
                    break;
                case Keys.Space:
                    if (charSelect == 1)
                    {
                        nameChar1.Text = labels[currentIndex].Text;
                        newName += labels[currentIndex].Text;
                        charSelect++;
                    }
                    else if (charSelect == 2)
                    {
                        nameChar2.Text = labels[currentIndex].Text;
                        newName += labels[currentIndex].Text;
                        charSelect++;
                    }
                    else
                    {
                        nameChar3.Text = labels[currentIndex].Text;
                        newName += labels[currentIndex].Text;
                        Close();
                    }
                    break;
                default:
                    break;
            }

            #endregion

            labels[currentIndex].BackColor = textColor;
            labels[currentIndex].ForeColor = formColor;
        }

        private void EnterScore_Paint(object sender, PaintEventArgs e)
        {
            Graphics formGraphics = e.Graphics;
            Pen drawPen = new Pen(textColor, 2);
            formGraphics.DrawRectangle(drawPen, 5, 5, this.Width - 10, this.Height - 10);
        }

        private void EnterScore_FormClosing(object sender, FormClosingEventArgs e)
        {
            Refresh();
            Refresh();
            System.Threading.Thread.Sleep(750);
            if (ArcadeUtilities.highScoreDB.Count() == 0)
            {
                ArcadeUtilities.LoadScores();
            }
            ArcadeUtilities.SaveScores(newScore, newName);
        }
    }
}
