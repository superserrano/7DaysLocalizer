namespace LocalizerGUI
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
            Label label1;
            textBox1 = new TextBox();
            button1 = new Button();
            textBoxOpenAIAPIKey = new TextBox();
            button2 = new Button();
            label2 = new Label();
            button3 = new Button();
            linkLabel1 = new LinkLabel();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 246);
            label1.Name = "label1";
            label1.Size = new Size(174, 25);
            label1.TabIndex = 1;
            label1.Text = "Select file to localize:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Location = new Point(12, 398);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(538, 265);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.Continue;
            button1.Location = new Point(12, 274);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 2;
            button1.Text = "Open File";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxOpenAIAPIKey
            // 
            textBoxOpenAIAPIKey.Location = new Point(12, 76);
            textBoxOpenAIAPIKey.Name = "textBoxOpenAIAPIKey";
            textBoxOpenAIAPIKey.PlaceholderText = "OpenAI Secret API Key";
            textBoxOpenAIAPIKey.Size = new Size(538, 31);
            textBoxOpenAIAPIKey.TabIndex = 3;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(12, 363);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 4;
            button2.Text = "Translate";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 48);
            label2.Name = "label2";
            label2.Size = new Size(138, 25);
            label2.TabIndex = 5;
            label2.Text = "OpenAI API Key";
            // 
            // button3
            // 
            button3.Location = new Point(12, 113);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 6;
            button3.Text = "Paste";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(270, 118);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(280, 25);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "How do I get an OpenAI API Key?";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(15, 167);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(98, 29);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "GPT 3.5";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(119, 167);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(84, 29);
            checkBox2.TabIndex = 9;
            checkBox2.Text = "GPT 4";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(570, 675);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(linkLabel1);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(textBoxOpenAIAPIKey);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "7DTD Localizer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private TextBox textBoxOpenAIAPIKey;
        private Button button2;
        private Label label2;
        private Button button3;
        private LinkLabel linkLabel1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
    }
}