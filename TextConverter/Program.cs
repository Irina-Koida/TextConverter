using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a text: ");
            string txt = Console.ReadLine();
            Console.WriteLine("Choose the format:");
            Console.WriteLine("1. txt\n2. csv");
            string format = Console.ReadLine();
            WriteFile wf = new WriteFile();

            switch (format)
            {
                case "1":
                    wf.WriteToFile(txt, FileType.txt);
                    Console.WriteLine($"File Console.{FileType.txt} Writed!");
                    break;
                case "2":
                    {
                        txt = txt.Replace(" ", ";");
                        wf.WriteToFile(txt, FileType.csv);
                        Console.WriteLine($"File Console.{FileType.csv} Writed!");
                    }
                    break;
                default: { throw new Exception("Error!"); }
            }

            Console.Read();
        }


        interface IWrite
        {
            void WriteToFile(string text, FileType texts);
        }

        class WriteFile : IWrite
        {
            public void WriteToFile(string text, FileType texts)
            {
                using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\Console." + texts, false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(text);
                }
            }
        }

        enum FileType
        {
            txt, csv
        }
    }
}
