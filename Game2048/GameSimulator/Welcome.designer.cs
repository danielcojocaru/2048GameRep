namespace GameSimulator
{
    partial class Welcome
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chb4 = new System.Windows.Forms.CheckBox();
            this.chb5 = new System.Windows.Forms.CheckBox();
            this.chb6 = new System.Windows.Forms.CheckBox();
            this.chb7 = new System.Windows.Forms.CheckBox();
            this.chb8 = new System.Windows.Forms.CheckBox();
            this.chb9 = new System.Windows.Forms.CheckBox();
            this.chb10 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wellcome to the 2024 game!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please choose the game level:";
            // 
            // chb4
            // 
            this.chb4.AutoSize = true;
            this.chb4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb4.Location = new System.Drawing.Point(35, 62);
            this.chb4.Name = "chb4";
            this.chb4.Size = new System.Drawing.Size(113, 22);
            this.chb4.TabIndex = 2;
            this.chb4.Text = "4 x 4 (normal)";
            this.chb4.UseVisualStyleBackColor = true;
            this.chb4.CheckedChanged += new System.EventHandler(this.chb4_CheckedChanged);
            // 
            // chb5
            // 
            this.chb5.AutoSize = true;
            this.chb5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb5.Location = new System.Drawing.Point(33, 90);
            this.chb5.Name = "chb5";
            this.chb5.Size = new System.Drawing.Size(128, 22);
            this.chb5.TabIndex = 3;
            this.chb5.Text = "5 x 5 (advanced)";
            this.chb5.UseVisualStyleBackColor = true;
            this.chb5.CheckedChanged += new System.EventHandler(this.chb4_CheckedChanged);
            // 
            // chb6
            // 
            this.chb6.AutoSize = true;
            this.chb6.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb6.Location = new System.Drawing.Point(33, 118);
            this.chb6.Name = "chb6";
            this.chb6.Size = new System.Drawing.Size(103, 22);
            this.chb6.TabIndex = 4;
            this.chb6.Text = "6 x 6 (profy)";
            this.chb6.UseVisualStyleBackColor = true;
            this.chb6.CheckedChanged += new System.EventHandler(this.chb4_CheckedChanged);
            // 
            // chb7
            // 
            this.chb7.AutoSize = true;
            this.chb7.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb7.Location = new System.Drawing.Point(32, 146);
            this.chb7.Name = "chb7";
            this.chb7.Size = new System.Drawing.Size(135, 22);
            this.chb7.TabIndex = 5;
            this.chb7.Text = "7 x 7 (world class)";
            this.chb7.UseVisualStyleBackColor = true;
            this.chb7.CheckedChanged += new System.EventHandler(this.chb4_CheckedChanged);
            // 
            // chb8
            // 
            this.chb8.AutoSize = true;
            this.chb8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb8.Location = new System.Drawing.Point(31, 173);
            this.chb8.Name = "chb8";
            this.chb8.Size = new System.Drawing.Size(111, 22);
            this.chb8.TabIndex = 6;
            this.chb8.Text = "8 x 8 (what??)";
            this.chb8.UseVisualStyleBackColor = true;
            this.chb8.CheckedChanged += new System.EventHandler(this.chb4_CheckedChanged);
            // 
            // chb9
            // 
            this.chb9.AutoSize = true;
            this.chb9.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb9.Location = new System.Drawing.Point(31, 199);
            this.chb9.Name = "chb9";
            this.chb9.Size = new System.Drawing.Size(127, 22);
            this.chb9.TabIndex = 7;
            this.chb9.Text = "9 x 9 (oh yeah!!)";
            this.chb9.UseVisualStyleBackColor = true;
            this.chb9.CheckedChanged += new System.EventHandler(this.chb4_CheckedChanged);
            // 
            // chb10
            // 
            this.chb10.AutoSize = true;
            this.chb10.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb10.Location = new System.Drawing.Point(31, 227);
            this.chb10.Name = "chb10";
            this.chb10.Size = new System.Drawing.Size(166, 22);
            this.chb10.TabIndex = 8;
            this.chb10.Text = "10 x 10 (Chuck Norris*)";
            this.chb10.UseVisualStyleBackColor = true;
            this.chb10.CheckedChanged += new System.EventHandler(this.chb4_CheckedChanged);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 254);
            this.Controls.Add(this.chb10);
            this.Controls.Add(this.chb9);
            this.Controls.Add(this.chb8);
            this.Controls.Add(this.chb7);
            this.Controls.Add(this.chb6);
            this.Controls.Add(this.chb5);
            this.Controls.Add(this.chb4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Monotxt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2024";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chb4;
        private System.Windows.Forms.CheckBox chb5;
        private System.Windows.Forms.CheckBox chb6;
        private System.Windows.Forms.CheckBox chb7;
        private System.Windows.Forms.CheckBox chb8;
        private System.Windows.Forms.CheckBox chb9;
        private System.Windows.Forms.CheckBox chb10;
    }
}