namespace Arcade
{
    partial class PauseScreen
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
            this.pauseLabel = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.continueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pauseLabel
            // 
            this.pauseLabel.AutoSize = true;
            this.pauseLabel.BackColor = System.Drawing.Color.Transparent;
            this.pauseLabel.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseLabel.ForeColor = System.Drawing.Color.Gold;
            this.pauseLabel.Location = new System.Drawing.Point(329, 96);
            this.pauseLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(197, 63);
            this.pauseLabel.TabIndex = 37;
            this.pauseLabel.Text = "Pause";
            // 
            // exitLabel
            // 
            this.exitLabel.BackColor = System.Drawing.Color.Transparent;
            this.exitLabel.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.ForeColor = System.Drawing.Color.Gold;
            this.exitLabel.Location = new System.Drawing.Point(54, 406);
            this.exitLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(756, 144);
            this.exitLabel.TabIndex = 38;
            this.exitLabel.Text = "Press Back Button to Exit";
            this.exitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // continueLabel
            // 
            this.continueLabel.BackColor = System.Drawing.Color.Transparent;
            this.continueLabel.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueLabel.ForeColor = System.Drawing.Color.Gold;
            this.continueLabel.Location = new System.Drawing.Point(26, 210);
            this.continueLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.continueLabel.Name = "continueLabel";
            this.continueLabel.Size = new System.Drawing.Size(817, 161);
            this.continueLabel.TabIndex = 39;
            this.continueLabel.Text = "Press the Green Button to Continue";
            this.continueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PauseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(863, 582);
            this.Controls.Add(this.continueLabel);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.pauseLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PauseScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PauseScreen";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PauseScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PauseScreen_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Label continueLabel;
    }
}