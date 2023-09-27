# Project Title
7 Days to Die Localizer: A Multilingual Translation Tool

## Description
7 Days to Die Localizer is a desktop application designed to translate English Localization files into multiple languages using the OpenAI API. It provides a user-friendly interface allowing users to load English Localization files, select translation models, and save the translated results.

## Features
- User-friendly GUI
- File Parsing: Load and parse existing English Localization files.
- Translation: Translate text entries into multiple languages.
- Save Results: Save the translated results to a file.
- Logging: View the log of activities and errors within the application.
- Model Selection: Choose between GPT 3.5 turbo and GPT 4 for translation.

## Getting Started
### Prerequisites
- .NET 5.0 or later
- An OpenAI API Key
- A Localization file with English translations

### Installation
1. Clone the repository
   ```sh
   git clone <repository-url>
2. Open the solution in Visual Studio
3. Build the solution to restore NuGet packages and compile the project

### Usage
1. Run the application from Visual Studio or using the compiled executable.
2. Load a text file with entries you wish to translate.
3. Enter your OpenAI API Key and select the desired translation model.
4. Click "Translate" to start the translation process.
5. Save the translated results to a file.

# Built With
1. C#
2. Windows Forms
3. OpenAI API

# License
This project is licensed under the MIT License

# Acknowledgments
OpenAI for providing the API used in this project.
The Fun Pimps for making such a great game.

# Troubleshooting
Every now and then the program will add extra lines between individual translations.  If this occurs, try translating again or use the GPT 4 model.
