using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkSouls.Objects.Player;
using DarkSouls.Objects.World;
using DarkSouls.Screens;

namespace DarkSouls
{
    public partial class MainScreen : Form
    {
        //World
        private World _world;

        //Player
        private Player _player;

        //Screens
        private RadarScreen _radarScreen;

        public MainScreen()
        {
            _world = new World();
            _world.CreateWorld();

            _player = new Player(new Point(50 , 50));

            _radarScreen = new RadarScreen(_world);

        
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, RadarPanel, new object[] { true });
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)
        {
            System.Console.WriteLine(_player.W + " ");

            if (e.KeyCode.Equals(Keys.W) || e.KeyCode.Equals(Keys.D) || e.KeyCode.Equals(Keys.S) || e.KeyCode.Equals(Keys.A))
            {               
                if (e.KeyCode.Equals(Keys.W))
                {
                    _player.W = true;
                }
                else if (e.KeyCode.Equals(Keys.D))
                {
                    _player.D = true;
                }
                else if (e.KeyCode.Equals(Keys.S))
                {
                    _player.S = true;
                }
                else if (e.KeyCode.Equals(Keys.A))
                {
                    _player.A = true;
                }
            }
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void MainScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.W) || e.KeyCode.Equals(Keys.D) || e.KeyCode.Equals(Keys.S) || e.KeyCode.Equals(Keys.A))
            {
                if (e.KeyCode.Equals(Keys.W))
                {
                    _player.W = false;
                }
                else if (e.KeyCode.Equals(Keys.D))
                {
                    _player.D = false;
                }
                else if (e.KeyCode.Equals(Keys.S))
                {
                    _player.S = false;
                }
                else if (e.KeyCode.Equals(Keys.A))
                {
                    _player.A = false;
                }
            }
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            Timer MyTimer = new Timer();
            MyTimer.Interval = (100);
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            _player.Move();
            GamePanel.Refresh();
        }

        private void RadarPanel_Paint(object sender, PaintEventArgs e)
        {
            _radarScreen.Draw(e.Graphics, _player);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
