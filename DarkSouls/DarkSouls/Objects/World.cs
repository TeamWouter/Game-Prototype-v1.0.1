using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkSouls.Objects.Player;
using DarkSouls.Objects.Tile;

namespace DarkSouls.Objects.World
{
    public class World
    {
        public readonly TileManager TileManager;
        public readonly Point BeginPoint = new Point(1, 1);
        public readonly Player.Player Player;

        public World()
        {
            TileManager = new TileManager();
            TileManager.CreateWorld();

            Player = new Player.Player(BeginPoint, TileManager);
        }





    }
}
