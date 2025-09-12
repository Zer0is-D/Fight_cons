namespace FightCons.WForms
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
            this.StandartVersCheckBox = new System.Windows.Forms.CheckBox();
            this.BildVersCheckBox = new System.Windows.Forms.CheckBox();
            this.SoundCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CurrentParamValueCheckBox = new System.Windows.Forms.CheckBox();
            this.BleedDmgUpDown = new System.Windows.Forms.NumericUpDown();
            this.NumOfGoodsUpDown = new System.Windows.Forms.NumericUpDown();
            this.NamOfBonusiesUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.DelayEffectCheckBox = new System.Windows.Forms.CheckBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SkipStartCheckBox = new System.Windows.Forms.CheckBox();
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
            // StandartVersCheckBox
            // 
            this.StandartVersCheckBox.AutoSize = true;
            this.StandartVersCheckBox.Checked = true;
            this.StandartVersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StandartVersCheckBox.Location = new System.Drawing.Point(12, 234);
            this.StandartVersCheckBox.Name = "StandartVersCheckBox";
            this.StandartVersCheckBox.Size = new System.Drawing.Size(130, 17);
            this.StandartVersCheckBox.TabIndex = 1;
            this.StandartVersCheckBox.Text = "Стандартный режим";
            this.StandartVersCheckBox.UseVisualStyleBackColor = true;
            this.StandartVersCheckBox.CheckedChanged += new System.EventHandler(this.BildVersActive_checkBox_CheckedChanged);
            // 
            // BildVersCheckBox
            // 
            this.BildVersCheckBox.AutoSize = true;
            this.BildVersCheckBox.Location = new System.Drawing.Point(12, 257);
            this.BildVersCheckBox.Name = "BildVersCheckBox";
            this.BildVersCheckBox.Size = new System.Drawing.Size(88, 17);
            this.BildVersCheckBox.TabIndex = 2;
            this.BildVersCheckBox.Text = "Билд режим";
            this.BildVersCheckBox.UseVisualStyleBackColor = true;
            this.BildVersCheckBox.CheckedChanged += new System.EventHandler(this.BildVers_checkBox_CheckedChanged);
            // 
            // SoundCheckBox
            // 
            this.SoundCheckBox.AutoSize = true;
            this.SoundCheckBox.Location = new System.Drawing.Point(227, 234);
            this.SoundCheckBox.Name = "SoundCheckBox";
            this.SoundCheckBox.Size = new System.Drawing.Size(66, 17);
            this.SoundCheckBox.TabIndex = 3;
            this.SoundCheckBox.Text = "Музыка";
            this.SoundCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CurrentParamValueCheckBox);
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
            // CurrentParamValueCheckBox
            // 
            this.CurrentParamValueCheckBox.AutoSize = true;
            this.CurrentParamValueCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentParamValueCheckBox.Location = new System.Drawing.Point(215, 111);
            this.CurrentParamValueCheckBox.Name = "CurrentParamValueCheckBox";
            this.CurrentParamValueCheckBox.Size = new System.Drawing.Size(153, 34);
            this.CurrentParamValueCheckBox.TabIndex = 7;
            this.CurrentParamValueCheckBox.Text = "Подробные значения \r\nпараметров";
            this.CurrentParamValueCheckBox.UseVisualStyleBackColor = true;
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
            this.StartBtn.Location = new System.Drawing.Point(333, 285);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(82, 23);
            this.StartBtn.TabIndex = 5;
            this.StartBtn.Text = "Продолжить";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // DelayEffectCheckBox
            // 
            this.DelayEffectCheckBox.AutoSize = true;
            this.DelayEffectCheckBox.Location = new System.Drawing.Point(227, 257);
            this.DelayEffectCheckBox.Name = "DelayEffectCheckBox";
            this.DelayEffectCheckBox.Size = new System.Drawing.Size(114, 17);
            this.DelayEffectCheckBox.TabIndex = 0;
            this.DelayEffectCheckBox.Text = "Задержка текста";
            this.DelayEffectCheckBox.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.IndianRed;
            this.CancelBtn.ForeColor = System.Drawing.Color.Black;
            this.CancelBtn.Location = new System.Drawing.Point(12, 285);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(59, 23);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "Сброс";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // SkipStartCheckBox
            // 
            this.SkipStartCheckBox.AutoSize = true;
            this.SkipStartCheckBox.Location = new System.Drawing.Point(12, 211);
            this.SkipStartCheckBox.Name = "SkipStartCheckBox";
            this.SkipStartCheckBox.Size = new System.Drawing.Size(130, 17);
            this.SkipStartCheckBox.TabIndex = 7;
            this.SkipStartCheckBox.Text = "Пропуск вступления";
            this.SkipStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConfigTry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 317);
            this.Controls.Add(this.SkipStartCheckBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.DelayEffectCheckBox);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SoundCheckBox);
            this.Controls.Add(this.BildVersCheckBox);
            this.Controls.Add(this.StandartVersCheckBox);
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
        private System.Windows.Forms.CheckBox StandartVersCheckBox;
        private System.Windows.Forms.CheckBox BildVersCheckBox;
        private System.Windows.Forms.CheckBox SoundCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.CheckBox DelayEffectCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.NumericUpDown BleedDmgUpDown;
        private System.Windows.Forms.NumericUpDown NamOfBonusiesUpDown;
        private System.Windows.Forms.NumericUpDown NumOfGoodsUpDown;
        private System.Windows.Forms.CheckBox CurrentParamValueCheckBox;
        private System.Windows.Forms.CheckBox SkipStartCheckBox;
    }
}