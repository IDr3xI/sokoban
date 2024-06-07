using System.Numerics;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class Sokoban : Form
    {
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        string[] maps = { Properties.Resources._01, Properties.Resources._02, Properties.Resources._03, Properties.Resources._04, Properties.Resources._05, Properties.Resources._06, Properties.Resources._07, Properties.Resources._08, Properties.Resources._09 };
        Label labelGame;
        Button button1, button2, button3, button4, button5, button6, button7, button8, button9;
        int level = 0;
        int height = 0;
        int width = 0;
        string[] tileImages = { };
        bool moveUp, moveDown, moveLeft, moveRight;
        Vector2 up = new Vector2(0, -1);
        Vector2 down = new Vector2(0, 1);
        Vector2 left = new Vector2(-1, 0);
        Vector2 right = new Vector2(1, 0);
        Vector2 direction;
        public Sokoban()
        {
            InitializeComponent();
            MainMenu();
        }
        public void MainMenu()
        {
            mainTimer.Stop();
            labelGame = new Label()
            {
                Font = new Font("Segoe UI", 48, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.White,
                Location = new Point(0, 0),
                Margin = new Padding(0),
                Text = "Sokoban"
            };
            button1 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(110, 50),
                ForeColor = Color.White,
                Location = new Point(90, 100),
                Text = "Play",
            };
            button2 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(110, 50),
                ForeColor = Color.White,
                Location = new Point(90, 170),
                Text = "Levels"
            };
            button3 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(110, 50),
                ForeColor = Color.White,
                Location = new Point(90, 240),
                Text = "Quit"
            };
            button1.Click += new EventHandler(buttonClick);
            button2.Click += new EventHandler(buttonClick);
            button3.Click += new EventHandler(buttonClick);
            Controls.Add(labelGame);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
        }
        public void NextMenu()
        {
            mainTimer.Stop();
            labelGame = new Label()
            {
                Font = new Font("Segoe UI", 48, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.White,
                Location = new Point(0, 0),
                Margin = new Padding(0),
                Text = "Completed"
            };
            button1 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(110, 50),
                ForeColor = Color.White,
                Location = new Point(130, 100),
                Text = "Next",
            };
            button2 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(110, 50),
                ForeColor = Color.White,
                Location = new Point(130, 170),
                Text = "Quit"
            };
            button1.Click += new EventHandler(buttonClick);
            button2.Click += new EventHandler(buttonClick);
            Controls.Add(labelGame);
            Controls.Add(button1);
            Controls.Add(button2);
        }
        public void LevelMenu()
        {
            labelGame = new Label()
            {
                Font = new Font("Segoe UI", 48, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.White,
                Location = new Point(0, 0),
                Margin = new Padding(0),
                Text = "Levels"
            };
            button1 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(50, 50),
                ForeColor = Color.White,
                Location = new Point(20, 100),
                Text = "1",
            };
            button2 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(50, 50),
                ForeColor = Color.White,
                Location = new Point(80, 100),
                Text = "2",
            };
            button3 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(50, 50),
                ForeColor = Color.White,
                Location = new Point(140, 100),
                Text = "3",
            };
            button4 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(50, 50),
                ForeColor = Color.White,
                Location = new Point(20, 160),
                Text = "4",
            };
            button5 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(50, 50),
                ForeColor = Color.White,
                Location = new Point(80, 160),
                Text = "5",
            };
            button6 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(50, 50),
                ForeColor = Color.White,
                Location = new Point(140, 160),
                Text = "6",
            };
            button7 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(50, 50),
                ForeColor = Color.White,
                Location = new Point(20, 220),
                Text = "7",
            };
            button8 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(50, 50),
                ForeColor = Color.White,
                Location = new Point(80, 220),
                Text = "8",
            };
            button9 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(50, 50),
                ForeColor = Color.White,
                Location = new Point(140, 220),
                Text = "9",
            };
            button1.Click += new EventHandler(buttonClick);
            button2.Click += new EventHandler(buttonClick);
            button3.Click += new EventHandler(buttonClick);
            button4.Click += new EventHandler(buttonClick);
            button5.Click += new EventHandler(buttonClick);
            button6.Click += new EventHandler(buttonClick);
            button7.Click += new EventHandler(buttonClick);
            button8.Click += new EventHandler(buttonClick);
            button9.Click += new EventHandler(buttonClick);
            Controls.Add(labelGame);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button9);
        }
        public void WinMenu()
        {
            mainTimer.Stop();
            labelGame = new Label()
            {
                Font = new Font("Segoe UI", 48, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.White,
                Location = new Point(0, 0),
                Margin = new Padding(0),
                Text = "You Won"
            };
            button1 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(110, 50),
                ForeColor = Color.White,
                Location = new Point(90, 100),
                Text = "Retry",
            };
            button2 = new Button()
            {
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Size = new Size(110, 50),
                ForeColor = Color.White,
                Location = new Point(90, 170),
                Text = "Quit",
            };
            button1.Click += new EventHandler(buttonClick);
            button2.Click += new EventHandler(buttonClick);
            Controls.Add(labelGame);
            Controls.Add(button1);
            Controls.Add(button2);
        }
        public void buttonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Text == "Play")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                button3.Dispose();
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
            if (button.Text == "Next")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                level++;
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
            if (button.Text == "Levels")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                button3.Dispose();
                LevelMenu();
            }
            if (button.Text == "Retry")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                level = 0;
                MainMenu();
            }
            if (button.Text == "Quit")
            {
                Application.Exit();
            }
            if (button.Text == "1")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                button3.Dispose();
                button4.Dispose();
                button5.Dispose();
                button6.Dispose();
                button7.Dispose();
                button8.Dispose();
                button9.Dispose();
                level = 0;
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
            if (button.Text == "2")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                button3.Dispose();
                button4.Dispose();
                button5.Dispose();
                button6.Dispose();
                button7.Dispose();
                button8.Dispose();
                button9.Dispose();
                level = 1;
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
            if (button.Text == "3")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                button3.Dispose();
                button4.Dispose();
                button5.Dispose();
                button6.Dispose();
                button7.Dispose();
                button8.Dispose();
                button9.Dispose();
                level = 2;
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
            if (button.Text == "4")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                button3.Dispose();
                button4.Dispose();
                button5.Dispose();
                button6.Dispose();
                button7.Dispose();
                button8.Dispose();
                button9.Dispose();
                level = 3;
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
            if (button.Text == "5")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                button3.Dispose();
                button4.Dispose();
                button5.Dispose();
                button6.Dispose();
                button7.Dispose();
                button8.Dispose();
                button9.Dispose();
                level = 4;
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
            if (button.Text == "6")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                button3.Dispose();
                button4.Dispose();
                button5.Dispose();
                button6.Dispose();
                button7.Dispose();
                button8.Dispose();
                button9.Dispose();
                level = 5;
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
            if (button.Text == "7")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                button3.Dispose();
                button4.Dispose();
                button5.Dispose();
                button6.Dispose();
                button7.Dispose();
                button8.Dispose();
                button9.Dispose();
                level = 6;
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
            if (button.Text == "8")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                button3.Dispose();
                button4.Dispose();
                button5.Dispose();
                button6.Dispose();
                button7.Dispose();
                button8.Dispose();
                button9.Dispose();
                level = 7;
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
            if (button.Text == "9")
            {
                labelGame.Dispose();
                button1.Dispose();
                button2.Dispose();
                button3.Dispose();
                button4.Dispose();
                button5.Dispose();
                button6.Dispose();
                button7.Dispose();
                button8.Dispose();
                button9.Dispose();
                level = 8;
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
        }
        public void ReadInput()
        {
            string[] _levelInfo = maps[level].Split();
            width = int.Parse(_levelInfo[0]);
            height = int.Parse(_levelInfo[1]);
            tileImages = _levelInfo;

        }
        public void GenerateMap()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    PictureBox pictureBox = new PictureBox()
                    {
                        Size = new Size(32, 32),
                        Margin = new Padding(0),
                        Location = new Point(32 * j, 32 * i)
                    };
                    switch (tileImages[i + 2][j])
                    {
                        case 'W':
                            pictureBox.Image = Properties.Resources.simple_32_wall;
                            pictureBox.Tag = "W";
                            break;
                        case 'E':
                            pictureBox.Image = Properties.Resources.simple_32_floor;
                            pictureBox.Tag = "E";
                            break;
                        case 'T':
                            pictureBox.Image = Properties.Resources.simple_32_dock;
                            pictureBox.Tag = "T";
                            break;
                        case 'P':
                            pictureBox.Image = Properties.Resources.simple_32_worker;
                            pictureBox.Tag = "P";
                            break;
                        case 'B':
                            pictureBox.Image = Properties.Resources.simple_32_box;
                            pictureBox.Tag = "B";
                            break;
                        case 'p':
                            pictureBox.Image = Properties.Resources.simple_32_worker_docked;
                            pictureBox.Tag = "p";
                            break;
                        case 'b':
                            pictureBox.Image = Properties.Resources.simple_32_box_docked;
                            pictureBox.Tag = "b";
                            break;
                    }
                    pictureBoxes.Add(pictureBox);
                    this.Controls.Add(pictureBox);
                }
            }
        }
        public void MovePlayer()
        {
            PictureBox _player = new PictureBox();
            PictureBox _next = new PictureBox();
            PictureBox _behind = new PictureBox();
            Point _temp = new Point();
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                if (pictureBox.Tag as string == "p" || pictureBox.Tag as string == "P")
                {
                    _player = pictureBox;
                }
            }
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                if (pictureBox.Location.X == (_player.Location.X + direction.X * 32) && pictureBox.Location.Y == (_player.Location.Y + direction.Y * 32))
                {
                    _next = pictureBox;
                }
                if (pictureBox.Location.X == (_player.Location.X + direction.X * 32 * 2) && pictureBox.Location.Y == (_player.Location.Y + direction.Y * 32 * 2))
                {
                    _behind = pictureBox;
                }
            }
            if (_next.Tag == "E")
            {
                _temp = _player.Location;
                _player.Location = _next.Location;
                _next.Location = _temp;
                if (_player.Tag == "P")
                {
                    _next.Tag = "E";
                    _next.Image = Properties.Resources.simple_32_floor;
                }
                else
                {
                    _next.Tag = "T";
                    _next.Image = Properties.Resources.simple_32_dock;
                }
                _player.Tag = "P";
                _player.Image = Properties.Resources.simple_32_worker;
            }
            else if (_next.Tag == "T")
            {
                _temp = _player.Location;
                _player.Location = _next.Location;
                _next.Location = _temp;
                if (_player.Tag == "P")
                {
                    _next.Tag = "E";
                    _next.Image = Properties.Resources.simple_32_floor;
                }
                else
                {
                    _next.Tag = "T";
                    _next.Image = Properties.Resources.simple_32_dock;
                }
                _player.Tag = "p";
                _player.Image = Properties.Resources.simple_32_worker_docked;
            }
            else if (_next.Tag == "B")
            {
                if (_behind.Tag == "T")
                {
                    _temp = _player.Location;
                    _player.Location = _next.Location;
                    _next.Location = _behind.Location;
                    _behind.Location = _temp;

                    if (_player.Tag == "P")
                    {
                        _behind.Tag = "E";
                        _behind.Image = Properties.Resources.simple_32_floor;
                    }
                    else
                    {
                        _behind.Tag = "T";
                        _behind.Image = Properties.Resources.simple_32_dock;
                    }
                    _player.Tag = "P";
                    _player.Image = Properties.Resources.simple_32_worker;
                    _next.Tag = "b";
                    _next.Image = Properties.Resources.simple_32_box_docked;
                }
                else if (_behind.Tag == "E")
                {
                    _temp = _player.Location;
                    _player.Location = _next.Location;
                    _next.Location = _behind.Location;
                    _behind.Location = _temp;

                    if (_player.Tag == "P")
                    {
                        _behind.Tag = "E";
                        _behind.Image = Properties.Resources.simple_32_floor;
                    }
                    else
                    {
                        _behind.Tag = "T";
                        _behind.Image = Properties.Resources.simple_32_dock;
                    }
                    _player.Tag = "P";
                    _player.Image = Properties.Resources.simple_32_worker;
                }
            }
            else if (_next.Tag == "b")
            {
                if (_behind.Tag == "T")
                {
                    _temp = _player.Location;
                    _player.Location = _next.Location;
                    _next.Location = _behind.Location;
                    _behind.Location = _temp;

                    if (_player.Tag == "P")
                    {
                        _behind.Tag = "E";
                        _behind.Image = Properties.Resources.simple_32_floor;
                    }
                    else
                    {
                        _behind.Tag = "T";
                        _behind.Image = Properties.Resources.simple_32_dock;
                    }
                    _player.Tag = "p";
                    _player.Image = Properties.Resources.simple_32_worker_docked;
                }
                else if (_behind.Tag == "E")
                {
                    _temp = _player.Location;
                    _player.Location = _next.Location;
                    _next.Location = _behind.Location;
                    _behind.Location = _temp;

                    if (_player.Tag == "P")
                    {
                        _behind.Tag = "E";
                        _behind.Image = Properties.Resources.simple_32_floor;
                    }
                    else
                    {
                        _behind.Tag = "T";
                        _behind.Image = Properties.Resources.simple_32_dock;
                    }
                    _player.Tag = "p";
                    _player.Image = Properties.Resources.simple_32_worker_docked;
                    _next.Tag = "B";
                    _next.Image = Properties.Resources.simple_32_box;
                }
            }
        }
        private void mainTimerEvent(object sender, EventArgs e)
        {
            int _boxesLeft = 0;
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                if (pictureBox.Tag == "B")
                {
                    _boxesLeft++;
                }
            }
            if (_boxesLeft == 0)
            {
                foreach (PictureBox pictureBox in pictureBoxes)
                {
                    pictureBox.Dispose();
                }
                pictureBoxes = new List<PictureBox>();
                if (level < 8)
                {
                    NextMenu();
                }
                else
                {
                    WinMenu();
                }
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && !moveUp)
            {
                moveUp = true;
                direction = up;
                MovePlayer();
            }
            if ((e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && !moveDown)
            {
                moveDown = true;
                direction = down;
                MovePlayer();
            }
            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && !moveLeft)
            {
                moveLeft = true;
                direction = left;
                MovePlayer();
            }
            if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && !moveRight)
            {
                moveRight = true;
                direction = right;
                MovePlayer();
            }
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
        }
    }
}
