using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSouls.Objects.Tile
{
    public class TileManager
    {
        private ArrayList _tiles = new ArrayList();
        public void CreateWorld()
        {
            int width = 250;

            for (int x = 0; x <= width; x++)
            {
                for (int y = 0; y <= width; y++)
                {
                    _tiles.Add(new Tile(new Point(x, y), 0, true));
                }
            }

            foreach (Tile tile in _tiles)
            {
                if (tile.Position.X == 0 || tile.Position.Y == 0 || tile.Position.X == width || tile.Position.Y == width)
                {
                    tile.Walkable = false;
                }
            }
        }

        public Objects.Tile.Tile GetTile(Point position)
        {
            foreach (Objects.Tile.Tile tile in _tiles)
            {
                if (tile.Position.Equals(position))
                {
                    return tile;
                }
            }
            return null;
        }
    }
}
