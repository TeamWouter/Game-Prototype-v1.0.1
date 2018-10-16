using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkSouls.Objects.Tile;

namespace DarkSouls.Objects.Player
{
    public class Player
    {
        private Movement _movement;

        public Player(Point beginPoint, TileManager tileManager)
        {
            _movement = new Movement(beginPoint, tileManager);
        }
    }
}
