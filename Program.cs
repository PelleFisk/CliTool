using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;

namespace CliTool
{
    public static class CliTool
    {
        public static List<string> chores = new List<string>();
        public static string ChoresName = "";
        public static int d = (int)DateTime.Now.DayOfWeek;
        public static string day = "";

        public static string? HeaderName = "";
        public static string? CName = "";

        public static void Main()
        {
            GetDay();
            Init();
        }

        public static void Init()
        {
            int? data;

            Console.WriteLine("====== Main Menu ======");
            Console.WriteLine("= 1: Create a c project   =");
            Console.WriteLine("= 2: Check Chores         =");
            Console.WriteLine("= 3: Add Chores           =");
            Console.WriteLine("= 4: Quit                 =");
            data = Convert.ToInt32(Console.ReadLine());

            switch (data)
            {
            case 1:
                CreateCFile();
                CreateHeaderFile();
                break;
            case 2:
                CheckChores();
                break;
            case 3:
                AddChores();
                break;
            case 4:
                break;
            }
        }

        public static void CreateCFile()
        {
            string directory = Environment.CurrentDirectory + @"\";
            Console.WriteLine("Please enter in the file name: ");
            CName = Console.ReadLine() + ".c";
            HeaderName = CName.Replace(".c", ".h");
            directory = directory + CName;

            if (!File.Exists(directory))
            {
                using (StreamWriter sw = File.CreateText(directory))
                {
                    sw.WriteLine($"""#include "{HeaderName}" """); 
                }
            }

            Main();
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

            Main();
        }

        public static void GetDay()
        {
            switch (d)
            {
                case 1:
                    day = "monday";
                    break;
                case 2:
                    day = "tuesday";
                    break;
                case 3:
                    day = "wendsday";
                    break;
                case 4:
                    day = "thursday";
                    break;
                case 5:
                    day = "friday";
                    break;
                case 6:
                    day = "saturday";
                    break;
                case 0:
                    day = "sunday";
                    break;
            }
        }

        public static void CheckChores()
        {
            string? line = "";
            string? directory = Environment.CurrentDirectory + @"\" + day + ".txt";
            StreamReader sr = new StreamReader(directory);

            line = sr.ReadLine();
            switch (day)
            {
                case "monday":
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    break;
                case "tuesday":
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    break;
                case "wednasday":
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    break;
                case "thursday":
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    break;
                case "friday":
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    break;
                case "saturday":
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    break;
                case "sunday":
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    break;
            }

            Main();
        }

        public static void AddChores()
        {
            string? data = "";
            string? data2 = "";
            Console.WriteLine("Which day do you want to add the chore to?: ");
            data = Console.ReadLine().ToUpper();

            switch (data)
            {
                case "MONDAY":
                    Console.WriteLine("What chores do you wanna add?: ");
                    data2 = Console.ReadLine();
                    chores.Clear();
                    chores.Add(data2);
                    ChoresSave("monday");
                    break;
                case "TUESDAY":
                    Console.WriteLine("What chores do you wanna add?: ");
                    data2 = Console.ReadLine();
                    chores.Clear();
                    chores.Add(data2);
                    ChoresSave("tuesday");
                    break;
                case "WEDNASDAY":
                    Console.WriteLine("What chores do you wanna add?: ");
                    data2 = Console.ReadLine();
                    chores.Clear();
                    chores.Add(data2);
                    ChoresSave("wednesday");
                    break;
                case "THURSDAY":
                    Console.WriteLine("What chores do you wanna add?: ");
                    data2 = Console.ReadLine();
                    chores.Clear();
                    chores.Add(data2);
                    ChoresSave("thursday");
                    break;
                case "FRIDAY":
                    Console.WriteLine("What chores do you wanna add?: ");
                    data2 = Console.ReadLine();
                    chores.Clear();
                    chores.Add(data2);
                    ChoresSave("friday");
                    break;
                case "SATURDAY":
                    Console.WriteLine("What chores do you wanna add?: ");
                    data2 = Console.ReadLine();
                    chores.Clear();
                    chores.Add(data2);
                    ChoresSave("saturday");
                    break;
                case "SUNDAY":
                    Console.WriteLine("What chores do you wanna add?: ");
                    data2 = Console.ReadLine();
                    chores.Clear();
                    chores.Add(data2);
                    ChoresSave("sunday");
                    break;
            }
        }

        public static void ChoresSave(string s)
        {
            string directory = Environment.CurrentDirectory + @"\" + s + ".txt";

            if (!File.Exists(directory))
            {
                using (StreamWriter sw = File.CreateText(directory))
                {
                    foreach (string chore in chores)
                    {
                        sw.WriteLine(chore);
                    }
                }
            }

            Main();
        }
    }
}