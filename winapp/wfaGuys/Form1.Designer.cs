namespace wfaGuys
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblJoe = new System.Windows.Forms.Label();
            this.lblJack = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.buttonJack2Joe = new System.Windows.Forms.Button();
            this.buttonJoe2Jack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Give $10 to Joe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(378, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "Receive $5 from Jack";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // lblJoe
            // 
            this.lblJoe.AutoSize = true;
            this.lblJoe.Location = new System.Drawing.Point(122, 62);
            this.lblJoe.Name = "lblJoe";
            this.lblJoe.Size = new System.Drawing.Size(68, 12);
            this.lblJoe.TabIndex = 2;
            this.lblJoe.Text = "Joe has $50";
            // 
            // lblJack
            // 
            this.lblJack.AutoSize = true;
            this.lblJack.Location = new System.Drawing.Point(122, 88);
            this.lblJack.Name = "lblJack";
            this.lblJack.Size = new System.Drawing.Size(80, 12);
            this.lblJack.TabIndex = 3;
            this.lblJack.Text = "Jack has $100";
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Location = new System.Drawing.Point(122, 116);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(102, 12);
            this.lblBank.TabIndex = 4;
            this.lblBank.Text = "The bank has $100";
            // 
            // buttonJack2Joe
            // 
            this.buttonJack2Joe.Location = new System.Drawing.Point(127, 219);
            this.buttonJack2Joe.Name = "buttonJack2Joe";
            this.buttonJack2Joe.Size = new System.Drawing.Size(75, 43);
            this.buttonJack2Joe.TabIndex = 0;
            this.buttonJack2Joe.Text = "Jack give $10 to Joe";
            this.buttonJack2Joe.UseVisualStyleBackColor = true;
            this.buttonJack2Joe.Click += new System.EventHandler(this.ButtonJack2Joe_Click);
            // 
            // buttonJoe2Jack
            // 
            this.buttonJoe2Jack.Location = new System.Drawing.Point(378, 219);
            this.buttonJoe2Jack.Name = "buttonJoe2Jack";
            this.buttonJoe2Jack.Size = new System.Drawing.Size(83, 43);
            this.buttonJoe2Jack.TabIndex = 1;
            this.buttonJoe2Jack.Text = "Joe give $15 to Jack";
            this.buttonJoe2Jack.UseVisualStyleBackColor = true;
            this.buttonJoe2Jack.Click += new System.EventHandler(this.ButtonJoe2Jack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.lblJack);
            this.Controls.Add(this.lblJoe);
            this.Controls.Add(this.buttonJoe2Jack);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonJack2Joe);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Fun with Joe and Jack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblJoe;
        private System.Windows.Forms.Label lblJack;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Button buttonJack2Joe;
        private System.Windows.Forms.Button buttonJoe2Jack;
    }
}

