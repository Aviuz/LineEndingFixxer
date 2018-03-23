using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformUnixWinNewlines
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1)
            {
                String inputPath = args[0];
                String outputPath = inputPath;
                if (args.Length >= 2 && args[1] == "/c")
                {
                    string extension = "." + inputPath.Split('.').Last();
                    outputPath = inputPath.Remove(inputPath.Length-extension.Length) + "_converted" + extension;
                }

                string[] lines;

                using (StreamReader stream = new StreamReader(inputPath))
                {
                    lines = stream.ReadToEnd().Split('\n');
                }
                using (StreamWriter stream = new StreamWriter(outputPath, false))
                {
                    foreach (var line in lines)
                        stream.Write(line + "\r\n");
                }
            }

        }

        static void HelpMessage()
        {
            Console.WriteLine("Use this program in this way:\n    TUWNl_converter.exe PATH_TO_FILE [/c]\n      use /c parameter if you want to create copy of file");
        }
    }
}
