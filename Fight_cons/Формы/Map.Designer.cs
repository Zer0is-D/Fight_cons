namespace Fight_cons.form
{
    partial class Map
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
            this.Cave_bt = new System.Windows.Forms.Button();
            this.Vally_bt = new System.Windows.Forms.Button();
            this.Neighborhood_bt = new System.Windows.Forms.Button();
            this.Woods_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Cave_bt
            // 
            this.Cave_bt.Location = new System.Drawing.Point(25, 249);
            this.Cave_bt.Name = "Cave_bt";
            this.Cave_bt.Size = new System.Drawing.Size(75, 23);
            this.Cave_bt.TabIndex = 0;
            this.Cave_bt.Text = "Пещеры";
            this.Cave_bt.UseVisualStyleBackColor = true;
            // 
            // Vally_bt
            // 
            this.Vally_bt.Location = new System.Drawing.Point(213, 161);
            this.Vally_bt.Name = "Vally_bt";
            this.Vally_bt.Size = new System.Drawing.Size(75, 23);
            this.Vally_bt.TabIndex = 1;
            this.Vally_bt.Text = "Долина";
            this.Vally_bt.UseVisualStyleBackColor = true;
            // 
            // Neighborhood_bt
            // 
            this.Neighborhood_bt.Location = new System.Drawing.Point(318, 33);
            this.Neighborhood_bt.Name = "Neighborhood_bt";
            this.Neighborhood_bt.Size = new System.Drawing.Size(145, 23);
            this.Neighborhood_bt.TabIndex = 3;
            this.Neighborhood_bt.Text = "Окрестности деревни";
            this.Neighborhood_bt.UseVisualStyleBackColor = true;
            this.Neighborhood_bt.Click += new System.EventHandler(this.Neighborhood_bt_Click);
            // 
            // Woods_bt
            // 
            this.Woods_bt.Location = new System.Drawing.Point(401, 235);
            this.Woods_bt.Name = "Woods_bt";
            this.Woods_bt.Size = new System.Drawing.Size(75, 23);
            this.Woods_bt.TabIndex = 4;
            this.Woods_bt.Text = "Лес";
            this.Woods_bt.UseVisualStyleBackColor = true;
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 315);
            this.Controls.Add(this.Woods_bt);
            this.Controls.Add(this.Neighborhood_bt);
            this.Controls.Add(this.Vally_bt);
            this.Controls.Add(this.Cave_bt);
            this.Name = "Map";
            this.Text = "Map";
            this.Load += new System.EventHandler(this.Map_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cave_bt;
        private System.Windows.Forms.Button Vally_bt;
        private System.Windows.Forms.Button Neighborhood_bt;
        private System.Windows.Forms.Button Woods_bt;
    }
}