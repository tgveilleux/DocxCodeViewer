using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DocxCodeViewer.XMLElement
{
    public class DocxElement
    {
        public string Label { get; set; }

        public string Where { get; set; }
        
        public string Id { get; set; }
        
        public string Code { get; set; }


        public void LoadCode(XmlDocument tagsDoc)
        {

       var xml =     XDocument.Parse(tagsDoc.OuterXml);


  

            var element = xml.Root?.Elements().Where(x=>x.Name.LocalName == "Tag" && x.Attribute("Id")?.Value == this.Id)?.FirstOrDefault();


            this.Code = element?.Elements().Where(x=>x.Name.LocalName == "Code")?.FirstOrDefault()?.Value ?? "";

        }


        public override string ToString()
        {
            
            var sb =new StringBuilder();
            sb.AppendLine($"/********** [{Label}] **********/");
            sb.AppendLine();
            sb.AppendLine(Code);
            sb.AppendLine();
            sb.AppendLine($"/********** [/{Label}] **********/");
            sb.AppendLine();
            return sb.ToString();

        }
    }
}
