namespace DarkSouls
{
    partial class MainScreen
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
            this.GamePanel = new System.Windows.Forms.Panel();
            this.RadarPanel = new System.Windows.Forms.Panel();
            this.EyesPanel = new System.Windows.Forms.Panel();
            this.EditorPanel = new System.Windows.Forms.Panel();
            this.GamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GamePanel
            // 
            this.GamePanel.Controls.Add(this.EditorPanel);
            this.GamePanel.Controls.Add(this.EyesPanel);
            this.GamePanel.Controls.Add(this.RadarPanel);
            this.GamePanel.Location = new System.Drawing.Point(0, 0);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(1146, 670);
            this.GamePanel.TabIndex = 0;
            // 
            // RadarPanel
            // 
            this.RadarPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RadarPanel.Location = new System.Drawing.Point(3, 3);
            this.RadarPanel.Name = "RadarPanel";
            this.RadarPanel.Size = new System.Drawing.Size(491, 336);
            this.RadarPanel.TabIndex = 0;
            this.RadarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RadarPanel_Paint);
            // 
            // EyesPanel
            // 
            this.EyesPanel.Location = new System.Drawing.Point(500, 3);
            this.EyesPanel.Name = "EyesPanel";
            this.EyesPanel.Size = new System.Drawing.Size(491, 336);
            this.EyesPanel.TabIndex = 1;
            // 
            // EditorPanel
            // 
            this.EditorPanel.Location = new System.Drawing.Point(3, 345);
            this.EditorPanel.Name = "EditorPanel";
            this.EditorPanel.Size = new System.Drawing.Size(491, 311);
            this.EditorPanel.TabIndex = 2;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 668);
            this.Controls.Add(this.GamePanel);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainScreen_KeyUp);
            this.GamePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Panel EditorPanel;
        private System.Windows.Forms.Panel EyesPanel;
        private System.Windows.Forms.Panel RadarPanel;
    }
}

