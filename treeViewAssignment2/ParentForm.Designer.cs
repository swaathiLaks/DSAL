namespace treeViewAssignment2
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
            toolStripMenuItem1 = new ToolStripMenuItem();
            manageRolesToolStripMenuItem = new ToolStripMenuItem();
            manageEmployeesToolStripMenuItem = new ToolStripMenuItem();
            manageProjectsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1973, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { manageRolesToolStripMenuItem, manageEmployeesToolStripMenuItem, manageProjectsToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(78, 29);
            toolStripMenuItem1.Text = "Forms";
            // 
            // manageRolesToolStripMenuItem
            // 
            manageRolesToolStripMenuItem.Name = "manageRolesToolStripMenuItem";
            manageRolesToolStripMenuItem.Size = new Size(270, 34);
            manageRolesToolStripMenuItem.Text = "Manage Roles";
            manageRolesToolStripMenuItem.Click += manageRolesToolStripMenuItem_Click;
            // 
            // manageEmployeesToolStripMenuItem
            // 
            manageEmployeesToolStripMenuItem.Name = "manageEmployeesToolStripMenuItem";
            manageEmployeesToolStripMenuItem.Size = new Size(270, 34);
            manageEmployeesToolStripMenuItem.Text = "Manage Employees";
            manageEmployeesToolStripMenuItem.Click += manageEmployeesToolStripMenuItem_Click;
            // 
            // manageProjectsToolStripMenuItem
            // 
            manageProjectsToolStripMenuItem.Name = "manageProjectsToolStripMenuItem";
            manageProjectsToolStripMenuItem.Size = new Size(270, 34);
            manageProjectsToolStripMenuItem.Text = "Manage Projects";
            manageProjectsToolStripMenuItem.Click += manageProjectsToolStripMenuItem_Click;
            // 
            // ParentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1973, 1016);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "ParentForm";
            Text = "Project manager";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem manageRolesToolStripMenuItem;
        private ToolStripMenuItem manageEmployeesToolStripMenuItem;
        private ToolStripMenuItem manageProjectsToolStripMenuItem;
    }
}