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
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            инструментыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            содержимоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            опрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
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
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { инструментыToolStripMenuItem, справкаToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(825, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // инструментыToolStripMenuItem
            // 
            инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { параметрыToolStripMenuItem });
            инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
            инструментыToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            инструментыToolStripMenuItem.Text = "&Инструменты";
            // 
            // параметрыToolStripMenuItem
            // 
            параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            параметрыToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            параметрыToolStripMenuItem.Text = "&Параметры";
            параметрыToolStripMenuItem.Click += параметрыToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { содержимоеToolStripMenuItem, toolStripSeparator5, опрограммеToolStripMenuItem });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            справкаToolStripMenuItem.Text = "&Справка";
            // 
            // содержимоеToolStripMenuItem
            // 
            содержимоеToolStripMenuItem.Name = "содержимоеToolStripMenuItem";
            содержимоеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            содержимоеToolStripMenuItem.Text = "&Содержимое";
            содержимоеToolStripMenuItem.Click += содержимоеToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // опрограммеToolStripMenuItem
            // 
            опрограммеToolStripMenuItem.Name = "опрограммеToolStripMenuItem";
            опрограммеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            опрограммеToolStripMenuItem.Text = "&О программе…";
            опрограммеToolStripMenuItem.Click += опрограммеToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(825, 643);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Activated += Form1_Enter;
            Deactivate += Form1_Leave;
            panel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem содержимоеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem опрограммеToolStripMenuItem;
    }
}
