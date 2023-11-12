using System.Drawing.Configuration;

namespace _2_homework
{
    public partial class Form1 : Form
    {
        private Point buttonTopLeft = Point.Empty;
        private Button currentButton = null;
        private int buttonCounter = 0;
        private Random random = new Random();

        private Color GetRandomColor()
        {
            return Color.FromArgb(
                this.random.Next(256), 
                this.random.Next(256), 
                this.random.Next(256)
            );
        }

        public Form1()
        {
            InitializeComponent();

            MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    buttonTopLeft = e.Location;
                    currentButton = new Button
                    {
                        Location = e.Location,
                        Text = (buttonCounter += 1).ToString(),
                        BackColor = this.GetRandomColor(),
                    };
                    Controls.Add(currentButton);
                    currentButton.BringToFront();
                }
            };

            MouseMove += (s, e) =>
            {
                if (!buttonTopLeft.IsEmpty)
                {
                    currentButton.Location = new Point(
                        Math.Min(e.X, buttonTopLeft.X),
                        Math.Min(e.Y, buttonTopLeft.Y)
                    );
                    currentButton.Width = Math.Abs(e.X - buttonTopLeft.X);
                    currentButton.Height = Math.Abs(e.Y - buttonTopLeft.Y);
                }
            };

            MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    buttonTopLeft = Point.Empty;
                    currentButton = null;
                }
            };
        }
    }
}