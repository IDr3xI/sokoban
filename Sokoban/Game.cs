using System.Numerics;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class Sokoban : Form
    {
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        string[] maps = { Properties.Resources._01, Properties.Resources._02, Properties.Resources._03, Properties.Resources._04, Properties.Resources._05, Properties.Resources._06, Properties.Resources._07, Properties.Resources._08, Properties.Resources._09 };
        Label labelGame;
        List<Button> buttons = new List<Button>();
        int level = 0;
        int height = 0;
        int width = 0;
        string[] tileImages = { };
        bool moveUp, moveDown, moveLeft, moveRight, restart, escape;
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
        public void ReadInput()
        {
            string[] _levelInfo = maps[level].Split();
            width = int.Parse(_levelInfo[0]);
            height = int.Parse(_levelInfo[1]);
            tileImages = _levelInfo;

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
            Controls.Add(labelGame);

            for (int i = 0; i < 3; i++)
            {
                Button button = new Button()
                {
                    Font = new Font("Segoe UI", 20, FontStyle.Bold),
                    Size = new Size(110, 50),
                    ForeColor = Color.White,
                    Location = new Point(90, 100 + i * 70),
                };
                buttons.Add(button);
                button.Click += new EventHandler(buttonClick);
                Controls.Add(button);
            }
            buttons[0].Text = "Play";
            buttons[1].Text = "Levels";
            buttons[2].Text = "Quit";
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
            Controls.Add(labelGame);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button()
                    {
                        Font = new Font("Segoe UI", 20, FontStyle.Bold),
                        Size = new Size(50, 50),
                        ForeColor = Color.White,
                        Location = new Point(20 + j * 60, 100 + i * 60),
                    };
                    buttons.Add(button);
                    button.Click += new EventHandler(buttonClick);
                    Controls.Add(button);
                }
            }
            buttons[0].Text = "1";
            buttons[1].Text = "2";
            buttons[2].Text = "3";
            buttons[3].Text = "4";
            buttons[4].Text = "5";
            buttons[5].Text = "6";
            buttons[6].Text = "7";
            buttons[7].Text = "8";
            buttons[8].Text = "9";
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
            Controls.Add(labelGame);

            for (int i = 0; i < 2; i++)
            {
                Button button = new Button()
                {
                    Font = new Font("Segoe UI", 20, FontStyle.Bold),
                    Size = new Size(110, 50),
                    ForeColor = Color.White,
                    Location = new Point(130, 100 + i * 70),
                };
                buttons.Add(button);
                button.Click += new EventHandler(buttonClick);
                Controls.Add(button);
            }
            buttons[0].Text = "Next";
            buttons[1].Text = "Quit";
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
            Controls.Add(labelGame);

            for (int i = 0; i < 2; i++)
            {
                Button button = new Button()
                {
                    Font = new Font("Segoe UI", 20, FontStyle.Bold),
                    Size = new Size(110, 50),
                    ForeColor = Color.White,
                    Location = new Point(90, 100 + i * 70),
                };
                buttons.Add(button);
                button.Click += new EventHandler(buttonClick);
                Controls.Add(button);
            }
            buttons[0].Text = "Retry";
            buttons[1].Text = "Quit";
        }
        public void DeleteMenu()
        {
            labelGame.Dispose();
            foreach (Button button in buttons)
            {
                button.Dispose();
            }
            buttons.Clear();
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
                    Controls.Add(pictureBox);
                }
            }
        }
        public void DeleteMap()
        {
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Dispose();
            }
            pictureBoxes.Clear();
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
                DeleteMap();
                if (level < 8)
                {
                    NextMenu();
                }
                else
                {
                    WinMenu();
                }
            }

            if (moveUp || moveDown || moveLeft || moveRight)
            {
                MovePlayer();
            }
        }
        public void buttonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Text == "Play")
            {
                DeleteMenu();
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
            else if (button.Text == "Next")
            {
                DeleteMenu();
                level++;
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
            else if (button.Text == "Levels")
            {
                DeleteMenu();
                LevelMenu();
            }
            else if (button.Text == "Retry")
            {
                DeleteMenu();
                level = 0;
                MainMenu();
            }
            else if (button.Text == "Quit")
            {
                Application.Exit();
            }
            else if (1 <= int.Parse(button.Text) && int.Parse(button.Text) <= 9)
            {
                DeleteMenu();
                level = int.Parse(button.Text) - 1;
                ReadInput();
                GenerateMap();
                mainTimer.Start();
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && !moveUp)
            {
                mainTimer.Stop();
                direction = up;
                MovePlayer();
                moveUp = true;
                mainTimer.Start();
            }
            if ((e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && !moveDown)
            {
                mainTimer.Stop();
                direction = down;
                MovePlayer();
                moveDown = true;
                mainTimer.Start();
            }
            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && !moveLeft)
            {
                mainTimer.Stop();
                direction = left;
                MovePlayer();
                moveLeft = true;
                mainTimer.Start();
            }
            if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && !moveRight)
            {
                mainTimer.Stop();
                direction = right;
                MovePlayer();
                moveRight = true;
                mainTimer.Start();
            }
            if ((e.KeyCode == Keys.R) && !restart && pictureBoxes.Count != 0)
            {
                restart = true;
                mainTimer.Stop();
                DeleteMap();
                GenerateMap();
                mainTimer.Start();
            }
            if ((e.KeyCode == Keys.Escape) && !escape)
            {
                escape = true;
                mainTimer.Stop();
                DeleteMap();
                DeleteMenu();
                level = 0;
                MainMenu();
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
            if (e.KeyCode == Keys.R)
            {
                restart = false;
            }
            if (e.KeyCode == Keys.Escape)
            {
                escape = false;
            }
        }
    }
}
