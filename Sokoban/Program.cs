namespace Sokoban
{
    internal static class Program
    {
        static List<PictureBox> pictureBoxes = new List<PictureBox>();
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Sokoban());
        }
        static void InputReader()
        {
            string width = null;
            string height = null;
            string tileImage = null;

            StreamReader reader = new StreamReader(Properties.Resources._01);
            string s = reader.ReadToEnd();
            TextBox t = new TextBox()
            {
                Location = new Point(0, 0),
                Size = new Size(100,100),
                Text = s
            };
            for (int i = 0; i < s.Length; i++)
            {
                
            }
        }
        static void GenerateMap(int width, int height, string tileImages)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    PictureBox pictureBox = new PictureBox()
                    {
                        Size = new Size(32, 32),
                        Margin = new Padding(0),
                        Location = new Point(32*j, 32*i)
                    };
                    pictureBoxes.Add(pictureBox);
                    switch (tileImages)
                    {
                        case "W":
                            pictureBox.Image = Properties.Resources.simple_32_wall;
                            pictureBox.Tag = "W";
                            break;
                        case "E":
                            pictureBox.Image = Properties.Resources.simple_32_floor;
                            pictureBox.Tag = "E";
                            break;
                        case "T":
                            pictureBox.Image = Properties.Resources.simple_32_dock;
                            pictureBox.Tag = "T";
                            break;
                        case "P":
                            pictureBox.Image = Properties.Resources.simple_32_worker;
                            pictureBox.Tag = "P";
                            break;
                        case "B":
                            pictureBox.Image = Properties.Resources.simple_32_box;
                            pictureBox.Tag = "b";
                            break;
                        case "p":
                            pictureBox.Image = Properties.Resources.simple_32_worker_docked;
                            pictureBox.Tag = "p";
                            break;
                        case "b":
                            pictureBox.Image = Properties.Resources.simple_32_box_docked;
                            pictureBox.Tag = "b";
                            break;
                    }
                }
            }
        }
    }
}