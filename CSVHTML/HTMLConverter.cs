using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVHTML
{
    public class HTMLConverter
    {
        List<string> headerCells { get; set; }
        List<List<string>> contentCells { get; set; }
        public HTMLConverter(List<string> headerCells_, List<List<string>> contentCells_)
        {
            headerCells = headerCells_;
            contentCells = contentCells_;
        }
        public override string ToString()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine(newTable());
            html.Append(getHeader());
            html.Append(getContent());
            html.AppendLine(endTable());
            return html.ToString();
        }
        string getHeader()
        {
            StringBuilder header = new StringBuilder();
            header.AppendLine(newRow());
            foreach (var cell in headerCells)
            {
                header.Append(newCell()).Append(cell).AppendLine(endCell());
            }
            header.AppendLine(endRow());
            return header.ToString();
        }
        string getContent()
        {
            StringBuilder content = new StringBuilder();
            foreach (var row in contentCells)
            {
                content.AppendLine(newRow());
                foreach (var cell in row)
                {
                    content.Append(newCell()).Append(cell).AppendLine(endCell());
                }
                content.AppendLine(endRow());
            }
            return content.ToString();
        }
        string newTable()
        {
            return "<table style=\"border: 1px solid black;border-collapse: collapse; \">";
        }
        string endTable()
        {
            return "</table>";
        }
        string newRow()
        {
            return "<tr>";
        }
        string endRow()
        {
            return "</tr>";
        }
        string newHeader()
        {
            return "<th style=\"border: 1px solid black; \">";
        }
        string endHeader()
        {
            return "</th>";
        }
        string newCell()
        {
            return "<td style=\"border: 1px solid black; \">";
        }
        string endCell()
        {
            return "</td>";
        }
    }
}
