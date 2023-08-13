using System.Security.Cryptography.X509Certificates;

namespace treeViewAssignment2
{
    partial class EmployeeForm
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
            eform_label1 = new Label();
            eform_uuid = new TextBox();
            eform_dummy_data = new CheckBox();
            eform_confirm = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            eform_rofficer = new ComboBox();
            eform_role = new ComboBox();
            eform_salary = new TextBox();
            eform_name = new TextBox();
            eform_salary_acc = new CheckBox();
            SuspendLayout();
            // 
            // eform_label1
            // 
            eform_label1.AutoSize = true;
            eform_label1.Location = new Point(193, 9);
            eform_label1.Name = "eform_label1";
            eform_label1.Size = new Size(59, 25);
            eform_label1.TabIndex = 0;
            eform_label1.Text = "label1";
            // 
            // eform_uuid
            // 
            eform_uuid.Location = new Point(227, 62);
            eform_uuid.Name = "eform_uuid";
            eform_uuid.Size = new Size(254, 31);
            eform_uuid.TabIndex = 1;
            // 
            // eform_dummy_data
            // 
            eform_dummy_data.AutoSize = true;
            eform_dummy_data.Location = new Point(12, 264);
            eform_dummy_data.Name = "eform_dummy_data";
            eform_dummy_data.Size = new Size(144, 29);
            eform_dummy_data.TabIndex = 2;
            eform_dummy_data.Text = "Dummy Data";
            eform_dummy_data.UseVisualStyleBackColor = true;
            // 
            // eform_confirm
            // 
            eform_confirm.Location = new Point(158, 315);
            eform_confirm.Name = "eform_confirm";
            eform_confirm.Size = new Size(112, 34);
            eform_confirm.TabIndex = 3;
            eform_confirm.Text = "Confirm";
            eform_confirm.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 211);
            label4.Name = "label4";
            label4.Size = new Size(46, 25);
            label4.TabIndex = 6;
            label4.Text = "Role";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 174);
            label5.Name = "label5";
            label5.Size = new Size(94, 25);
            label5.TabIndex = 7;
            label5.Text = "Salary (S$)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 137);
            label6.Name = "label6";
            label6.Size = new Size(59, 25);
            label6.TabIndex = 8;
            label6.Text = "Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 99);
            label7.Name = "label7";
            label7.Size = new Size(148, 25);
            label7.TabIndex = 9;
            label7.Text = "Reporting Officer";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 62);
            label8.Name = "label8";
            label8.Size = new Size(54, 25);
            label8.TabIndex = 10;
            label8.Text = "UUID";
            // 
            // eform_rofficer
            // 
            eform_rofficer.FormattingEnabled = true;
            eform_rofficer.Location = new Point(227, 99);
            eform_rofficer.Name = "eform_rofficer";
            eform_rofficer.Size = new Size(254, 33);
            eform_rofficer.TabIndex = 11;
            // 
            // eform_role
            // 
            eform_role.FormattingEnabled = true;
            eform_role.Location = new Point(227, 211);
            eform_role.Name = "eform_role";
            eform_role.Size = new Size(254, 33);
            eform_role.TabIndex = 12;
            // 
            // eform_salary
            // 
            eform_salary.Location = new Point(227, 174);
            eform_salary.Name = "eform_salary";
            eform_salary.Size = new Size(254, 31);
            eform_salary.TabIndex = 15;
            // 
            // eform_name
            // 
            eform_name.Location = new Point(227, 137);
            eform_name.Name = "eform_name";
            eform_name.Size = new Size(254, 31);
            eform_name.TabIndex = 16;
            // 
            // eform_salary_acc
            // 
            eform_salary_acc.AutoSize = true;
            eform_salary_acc.Location = new Point(285, 264);
            eform_salary_acc.Name = "eform_salary_acc";
            eform_salary_acc.Size = new Size(196, 29);
            eform_salary_acc.TabIndex = 17;
            eform_salary_acc.Text = "Salary Accountable?";
            eform_salary_acc.UseVisualStyleBackColor = true;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 386);
            Controls.Add(eform_salary_acc);
            Controls.Add(eform_name);
            Controls.Add(eform_salary);
            Controls.Add(eform_role);
            Controls.Add(eform_rofficer);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(eform_confirm);
            Controls.Add(eform_dummy_data);
            Controls.Add(eform_uuid);
            Controls.Add(eform_label1);
            Name = "EmployeeForm";
            Text = "EmployeeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label eform_label1;
        public TextBox eform_uuid;
        public CheckBox eform_dummy_data;
        public Button eform_confirm;
        public Label label4;
        public Label label5;
        public Label label6;
        public Label label7;
        public Label label8;
        public ComboBox eform_rofficer;
        public ComboBox eform_role;
        public TextBox eform_salary;
        public TextBox eform_name;
        public CheckBox eform_salary_acc;
    }
}