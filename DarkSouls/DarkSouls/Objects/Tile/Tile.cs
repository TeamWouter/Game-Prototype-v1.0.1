using System.Drawing;

namespace DarkSouls.Objects.Tile
{
    public class Tile
    {
        public readonly Point Position;
        public readonly int TextId;
        public bool Walkable;

        public Tile(Point position, int textId, bool walkable)
        {
            this.Position = position;
            this.TextId = textId;
            this.Walkable = walkable;
        }
    }
}
