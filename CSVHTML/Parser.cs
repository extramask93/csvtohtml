using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSVHTML
{
    public interface Parser
    {
        List<string> getHeader();
        List<List<string>> getContent();

    }
    public class CsvParser : Parser
    {
        List<string> content { get; set; }
        char divchar { get; set; }

        public CsvParser(List<string> content_, char separator = ';')
        {
            content = content_;
            divchar = separator;
        }
        public List<string> getHeader()
        {
            List<string> columnNames = new List<string>(content[0].Split(divchar));
            return columnNames;
        }
        public List<List<string>> getContent()
        {
            List<List<string>> all = new List<List<string>>();
            for(int i = 1; i < content.Count; i++)
            {
                all.Add(content[i].Split(divchar).ToList<string>());
            }
            return all;
        }
    }
}
