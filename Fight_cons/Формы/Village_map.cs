using Fight_cons.Мир;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fight_cons.form
{
    public partial class Village_map : Form
    {
        Hero hero_tp;
        public string CalledLocation { get; set; }

        public Village_map(Hero hero)
        {
            InitializeComponent();
            List<LocationButton> locs = new List<LocationButton>()
            {
                new LocationButton(Neighborhood_bt) { LocationName = "Neighborhood" },
                new LocationButton(Inn_bt) { LocationName = "Inn" },
                new LocationButton(Market_loc_bt) { LocationName = "Market_loc" },
            };

            for (int i = 0; i < locs.Count; i++)
            {
                locs[i].Click += Teleport_Click;
                this.Controls.Add(locs[i]);
                this.Controls.Remove(locs[i].Pattern);
            }

            hero_tp = hero;
        }

        private void Teleport_Click(object sender, EventArgs e)
        {
            CalledLocation = (sender as LocationButton).LocationName;
            DialogResult = DialogResult.OK;
        }

        private void Market_loc_bt_Click(object sender, EventArgs e)
        {
            VillageLoc.Market_loc(hero_tp);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Map map_ = new Map(hero_tp);
            this.Close();
            var dialog_rez = map_.ShowDialog();
            if (dialog_rez != DialogResult.Cancel)
            {
                CalledLocation = map_.CalledLocation;
                DialogResult = dialog_rez;
            }
            this.Close();
        }

        private void Neighborhood_bt_Click(object sender, EventArgs e)
        {
            VillageLoc.Neighborhood(hero_tp);
            this.Close();
        }

        private void Inn_bt_Click(object sender, EventArgs e)
        {
            VillageLoc.Inn(hero_tp);
            this.Close();
        }
    }
}
