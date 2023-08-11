namespace seat_simulation_asg
{
    partial class ParentForm
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
            menuStrip1 = new MenuStrip();
            simulationModeToolStripMenuItem = new ToolStripMenuItem();
            normalModeToolStripMenuItem = new ToolStripMenuItem();
            safeDistanceModeToolStripMenuItem = new ToolStripMenuItem();
            safeDistanceSmartModeToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { simulationModeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1628, 33);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // simulationModeToolStripMenuItem
            // 
            simulationModeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { normalModeToolStripMenuItem, safeDistanceModeToolStripMenuItem, safeDistanceSmartModeToolStripMenuItem });
            simulationModeToolStripMenuItem.Name = "simulationModeToolStripMenuItem";
            simulationModeToolStripMenuItem.Size = new Size(164, 29);
            simulationModeToolStripMenuItem.Text = "Simulation Mode";
            // 
            // normalModeToolStripMenuItem
            // 
            normalModeToolStripMenuItem.Name = "normalModeToolStripMenuItem";
            normalModeToolStripMenuItem.Size = new Size(320, 34);
            normalModeToolStripMenuItem.Text = "Normal Mode";
            normalModeToolStripMenuItem.Click += normalModeToolStripMenuItem_Click;
            // 
            // safeDistanceModeToolStripMenuItem
            // 
            safeDistanceModeToolStripMenuItem.Name = "safeDistanceModeToolStripMenuItem";
            safeDistanceModeToolStripMenuItem.Size = new Size(320, 34);
            safeDistanceModeToolStripMenuItem.Text = "Safe distance mode";
            safeDistanceModeToolStripMenuItem.Click += safeDistanceModeToolStripMenuItem_Click;
            // 
            // safeDistanceSmartModeToolStripMenuItem
            // 
            safeDistanceSmartModeToolStripMenuItem.Name = "safeDistanceSmartModeToolStripMenuItem";
            safeDistanceSmartModeToolStripMenuItem.Size = new Size(320, 34);
            safeDistanceSmartModeToolStripMenuItem.Text = "Safe distance smart mode";
            safeDistanceSmartModeToolStripMenuItem.Click += safeDistanceSmartModeToolStripMenuItem_Click;
            // 
            // ParentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1628, 975);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            Name = "ParentForm";
            Text = "ParentForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem simulationModeToolStripMenuItem;
        private ToolStripMenuItem normalModeToolStripMenuItem;
        private ToolStripMenuItem safeDistanceModeToolStripMenuItem;
        private ToolStripMenuItem safeDistanceSmartModeToolStripMenuItem;
    }
}