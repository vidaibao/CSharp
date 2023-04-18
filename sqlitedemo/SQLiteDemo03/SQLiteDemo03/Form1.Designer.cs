namespace SQLiteDemo03
{
    partial class fStudent
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
            label1 = new Label();
            label2 = new Label();
            txtStudentId = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtFirstName = new TextBox();
            label5 = new Label();
            txtLastName = new TextBox();
            label6 = new Label();
            txtYob = new TextBox();
            label7 = new Label();
            txtGpa = new TextBox();
            insert_btn = new Button();
            dataGridView1 = new DataGridView();
            update_btn = new Button();
            delete_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 31);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "Add Student";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(293, 31);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 1;
            label2.Text = "Student List";
            // 
            // txtStudentId
            // 
            txtStudentId.ForeColor = Color.Gray;
            txtStudentId.Location = new Point(127, 59);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(108, 23);
            txtStudentId.TabIndex = 2;
            txtStudentId.Text = "1";
            txtStudentId.TextChanged += txtStudentId_TextChanged;
            txtStudentId.Enter += txtStudentId_Enter;
            txtStudentId.Leave += txtStudentId_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 62);
            label3.Name = "label3";
            label3.Size = new Size(20, 15);
            label3.TabIndex = 0;
            label3.Text = "Id:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 91);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 0;
            label4.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(127, 88);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(108, 23);
            txtFirstName.TabIndex = 2;
            txtFirstName.Text = "First Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 120);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 0;
            label5.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(127, 117);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(108, 23);
            txtLastName.TabIndex = 2;
            txtLastName.Text = "Last Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 149);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 0;
            label6.Text = "Year od Birth";
            // 
            // txtYob
            // 
            txtYob.Location = new Point(127, 146);
            txtYob.Name = "txtYob";
            txtYob.Size = new Size(108, 23);
            txtYob.TabIndex = 2;
            txtYob.Text = "Yob";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(52, 178);
            label7.Name = "label7";
            label7.Size = new Size(30, 15);
            label7.TabIndex = 0;
            label7.Text = "GPA";
            // 
            // txtGpa
            // 
            txtGpa.Location = new Point(127, 175);
            txtGpa.Name = "txtGpa";
            txtGpa.Size = new Size(108, 23);
            txtGpa.TabIndex = 2;
            txtGpa.Text = "Gpa";
            // 
            // insert_btn
            // 
            insert_btn.Location = new Point(52, 233);
            insert_btn.Name = "insert_btn";
            insert_btn.Size = new Size(183, 26);
            insert_btn.TabIndex = 4;
            insert_btn.Text = "Insert";
            insert_btn.UseVisualStyleBackColor = true;
            insert_btn.Click += insert_btn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(293, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(374, 269);
            dataGridView1.TabIndex = 5;
            // 
            // update_btn
            // 
            update_btn.Location = new Point(52, 270);
            update_btn.Name = "update_btn";
            update_btn.Size = new Size(183, 24);
            update_btn.TabIndex = 6;
            update_btn.Text = "Update";
            update_btn.UseVisualStyleBackColor = true;
            // 
            // delete_btn
            // 
            delete_btn.Location = new Point(52, 304);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(183, 24);
            delete_btn.TabIndex = 7;
            delete_btn.Text = "Delete";
            delete_btn.UseVisualStyleBackColor = true;
            // 
            // fStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 353);
            Controls.Add(delete_btn);
            Controls.Add(update_btn);
            Controls.Add(dataGridView1);
            Controls.Add(insert_btn);
            Controls.Add(txtGpa);
            Controls.Add(txtYob);
            Controls.Add(label7);
            Controls.Add(txtLastName);
            Controls.Add(label6);
            Controls.Add(txtFirstName);
            Controls.Add(label5);
            Controls.Add(txtStudentId);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "fStudent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SQLite for Student Management";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtStudentId;
        private Label label3;
        private Label label4;
        private TextBox txtFirstName;
        private Label label5;
        private TextBox txtLastName;
        private Label label6;
        private TextBox txtYob;
        private Label label7;
        private TextBox txtGpa;
        private Button insert_btn;
        private DataGridView dataGridView1;
        private Button update_btn;
        private Button delete_btn;
    }
}