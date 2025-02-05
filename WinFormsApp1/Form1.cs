using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private bool isTrackingActive = false;
        private Thread trackingThread;

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys keyCode);

        public MainForm()
        {
            SetupUIComponents();
            this.Controls.AddRange(new Control[]
            {
                logKeystrokesCheck,
                monitorProcessesCheck,
                logFilePathInput,
                restrictedWordsInput,
                restrictedAppsInput,
                startButton,
                stopButton,
                reportButton
            });
        }

        private void StartMonitoring(object sender, EventArgs e)
        {
            isTrackingActive = true;
            trackingThread = new Thread(TrackUserActivity);
            trackingThread.IsBackground = true;
            trackingThread.Start();
        }

        private void StopMonitoring(object sender, EventArgs e)
        {
            isTrackingActive = false;
            trackingThread?.Join();
        }

        private void ShowReport(object sender, EventArgs e)
        {
            if (File.Exists(logFilePathInput.Text))
                Process.Start("notepad.exe", logFilePathInput.Text);
        }

        private void TrackUserActivity()
        {
            string logFile = logFilePathInput.Text;
            string[] restrictedWords = restrictedWordsInput.Text.Split(',');
            string[] restrictedApps = restrictedAppsInput.Text.Split(',');

            while (isTrackingActive)
            {
                if (monitorProcessesCheck.Checked)
                {
                    var processes = Process.GetProcesses().Select(p => p.ProcessName);
                    foreach (var process in processes)
                    {
                        if (restrictedApps.Contains(process))
                        {
                            File.AppendAllText(logFile, $"Припинено роботу обмеженого додатку: {process} {DateTime.Now}\n");
                            foreach (var proc in Process.GetProcessesByName(process)) proc.Kill();
                        }
                    }
                }

                if (logKeystrokesCheck.Checked)
                {
                    foreach (Keys key in Enum.GetValues(typeof(Keys)))
                    {
                        if (GetAsyncKeyState(key) < 0)
                        {
                            File.AppendAllText(logFile, key.ToString() + " ");
                        }
                    }
                }
                Thread.Sleep(400);
            }
        }
    }
}
