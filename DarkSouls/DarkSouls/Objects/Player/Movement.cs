using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkSouls.Objects.Tile;

namespace DarkSouls.Objects.Player
{
    public class Movement
    {
        private Point _position;
        private Point _newPosition;

        private TileManager _tileManager;

        private int Speed = 50;

        public bool W;
        public bool D;
        public bool S;
        public bool A;

        public Movement(Point beginPosition, TileManager tileManager)
        {
            _position = beginPosition;
            _newPosition = Point.Empty;

            _tileManager = tileManager;

            W = false;
            D = false;
            S = false;
            A = false;
        }

        public void Move()
        {
            if (W && D)
                MoveWD();
            else if (D && S)
            {
                MoveDS();
            }
            else if (S && A)
            {
                MoveSA();
            }
            else if (A && W)
            {
                MoveAW();
            }

            else if (W)
            {
                MoveW();
            }
            else if (D)
            {
                MoveD();
            }
            else if (S)
            {
                MoveS();
            }
            else if (A)
            {
                MoveA();
            }
        }

        private void MoveWD()
        {
            _newPosition.X = _position.X + (Speed / 2);
            _newPosition.Y = _position.Y + (Speed / 2);



        }

        private void MoveDS()
        {
            _newPosition = new Point(_position.X + (Speed / 2), _position.Y - (Speed / 2));
        }

        private void MoveSA()
        {
            _newPosition = new Point(_position.X - (Speed / 2), _position.Y - (Speed / 2));
        }

        private void MoveAW()
        {
            _newPosition = new Point(_position.X - (Speed / 2), _position.Y + (Speed / 2));
        }

        private void MoveW()
        {
            _newPosition = new Point(_position.X, _position.Y + Speed);
        }

        private void MoveD()
        {
            _newPosition = new Point(_position.X + Speed, _position.Y);
        }


        private void MoveS()
        {
            _newPosition = new Point(_position.X, _position.Y - Speed);
        }


        private void MoveA()
        {
            _newPosition = new Point(_position.X - Speed, _position.Y);
        }


        //Position
        private bool CheckPosition(Point position)
        {
            decimal x = position.X / 50;
            decimal y = position.Y / 50;

            int xx = (int)Math.Ceiling(x);
            int yy = (int)Math.Ceiling(y);

            Point newPosition = new Point(xx, yy);

            return _tileManager.GetTile(newPosition).Walkable;
        }

        public Point GetPosition()
        {
            return _position;
        }
    }
}
