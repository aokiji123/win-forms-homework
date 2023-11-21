namespace _5_homework
{
    public partial class Form1 : Form
    {
        private Button buttonForColorSelecting;

        public Form1()
        {
            InitializeComponent();
            InitializeButton();
        }

        private void InitializeButton()
        {
            buttonForColorSelecting = new Button();
            buttonForColorSelecting.Text = "Pick color for background!";
            buttonForColorSelecting.Width = 100;
            buttonForColorSelecting.Height = 100;

            buttonForColorSelecting.Location = new Point(Width / 2 - buttonForColorSelecting.Width / 2, Height / 2 - buttonForColorSelecting.Height / 2);

            buttonForColorSelecting.Click += buttonSelectColor_Click;
            Controls.Add(buttonForColorSelecting);
        }

        private void buttonSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog.Color;
            }
        }
    }
}