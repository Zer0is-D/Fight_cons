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

namespace FightCons.WForms
{
    public partial class ConfigTry : Form
    {
        public static string MainPath = System.Windows.Forms.Application.StartupPath + "\\Fight_cons.exe";

        public ConfigTry()
        {
            InitializeComponent();

            NumOfGoodsUpDown.Value = Locations.NamOfGoods;
            NamOfBonusiesUpDown.Value = Locations.NamOfGoods;
            BleedDmgUpDown.Value = Conditions.BleedDmg;

            BildVersCheckBox.Checked = Settings.OwnBildVersion;
            DelayEffectCheckBox.Checked = Settings.DelayEffects;
            SoundCheckBox.Checked = Settings.SoundEffects;
            CurrentParamValueCheckBox.Checked = Settings.DetailedParamValue;
            SkipStartCheckBox.Checked = Settings.SkipStart;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            Settings.OwnBildVersion = BildVersCheckBox.Checked;
            Settings.DelayEffects = DelayEffectCheckBox.Checked;
            Settings.SoundEffects = SoundCheckBox.Checked;
            Settings.DetailedParamValue = CurrentParamValueCheckBox.Checked;
            Settings.SkipStart = SkipStartCheckBox.Checked;

            Locations.NamOfGoods = (sbyte) NumOfGoodsUpDown.Value;
            Locations.NamOfGoods = (sbyte) NamOfBonusiesUpDown.Value;
            Conditions.BleedDmg = (sbyte) BleedDmgUpDown.Value;
             
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
            if (StandartVersCheckBox.Checked)
            {
                BildVersCheckBox.Checked = false;
                StandartVersCheckBox.Checked = true;
            }
            else
            {
                BildVersCheckBox.Checked = true;
                StandartVersCheckBox.Checked = false;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            StandartVersCheckBox.Checked = true;
            BildVersCheckBox.Checked = false;
            SoundCheckBox.Checked = false;
            DelayEffectCheckBox.Checked = false;

            NamOfBonusiesUpDown.Value = 2;
            NamOfBonusiesUpDown.Value = 4;
            BleedDmgUpDown.Value = 3;
        }
    }
}
