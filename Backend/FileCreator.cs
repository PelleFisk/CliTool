using Spectre.Console;

namespace CliTool.Backend;

public class FileCreator
{
    public static void CreateCSharpFile()
    {
        string fileName;
        var fileType = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please choose a file [green]type[/]?")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
                .AddChoices([
                    "Class", "Interface", "Enum"
                ]));

        switch (fileType)
        {
            case "Class":
                fileName = AnsiConsole.Ask<string>("Please enter the file name: ");
                FileWriter.WriteCSharpClass($"{fileName}.cs", "class");
                break;
            case "Interface":
                fileName = AnsiConsole.Ask<string>("Please enter the file name: ");
                FileWriter.WriteCSharpClass($"{fileName}.cs", "interface");
                break;
            case "Enum":
                fileName = AnsiConsole.Ask<string>("Please enter the file name: ");
                FileWriter.WriteCSharpClass($"{fileName}.cs", "enum");
                break;
        }
    }

    public static void CreateGoFile()
    {
        var fileName = AnsiConsole.Ask<string>("Please enter the file name: ");
        var packageName = AnsiConsole.Ask<string>("What package is the file part of?");
        FileWriter.WriteGoFile($"{fileName}.go", packageName);
    }
}