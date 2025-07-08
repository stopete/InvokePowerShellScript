namespace InvokePowerShellScript
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            button2 = new Button();
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem1 = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            groupBox2 = new GroupBox();
            button5 = new Button();
            checkBox1 = new CheckBox();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Font = new Font("Segoe UI", 9F);
            groupBox1.Location = new Point(62, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(647, 287);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Choose file from predefine dirctory";
            // 
            // button4
            // 
            button4.Image = Properties.Resources.exit_16560516_12;
            button4.Location = new Point(403, 200);
            button4.Name = "button4";
            button4.Size = new Size(91, 41);
            button4.TabIndex = 5;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.go1;
            button3.Location = new Point(514, 198);
            button3.Name = "button3";
            button3.Size = new Size(94, 41);
            button3.TabIndex = 4;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(22, 145);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(595, 28);
            comboBox2.TabIndex = 1;
            comboBox2.Text = "Pick a PowerShell script to invoke:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(22, 77);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(595, 28);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Pick a text file with computer names:";
            // 
            // button2
            // 
            button2.Image = Properties.Resources.icons8_powershell_48;
            button2.Location = new Point(77, 121);
            button2.Name = "button2";
            button2.Size = new Size(94, 52);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.txt_file_3;
            button1.Location = new Point(77, 48);
            button1.Name = "button1";
            button1.Size = new Size(94, 58);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1079, 28);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem, exitToolStripMenuItem1 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(60, 24);
            toolStripMenuItem1.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(171, 26);
            exitToolStripMenuItem.Text = "Set up Vault";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size = new Size(171, 26);
            exitToolStripMenuItem1.Text = "Exit";
            exitToolStripMenuItem1.Click += exitToolStripMenuItem1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(button2);
            groupBox2.Location = new Point(764, 84);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 274);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Browse files ";
            // 
            // button5
            // 
            button5.Image = Properties.Resources.go;
            button5.Location = new Point(83, 218);
            button5.Name = "button5";
            button5.Size = new Size(94, 41);
            button5.TabIndex = 4;
            button5.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(772, 49);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(174, 24);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Opton to browse files";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1079, 414);
            Controls.Add(checkBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Orchestrate PowerShell-based automation on remote endpoints";
            groupBox1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button button3;
        private Button button2;
        private Button button1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button button4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private GroupBox groupBox2;
        private Button button5;
        private CheckBox checkBox1;
    }
}
