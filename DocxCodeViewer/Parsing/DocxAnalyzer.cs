using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using DocxCodeViewer.XMLElement;
using Ionic.Zip;

namespace DocxCodeViewer.Parsing
{
  public  class DocxAnalyzer
    {
        private string TempFolder  = Path.GetTempPath();
        private Guid CurrentDirectory = Guid.NewGuid();
        private Guid? fileGuid = null;
        public string FileName = "";
  public string fileNamePath = null;
        private XmlDocument document; 
        private XmlDocument tagsDoc;
        private XmlDocument xdcDoc;
        public string Container = "document.xml";
        public List<string> PossibleContainers = new List<string>();
        public List<DocxElement> DocxElements = new List<DocxElement>();
        public bool SQLMode = false;

        public DataSourceElement sqlElement = new DataSourceElement();



      void  Reload()
      {
          document = null;
          tagsDoc = null;
            PossibleContainers = new List<string>();
            DocxElements = new List<DocxElement>();
      }



        public string result
        {
            get
            {



                var sb = new StringBuilder();

                if (SQLMode)
                {
                    foreach (var element in sqlElement.Elements)
                    {

                         sb.AppendLine(element.ToString());


                    }

                }
                else
                {
                         foreach (DocxElement el in DocxElements)
                        {
                            sb.Append(el);
                        }
                }

               
                return sb.ToString();


            }
        }

      
      


        private string WorkingDirectory
        {
            get { return this.TempFolder + "\\" + this.CurrentDirectory.ToString() + "\\"; }
        }


        private string FileWorkingDirectory
        {
            get
            {
                if(fileGuid == null) throw new ArgumentException("Please, access FileWorkingDirectory after opening a file;");

                return this.TempFolder + "\\" + this.CurrentDirectory.ToString() + "\\" + this.fileGuid.Value + "\\";
            }
        }




        public DocxAnalyzer()
        {
            //création du dossier temporaire
            Directory.CreateDirectory(WorkingDirectory);
            

        }

        public void Open(string fileNamepath, string docToLoad = "document.xml")
        {

            
            
            this.Reload();

            this.Container = docToLoad;

            if(!File.Exists(fileNamepath)) throw new ArgumentException($"File {fileNamepath} doesn't exist!");
            if(Path.GetExtension(fileNamepath) != ".docx") throw  new ArgumentException($"Please select a word document.");

            this.fileNamePath = fileNamepath;
            this.FileName = Path.GetFileName(fileNamepath);
            this.fileGuid = Guid.NewGuid();
            
            this.ExtractFileToDirectory(fileNamepath,FileWorkingDirectory);


            this.LoadFiles(docToLoad);

            if (SQLMode)
            {
                this.LoadDataSource();


            }
            else
            {
                this.ParseDocument();
            this.parseCode();
            }

            

        }


  



        private void ParseDocument()
        {


            var nsmgr = new XmlNamespaceManager(document.NameTable);
            nsmgr.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");


            XmlNodeList list = this.document.DocumentElement?.SelectNodes("//w:sdt/w:sdtPr", nsmgr);

    
            foreach (XmlNode node in list)

            {

                var alias = node.SelectSingleNode("w:alias", nsmgr);
                var tag = node.SelectSingleNode("w:tag", nsmgr);
                var databinding = node.SelectSingleNode("w:dataBinding ", nsmgr);

                var docxElement = new DocxElement();

               

                if (alias?.Attributes != null)
                   docxElement.Label =  alias.Attributes["w:val"]?.Value;


                if (tag?.Attributes != null)
                    docxElement.Id = tag.Attributes["w:val"]?.Value;

                if (databinding?.Attributes != null)
                    docxElement.Where = databinding.Attributes["w:xpath"]?.Value;

               
                this.DocxElements.Add(docxElement);

            }


            
        }

        private void parseCode()
        {

            if (tagsDoc == null) return;

            foreach (var docxElement in DocxElements)
            {
                docxElement.LoadCode(tagsDoc);
            }

        }


        public void ExtractFileToDirectory(string zipFileName, string outputDirectory)
        {
            ZipFile zip = ZipFile.Read(zipFileName);
            Directory.CreateDirectory(outputDirectory);
            foreach (ZipEntry e in zip)
            {
                 e.Extract(outputDirectory, ExtractExistingFileAction.OverwriteSilently);
            }
        }



        public void LoadFiles(string wordToLoad)
        {


            this.PossibleContainers = Directory.GetFiles(FileWorkingDirectory + "\\word\\").Select(x=>Path.GetFileName(x)).ToList();
             this.PossibleContainers.Add("SQL");
            if (wordToLoad == "SQL") SQLMode = true;
            else SQLMode = false;

            if (SQLMode) wordToLoad = "document.xml";

            XmlDocument doc0 = new ConfigXmlDocument();

            doc0.Load(FileWorkingDirectory + $"\\word\\{wordToLoad}");

            this.document = doc0;

            foreach (var file in Directory.GetFiles(FileWorkingDirectory + "\\customXml\\"))
            {

                XmlDocument doc1 = new ConfigXmlDocument();

                doc1.Load(file);


              if (doc1.DocumentElement?.Name == "Tags")
               {
                        tagsDoc = doc1;

                }
                if (doc1.DocumentElement?.Name == "XDC")
                {
                    xdcDoc = doc1;
                }
          





            }


            

        }

       


        ~DocxAnalyzer()
        {
            Directory.Delete(WorkingDirectory, true);
            
        }


        public void refresh()
        {
            if(string.IsNullOrWhiteSpace(this.fileNamePath)) throw  new Exception("Open a word document beforehand.");
            this.Open(this.fileNamePath);

            
        }



        public void LoadDataSource()
        {

            if (xdcDoc == null) return;

            this.sqlElement.LoadXDC(this.xdcDoc);





        }



    }
}
