using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fight_cons.form
{
    public partial class Map : Form
    {
        Hero hero_tp;
        public string CalledLocation { get; set; }

        public Map(Hero hero)
        {
            InitializeComponent();

            List<LocationButton> locs = new List<LocationButton>()
            {
                new LocationButton(Cave_bt) { LocationName = "Caves" },
                new LocationButton(Vally_bt) { LocationName = "Vally" },
                new LocationButton(Woods_bt) { LocationName = "Deep_woods" },
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

        private void Neighborhood_bt_Click(object sender, EventArgs e)
        {
            Village_map village_ = new Village_map(hero_tp);            
            var dialog_rez = village_.ShowDialog();
            if (dialog_rez != DialogResult.Cancel)
            {
                CalledLocation = village_.CalledLocation;
                DialogResult = dialog_rez;
            }
        }
    }

    class LocationButton : Button
    {
        public Button Pattern { get; set; }
        public LocationButton(Button button)
        {
            Location = button.Location;
            Text = button.Text;
            Pattern = button;
        }

        public string LocationName { get; set; }
    }
}
