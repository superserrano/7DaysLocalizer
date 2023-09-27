using System.Diagnostics;

namespace LocalizerGUI
{
    /// <summary>
    /// Represents the main form of the application, handling user interactions and UI updates.
    /// </summary>
    public partial class Form1 : Form
    {
        // Services used for file parsing and interaction with the OpenAI API.
        private readonly FileServices _fileParserService = new FileServices();
        private OpenAIService _openAIService;
        private LogManager logManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Set default selection for model to GPT 3.5.
            checkBox1.Checked = true;

            // Initialize the LogManager for logging messages.
            logManager = new LogManager();

            // Subscribe to the OnLogMessage event to update the TextBox with log messages.
            LogManager.Instance().OnLogMessage += (message) =>
            {
                // Ensure thread safety when appending text to TextBox.
                if (textBox1.InvokeRequired)
                {
                    textBox1.Invoke(new Action<string>(textBox1.AppendText), message);
                    textBox1.AppendText(Environment.NewLine);
                }
                else
                {
                    textBox1.AppendText(message);
                    textBox1.AppendText(Environment.NewLine);
                }
            };

            LogManager.Instance().LogMessage("Initializing form...");
        }

        /// <summary>
        /// Handles the Click event of the Open File button.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            LogManager.Instance().LogMessage("Opening original file...");
            string originalFilePath = "";

            // Show OpenFileDialog to allow user to select the original file.
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set initial directory and file filter.
                openFileDialog.InitialDirectory = "c:\\"; // Consider using a configuration or constant for this value.
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path.
                    originalFilePath = openFileDialog.FileName;
                    LogManager.Instance().LogMessage(originalFilePath);
                }
            }

            // Parse the selected file and initialize the OpenAIService with parsed entries.
            var entries = _fileParserService.ParseFile(originalFilePath);
            _openAIService = new OpenAIService(textBoxOpenAIAPIKey.Text, entries, _fileParserService.originalFile, checkBox1.Enabled ? OpenAI_API.Models.Model.ChatGPTTurbo : OpenAI_API.Models.Model.GPT4);

            // Enable the Translate button after file is opened and parsed.
            button2.Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the Translate button.
        /// </summary>
        async private void button2_Click(object sender, EventArgs e)
        {
            // Call the TranslateAsync method of OpenAIService to start the translation process.
            await (_openAIService.TranslateAsync());
        }

        /// <summary>
        /// Handles the Click event of the Paste API Key button.
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            // Paste the API Key from the clipboard to the TextBox.
            textBoxOpenAIAPIKey.Text = Clipboard.GetText();
        }

        /// <summary>
        /// Handles the LinkClicked event of the OpenAI API Key link label.
        /// </summary>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mark the link as visited and open the OpenAI API Keys page in the default web browser.
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://platform.openai.com/account/api-keys") { UseShellExecute = true });
        }

        /// <summary>
        /// Handles the CheckedChanged event of the GPT-3.5 checkbox.
        /// </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Ensure mutual exclusivity between checkboxes.
            if (checkBox1.Checked)
                checkBox2.Checked = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the GPT-4 checkbox.
        /// </summary>
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Ensure mutual exclusivity between checkboxes.
            if (checkBox2.Checked)
                checkBox1.Checked = false;
        }
    }
}
