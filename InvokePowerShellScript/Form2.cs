using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InvokePowerShellScript
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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



        public void ReplaceVariablesInFile(string userValue, string secretName, string description, string User)
        {
            string exePath = Application.StartupPath;
            string filePath = Path.Combine(exePath, "setvault.ps1");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found: " + filePath);
                return;
            }

            string fileContent = File.ReadAllText(filePath);

            // Replace only the specific variable assignments
            fileContent = System.Text.RegularExpressions.Regex.Replace(
                fileContent, @"\$user\s*=\s*"".*?""", $"$user = \"{User}\"");

            fileContent = System.Text.RegularExpressions.Regex.Replace(
                fileContent, @"\$vaultName\s*=\s*"".*?""", $"$vaultName = \"{userValue}\"");

            fileContent = System.Text.RegularExpressions.Regex.Replace(
                fileContent, @"\$secretName\s*=\s*"".*?""", $"$secretName = \"{secretName}\"");

            fileContent = System.Text.RegularExpressions.Regex.Replace(
                fileContent, @"\$descriptionName\s*=\s*"".*?""", $"$descriptionName = \"{description}\"");

            File.WriteAllText(filePath, fileContent);

            MessageBox.Show("Variables updated successfully!");
        }





        private void button1_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedItem))
            {
                MessageBox.Show("Please select an item from the list.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
                    MessageBox.Show("You selected" + selectedItem);

                    string strUserValue = selectedItem;
                    string strSecretName = selectedItem;
                    string strDescription = selectedItem;            
                    string strUser = selectedItem;

                    ReplaceVariablesInFile(strUserValue, strSecretName, strDescription, strUser);


                    string scriptPath = Path.Combine(Application.StartupPath, "setvault.ps1");
                    RunPowerShellScript(scriptPath);

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //Add items to comboBox1 from users.txt file at startup 
            string filePath = Path.Combine(Application.StartupPath, "users.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                comboBox1.Items.AddRange(lines);
            }
            else
            {
                MessageBox.Show("users.txt not found in the application directory.");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close(); // Closes only the SettingsForm

        }
    }
}
