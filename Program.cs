using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;

namespace CliTool
{
    public static class CliTool
    {

        public static string? HeaderName = "";
        public static string? CName = "";

        public static void Main()
        {
            Init();
        }

        public static void Init()
        {
            string? data = "";

            Console.WriteLine("====== Main Menu ======");
            Console.WriteLine("= (C)Create a c project   =");
            data = Console.ReadLine();

            if (data == "c")
            {
                CreateCFile();
                CreateHeaderFile();
            }
        }

        public static void CreateCFile()
        {
            string directory = Environment.CurrentDirectory + @"\";
            Console.WriteLine("Please enter in the file name: ");
            CName = Console.ReadLine() + ".c";
            Console.WriteLine(CName);
            HeaderName = CName.Replace(".c", ".h");
            directory = directory + CName;

            Console.WriteLine(directory);

            if (!File.Exists(directory))
            {
                using (StreamWriter sw = File.CreateText(directory))
                {
                    sw.WriteLine($"""#include "{HeaderName}" """); 
                }
            }
        }

        public static void CreateHeaderFile()
        {
            string directory = Environment.CurrentDirectory + @"\";
            HeaderName = CName.Replace(".c", ".h");
            directory = directory + HeaderName;

            if (!File.Exists(directory))
            {
                using (StreamWriter sw = File.CreateText(directory))
                {
                    sw.WriteLine("#ifndef " + HeaderName.Replace(".h", "") + "_" + "H" + "_");
                    sw.WriteLine("#define " + HeaderName.Replace(".h", "") + "_" + "H" + "_");
                    sw.WriteLine();
                    sw.WriteLine();
                    sw.WriteLine();
                    sw.WriteLine("#endif");
                }
            }
        }
    }
}