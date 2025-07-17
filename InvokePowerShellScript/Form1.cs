


using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InvokePowerShellScript



{
    public partial class Form1 : Form
    {
        // Fix for CS0229: Ensure only one declaration of 'timer1' exists and use fully qualified name for clarity.
        // Fix for IDE0017: Use object initializer for timer1.

      
        
        public Form1()
        {
            InitializeComponent();

            string basePath = Application.StartupPath;

            string computersPath = Path.Combine(basePath, "InvokeCommandFiles", "Computers");
            string scriptsPath = Path.Combine(basePath, "InvokeCommandFiles", "Scripts");

            LoadFilesIntoComboBox(computersPath);
            LoadPowerShellScripts(scriptsPath);

            InitializeStatusStrip();
            InitializeTimer();

        }



        private void InvokeScript(string strcomputers, string strscript)
        {
            MessageBox.Show($"Invoking script: {strscript} on computers: {strcomputers}");
        }

        private void LoadFilesIntoComboBox(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                string[] files = Directory.GetFiles(directoryPath);

                comboBox1.Items.Clear();

                foreach (string file in files)
                {
                    comboBox1.Items.Add(file);
                }
            }
            else
            {
                MessageBox.Show("Directory does not exist.");
            }
        }

        private void LoadPowerShellScripts(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                string[] psFiles = Directory.GetFiles(directoryPath, "*.ps1");

                comboBox2.Items.Clear();

                foreach (string file in psFiles)
                {
                    comboBox2.Items.Add(file);
                }
            }
            else
            {
                MessageBox.Show("Directory does not exist.");
            }
        }

        public void RunPowerShellScript(string scriptPath)
        {
            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoExit -ExecutionPolicy Bypass -File \"{scriptPath}\"",
                    UseShellExecute = true, // Important: allows console window to show
                    CreateNoWindow = false  // Show the PowerShell window
                };


                using var _ = System.Diagnostics.Process.Start(psi);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error launching PowerShell:\n" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string computersPath = comboBox1.SelectedItem?.ToString();
            string scriptFilePath = comboBox2.SelectedItem?.ToString();

            string scriptPath = Path.Combine(Application.StartupPath, "InvokeScript.ps1");

            if (string.IsNullOrWhiteSpace(computersPath) || string.IsNullOrWhiteSpace(scriptFilePath))
            {
                MessageBox.Show("Please select both a computer list and a script file.");
                return;
            }

            string psScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InvokeScript.ps1");

            if (!File.Exists(psScriptPath))
            {
                MessageBox.Show("PowerShell script not found.");
                return;
            }

            string scriptContent = File.ReadAllText(psScriptPath);

            // Replace $computers and $scriptfile values using regex
            scriptContent = Regex.Replace(scriptContent, @"(?m)^\$computers\s*=\s*"".*?""", $"$computers = \"{computersPath}\"");
            scriptContent = Regex.Replace(scriptContent, @"(?m)^\$scriptfile\s*=\s*"".*?""", $"$scriptfile = \"{scriptFilePath}\"");

            File.WriteAllText(psScriptPath, scriptContent);

            MessageBox.Show("PowerShell script updated successfully.");

            RunPowerShellScript(scriptPath);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2();
            form2.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.Title = "Select a text file";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog1.FileName;

                    // Path to the PowerShell script in the same folder as the EXE
                    string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InvokeScript.ps1");

                    // Read and update the script
                    string[] lines = File.ReadAllLines(scriptPath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Trim().StartsWith("$computers ="))
                        {
                            lines[i] = $"$computers = \"{selectedFilePath}\"";
                            break;
                        }
                    }

                    // Save the updated script
                    File.WriteAllLines(scriptPath, lines);

                    MessageBox.Show("PowerShell script updated with selected file path.", "Success");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog2 = new OpenFileDialog())
            {
                openFileDialog2.Filter = "PowerShell files (*.ps1)|*.ps1|All files (*.*)|*.*";
                openFileDialog2.Title = "Select a Powershell file";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog1.FileName;

                    // Path to the PowerShell script in the same folder as the EXE
                    string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InvokeScript.ps1");

                    // Read and update the script
                    string[] lines = File.ReadAllLines(scriptPath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Trim().StartsWith("$scriptfile ="))
                        {
                            lines[i] = $"$scriptfile = \"{selectedFilePath}\"";
                            break;
                        }
                    }

                    // Save the updated script
                    File.WriteAllLines(scriptPath, lines);

                    MessageBox.Show("PowerShell script updated with selected file path.", "Success");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            bool isChecked = checkBox1.Checked;

            button1.Enabled = isChecked;
            button2.Enabled = isChecked;
            button5.Enabled = isChecked;
            button3.Enabled = !isChecked;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string scriptPath = Path.Combine(Application.StartupPath, "InvokeScript.ps1");
            RunPowerShellScript(scriptPath);
        }



        private void InitializeStatusStrip()
        {
            // Create StatusStrip
            StatusStrip statusStrip1 = new StatusStrip();

            // Create labels
            ToolStripStatusLabel dateLabel = new ToolStripStatusLabel();
            ToolStripStatusLabel timeLabel = new ToolStripStatusLabel();
            ToolStripStatusLabel copyrightLabel = new ToolStripStatusLabel();

            // Set initial text
            dateLabel.Name = "dateLabel";
            dateLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            timeLabel.Name = "timeLabel";
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");

            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.Text = "Topete © 2025";

            // Add spacing between items
            ToolStripStatusLabel spacer1 = new ToolStripStatusLabel() { Spring = true };
            ToolStripStatusLabel spacer2 = new ToolStripStatusLabel() { Spring = true };

            // Add items to StatusStrip
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(spacer1);
            statusStrip1.Items.Add(timeLabel);
            statusStrip1.Items.Add(spacer2);
            statusStrip1.Items.Add(copyrightLabel);

            // Add StatusStrip to the form
            this.Controls.Add(statusStrip1);
        }

        // ... other code ...

        private void InitializeTimer()
        {
            timer1 = new System.Windows.Forms.Timer
            {
                Interval = 1000 // 1 second
            };
            timer1.Tick += Timer_Tick;
            timer1.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update date and time labels
            foreach (Control control in this.Controls)
            {
                if (control is StatusStrip statusStrip)
                {
                    foreach (ToolStripItem item in statusStrip.Items)
                    {
                        if (item.Name == "dateLabel")
                            item.Text = DateTime.Now.ToString("MMMM dd, yyyy");
                        else if (item.Name == "timeLabel")
                            item.Text = DateTime.Now.ToString("hh:mm:ss tt");
                    }
                }
            }
        }

       
    }
}
