namespace _8_homework
{
    public partial class LevelForm : Form
    {
        public Maze maze; // ������ �� ������ ����� ������������� � ���������
        public Character Hero;
        StatusStrip statusStrip1;
        public LevelForm()
        {
            InitializeComponent();
            FormSettings();
            StartGameProcess();
            Text = "Maze";

            statusStrip1 = new StatusStrip();
            statusStrip1.Location = new Point(0, 369);
            statusStrip1.ForeColor = Color.White;
            statusStrip1.Items.AddRange(new ToolStripItem[] {
                new ToolStripStatusLabel("Health: "),
                new ToolStripStatusLabel("Score: "),
                new ToolStripStatusLabel("Steps: "),
                new ToolStripStatusLabel("Energy: ")
            });
            Controls.Add(statusStrip1);
            UpdateUI(Hero);
        }
        public void UpdateUI(Character Hero)
        {
            statusStrip1.Items[0].Text = "Health: " + Hero.Health.ToString();
            statusStrip1.Items[1].Text = "Score: " + Hero.Score.ToString();
            statusStrip1.Items[2].Text = "Steps: " + Hero.Steps.ToString();
            statusStrip1.Items[3].Text = "Energy: " + Hero.Energy.ToString();
        }
        public void FormSettings()
        {
            Text = Configuration.Title;
            BackColor = Configuration.Background;

            // ������� ���������� ������� �����
            ClientSize = new Size(
                Configuration.Columns * Configuration.PictureSide + 10,
                Configuration.Rows * Configuration.PictureSide + 28);

            StartPosition = FormStartPosition.CenterScreen;
        }

        public void StartGameProcess()
        {
            Hero = new Character(this);
            maze = new Maze(this);
            maze.Generate();
            maze.Show();
        }

        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (Hero.Health > 0 && Hero.Energy > 0)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (Hero.PosX != maze.cells.GetLength(0) - 1)
                    {
                        // �������� �� ��, �������� �� ������ ������
                        if (maze.cells[Hero.PosY, Hero.PosX + 1].Type != CellType.WALL)
                        {
                            if (maze.cells[Hero.PosY, Hero.PosX + 1].Type != CellType.HEAL)
                            {
                                if (maze.cells[Hero.PosY, Hero.PosX + 1].Type != CellType.COFFE)
                                {
                                    if (maze.cells[Hero.PosY, Hero.PosX + 1].Type == CellType.ENEMY)
                                        Hero.Health -= 25;
                                    if (maze.cells[Hero.PosY, Hero.PosX + 1].Type == CellType.MEDAL)
                                        Hero.Score += 50;
                                    Hero.Clear();
                                    Hero.MoveRight();
                                    Hero.Show();
                                }
                                else if (Hero.CoffeCD <= 0)
                                {
                                    Hero.Energy += 25;
                                    Hero.Clear();
                                    Hero.MoveRight();
                                    Hero.Show();
                                }
                            }
                            else if (Hero.Health < 100)
                            {
                                Hero.Health += (int)Math.Floor(Hero.Health * 0.05);
                                Hero.Health = Math.Min(Hero.Health, 100);
                                Hero.CoffeCD = 10;
                                Hero.Clear();
                                Hero.MoveRight();
                                Hero.Show();
                            }
                        }
                    }
                    else
                        MessageBox.Show("You won :)");
                }
                else if (e.KeyCode == Keys.Left && Hero.PosX != 0)
                {
                    // �������� �� ��, �������� �� ������ �����
                    if (maze.cells[Hero.PosY, Hero.PosX - 1].Type != CellType.WALL)
                    {
                        if (maze.cells[Hero.PosY, Hero.PosX - 1].Type != CellType.HEAL)
                        {
                            if (maze.cells[Hero.PosY, Hero.PosX - 1].Type != CellType.COFFE)
                            {
                                if (maze.cells[Hero.PosY, Hero.PosX - 1].Type == CellType.ENEMY)
                                    Hero.Health -= 25;
                                if (maze.cells[Hero.PosY, Hero.PosX - 1].Type == CellType.MEDAL)
                                    Hero.Score += 50;
                                Hero.Clear();
                                Hero.MoveLeft();
                                Hero.Show();
                            }
                            else if (Hero.CoffeCD <= 0)
                            {
                                Hero.Energy += 25;
                                Hero.Clear();
                                Hero.MoveLeft();
                                Hero.Show();
                            }
                        }
                        else if (Hero.Health < 100)
                        {
                            Hero.Health += (int)Math.Floor(Hero.Health * 0.05);
                            Hero.Health = Math.Min(Hero.Health, 100);
                            Hero.CoffeCD = 10;
                            Hero.Clear();
                            Hero.MoveLeft();
                            Hero.Show();
                        }
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    // �������� �� ��, �������� �� ������ ����
                    if (maze.cells[Hero.PosY - 1, Hero.PosX].Type != CellType.WALL)
                    {
                        if (maze.cells[Hero.PosY - 1, Hero.PosX].Type != CellType.HEAL)
                        {
                            if (maze.cells[Hero.PosY - 1, Hero.PosX].Type != CellType.COFFE)
                            {
                                if (maze.cells[Hero.PosY - 1, Hero.PosX].Type == CellType.ENEMY)
                                    Hero.Health -= 25;
                                if (maze.cells[Hero.PosY - 1, Hero.PosX].Type == CellType.MEDAL)
                                    Hero.Score += 50;
                                Hero.Clear();
                                Hero.MoveUp();
                                Hero.Show();
                            }
                            else if (Hero.CoffeCD <= 0)
                            {
                                Hero.Energy += 25;
                                Hero.Clear();
                                Hero.MoveUp();
                                Hero.Show();
                            }
                        }
                        else if (Hero.Health < 100)
                        {
                            Hero.Health += (int)Math.Floor(Hero.Health * 0.05);
                            Hero.Health = Math.Min(Hero.Health, 100);
                            Hero.CoffeCD = 10;
                            Hero.Clear();
                            Hero.MoveUp();
                            Hero.Show();
                        }

                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    // �������� �� ��, �������� �� ������ ����
                    if (maze.cells[Hero.PosY + 1, Hero.PosX].Type != CellType.WALL)
                    {
                        if (maze.cells[Hero.PosY + 1, Hero.PosX].Type != CellType.HEAL)
                        {
                            if (maze.cells[Hero.PosY + 1, Hero.PosX].Type != CellType.COFFE)
                            {
                                if (maze.cells[Hero.PosY + 1, Hero.PosX].Type == CellType.ENEMY)
                                    Hero.Health -= 25;
                                if (maze.cells[Hero.PosY + 1, Hero.PosX].Type == CellType.MEDAL)
                                    Hero.Score += 50;
                                Hero.Clear();
                                Hero.MoveDown();
                                Hero.Show();
                            }
                            else if (Hero.CoffeCD <= 0)
                            {
                                Hero.Energy += 25;
                                Hero.Clear();
                                Hero.MoveDown();
                                Hero.Show();
                            }
                        }
                        else if (Hero.Health < 100)
                        {
                            Hero.Health += (int)Math.Floor(Hero.Health * 0.05);
                            Hero.Health = Math.Min(Hero.Health, 100);
                            Hero.CoffeCD = 10;
                            Hero.Clear();
                            Hero.MoveDown();
                            Hero.Show();
                        }
                    }
                }
                UpdateUI(Hero);
                if (!maze.CheckForEnemies())
                {
                    MessageBox.Show("No enemies left!\n You won!!!");
                }
                if (Hero.Health <= 0) {
                    MessageBox.Show("You died!!\n (no health)");
                }
                else if (Hero.Energy <= 0) {
                    MessageBox.Show("You died!!\n (no energy)");
                }
            }
            else
            {
                if (Hero.Health <= 0)
                {
                    MessageBox.Show("You died!!\n (no health)");
                }
                else if (Hero.Energy <= 0) {
                    MessageBox.Show("You died!!\n (no energy)");
                }
            }
        }
    }

}