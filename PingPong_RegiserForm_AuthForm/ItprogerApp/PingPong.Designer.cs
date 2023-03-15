namespace ItprogerApp
{
    partial class PingPong
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
            this.components = new System.ComponentModel.Container();
            this.Platform = new System.Windows.Forms.PictureBox();
            this.GameBall = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.GamePanel = new System.Windows.Forms.Panel();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.LoseLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Platform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameBall)).BeginInit();
            this.GamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Platform
            // 
            this.Platform.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(105)))), ((int)(((byte)(70)))));
            this.Platform.Location = new System.Drawing.Point(255, 405);
            this.Platform.Name = "Platform";
            this.Platform.Size = new System.Drawing.Size(273, 33);
            this.Platform.TabIndex = 0;
            this.Platform.TabStop = false;
            // 
            // GameBall
            // 
            this.GameBall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(177)))), ((int)(((byte)(84)))));
            this.GameBall.Location = new System.Drawing.Point(149, 152);
            this.GameBall.Name = "GameBall";
            this.GameBall.Size = new System.Drawing.Size(50, 50);
            this.GameBall.TabIndex = 1;
            this.GameBall.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // GamePanel
            // 
            this.GamePanel.Controls.Add(this.LoseLabel);
            this.GamePanel.Controls.Add(this.Platform);
            this.GamePanel.Controls.Add(this.ResultLabel);
            this.GamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GamePanel.Location = new System.Drawing.Point(0, 0);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(800, 450);
            this.GamePanel.TabIndex = 2;
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultLabel.Location = new System.Drawing.Point(618, 26);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(144, 28);
            this.ResultLabel.TabIndex = 0;
            this.ResultLabel.Text = "Результат: 0";
            // 
            // LoseLabel
            // 
            this.LoseLabel.AutoSize = true;
            this.LoseLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoseLabel.Location = new System.Drawing.Point(293, 206);
            this.LoseLabel.Name = "LoseLabel";
            this.LoseLabel.Size = new System.Drawing.Size(202, 31);
            this.LoseLabel.TabIndex = 1;
            this.LoseLabel.Text = "Вы проиграли!";
            this.LoseLabel.Visible = false;
            // 
            // PingPong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GameBall);
            this.Controls.Add(this.GamePanel);
            this.Name = "PingPong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пинг Понг";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PingPong_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Platform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameBall)).EndInit();
            this.GamePanel.ResumeLayout(false);
            this.GamePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Platform;
        private System.Windows.Forms.PictureBox GameBall;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Label LoseLabel;
    }
}