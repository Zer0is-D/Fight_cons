using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fight_cons.Формы
{
    public partial class ConfigTry : Form
    {
        public static string MainPath = System.Windows.Forms.Application.StartupPath + "\\Fight_cons.exe";

        public ConfigTry()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            Settings.OwnBildVersion = BildVers_checkBox.Checked;
            Settings.DelayEffects = DelayEffect_checkBox.Checked;
            Settings.SoundEffects = Sound_checkBox.Checked;
            Settings.DetiledParamValue = CurrentParamValue_checkBox.Checked;

            Market.NamOfGoods = (sbyte) NumOfGoodsUpDown.Value;
            Market.NamOfBonusies = (sbyte) NamOfBonusiesUpDown.Value;
            Condition.BleedDmg = (sbyte) BleedDmgUpDown.Value;
             
            DialogResult = DialogResult.No;
        }

        private void BildVersActive_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            BildCheck();
        }

        private void BildVers_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            BildCheck();
        }

        private void BildCheck()
        {
            if (StandartVers_checkBox.Checked)
            {
                BildVers_checkBox.Checked = false;
                StandartVers_checkBox.Checked = true;
            }
            else
            {
                BildVers_checkBox.Checked = true;
                StandartVers_checkBox.Checked = false;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            StandartVers_checkBox.Checked = true;
            BildVers_checkBox.Checked = false;
            Sound_checkBox.Checked = false;
            DelayEffect_checkBox.Checked = false;

            NamOfBonusiesUpDown.Value = 2;
            NamOfBonusiesUpDown.Value = 4;
            BleedDmgUpDown.Value = 3;
        }
    }
}
