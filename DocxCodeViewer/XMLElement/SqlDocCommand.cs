using System;
using System.Collections.Generic;
using System.Text;

namespace DocxCodeViewer.XMLElement
{
    public class SqlDocCommand
    {
        public string ConnectionName { get; set; }

      

        public string Name { get; set; }

        public string Query { get; set; }

        public List<string> Columns { get; set; } = new List<string>();



        public string PadBoth(string source, int length)
        {
            int spaces = length - source.Length;
            int padLeft = spaces / 2 + source.Length;
            return source.PadLeft(padLeft).PadRight(length);

        }

        public override string ToString()
        {

            var sb = new StringBuilder();




            var header = "--" + PadBoth($"NAME : {Name}  ({ConnectionName})",80) + "--";
            sb.AppendLine(new String('-', header.Length));
            sb.AppendLine(header);
            sb.AppendLine(new String('-', header.Length));

            sb.AppendLine("-- RETURNS :");
            foreach (var column in Columns)
            {
                sb.AppendLine("--    " + column);
            }
            sb.AppendLine(new String('-', header.Length));
            
            sb.AppendLine();
            sb.AppendLine(Query);
            sb.AppendLine();
            


            return sb.ToString();

        }
    }
}