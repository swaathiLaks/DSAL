namespace treeViewAssignment2
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
            treeView1 = new TreeView();
            read_only_box = new GroupBox();
            proj_leader_form1 = new CheckBox();
            label2 = new Label();
            name_form1 = new TextBox();
            label1 = new Label();
            uuid_form1 = new TextBox();
            reset = new Button();
            save = new Button();
            load = new Button();
            label3 = new Label();
            label4 = new Label();
            expand_all = new Button();
            collapse_all = new Button();
            panel1 = new Panel();
            read_only_box.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(565, 128);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(1293, 729);
            treeView1.TabIndex = 1;
            // 
            // read_only_box
            // 
            read_only_box.Controls.Add(proj_leader_form1);
            read_only_box.Controls.Add(label2);
            read_only_box.Controls.Add(name_form1);
            read_only_box.Controls.Add(label1);
            read_only_box.Controls.Add(uuid_form1);
            read_only_box.Location = new Point(3, 128);
            read_only_box.Name = "read_only_box";
            read_only_box.Size = new Size(534, 224);
            read_only_box.TabIndex = 2;
            read_only_box.TabStop = false;
            read_only_box.Text = "Selected Role Node Information";
            // 
            // proj_leader_form1
            // 
            proj_leader_form1.AutoSize = true;
            proj_leader_form1.Location = new Point(6, 127);
            proj_leader_form1.Name = "proj_leader_form1";
            proj_leader_form1.Size = new Size(188, 29);
            proj_leader_form1.TabIndex = 4;
            proj_leader_form1.Text = "Project Leader Role";
            proj_leader_form1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 99);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 3;
            label2.Text = "Name";
            // 
            // name_form1
            // 
            name_form1.Location = new Point(194, 93);
            name_form1.Name = "name_form1";
            name_form1.Size = new Size(334, 31);
            name_form1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 62);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 1;
            label1.Text = "UUID";
            // 
            // uuid_form1
            // 
            uuid_form1.Location = new Point(194, 56);
            uuid_form1.Name = "uuid_form1";
            uuid_form1.Size = new Size(334, 31);
            uuid_form1.TabIndex = 0;
            // 
            // reset
            // 
            reset.Location = new Point(4, 369);
            reset.Name = "reset";
            reset.Size = new Size(112, 34);
            reset.TabIndex = 3;
            reset.Text = "Reset";
            reset.UseVisualStyleBackColor = true;
            reset.Click += reset_Click;
            // 
            // save
            // 
            save.Location = new Point(122, 369);
            save.Name = "save";
            save.Size = new Size(112, 34);
            save.TabIndex = 4;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // load
            // 
            load.Location = new Point(240, 369);
            load.Name = "load";
            load.Size = new Size(112, 34);
            load.TabIndex = 5;
            load.Text = "Load";
            load.UseVisualStyleBackColor = true;
            load.Click += load_Click;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(3, 406);
            label3.Name = "label3";
            label3.Size = new Size(503, 124);
            label3.TabIndex = 6;
            // 
            // label4
            // 
            label4.Location = new Point(565, 9);
            label4.Name = "label4";
            label4.Size = new Size(470, 57);
            label4.TabIndex = 7;
            label4.Text = "Role Node Tree View\r\nRight click to perform actions: edit, remove and add roles";
            // 
            // expand_all
            // 
            expand_all.Location = new Point(565, 69);
            expand_all.Name = "expand_all";
            expand_all.Size = new Size(112, 34);
            expand_all.TabIndex = 8;
            expand_all.Text = "Expand All";
            expand_all.UseVisualStyleBackColor = true;
            expand_all.Click += expand_all_Click;
            // 
            // collapse_all
            // 
            collapse_all.Location = new Point(704, 69);
            collapse_all.Name = "collapse_all";
            collapse_all.Size = new Size(112, 34);
            collapse_all.TabIndex = 9;
            collapse_all.Text = "Collapse All";
            collapse_all.UseVisualStyleBackColor = true;
            collapse_all.Click += collapse_all_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(collapse_all);
            panel1.Controls.Add(expand_all);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1853, 122);
            panel1.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1853, 761);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(load);
            Controls.Add(save);
            Controls.Add(reset);
            Controls.Add(read_only_box);
            Controls.Add(treeView1);
            Name = "Form1";
            Text = "Role Form";
            read_only_box.ResumeLayout(false);
            read_only_box.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        public GroupBox read_only_box;
        private Label label1;
        public TextBox uuid_form1;
        public CheckBox proj_leader_form1;
        private Label label2;
        public TextBox name_form1;
        private Button reset;
        private Button save;
        private Button load;
        private Label label3;
        private Label label4;
        private Button expand_all;
        private Button collapse_all;
        private Panel panel1;
    }
}