using Newtonsoft.Json;
using Timer = System.Windows.Forms.Timer;
namespace _7_homework
{
    public partial class Form1 : Form
    {
        public class MyTimeZone
        {
            public string TZCode { get; set; }
            public string TZDesc { get; set; }
        }

        private TextBox inputCityTextBox;
        private Label timeLabel;
        private Timer updateTimer;
        private List<MyTimeZone> timeZones;

        public Form1()
        {
            InitializeComponent();
            LoadTimeZones();
            InitializeUIComponents();
            StartTimer();
        }

        private void InitializeUIComponents()
        {
            inputCityTextBox = new TextBox
            {
                Width = 400,
                Location = new Point(100, 100)
            };
            Controls.Add(inputCityTextBox);

            timeLabel = new Label
            {
                Width = 400,
                Location = new Point(100, 150)
            };
            Controls.Add(timeLabel);
        }

        private void StartTimer()
        {
            updateTimer = new Timer
            {
                Interval = 1000
            };
            updateTimer.Tick += TimerHandler;
            updateTimer.Start();
        }

        private void LoadTimeZones()
        {
            try
            {
                var json = File.ReadAllText("db.json");
                timeZones = JsonConvert.DeserializeObject<List<MyTimeZone>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading time zones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimerHandler(object sender, EventArgs e)
        {
            var city = inputCityTextBox.Text;
            var timeZone = timeZones.FirstOrDefault(tz => tz.TZDesc.Contains(city));

            if (timeZone != null)
            {
                var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone.TZCode);
                var now = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
                timeLabel.Text = $"Current time in {city} is {now}";
            }
            else
            {
                timeLabel.Text = $"Time zone for {city} not found";
            }
        }
    }
}
