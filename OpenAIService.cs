using OpenAI_API;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalizerGUI
{
    /// <summary>
    /// Provides services related to interacting with the OpenAI API for translation purposes.
    /// </summary>
    internal class OpenAIService
    {
        // Holds the instructions for translation.
        private const string TranslationInstructions = "For each word or phrase that you receive, you will translate it into several languages. After each full translation of the word or phrase, place a comma and then continue with the remainder of the languages. Please don't add line breaks after the commas. These are the languages: german,spanish,french,italian,japanese,koreana,polish,brazilian,russian,turkish,simplified chinese,traditional chinese. This is the output format: german,spanish,french,italian,japanese,koreana,polish,brazilian,russian,turkish,simplified chinese,traditional chinese. You will respond with only the correctly translated and formatted output.  Here is an example: INPUT=Glass Bullet Tip  OUTPUT=Glas Kugelspitze, Punta de bala de vidrio, Pointe de balle en verre, Punta di proiettile in vetro, グラス弾丸先端, 유리 총알 팁, Szkło szpicakowe kulka, Ponta de bala de vidro, Стеклянный остроконечный снаряд, Cam takoz ucu, 玻璃子弹尖, 玻璃子彈尖";

        // Holds the OpenAIAPI instance for making API calls.
        private OpenAIAPI api;

        // Holds the list of entries to translate and their original state.
        private List<Entry> entries, originalFile;

        // Holds the new translated entries.
        private List<Entry> NewFile;

        // Specifies the model to be used for translation.
        private OpenAI_API.Models.Model model;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIService"/> class.
        /// </summary>
        /// <param name="apiKey">The API Key for OpenAI.</param>
        /// <param name="_entries">The entries to be translated.</param>
        /// <param name="_originalFile">The original state of the entries.</param>
        /// <param name="_model">The model to be used for translation.</param>
        public OpenAIService(string apiKey, List<Entry> _entries, List<Entry> _originalFile, OpenAI_API.Models.Model _model)
        {
            LogManager.Instance().LogMessage("Initializing OpenAI...");

            // Initialize OpenAI API here with the provided API key and model.
            api = new OpenAIAPI(apiKey);
            model = _model;
            entries = _entries;
            originalFile = _originalFile;

            LogManager.Instance().LogMessage("OpenAI Initialized.");
        }

        /// <summary>
        /// Translates the provided entries asynchronously using the OpenAI API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task TranslateAsync()
        {
            LogManager.Instance().LogMessage("Beginning translation");

            // Initialize the NewFile list to hold the translated entries.
            NewFile = new List<Entry>();

            // Create a conversation for translation.
            //var chat = api.Chat.CreateConversation();
            //chat.Model = model;
            //chat.AppendSystemMessage(TranslationInstructions);

            //// Set the first line; the key.
            //NewFile.Add(new Entry() { EnglishText = "Key,File,Type,UsedInMainMenu,NoTranslate,english,Context / Alternate Text,german,spanish,french,italian,japanese,koreana,polish,brazilian,russian,turkish,schinese,tchinese" });
            ;
            // Iterate over each entry and perform translation, skipping the first line.
            for (int i = 1; i < entries.Count; i++)
            {
                LogManager.Instance().LogMessage($"Translating entry {i} out of {originalFile.Count - 1}");
                var chat = api.Chat.CreateConversation();
                chat = api.Chat.CreateConversation();

                chat.Model = model;
                chat.AppendSystemMessage(TranslationInstructions);

                // Set the first line; the key.
               // NewFile.Add(new Entry() { EnglishText = "Key,File,Type,UsedInMainMenu,NoTranslate,english,Context / Alternate Text,german,spanish,french,italian,japanese,koreana,polish,brazilian,russian,turkish,schinese,tchinese" });
                // Append the English text to the chat and get the translation.
                chat.AppendUserInput(entries[i].EnglishText);
                var result = await chat.GetResponseFromChatbotAsync();

                // Create a new entry using the results and add it to the NewFile list.
                NewFile.Add(new Entry() { EnglishText = String.Concat(originalFile[i].EnglishText, ",,", result) });
            }
            NewFile.Insert(0, new Entry() { EnglishText = "Key,File,Type,UsedInMainMenu,NoTranslate,english,Context / Alternate Text,german,spanish,french,italian,japanese,koreana,polish,brazilian,russian,turkish,schinese,tchinese" });
            LogManager.Instance().LogMessage("File Translated.");
            FileServices.SaveTranslationToFile(NewFile);
        }
    }
}
