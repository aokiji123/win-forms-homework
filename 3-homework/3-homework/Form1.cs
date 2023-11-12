using System.Timers;

namespace _3_homework
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;
        private DateTime newYearDate = new DateTime(2024, 1, 1);
        private DateTime currentTime;
        public Form1()
        {
            InitializeComponent();

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += HandleTimeEvent;
            timer.Enabled = true;
            currentTime = DateTime.Now;
        }

        private void HandleTimeEvent(object sender, ElapsedEventArgs e)
        {
            TimeSpan timeLeft = newYearDate - DateTime.Now;
            // needed this to prevent error System.InvalidOperationException: 'Cross-thread operation not valid:
            // Control 'label1' accessed from a thread other than the thread it was created on.'
            this.Invoke((MethodInvoker)delegate
            {
                label1.Text = "Time left before New Year: " +
                    $"{timeLeft.Days} days, " +
                    $"{timeLeft.Hours} hours, " +
                    $"{timeLeft.Minutes} minutes, " +
                    $"{timeLeft.Seconds} seconds.";
            });

            TimeSpan timeElapsed = DateTime.Now - currentTime;
            this.Invoke((MethodInvoker)delegate
            {
                Text = "Time from the start of the app: " + $"{(int)timeElapsed.TotalMilliseconds} ms";
            });
        }
    }
}