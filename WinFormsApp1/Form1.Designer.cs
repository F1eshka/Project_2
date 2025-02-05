namespace WinFormsApp1
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void SetupUIComponents()
        {
            startButton = new Button();
            stopButton = new Button();
            reportButton = new Button();
            logKeystrokesCheck = new CheckBox();
            monitorProcessesCheck = new CheckBox();
            logFilePathInput = new TextBox();
            restrictedWordsInput = new TextBox();
            restrictedAppsInput = new TextBox();
            controlPanel = new Panel();

            this.Text = "Трекер активности пользователя";
            this.ClientSize = new Size(800, 450);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Cyan; 


            this.Text = "Трекер активності користувача";
            this.ClientSize = new Size(800, 450);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            controlPanel.Location = new Point(20, 20);
            controlPanel.Size = new Size(760, 250);
            controlPanel.BorderStyle = BorderStyle.FixedSingle;

            startButton.Location = new Point(52, 293);
            startButton.Size = new Size(169, 56);
            startButton.Text = "Розпочати моніторінг";
            startButton.BackColor = Color.Blue;
            startButton.ForeColor = Color.White;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Font = new Font("Arial", 12, FontStyle.Bold);
            startButton.Click += StartMonitoring;
            startButton.FlatAppearance.BorderSize = 0;
            startButton.ImageAlign = ContentAlignment.MiddleLeft;
            startButton.Image = SystemIcons.Information.ToBitmap();

            stopButton.Location = new Point(310, 293);
            stopButton.Size = new Size(169, 56);
            stopButton.Text = "Зупинити моніторінг";
            stopButton.BackColor = Color.FromArgb(255, 87, 34);
            stopButton.ForeColor = Color.White;
            stopButton.FlatStyle = FlatStyle.Flat;
            stopButton.Font = new Font("Arial", 12, FontStyle.Bold);
            stopButton.Click += StopMonitoring;
            stopButton.FlatAppearance.BorderSize = 0;
            stopButton.ImageAlign = ContentAlignment.MiddleLeft;
            stopButton.Image = SystemIcons.Error.ToBitmap();

            reportButton.Location = new Point(589, 293);
            reportButton.Size = new Size(190, 56);
            reportButton.Text = "Показати звіт";
            reportButton.BackColor = Color.FromArgb(30, 136, 229);
            reportButton.ForeColor = Color.White;
            reportButton.FlatStyle = FlatStyle.Flat;
            reportButton.Font = new Font("Arial", 12, FontStyle.Bold);
            reportButton.Click += ShowReport;
            reportButton.FlatAppearance.BorderSize = 0;
            reportButton.ImageAlign = ContentAlignment.MiddleLeft;
            reportButton.Image = SystemIcons.Information.ToBitmap();

            logKeystrokesCheck.Text = "Записувати натискання клавіш";
            logKeystrokesCheck.AutoSize = true;
            logKeystrokesCheck.Location = new Point(52, 48);
            logKeystrokesCheck.Font = new Font("Arial", 10);

            monitorProcessesCheck.Text = "Track Applications";
            monitorProcessesCheck.AutoSize = true;
            monitorProcessesCheck.Location = new Point(250, 48);
            monitorProcessesCheck.Font = new Font("Arial", 10);

            logFilePathInput.Location = new Point(52, 85);
            logFilePathInput.Size = new Size(600, 23);
            logFilePathInput.Text = "DONE.txt";
            logFilePathInput.PlaceholderText = "Введіть шлях до файлу для запису...";

            restrictedWordsInput.Location = new Point(52, 135);
            restrictedWordsInput.Size = new Size(600, 23);
            restrictedWordsInput.PlaceholderText = "Введіть заборонені слова (через кому)...";

            restrictedAppsInput.Location = new Point(52, 185);
            restrictedAppsInput.Size = new Size(600, 23);
            restrictedAppsInput.PlaceholderText = "Введіть заборонені додатки (через кому)...";

            controlPanel.Controls.Add(logKeystrokesCheck);
            controlPanel.Controls.Add(monitorProcessesCheck);
            controlPanel.Controls.Add(logFilePathInput);
            controlPanel.Controls.Add(restrictedWordsInput);
            controlPanel.Controls.Add(restrictedAppsInput);
        }

        private Button startButton;
        private Button stopButton;
        private Button reportButton;
        private CheckBox logKeystrokesCheck;
        private CheckBox monitorProcessesCheck;
        private TextBox logFilePathInput;
        private TextBox restrictedWordsInput;
        private TextBox restrictedAppsInput;
        private Panel controlPanel;
    }
}
