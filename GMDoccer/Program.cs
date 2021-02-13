using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GMDoccer
{
    class Program
    {
        static int Main(string[] args)
        {
            // 1 - an error or invalid args.
            // 0 - all fine.

            if (args.Length <= 0)
            {
                Console.WriteLine("Drag your 'scripts' folder onto the exe,");
                Console.WriteLine("Thanks.");
                Console.ReadKey(true);
                return 1;
            }
            else
            {
                if (!Directory.Exists(args[0]))
                {
                    Console.WriteLine("Directory does not exist.");
                    return 1;
                }
                else
                {
                    if (GMDoccer.GenerateDocs(args[0])) return 0; else return 1;
                }
            }
        }
    }
}
