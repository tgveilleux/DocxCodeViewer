using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace DocxCodeViewer.XMLElement
{
    public class DataSourceElement
    {

        public List<SqlDocCommand> Elements = new List<SqlDocCommand>();

         
        public void LoadXDC(XmlDocument xdcDoc)
        {

            var xml = XDocument.Parse(xdcDoc.OuterXml);




            var DataSources = xml.Root?.Elements().Where(x => x.Name.LocalName == "DataSources")?.FirstOrDefault();

            var connections = DataSources?.Elements().Where(x => x.Name.LocalName == "Connection")?.ToList();

            foreach (var connection in connections)
            {


                var name = connection.Attribute("name")?.Value;

                if (name == null) continue;

                var commands = connection.Elements().Where(x => x.Name.LocalName == "Command")?.ToList();

                foreach (var command in commands)
                {
                    var commandName = command.Attribute("name")?.Value;
                    var query = command.Attribute("query")?.Value.Replace("&#xA;", Environment.NewLine);

                    var columns =  command.Elements().Where(x => x.Name.LocalName == "Column")?.Select(x=>$"{x.Attribute("name")?.Value} ({x.Attribute("type")?.Value})").ToList();

                
                   
                    this.Elements.Add(new SqlDocCommand(){Columns = columns,ConnectionName = name, Name = commandName, Query = query});

                }




            }



        }

    }
}