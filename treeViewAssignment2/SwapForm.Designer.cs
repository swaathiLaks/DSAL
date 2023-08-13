namespace treeViewAssignment2
{
    partial class SwapForm
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
            swapform_tree = new TreeView();
            swapform_name = new TextBox();
            swapform_salary = new TextBox();
            swapform_role = new ComboBox();
            swapform_rofficer = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            swapform_confirm = new Button();
            swapform_uuid = new TextBox();
            swapform_replacing = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label9 = new Label();
            SuspendLayout();
            // 
            // swapform_tree
            // 
            swapform_tree.Location = new Point(0, 124);
            swapform_tree.Name = "swapform_tree";
            swapform_tree.Size = new Size(521, 560);
            swapform_tree.TabIndex = 0;
            // 
            // swapform_name
            // 
            swapform_name.Location = new Point(805, 306);
            swapform_name.Name = "swapform_name";
            swapform_name.Size = new Size(254, 31);
            swapform_name.TabIndex = 30;
            // 
            // swapform_salary
            // 
            swapform_salary.Location = new Point(805, 343);
            swapform_salary.Name = "swapform_salary";
            swapform_salary.Size = new Size(254, 31);
            swapform_salary.TabIndex = 29;
            // 
            // swapform_role
            // 
            swapform_role.FormattingEnabled = true;
            swapform_role.Location = new Point(805, 380);
            swapform_role.Name = "swapform_role";
            swapform_role.Size = new Size(254, 33);
            swapform_role.TabIndex = 28;
            // 
            // swapform_rofficer
            // 
            swapform_rofficer.FormattingEnabled = true;
            swapform_rofficer.Location = new Point(805, 268);
            swapform_rofficer.Name = "swapform_rofficer";
            swapform_rofficer.Size = new Size(254, 33);
            swapform_rofficer.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(590, 231);
            label8.Name = "label8";
            label8.Size = new Size(54, 25);
            label8.TabIndex = 26;
            label8.Text = "UUID";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(590, 268);
            label7.Name = "label7";
            label7.Size = new Size(148, 25);
            label7.TabIndex = 25;
            label7.Text = "Reporting Officer";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(590, 306);
            label6.Name = "label6";
            label6.Size = new Size(59, 25);
            label6.TabIndex = 24;
            label6.Text = "Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(590, 343);
            label5.Name = "label5";
            label5.Size = new Size(94, 25);
            label5.TabIndex = 23;
            label5.Text = "Salary (S$)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(590, 380);
            label4.Name = "label4";
            label4.Size = new Size(46, 25);
            label4.TabIndex = 22;
            label4.Text = "Role";
            // 
            // swapform_confirm
            // 
            swapform_confirm.Location = new Point(738, 440);
            swapform_confirm.Name = "swapform_confirm";
            swapform_confirm.Size = new Size(112, 34);
            swapform_confirm.TabIndex = 21;
            swapform_confirm.Text = "Confirm";
            swapform_confirm.UseVisualStyleBackColor = true;
            // 
            // swapform_uuid
            // 
            swapform_uuid.Location = new Point(805, 231);
            swapform_uuid.Name = "swapform_uuid";
            swapform_uuid.Size = new Size(254, 31);
            swapform_uuid.TabIndex = 19;
            // 
            // swapform_replacing
            // 
            swapform_replacing.Location = new Point(110, 12);
            swapform_replacing.Name = "swapform_replacing";
            swapform_replacing.Size = new Size(254, 31);
            swapform_replacing.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 33;
            label2.Text = "Replacing:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(590, 124);
            label3.Name = "label3";
            label3.Size = new Size(134, 25);
            label3.TabIndex = 34;
            label3.Text = "Replacing With:";
            // 
            // label9
            // 
            label9.Location = new Point(12, 64);
            label9.Name = "label9";
            label9.Size = new Size(455, 34);
            label9.TabIndex = 35;
            label9.Text = "Select employee to replace with on Tree view.\r\n\r\n.";
            // 
            // SwapForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 684);
            Controls.Add(label9);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(swapform_replacing);
            Controls.Add(swapform_name);
            Controls.Add(swapform_salary);
            Controls.Add(swapform_role);
            Controls.Add(swapform_rofficer);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(swapform_confirm);
            Controls.Add(swapform_uuid);
            Controls.Add(swapform_tree);
            Name = "SwapForm";
            Text = "SwapForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TreeView swapform_tree;
        public TextBox swapform_name;
        public TextBox swapform_salary;
        public ComboBox swapform_role;
        public ComboBox swapform_rofficer;
        public Label label8;
        public Label label7;
        public Label label6;
        public Label label5;
        public Label label4;
        public Button swapform_confirm;
        public TextBox swapform_uuid;
        public TextBox swapform_replacing;
        public Label label2;
        public Label label3;
        public Label label9;
    }
}