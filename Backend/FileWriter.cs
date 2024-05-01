using System.Reflection;

namespace CliTool.Backend;

public abstract class FileWriter
{
    public static void WriteCSharpClass(string fileName, string type)
    {
        var directory = @$"{Environment.CurrentDirectory}\";
        var filePath = $"{directory}{fileName}";
        var nameSpace = Assembly.GetExecutingAssembly().GetName().Name;

        if (!CheckForProjectFiles(directory))
        {
            string directoryName = new DirectoryInfo(Directory.GetCurrentDirectory()).Name;
            nameSpace += $".{directoryName}";
        }

        using StreamWriter sw = new StreamWriter(filePath);

        sw.WriteLine("using System;");
        sw.WriteLine();
        sw.WriteLine($"namespace {nameSpace};");
        sw.WriteLine();
        sw.WriteLine($"public {type} {fileName.Replace(".cs", "")}");
        sw.WriteLine("{");
        sw.WriteLine("}");
    }

    private static bool CheckForProjectFiles(string directoryPath)
    {
        var files = Directory.GetFiles(directoryPath);
        return files.Any(file => Path.GetExtension(file) == ".csproj" || Path.GetExtension(file) == ".sln");
    }

    public static void WriteGoFile(string fileName, string packageName)
    {
        var directory = @$"{Environment.CurrentDirectory}\";
        var filePath = $"{directory}{fileName}";

        using StreamWriter sw = new StreamWriter(filePath);

        sw.WriteLine($"package {packageName}");
        sw.WriteLine();
    }
}