namespace Fight_cons.Формы
{
    partial class ConfigTry
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
            this.StandartVers_checkBox = new System.Windows.Forms.CheckBox();
            this.BildVers_checkBox = new System.Windows.Forms.CheckBox();
            this.Sound_checkBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CurrentParamValue_checkBox = new System.Windows.Forms.CheckBox();
            this.BleedDmgUpDown = new System.Windows.Forms.NumericUpDown();
            this.NumOfGoodsUpDown = new System.Windows.Forms.NumericUpDown();
            this.NamOfBonusiesUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.DelayEffect_checkBox = new System.Windows.Forms.CheckBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BleedDmgUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfGoodsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NamOfBonusiesUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(182, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Config";
            // 
            // StandartVers_checkBox
            // 
            this.StandartVers_checkBox.AutoSize = true;
            this.StandartVers_checkBox.Checked = true;
            this.StandartVers_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StandartVers_checkBox.Location = new System.Drawing.Point(12, 195);
            this.StandartVers_checkBox.Name = "StandartVers_checkBox";
            this.StandartVers_checkBox.Size = new System.Drawing.Size(130, 17);
            this.StandartVers_checkBox.TabIndex = 1;
            this.StandartVers_checkBox.Text = "Стандартный режим";
            this.StandartVers_checkBox.UseVisualStyleBackColor = true;
            this.StandartVers_checkBox.CheckedChanged += new System.EventHandler(this.BildVersActive_checkBox_CheckedChanged);
            // 
            // BildVers_checkBox
            // 
            this.BildVers_checkBox.AutoSize = true;
            this.BildVers_checkBox.Location = new System.Drawing.Point(12, 218);
            this.BildVers_checkBox.Name = "BildVers_checkBox";
            this.BildVers_checkBox.Size = new System.Drawing.Size(88, 17);
            this.BildVers_checkBox.TabIndex = 2;
            this.BildVers_checkBox.Text = "Билд режим";
            this.BildVers_checkBox.UseVisualStyleBackColor = true;
            this.BildVers_checkBox.CheckedChanged += new System.EventHandler(this.BildVers_checkBox_CheckedChanged);
            // 
            // Sound_checkBox
            // 
            this.Sound_checkBox.AutoSize = true;
            this.Sound_checkBox.Location = new System.Drawing.Point(227, 195);
            this.Sound_checkBox.Name = "Sound_checkBox";
            this.Sound_checkBox.Size = new System.Drawing.Size(66, 17);
            this.Sound_checkBox.TabIndex = 3;
            this.Sound_checkBox.Text = "Музыка";
            this.Sound_checkBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CurrentParamValue_checkBox);
            this.groupBox1.Controls.Add(this.BleedDmgUpDown);
            this.groupBox1.Controls.Add(this.NumOfGoodsUpDown);
            this.groupBox1.Controls.Add(this.NamOfBonusiesUpDown);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 153);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Доп настройки";
            // 
            // CurrentParamValue_checkBox
            // 
            this.CurrentParamValue_checkBox.AutoSize = true;
            this.CurrentParamValue_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentParamValue_checkBox.Location = new System.Drawing.Point(215, 111);
            this.CurrentParamValue_checkBox.Name = "CurrentParamValue_checkBox";
            this.CurrentParamValue_checkBox.Size = new System.Drawing.Size(153, 34);
            this.CurrentParamValue_checkBox.TabIndex = 7;
            this.CurrentParamValue_checkBox.Text = "Подробные значения \r\nпараметров";
            this.CurrentParamValue_checkBox.UseVisualStyleBackColor = true;
            // 
            // BleedDmgUpDown
            // 
            this.BleedDmgUpDown.Location = new System.Drawing.Point(9, 118);
            this.BleedDmgUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.BleedDmgUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BleedDmgUpDown.Name = "BleedDmgUpDown";
            this.BleedDmgUpDown.Size = new System.Drawing.Size(50, 22);
            this.BleedDmgUpDown.TabIndex = 8;
            this.BleedDmgUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // NumOfGoodsUpDown
            // 
            this.NumOfGoodsUpDown.Location = new System.Drawing.Point(9, 77);
            this.NumOfGoodsUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumOfGoodsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumOfGoodsUpDown.Name = "NumOfGoodsUpDown";
            this.NumOfGoodsUpDown.Size = new System.Drawing.Size(50, 22);
            this.NumOfGoodsUpDown.TabIndex = 7;
            this.NumOfGoodsUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // NamOfBonusiesUpDown
            // 
            this.NamOfBonusiesUpDown.Location = new System.Drawing.Point(9, 38);
            this.NamOfBonusiesUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NamOfBonusiesUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NamOfBonusiesUpDown.Name = "NamOfBonusiesUpDown";
            this.NamOfBonusiesUpDown.Size = new System.Drawing.Size(50, 22);
            this.NamOfBonusiesUpDown.TabIndex = 6;
            this.NamOfBonusiesUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Урон от кровотечения (1-10)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Количество предметов в магазине (1-10)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество бонусов у оружия в магазине (1-8)";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(333, 246);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(82, 23);
            this.StartBtn.TabIndex = 5;
            this.StartBtn.Text = "Продолжить";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // DelayEffect_checkBox
            // 
            this.DelayEffect_checkBox.AutoSize = true;
            this.DelayEffect_checkBox.Location = new System.Drawing.Point(227, 218);
            this.DelayEffect_checkBox.Name = "DelayEffect_checkBox";
            this.DelayEffect_checkBox.Size = new System.Drawing.Size(114, 17);
            this.DelayEffect_checkBox.TabIndex = 0;
            this.DelayEffect_checkBox.Text = "Задержка текста";
            this.DelayEffect_checkBox.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.IndianRed;
            this.CancelBtn.ForeColor = System.Drawing.Color.Black;
            this.CancelBtn.Location = new System.Drawing.Point(12, 246);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(59, 23);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "Сброс";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ConfigTry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 281);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.DelayEffect_checkBox);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Sound_checkBox);
            this.Controls.Add(this.BildVers_checkBox);
            this.Controls.Add(this.StandartVers_checkBox);
            this.Controls.Add(this.label1);
            this.Name = "ConfigTry";
            this.Text = "Конфигурация";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BleedDmgUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfGoodsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NamOfBonusiesUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox StandartVers_checkBox;
        private System.Windows.Forms.CheckBox BildVers_checkBox;
        private System.Windows.Forms.CheckBox Sound_checkBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.CheckBox DelayEffect_checkBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.NumericUpDown BleedDmgUpDown;
        private System.Windows.Forms.NumericUpDown NamOfBonusiesUpDown;
        private System.Windows.Forms.NumericUpDown NumOfGoodsUpDown;
        private System.Windows.Forms.CheckBox CurrentParamValue_checkBox;
    }
}