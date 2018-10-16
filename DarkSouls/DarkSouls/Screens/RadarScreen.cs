using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkSouls.Objects.Player;
using DarkSouls.Objects.Tile;
using DarkSouls.Objects.World;

namespace DarkSouls.Screens
{
    class RadarScreen
    {
        //2D Screen
        private Panel _panel;

        private World _world;
        private int GridSize = 50;

        //Colors
        private Brush _white;

        private Brush _red;

        private Pen _black;

        public RadarScreen(World world)
        {
            _world = world;
            _white = new SolidBrush(Color.White);
            _red = new SolidBrush(Color.Red);
            _black = new Pen(Color.Black);
        }

        public void Draw(Graphics g, Player player)
        {
            //Grid
            foreach (Tile tile in _world.GetTiles())
            {
                Rectangle rec = new Rectangle(new Point(tile.Position.X * GridSize, tile.Position.Y * GridSize), new Size(new Point(GridSize, GridSize)));
                g.FillRectangle(_white, rec);
                g.DrawRectangle(_black, rec);
            }

            //Player
            Rectangle playerIcon = new Rectangle(player.GetPosition(), new Size(new Point(GridSize, GridSize)));

            g.FillRectangle(_red, playerIcon);
        }
    }
}
