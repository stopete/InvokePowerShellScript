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

            switch (selectedItem)
            {
                case "s.topete_wa":
                    MessageBox.Show("You selected s.topete_wa!");
                    string strUserValue = "s.topete_wa";
                    string strSecretName = "s.topete_wa";
                    string strDescription = "s.topete_wa";
                    string strUser = "ern\\s.topete_wa";

                    ReplaceVariablesInFile(strUserValue, strSecretName, strDescription, strUser);


                    string scriptPath = Path.Combine(Application.StartupPath, "setvault.ps1");
                    RunPowerShellScript(scriptPath);

                    break;
                case "s.topete_sa":
                    MessageBox.Show("You selected s.topete_sa!");
                    string strUserValue1 = "s.topete_sa";
                    string strSecretName1 = "s.topete_sa";
                    string strDescription1 = "s.topete_sa";
                    string strUser1 = "ern\\s.topete_sa";
                    ReplaceVariablesInFile(strUserValue1, strSecretName1, strDescription1, strUser1);


                    string scriptPath1 = Path.Combine(Application.StartupPath, "setvault.ps1");
                    RunPowerShellScript(scriptPath1);

                    break;
                case "libsys":
                    MessageBox.Show("You selected libsys!");
                    string strUserValue2 = "libsys";
                    string strSecretName2 = "libsys";
                    string strDescription2 = "libsys";
                    string strUser2 = ".\\libsys";
                    ReplaceVariablesInFile(strUserValue2, strSecretName2, strDescription2, strUser2);

                    string scriptPath2 = Path.Combine(Application.StartupPath, "setvault.ps1");
                    RunPowerShellScript(scriptPath2);
                    break;
                default:
                    MessageBox.Show("Unknown selection.");
                    break;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            // comboBox1.Items.Add("s.topete_wa");
            // comboBox1.Items.Add("s.topete_sa");
            // comboBox1.Items.Add("libsys");


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
    }
}
