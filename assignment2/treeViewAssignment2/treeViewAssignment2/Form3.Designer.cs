namespace treeViewAssignment2
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            panel1 = new Panel();
            label1 = new Label();
            mode_form3 = new ComboBox();
            load = new Button();
            save = new Button();
            reset = new Button();
            label4 = new Label();
            collapse_all = new Button();
            expand_all = new Button();
            treeView1 = new TreeView();
            add_box = new GroupBox();
            label9 = new Label();
            confirm_add = new Button();
            cancel_add = new Button();
            sfe_add = new Button();
            tlead_add = new ComboBox();
            label8 = new Label();
            label88 = new Label();
            revenue_add = new TextBox();
            label6 = new Label();
            pname_add = new TextBox();
            edit_box = new GroupBox();
            tlead_edit = new ComboBox();
            confirm_edit = new Button();
            label2 = new Label();
            delete_edit = new Button();
            label3 = new Label();
            sfe_edit = new Button();
            revenue_edit = new TextBox();
            label5 = new Label();
            label14 = new Label();
            pname_edit = new TextBox();
            uuid_edit = new TextBox();
            label15 = new Label();
            listView1 = new ListView();
            column_uuid = new ColumnHeader();
            column_project = new ColumnHeader();
            column_revenue = new ColumnHeader();
            column_teamLeader = new ColumnHeader();
            panel1.SuspendLayout();
            add_box.SuspendLayout();
            edit_box.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(mode_form3);
            panel1.Controls.Add(load);
            panel1.Controls.Add(save);
            panel1.Controls.Add(reset);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(collapse_all);
            panel1.Controls.Add(expand_all);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1943, 167);
            panel1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1684, 44);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 12;
            label1.Text = "Mode";
            // 
            // mode_form3
            // 
            mode_form3.FormattingEnabled = true;
            mode_form3.Items.AddRange(new object[] { "View", "Add", "Edit" });
            mode_form3.Location = new Point(1749, 41);
            mode_form3.Name = "mode_form3";
            mode_form3.Size = new Size(182, 33);
            mode_form3.TabIndex = 19;
            mode_form3.Text = "View";
            // 
            // load
            // 
            load.Location = new Point(241, 12);
            load.Name = "load";
            load.Size = new Size(112, 34);
            load.TabIndex = 18;
            load.Text = "Load";
            load.UseVisualStyleBackColor = true;
            load.Click += load_Click;
            // 
            // save
            // 
            save.Location = new Point(123, 12);
            save.Name = "save";
            save.Size = new Size(112, 34);
            save.TabIndex = 17;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // reset
            // 
            reset.Location = new Point(5, 12);
            reset.Name = "reset";
            reset.Size = new Size(112, 34);
            reset.TabIndex = 16;
            reset.Text = "Reset";
            reset.UseVisualStyleBackColor = true;
            reset.Click += reset_Click;
            // 
            // label4
            // 
            label4.Location = new Point(5, 60);
            label4.Name = "label4";
            label4.Size = new Size(470, 33);
            label4.TabIndex = 7;
            label4.Text = "Role Node Tree View\r\n";
            // 
            // collapse_all
            // 
            collapse_all.Location = new Point(123, 96);
            collapse_all.Name = "collapse_all";
            collapse_all.Size = new Size(112, 34);
            collapse_all.TabIndex = 9;
            collapse_all.Text = "Collapse All";
            collapse_all.UseVisualStyleBackColor = true;
            collapse_all.Click += collapse_all_Click;
            // 
            // expand_all
            // 
            expand_all.Location = new Point(5, 96);
            expand_all.Name = "expand_all";
            expand_all.Size = new Size(112, 34);
            expand_all.TabIndex = 8;
            expand_all.Text = "Expand All";
            expand_all.UseVisualStyleBackColor = true;
            expand_all.Click += expand_all_Click;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Left;
            treeView1.Location = new Point(0, 167);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(601, 839);
            treeView1.TabIndex = 12;
            // 
            // add_box
            // 
            add_box.Controls.Add(label9);
            add_box.Controls.Add(confirm_add);
            add_box.Controls.Add(cancel_add);
            add_box.Controls.Add(sfe_add);
            add_box.Controls.Add(tlead_add);
            add_box.Controls.Add(label8);
            add_box.Controls.Add(label88);
            add_box.Controls.Add(revenue_add);
            add_box.Controls.Add(label6);
            add_box.Controls.Add(pname_add);
            add_box.Location = new Point(607, 173);
            add_box.Name = "add_box";
            add_box.Size = new Size(720, 353);
            add_box.TabIndex = 13;
            add_box.TabStop = false;
            add_box.Text = "Add New Project";
            // 
            // label9
            // 
            label9.Location = new Point(6, 50);
            label9.Name = "label9";
            label9.Size = new Size(685, 114);
            label9.TabIndex = 24;
            label9.Text = resources.GetString("label9.Text");
            // 
            // confirm_add
            // 
            confirm_add.Location = new Point(288, 305);
            confirm_add.Name = "confirm_add";
            confirm_add.Size = new Size(123, 34);
            confirm_add.TabIndex = 23;
            confirm_add.Text = "Confirm Add";
            confirm_add.UseVisualStyleBackColor = true;
            // 
            // cancel_add
            // 
            cancel_add.Location = new Point(203, 305);
            cancel_add.Name = "cancel_add";
            cancel_add.Size = new Size(79, 34);
            cancel_add.TabIndex = 22;
            cancel_add.Text = "Cancel";
            cancel_add.UseVisualStyleBackColor = true;
            // 
            // sfe_add
            // 
            sfe_add.Location = new Point(6, 305);
            sfe_add.Name = "sfe_add";
            sfe_add.Size = new Size(191, 34);
            sfe_add.TabIndex = 21;
            sfe_add.Text = "Search For Employee";
            sfe_add.UseVisualStyleBackColor = true;
            // 
            // tlead_add
            // 
            tlead_add.FormattingEnabled = true;
            tlead_add.Location = new Point(194, 247);
            tlead_add.Name = "tlead_add";
            tlead_add.Size = new Size(334, 33);
            tlead_add.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 247);
            label8.Name = "label8";
            label8.Size = new Size(110, 25);
            label8.TabIndex = 12;
            label8.Text = "Team Leader";
            // 
            // label88
            // 
            label88.AutoSize = true;
            label88.Location = new Point(6, 210);
            label88.Name = "label88";
            label88.Size = new Size(78, 25);
            label88.TabIndex = 10;
            label88.Text = "Revenue";
            // 
            // revenue_add
            // 
            revenue_add.Location = new Point(194, 204);
            revenue_add.Name = "revenue_add";
            revenue_add.Size = new Size(334, 31);
            revenue_add.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 173);
            label6.Name = "label6";
            label6.Size = new Size(118, 25);
            label6.TabIndex = 8;
            label6.Text = "Project Name";
            // 
            // pname_add
            // 
            pname_add.Location = new Point(194, 167);
            pname_add.Name = "pname_add";
            pname_add.Size = new Size(334, 31);
            pname_add.TabIndex = 7;
            // 
            // edit_box
            // 
            edit_box.Controls.Add(tlead_edit);
            edit_box.Controls.Add(confirm_edit);
            edit_box.Controls.Add(label2);
            edit_box.Controls.Add(delete_edit);
            edit_box.Controls.Add(label3);
            edit_box.Controls.Add(sfe_edit);
            edit_box.Controls.Add(revenue_edit);
            edit_box.Controls.Add(label5);
            edit_box.Controls.Add(label14);
            edit_box.Controls.Add(pname_edit);
            edit_box.Controls.Add(uuid_edit);
            edit_box.Location = new Point(1333, 173);
            edit_box.Name = "edit_box";
            edit_box.Size = new Size(534, 353);
            edit_box.TabIndex = 14;
            edit_box.TabStop = false;
            edit_box.Text = "View/ Edit New Project";
            // 
            // tlead_edit
            // 
            tlead_edit.FormattingEnabled = true;
            tlead_edit.Location = new Point(194, 177);
            tlead_edit.Name = "tlead_edit";
            tlead_edit.Size = new Size(334, 33);
            tlead_edit.TabIndex = 26;
            // 
            // confirm_edit
            // 
            confirm_edit.Location = new Point(289, 216);
            confirm_edit.Name = "confirm_edit";
            confirm_edit.Size = new Size(123, 34);
            confirm_edit.TabIndex = 26;
            confirm_edit.Text = "Confirm Edit";
            confirm_edit.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 177);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 25;
            label2.Text = "Team Leader";
            // 
            // delete_edit
            // 
            delete_edit.Location = new Point(204, 216);
            delete_edit.Name = "delete_edit";
            delete_edit.Size = new Size(79, 34);
            delete_edit.TabIndex = 25;
            delete_edit.Text = "Delete";
            delete_edit.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 140);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 24;
            label3.Text = "Revenue";
            // 
            // sfe_edit
            // 
            sfe_edit.Location = new Point(7, 216);
            sfe_edit.Name = "sfe_edit";
            sfe_edit.Size = new Size(191, 34);
            sfe_edit.TabIndex = 24;
            sfe_edit.Text = "Search For Employee";
            sfe_edit.UseVisualStyleBackColor = true;
            // 
            // revenue_edit
            // 
            revenue_edit.Location = new Point(194, 134);
            revenue_edit.Name = "revenue_edit";
            revenue_edit.Size = new Size(334, 31);
            revenue_edit.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 103);
            label5.Name = "label5";
            label5.Size = new Size(118, 25);
            label5.TabIndex = 22;
            label5.Text = "Project Name";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 62);
            label14.Name = "label14";
            label14.Size = new Size(54, 25);
            label14.TabIndex = 1;
            label14.Text = "UUID";
            // 
            // pname_edit
            // 
            pname_edit.Location = new Point(194, 97);
            pname_edit.Name = "pname_edit";
            pname_edit.Size = new Size(334, 31);
            pname_edit.TabIndex = 21;
            // 
            // uuid_edit
            // 
            uuid_edit.Location = new Point(194, 56);
            uuid_edit.Name = "uuid_edit";
            uuid_edit.Size = new Size(334, 31);
            uuid_edit.TabIndex = 0;
            // 
            // label15
            // 
            label15.BorderStyle = BorderStyle.FixedSingle;
            label15.Location = new Point(607, 532);
            label15.Name = "label15";
            label15.Size = new Size(454, 360);
            label15.TabIndex = 17;
            // 
            // listView1
            // 
            listView1.Alignment = ListViewAlignment.Left;
            listView1.Columns.AddRange(new ColumnHeader[] { column_uuid, column_project, column_revenue, column_teamLeader });
            listView1.Location = new Point(1067, 532);
            listView1.Name = "listView1";
            listView1.Size = new Size(800, 360);
            listView1.TabIndex = 18;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // column_uuid
            // 
            column_uuid.Text = "UUID";
            // 
            // column_project
            // 
            column_project.Text = "Project Name";
            column_project.Width = 300;
            // 
            // column_revenue
            // 
            column_revenue.Text = "Revenue";
            column_revenue.Width = 100;
            // 
            // column_teamLeader
            // 
            column_teamLeader.Text = "Team Leader";
            column_teamLeader.Width = 300;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1943, 1006);
            Controls.Add(listView1);
            Controls.Add(label15);
            Controls.Add(edit_box);
            Controls.Add(add_box);
            Controls.Add(treeView1);
            Controls.Add(panel1);
            Name = "Form3";
            Text = "Project Form";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            add_box.ResumeLayout(false);
            add_box.PerformLayout();
            edit_box.ResumeLayout(false);
            edit_box.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Button collapse_all;
        private Button expand_all;
        private Label label1;
        public ComboBox mode_form3;
        public Button load;
        public Button save;
        public Button reset;
        public TreeView treeView1;
        public GroupBox add_box;
        private Label label8;
        private Label label88;
        public TextBox revenue_add;
        private Label label6;
        public TextBox pname_add;
        public GroupBox edit_box;
        private Label label14;
        public TextBox uuid_edit;
        public Button confirm_add;
        public Button cancel_add;
        public Button sfe_add;
        public ComboBox tlead_add;
        public ComboBox tlead_edit;
        public Button confirm_edit;
        private Label label2;
        public Button delete_edit;
        private Label label3;
        public Button sfe_edit;
        public TextBox revenue_edit;
        private Label label5;
        public TextBox pname_edit;
        private Label label15;
        public ListView listView1;
        private Label label9;
        public ColumnHeader column_uuid;
        public ColumnHeader column_project;
        public ColumnHeader column_revenue;
        public ColumnHeader column_teamLeader;
    }
}