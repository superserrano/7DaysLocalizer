using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LocalizerGUI
{
    /// <summary>
    /// Provides logging functionalities by invoking an event with the log message.
    /// </summary>
    public class LogManager
    {
        public event Action<string> OnLogMessage;

        private static readonly Lazy<LogManager> lazy = new Lazy<LogManager>(() => new LogManager());

        /// <summary>
        /// Gets the single instance of LogManager.
        /// </summary>
        public static LogManager Instance() => lazy.Value;

        /// <summary>
        /// Logs a message by invoking the OnLogMessage event.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogMessage(string message) => OnLogMessage?.Invoke(message);
    }

    /// <summary>
    /// Represents an entry in the original file.
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// Gets or sets the English text of the entry.
        /// </summary>
        public string EnglishText { get; set; }
    }

    /// <summary>
    /// Provides services related to file operations such as parsing and saving files.
    /// </summary>
    internal class FileServices
    {
        /// <summary>
        /// Holds the entries of the original file.
        /// </summary>
        public List<Entry> originalFile = new List<Entry>();

        /// <summary>
        /// Parses a file and returns a list of entries.
        /// </summary>
        /// <param name="filePath">The path of the file to parse.</param>
        /// <returns>A list of entries parsed from the file.</returns>
        public List<Entry> ParseFile(string filePath)
        {
            LogManager.Instance().LogMessage("Parsing original file...");

            var entries = new List<Entry>();
            try
            {
                using var reader = new StreamReader(filePath);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var entry = ParseLine(line);
                    if (entry != null) entries.Add(entry);

                    originalFile.Add(new Entry() { EnglishText = line });
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance().LogMessage(ex.Message);
            }

            LogManager.Instance().LogMessage("Original file parsed and ready.");
            return entries;
        }

        /// <summary>
        /// Parses a line from the file and returns an Entry object.
        /// </summary>
        /// <param name="line">The line to parse.</param>
        /// <returns>An Entry object representing the parsed line.</returns>
        private Entry ParseLine(string line)
        {
            var entry = new Entry();
            var parts = line.Split(',');
            entry.EnglishText = parts[5];

            return entry;
        }

        /// <summary>
        /// Saves the translated entries to a file selected by the user.
        /// </summary>
        /// <param name="NewFile">The list of translated entries to save.</param>
        public static void SaveTranslationToFile(List<Entry> NewFile)
        {
            LogManager.Instance().LogMessage("Saving translation to file...");

            string filePath = "";
            using var saveFileDialog = new SaveFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                var lines = NewFile.Select(entry => entry.EnglishText).ToList();

                try
                {
                    File.WriteAllLines(filePath, lines);
                }
                catch (Exception ex)
                {
                    LogManager.Instance().LogMessage($"Error: Could not write file to disk. Original error: {ex.Message}");
                }
            }

            LogManager.Instance().LogMessage($"File saved to {filePath}");
        }
    }
}
