namespace Fight_cons
{
    partial class Arm_game
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
            this.slider_ = new System.Windows.Forms.TrackBar();
            this.Start_b = new System.Windows.Forms.Button();
            this.Click_b = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Hard_lab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.slider_)).BeginInit();
            this.SuspendLayout();
            // 
            // slider_
            // 
            this.slider_.Location = new System.Drawing.Point(53, 105);
            this.slider_.Maximum = 300;
            this.slider_.Minimum = 1;
            this.slider_.Name = "slider_";
            this.slider_.Size = new System.Drawing.Size(377, 45);
            this.slider_.TabIndex = 0;
            this.slider_.Value = 150;
            // 
            // Start_b
            // 
            this.Start_b.Location = new System.Drawing.Point(182, 156);
            this.Start_b.Name = "Start_b";
            this.Start_b.Size = new System.Drawing.Size(119, 31);
            this.Start_b.TabIndex = 1;
            this.Start_b.Text = "Начать";
            this.Start_b.UseVisualStyleBackColor = true;
            this.Start_b.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // Click_b
            // 
            this.Click_b.Enabled = false;
            this.Click_b.Location = new System.Drawing.Point(182, 156);
            this.Click_b.Name = "Click_b";
            this.Click_b.Size = new System.Drawing.Size(119, 31);
            this.Click_b.TabIndex = 2;
            this.Click_b.Text = "ЖМИ!";
            this.Click_b.UseVisualStyleBackColor = true;
            this.Click_b.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(126, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Победите противника";
            // 
            // Hard_lab
            // 
            this.Hard_lab.AutoSize = true;
            this.Hard_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Hard_lab.Location = new System.Drawing.Point(11, 11);
            this.Hard_lab.Name = "Hard_lab";
            this.Hard_lab.Size = new System.Drawing.Size(94, 20);
            this.Hard_lab.TabIndex = 4;
            this.Hard_lab.Text = "Сложность";
            // 
            // Arm_game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 203);
            this.Controls.Add(this.Hard_lab);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slider_);
            this.Controls.Add(this.Start_b);
            this.Controls.Add(this.Click_b);
            this.Name = "Arm_game";
            this.Text = "Армреслинг";
            ((System.ComponentModel.ISupportInitialize)(this.slider_)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar slider_;
        private System.Windows.Forms.Button Start_b;
        private System.Windows.Forms.Button Click_b;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Hard_lab;
    }
}