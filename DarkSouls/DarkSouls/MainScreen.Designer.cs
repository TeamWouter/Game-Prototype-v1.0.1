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
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.camera3D = new System.Windows.Forms.Panel();
            this.camera2D = new System.Windows.Forms.Panel();
            this.waves2D = new System.Windows.Forms.Panel();
            this.flow.SuspendLayout();
            this.SuspendLayout();
            // 
            // flow
            // 
            this.flow.AutoScroll = true;
            this.flow.Controls.Add(this.camera3D);
            this.flow.Controls.Add(this.camera2D);
            this.flow.Controls.Add(this.waves2D);
            this.flow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow.Location = new System.Drawing.Point(0, 0);
            this.flow.Name = "flow";
            this.flow.Size = new System.Drawing.Size(1146, 668);
            this.flow.TabIndex = 0;
            // 
            // camera3D
            // 
            this.camera3D.Location = new System.Drawing.Point(3, 3);
            this.camera3D.Name = "camera3D";
            this.camera3D.Size = new System.Drawing.Size(1123, 218);
            this.camera3D.TabIndex = 0;
            // 
            // camera2D
            // 
            this.camera2D.Location = new System.Drawing.Point(3, 227);
            this.camera2D.Name = "camera2D";
            this.camera2D.Size = new System.Drawing.Size(1123, 218);
            this.camera2D.TabIndex = 1;
            // 
            // waves2D
            // 
            this.waves2D.Location = new System.Drawing.Point(3, 451);
            this.waves2D.Name = "waves2D";
            this.waves2D.Size = new System.Drawing.Size(1123, 218);
            this.waves2D.TabIndex = 2;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 668);
            this.Controls.Add(this.flow);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainScreen_KeyUp);
            this.flow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flow;
        private System.Windows.Forms.Panel camera3D;
        private System.Windows.Forms.Panel camera2D;
        private System.Windows.Forms.Panel waves2D;
    }
}

