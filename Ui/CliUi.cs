using Spectre.Console;
using CliTool.Backend;

namespace CliTool.Ui;

public class CliUi
{
    public static void Ui()
    {
        Console.Clear();

        AnsiConsole.Write(
            new FigletText("File Template Creator")
                .LeftJustified()
                .Color(Color.Aquamarine1_1));

        FileCreationUi();
    }

    public static void FileCreationUi()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("File Template To Create")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
                .AddChoices(new[]
                {
                    "C#",
                    "Go"
                }));

        switch (choice)
        {
            case "C#":
                FileCreator.CreateCSharpFile();
                break;
            case "Go":
                FileCreator.CreateGoFile();
                break;
        }
    }
}