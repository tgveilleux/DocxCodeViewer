using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using ICSharpCode.TextEditor.Document;

namespace DocxCodeViewer.highlighting
{
    public class AppSyntaxModeProvider : ISyntaxModeFileProvider
        {
            List<SyntaxMode> syntaxModes = null;

            public ICollection<SyntaxMode> SyntaxModes
            {
                get
                {
                    return syntaxModes;
                }
            }


            public AppSyntaxModeProvider()
            {
                Assembly assembly = Assembly.GetExecutingAssembly();


                Stream syntaxModeStream = assembly.GetManifestResourceStream("XpertDocAnalyzer.highlighting.SyntaxMode.xml");
                if (syntaxModeStream != null)
                {
                    syntaxModes = SyntaxMode.GetSyntaxModes(syntaxModeStream);
                }
                else
                {
                    syntaxModes = new List<SyntaxMode>();
                }
            }

            public XmlTextReader GetSyntaxModeFile(SyntaxMode syntaxMode)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();

                // load syntax schema
                Stream stream = assembly.GetManifestResourceStream("XpertDocAnalyzer.highlighting." + syntaxMode.FileName);
                return new XmlTextReader(stream);
            }

            public void UpdateSyntaxModeList()
            {
                // resources don't change during runtime
            }
        }
    

}
