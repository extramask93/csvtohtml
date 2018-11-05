using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVHTML;

namespace CSVHTMLConverterCUI
{
    class Program
    {
        static int Main(string[] args)
        {
            if(args.Length != 2)
            {
                Console.WriteLine("Usage: CSVHTMLConverter source target");
                return 1;
            }
            string source = args[0];
            string target = args[1];
            try
            {
                var linesList = System.IO.File.ReadAllLines(source).ToList<string>();
                CsvParser parser = new CsvParser(linesList);
                HTMLConverter converter = new HTMLConverter(parser.getHeader(), parser.getContent());
                System.IO.File.WriteAllText(target, converter.ToString());

            }
            catch(System.IO.IOException e)
            {
                Console.WriteLine(e.ToString());
                return 2;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return 3;
            }
            return 0;
        }
    }
}
