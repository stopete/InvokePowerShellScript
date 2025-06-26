


using System.Diagnostics;

namespace InvokePowerShellScript
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //CheckAndInstallModules();
            LoadFilesIntoComboBox(@"C:\DoNotDelete\InvokeCommandFiles\Computers");
            LoadPowerShellScripts(@"C:\DoNotDelete\InvokeCommandFiles\Scripts");
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select an item from both ComboBox1 and ComboBox2.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? selectedItem1 = comboBox1.SelectedItem?.ToString();
            string? selectedItem2 = comboBox2.SelectedItem?.ToString();

            if (selectedItem1 != null && selectedItem2 != null)
            {
                DialogResult result = MessageBox.Show(
                    $"You selected:\nComboBox1: {selectedItem1}\nComboBox2: {selectedItem2}\nDo you want to proceed?",
                    "Confirmation",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    InvokeScript(selectedItem1, selectedItem2);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Get the path to the script in the same folder as the executable
            string scriptPath = Path.Combine(Application.StartupPath, "HelloWorld.ps1");

            // Create the PowerShell process
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -File \"{scriptPath}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = false
            };

            try
            {
                // Fix for CS8600: Ensure 'Process.Start' result is checked for null
                using (Process? process = Process.Start(psi))
                {
                    if (process == null)
                    {
                        throw new InvalidOperationException("Failed to start the process.");
                    }

                    // Fix for IDE0063: Simplify 'using' statement
                    string output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    MessageBox.Show("Output:\n" + output);

                    if (!string.IsNullOrEmpty(errors))
                    {
                        MessageBox.Show("Errors:\n" + errors);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
    }
}
