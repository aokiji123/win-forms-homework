using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace _4_homework
{
    public partial class Form1 : Form
    {
        private Timer colorChangeTimer;
        private Timer clickTimer;
        private int currentColorIndex = 0;
        private Color[] colors = {
            Color.Black, 
            Color.Red, 
            Color.Yellow, 
            Color.Green, 
            Color.Blue, 
            Color.Cyan, 
            Color.Magenta, 
            Color.White 
        };

        private ColorBlend colorBlend = new ColorBlend();
        private int blendStep = 0;
        private const int totalBlendSteps = 100;

        private int clickCount = 0;
        private int maxClickRecord = 0;

        private Button clickButton;

        public Form1()
        {
            InitializeComponent();

            clickButton = new Button();
            clickButton.Width = 200;
            clickButton.Height = 100; 
            clickButton.Text = "Click!!!!";
            clickButton.Click += ClickButton_Click;
            clickButton.Location = new Point(Width / 2 - clickButton.Width / 2, Height / 2 - clickButton.Height / 2);
            
            Controls.Add(clickButton);

            colorChangeTimer = new Timer();
            colorChangeTimer.Interval = 100;
            colorChangeTimer.Tick += ColorChangeTimer_Tick;

            clickTimer = new Timer();
            clickTimer.Interval = 20000;
            clickTimer.Tick += ClickTimer_Tick;

            colorChangeTimer.Start();

            colorBlend.Colors = new Color[] { colors[0], colors[1] };
            colorBlend.Positions = new float[] { 0, 1 };

            clickTimer.Start();
        }

        private void ClickButton_Click(object sender, EventArgs e)
        {
            clickCount++;
        }

        private void ColorChangeTimer_Tick(object sender, EventArgs e)
        {
            if (blendStep < totalBlendSteps)
            {
                blendStep++;
                colorBlend.Positions[0] = (float)blendStep / totalBlendSteps;
                colorBlend.Positions[1] = 1 - (float)blendStep / totalBlendSteps;
                BackColor = ChangeColors(colorBlend);
            }
            else
            {
                blendStep = 0;
                currentColorIndex = (currentColorIndex + 1) % colors.Length;
                colorBlend.Colors = new Color[] { colors[currentColorIndex], colors[(currentColorIndex + 1) % colors.Length] };
            }
        }

        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            colorChangeTimer.Stop();
            clickTimer.Stop();

            MessageBox.Show($"Clicks amount: {clickCount}\nRecord: {maxClickRecord}", "Results");

            if (clickCount > maxClickRecord)
            {
                maxClickRecord = clickCount;
            }
            clickCount = 0;

            colorChangeTimer.Start();
            clickTimer.Start();
        }

        private Color ChangeColors(ColorBlend blend)
        {
            float r = blend.Colors[0].R * blend.Positions[0] + blend.Colors[1].R * blend.Positions[1];
            float g = blend.Colors[0].G * blend.Positions[0] + blend.Colors[1].G * blend.Positions[1];
            float b = blend.Colors[0].B * blend.Positions[0] + blend.Colors[1].B * blend.Positions[1];

            return Color.FromArgb((int)r, (int)g, (int)b);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            colorChangeTimer.Stop();
            clickTimer.Stop();
        }
    }
}