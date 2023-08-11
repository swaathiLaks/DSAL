using System.Security.Cryptography.X509Certificates;

namespace treeViewAssignment2
{
    partial class RoleForm
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
            label1 = new Label();
            roleform_uuid = new TextBox();
            roleform_parent = new TextBox();
            roleform_name = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            roleform_proj_lead = new CheckBox();
            roleform_confirm = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(235, 9);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // roleform_uuid
            // 
            roleform_uuid.Location = new Point(205, 47);
            roleform_uuid.Name = "roleform_uuid";
            roleform_uuid.Size = new Size(307, 31);
            roleform_uuid.TabIndex = 1;
            // 
            // roleform_parent
            // 
            roleform_parent.Location = new Point(205, 121);
            roleform_parent.Name = "roleform_parent";
            roleform_parent.Size = new Size(307, 31);
            roleform_parent.TabIndex = 2;
            // 
            // roleform_name
            // 
            roleform_name.Location = new Point(205, 84);
            roleform_name.Name = "roleform_name";
            roleform_name.Size = new Size(307, 31);
            roleform_name.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 47);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 4;
            label2.Text = "UUID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 84);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 5;
            label3.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 121);
            label4.Name = "label4";
            label4.Size = new Size(100, 25);
            label4.TabIndex = 6;
            label4.Text = "Parent Role";
            // 
            // roleform_proj_lead
            // 
            roleform_proj_lead.AutoSize = true;
            roleform_proj_lead.Location = new Point(36, 173);
            roleform_proj_lead.Name = "roleform_proj_lead";
            roleform_proj_lead.Size = new Size(149, 29);
            roleform_proj_lead.TabIndex = 7;
            roleform_proj_lead.Text = "Project Leader";
            roleform_proj_lead.UseVisualStyleBackColor = true;
            // 
            // roleform_confirm
            // 
            roleform_confirm.Location = new Point(205, 224);
            roleform_confirm.Name = "roleform_confirm";
            roleform_confirm.Size = new Size(112, 34);
            roleform_confirm.TabIndex = 8;
            roleform_confirm.Text = "Confirm";
            roleform_confirm.UseVisualStyleBackColor = true;
            // 
            // RoleForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 288);
            Controls.Add(roleform_confirm);
            Controls.Add(roleform_proj_lead);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(roleform_name);
            Controls.Add(roleform_parent);
            Controls.Add(roleform_uuid);
            Controls.Add(label1);
            Name = "RoleForm";
            Text = "RoleForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label label1;
        public TextBox roleform_uuid;
        public TextBox roleform_parent;
        public TextBox roleform_name;
        public Label label2;
        public Label label3;
        public Label label4;
        public CheckBox roleform_proj_lead;
        public Button roleform_confirm;
    }
}