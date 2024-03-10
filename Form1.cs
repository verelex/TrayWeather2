using Microsoft.Web.WebView2.Core;

namespace TrayWeather2
{
    public partial class Form1 : Form
    {
        private bool firstTimeNavigationCompleted = true;

        private bool firstTimeTimerRaised = true;

        private NotifyIcon trayIcon;

        private string temperature = string.Empty;

        private static int minutes = 0;

        private bool hidden = false;

        private static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        private TwOptions? options;

        public Form1()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = new System.Drawing.Icon(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\icons\+.ico"),
                ContextMenuStrip = new ContextMenuStrip()
                {
                    Items = { new ToolStripMenuItem("Get now", null, GetWetherNow),
                                new ToolStripMenuItem("Setup", null, Setup),
                                new ToolStripMenuItem("Exit", null, Exit) }
                },
                Visible = true,
                Text = "Weather",
            };
            trayIcon.Click += trayIcon_Click;

            InitializeComponent();

            webView21.NavigationCompleted += webView21_NavigationCompleted;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webView21.EnsureCoreWebView2Async();

            XMLWorker xmlWorker = new XMLWorker();
            options = new TwOptions();
            options = xmlWorker.LoadConfig("xml.conf");
            textBox1.Text = options.key;
            textBox2.Text = options.q;
            textBox3.Text = options.rph;

            trayIcon.Text = options.q;
            this.ShowInTaskbar = false;
            this.Hide();
            hidden = true;

            minutes = SetInformation(options.rph);

            webView21.Source = new Uri($"https://yandex.ru/pogoda/{options.q}", UriKind.Absolute);

            // modify EH
            //myTimer.Tick += new EventHandler((sender, e) => TimerEventCtrl(sender, e, ref statusChecker));
            myTimer.Tick += TimerEventCtrl;

            // Sets the timer interval to 2 sec and then from config
            myTimer.Interval = 2000;
            myTimer.Start();
        }

        private async void webView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            string myScript = "document.documentElement.getElementsByClassName('temp__value temp__value_with-unit')[1].innerText";
            string webData = await webView21.ExecuteScriptAsync(myScript);
            temperature = webData.Trim('\"').Replace('−', '-');
            if (firstTimeNavigationCompleted)
            {
                SetTrayDegree();
                firstTimeNavigationCompleted = false;
            }
            /*int x = 0;
            Int32.TryParse(webData, out x);*/
        }

        private void TimerEventCtrl(Object myObject, EventArgs myEventArgs/*, ref StatusChecker sch*/)
        {
            myTimer.Stop();

            if (firstTimeTimerRaised)
            {
                SetTimerInterval(minutes);
                firstTimeTimerRaised = false;
            }

            if (!firstTimeNavigationCompleted)
            {
                webView21.CoreWebView2.Reload();
                SetTrayDegree();
            }

            myTimer.Enabled = true;
        }

        private void SetTimerInterval(int Minutes)
        {
            //                 sec    min
            myTimer.Interval = 1000 * 60 * Minutes;
        }

        private void SetTrayDegree()
        {
            if (temperature != "")
            {
                LogWriter lw = new LogWriter();
                lw.LogWrite($" SetTrayDegree(): Температура = {temperature} °C ");

                string s = string.Empty;
                if (!(temperature.StartsWith("-"))) // if T >= 0
                {
                    s = "+";
                }
                string IcoFullName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\icons\" + s + temperature + @".ico";
                trayIcon.Icon = new System.Drawing.Icon(IcoFullName);
            }
        }

        void GetWetherNow(object sender, EventArgs e)
        {
            SetTrayDegree();
        }

        void Setup(object sender, EventArgs e)
        {
            if (hidden)
            {
                this.ControlBox = false;
                this.Show();
                this.BringToFront();
                hidden = false;
            }
            else
            {
                this.Hide();
                hidden = true;
            }
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;
            Application.Exit();
        }

        private void trayIcon_Click(object sender, EventArgs e)
        {
            var eventArgs = e as MouseEventArgs;
            switch (eventArgs.Button)
            {
                // Left click to reactivate
                case MouseButtons.Left:
                    //
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkTextBoxesTextChanged())
            {
                DialogResult = MessageBox.Show("Сохранить конфиг?", "Опции были изменены", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                    options.SetAll(textBox1.Text, textBox2.Text, textBox3.Text);
                    XMLWorker xmlWorker = new XMLWorker();
                    xmlWorker.SaveConfig("xml.conf", options);
                }
            }
            Setup(sender, e); //hide form
        }

        private bool checkTextBoxesTextChanged()
        {
            if (String.Equals(options.key, textBox1.Text) &&
            String.Equals(options.q, textBox2.Text) &&
               String.Equals(options.rph, textBox3.Text))
            {
                return false;
            }
            return true;
        }

        private int SetInformation(string s)
        {
            int countPerHour = 1;
            Int32.TryParse(s, out countPerHour);
            int runs1 = 24 * countPerHour;

            if (countPerHour != 0)
            {
                int runs2 = 60 / countPerHour;
                label4.Text = $"Всего в сутки: {runs1} раз (каждые {runs2} минут)";
                LogWriter logWriter = new LogWriter();
                logWriter.LogWrite($" SetInformation(): Срабатывание таймера каждые {runs2} минут");
                return runs2;
            }
            return 15;
        }
    }
}
