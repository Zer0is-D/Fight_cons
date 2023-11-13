namespace Fight_cons.form
{
    partial class Village_map
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
            this.Back_to_vally = new System.Windows.Forms.Button();
            this.Neighborhood_bt = new System.Windows.Forms.Button();
            this.Market_loc_bt = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Inn_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Back_to_vally
            // 
            this.Back_to_vally.Location = new System.Drawing.Point(12, 12);
            this.Back_to_vally.Name = "Back_to_vally";
            this.Back_to_vally.Size = new System.Drawing.Size(103, 23);
            this.Back_to_vally.TabIndex = 0;
            this.Back_to_vally.Text = "Выйти в долину";
            this.Back_to_vally.UseVisualStyleBackColor = true;
            this.Back_to_vally.Click += new System.EventHandler(this.button1_Click);
            // 
            // Neighborhood_bt
            // 
            this.Neighborhood_bt.Location = new System.Drawing.Point(21, 183);
            this.Neighborhood_bt.Name = "Neighborhood_bt";
            this.Neighborhood_bt.Size = new System.Drawing.Size(94, 23);
            this.Neighborhood_bt.TabIndex = 1;
            this.Neighborhood_bt.Text = "Окрестности";
            this.Neighborhood_bt.UseVisualStyleBackColor = true;
            this.Neighborhood_bt.Click += new System.EventHandler(this.Neighborhood_bt_Click);
            // 
            // Market_loc_bt
            // 
            this.Market_loc_bt.Location = new System.Drawing.Point(300, 144);
            this.Market_loc_bt.Name = "Market_loc_bt";
            this.Market_loc_bt.Size = new System.Drawing.Size(75, 23);
            this.Market_loc_bt.TabIndex = 3;
            this.Market_loc_bt.Text = "Рынок";
            this.Market_loc_bt.UseVisualStyleBackColor = true;
            this.Market_loc_bt.Click += new System.EventHandler(this.Market_loc_bt_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(176, 99);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 35);
            this.button5.TabIndex = 4;
            this.button5.Text = "Главная площадь";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Inn_bt
            // 
            this.Inn_bt.Location = new System.Drawing.Point(263, 29);
            this.Inn_bt.Name = "Inn_bt";
            this.Inn_bt.Size = new System.Drawing.Size(75, 23);
            this.Inn_bt.TabIndex = 2;
            this.Inn_bt.Text = "Трактир";
            this.Inn_bt.UseVisualStyleBackColor = true;
            this.Inn_bt.Click += new System.EventHandler(this.Inn_bt_Click);
            // 
            // Village_map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 246);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Market_loc_bt);
            this.Controls.Add(this.Inn_bt);
            this.Controls.Add(this.Neighborhood_bt);
            this.Controls.Add(this.Back_to_vally);
            this.Name = "Village_map";
            this.Text = "Village_map";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Back_to_vally;
        private System.Windows.Forms.Button Neighborhood_bt;
        private System.Windows.Forms.Button Market_loc_bt;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button Inn_bt;
    }
}