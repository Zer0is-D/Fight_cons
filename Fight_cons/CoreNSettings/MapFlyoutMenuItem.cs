using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightCons.CoreNSettings
{
    public class MapFlyoutMenuItem
    {
        public MapFlyoutMenuItem()
        {
            TargetType = typeof(MapFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}