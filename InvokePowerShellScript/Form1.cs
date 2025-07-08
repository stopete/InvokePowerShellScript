


using System.Diagnostics;
using System.Text.RegularExpressions;

namespace InvokePowerShellScript
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string basePath = Application.StartupPath;

            string computersPath = Path.Combine(basePath, "InvokeCommandFiles", "Computers");
            string scriptsPath = Path.Combine(basePath, "InvokeCommandFiles", "Scripts");

            LoadFilesIntoComboBox(computersPath);
            LoadPowerShellScripts(scriptsPath);

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

        }
    }
}
