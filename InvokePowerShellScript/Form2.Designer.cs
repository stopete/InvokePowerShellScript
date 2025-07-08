namespace InvokePowerShellScript
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            comboBox1 = new ComboBox();
            groupBox1 = new GroupBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(70, 92);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(429, 28);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Pick credential:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Location = new Point(71, 59);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(606, 260);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Profiles";
            // 
            // button1
            // 
            button1.Image = Properties.Resources.go;
            button1.Location = new Point(401, 148);
            button1.Name = "button1";
            button1.Size = new Size(94, 44);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.exit_16560516_12;
            button2.Location = new Point(295, 149);
            button2.Name = "button2";
            button2.Size = new Size(94, 42);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 402);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            Text = "Credential Manager";
            Load += Form2_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private Button button1;
        private Button button2;
    }
}