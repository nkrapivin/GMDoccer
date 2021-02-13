using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GMDoccer
{
    public static class GMDoccer
    {
        const string GMDOC_PREFIX = "//"; // replace to "///" if needed.
        const string OUTPUT_FNAME = "docs.txt";

        public static bool GenerateDocs(string scriptsDir)
        {
            try
            {
                var scripts = Directory.EnumerateDirectories(scriptsDir);
                string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, OUTPUT_FNAME);
                if (File.Exists(outputPath)) File.Delete(outputPath);
                File.AppendAllText(outputPath, "-- GMDoccer by nkrapivindev" + Environment.NewLine);
                foreach (var script in scripts)
                {
                    Console.WriteLine("Processing script " + script);
                    string sfname = Path.GetFileNameWithoutExtension(script) + ".gml";
                    sfname = sfname.Replace("@", string.Empty);
                    ProcessOne(Path.Combine(script, sfname), outputPath);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Uh oh, an exception has occured:");
                Console.WriteLine(e.ToString());
                Console.ReadKey(true);
                return false;
            }
        }

        public static void ProcessOne(string fullPath, string outputPath)
        {
            string str = Path.GetFileName(fullPath) + ": {" + Environment.NewLine;

            var strings = File.ReadAllLines(fullPath);
            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].StartsWith(GMDOC_PREFIX))
                {
                    str += strings[i] + Environment.NewLine;
                }
                else
                {
                    break;
                }
            }
            str += "}" + Environment.NewLine;

            File.AppendAllText(outputPath, str);
        }
    }
}
