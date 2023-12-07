namespace _6_homework
{
    public partial class Form1 : Form
    {
        private ToolStripMenuItem toolStripMenuItem;
        private int count = 0;

        public Form1()
        {
            InitializeComponent();

            this.BackColor = Color.LightGray;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            toolStripMenuItem = new ToolStripMenuItem((count++).ToString());
            toolStripMenuItem.ForeColor = Color.Blue;
            toolStripMenuItem.Font = new Font("Arial", 12, FontStyle.Bold);
            toolStripMenuItem.DropDownOpening += DropDownOpeningHandler;

            MenuStrip menuStrip = new MenuStrip();
            menuStrip.Items.Add(toolStripMenuItem);

            Controls.Add(menuStrip);

            MainMenuStrip = menuStrip;
        }

        void DropDownOpeningHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem root = sender as ToolStripMenuItem;

            if (!root.HasDropDownItems)
            {
                ToolStripMenuItem newItem = new ToolStripMenuItem((count++).ToString());
                newItem.DropDownOpening += DropDownOpeningHandler;
                root.DropDownItems.Add(newItem);
            }
        }
    }
}
