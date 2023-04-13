namespace GameWindowApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new System.Windows.Forms.Panel();
            glControl1 = new OpenTK.GLControl();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(glControl1);
            panel1.Location = new System.Drawing.Point(12, 33);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(800, 600);
            panel1.TabIndex = 0;
            // 
            // glControl1
            // 
            glControl1.BackColor = System.Drawing.Color.Black;
            glControl1.Location = new System.Drawing.Point(0, 0);
            glControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            glControl1.Name = "glControl1";
            glControl1.Size = new System.Drawing.Size(800, 600);
            glControl1.TabIndex = 0;
            glControl1.VSync = true;
            glControl1.Load += glControl1_Load;
            glControl1.Paint += glControl1_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(825, 643);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private OpenTK.GLControl glControl1;
    }
}
