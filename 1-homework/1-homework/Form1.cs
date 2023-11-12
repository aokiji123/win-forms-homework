namespace _1_homework
{
    public partial class Form1 : Form
    {
        private Button button;
        public Form1()
        {
            InitializeComponent();

            this.Text = "Escaping button";
            button = new Button();
            button.Text = "Try to catch me!";
            button.Width = 120;
            button.Height = 120;
            button.Location = new Point(ClientSize.Width / 2, ClientSize.Height / 2);
            button.MouseHover += (sender, e) => MoveButton();
            Controls.Add(button);
        }
        private void MoveButton()
        {
            Random random = new Random();
            int x = random.Next(0, ClientSize.Width - button.Width);
            int y = random.Next(0, ClientSize.Height - button.Height);
            button.Location = new Point(x, y);
        }
    }
}