using System.Security.Cryptography.X509Certificates;

namespace treeViewAssignment2
{
    partial class Form2
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
            panel1 = new Panel();
            label4 = new Label();
            collapse_all = new Button();
            expand_all = new Button();
            label3 = new Label();
            load = new Button();
            save = new Button();
            reset = new Button();
            read_only_form2 = new GroupBox();
            salary_acc_form2 = new CheckBox();
            label8 = new Label();
            projects_form2 = new TextBox();
            label7 = new Label();
            role_form2 = new TextBox();
            label6 = new Label();
            salary_form2 = new TextBox();
            label5 = new Label();
            name_form2 = new TextBox();
            dummy_data_form2 = new CheckBox();
            label2 = new Label();
            rofficer_form2 = new TextBox();
            label1 = new Label();
            uuid_form2 = new TextBox();
            treeView2 = new TreeView();
            panel1.SuspendLayout();
            read_only_form2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(collapse_all);
            panel1.Controls.Add(expand_all);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1935, 110);
            panel1.TabIndex = 17;
            // 
            // label4
            // 
            label4.Location = new Point(547, 9);
            label4.Name = "label4";
            label4.Size = new Size(470, 57);
            label4.TabIndex = 7;
            label4.Text = "Role Node Tree View\r\nRight click to perform actions: edit, remove and add roles";
            // 
            // collapse_all
            // 
            collapse_all.Location = new Point(671, 69);
            collapse_all.Name = "collapse_all";
            collapse_all.Size = new Size(112, 34);
            collapse_all.TabIndex = 9;
            collapse_all.Text = "Collapse All";
            collapse_all.UseVisualStyleBackColor = true;
            collapse_all.Click += collapse_all_Click;
            // 
            // expand_all
            // 
            expand_all.Location = new Point(546, 69);
            expand_all.Name = "expand_all";
            expand_all.Size = new Size(112, 34);
            expand_all.TabIndex = 8;
            expand_all.Text = "Expand All";
            expand_all.UseVisualStyleBackColor = true;
            expand_all.Click += expand_all_Click;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(3, 441);
            label3.Name = "label3";
            label3.Size = new Size(503, 124);
            label3.TabIndex = 16;
            // 
            // load
            // 
            load.Location = new Point(242, 390);
            load.Name = "load";
            load.Size = new Size(112, 34);
            load.TabIndex = 15;
            load.Text = "Load";
            load.UseVisualStyleBackColor = true;
            load.Click += load_Click;
            // 
            // save
            // 
            save.Location = new Point(124, 390);
            save.Name = "save";
            save.Size = new Size(112, 34);
            save.TabIndex = 14;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // reset
            // 
            reset.Location = new Point(6, 390);
            reset.Name = "reset";
            reset.Size = new Size(112, 34);
            reset.TabIndex = 13;
            reset.Text = "Reset";
            reset.UseVisualStyleBackColor = true;
            reset.Click += reset_Click;
            // 
            // read_only_form2
            // 
            read_only_form2.Controls.Add(salary_acc_form2);
            read_only_form2.Controls.Add(label8);
            read_only_form2.Controls.Add(projects_form2);
            read_only_form2.Controls.Add(label7);
            read_only_form2.Controls.Add(role_form2);
            read_only_form2.Controls.Add(label6);
            read_only_form2.Controls.Add(salary_form2);
            read_only_form2.Controls.Add(label5);
            read_only_form2.Controls.Add(name_form2);
            read_only_form2.Controls.Add(dummy_data_form2);
            read_only_form2.Controls.Add(label2);
            read_only_form2.Controls.Add(rofficer_form2);
            read_only_form2.Controls.Add(label1);
            read_only_form2.Controls.Add(uuid_form2);
            read_only_form2.Location = new Point(3, 12);
            read_only_form2.Name = "read_only_form2";
            read_only_form2.Size = new Size(534, 361);
            read_only_form2.TabIndex = 12;
            read_only_form2.TabStop = false;
            read_only_form2.Text = "Selected Employee Node Information";
            // 
            // salary_acc_form2
            // 
            salary_acc_form2.AutoSize = true;
            salary_acc_form2.Location = new Point(6, 313);
            salary_acc_form2.Name = "salary_acc_form2";
            salary_acc_form2.Size = new Size(188, 29);
            salary_acc_form2.TabIndex = 13;
            salary_acc_form2.Text = "Salary Accountable";
            salary_acc_form2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 247);
            label8.Name = "label8";
            label8.Size = new Size(74, 25);
            label8.TabIndex = 12;
            label8.Text = "Projects";
            // 
            // projects_form2
            // 
            projects_form2.Location = new Point(194, 241);
            projects_form2.Name = "projects_form2";
            projects_form2.Size = new Size(334, 31);
            projects_form2.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 210);
            label7.Name = "label7";
            label7.Size = new Size(46, 25);
            label7.TabIndex = 10;
            label7.Text = "Role";
            // 
            // role_form2
            // 
            role_form2.Location = new Point(194, 204);
            role_form2.Name = "role_form2";
            role_form2.Size = new Size(334, 31);
            role_form2.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 173);
            label6.Name = "label6";
            label6.Size = new Size(59, 25);
            label6.TabIndex = 8;
            label6.Text = "Salary";
            // 
            // salary_form2
            // 
            salary_form2.Location = new Point(194, 167);
            salary_form2.Name = "salary_form2";
            salary_form2.Size = new Size(334, 31);
            salary_form2.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 136);
            label5.Name = "label5";
            label5.Size = new Size(59, 25);
            label5.TabIndex = 6;
            label5.Text = "Name";
            // 
            // name_form2
            // 
            name_form2.Location = new Point(194, 130);
            name_form2.Name = "name_form2";
            name_form2.Size = new Size(334, 31);
            name_form2.TabIndex = 5;
            // 
            // dummy_data_form2
            // 
            dummy_data_form2.AutoSize = true;
            dummy_data_form2.Location = new Point(6, 278);
            dummy_data_form2.Name = "dummy_data_form2";
            dummy_data_form2.Size = new Size(144, 29);
            dummy_data_form2.TabIndex = 4;
            dummy_data_form2.Text = "Dummy Data";
            dummy_data_form2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 99);
            label2.Name = "label2";
            label2.Size = new Size(148, 25);
            label2.TabIndex = 3;
            label2.Text = "Reporting Officer";
            // 
            // rofficer_form2
            // 
            rofficer_form2.Location = new Point(194, 93);
            rofficer_form2.Name = "rofficer_form2";
            rofficer_form2.Size = new Size(334, 31);
            rofficer_form2.TabIndex = 2;
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
            // uuid_form2
            // 
            uuid_form2.Location = new Point(194, 56);
            uuid_form2.Name = "uuid_form2";
            uuid_form2.Size = new Size(334, 31);
            uuid_form2.TabIndex = 0;
            // 
            // treeView2
            // 
            treeView2.Location = new Point(543, 109);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(1392, 827);
            treeView2.TabIndex = 11;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1935, 936);
            Controls.Add(read_only_form2);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(load);
            Controls.Add(save);
            Controls.Add(reset);
            Controls.Add(treeView2);
            Name = "Form2";
            Text = "Employee Form";
            panel1.ResumeLayout(false);
            read_only_form2.ResumeLayout(false);
            read_only_form2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public Panel panel1;
        public Label label4;
        public Button collapse_all;
        public Button expand_all;
        public Label label3;
        public Button load;
        public Button save;
        public Button reset;
        public GroupBox read_only_form2;
        public CheckBox dummy_data_form2;
        public Label label2;
        public TextBox rofficer_form2;
        public Label label1;
        public TextBox uuid_form2;
        public TreeView treeView2;
        public CheckBox salary_acc_form2;
        public Label label8;
        public TextBox projects_form2;
        public Label label7;
        public TextBox role_form2;
        public Label label6;
        public TextBox salary_form2;
        public Label label5;
        public TextBox name_form2;
    }
}