using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DocxCodeViewer.highlighting;
using DocxCodeViewer.Parsing;
using DocxCodeViewer.Tools;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace DocxCodeViewer
{
    public partial class DocxCodeViewer : Form
    {

        ICSharpCode.TextEditor.TextEditorControl TextEditor = new TextEditorControl();
        DocxAnalyzer docxAnalyzer = new DocxAnalyzer();

       public TypeAssistant assistant;

        private int position = 0;


        public DocxCodeViewer()
        {
            InitializeComponent();
            HighlightingManager.Manager.AddSyntaxModeFileProvider(
                new AppSyntaxModeProvider());

            this.KeyDown += OnKeyDown;
            
            this.ResetTextEditor();

             this.backgroundWorker1.DoWork += BackgroundWorker1OnDoWork;

            this.documentsToLoad.Visible = false;
            this.refresh.Visible = false;


            assistant = new TypeAssistant();
            assistant.Idled += assistant_Idled;



        }


        private void ResetTextEditor(string highlighting="C#")
        {
            this.EditorContainer.Controls.Clear();
            this.TextEditor = new TextEditorControl();
            this.TextEditor.Dock = DockStyle.Fill;
            this.EditorContainer.Controls.Add(this.TextEditor);
            this.TextEditor.SetHighlighting(highlighting);
            this.TextEditor.ActiveTextAreaControl.TextArea.KeyDown += OnKeyDown;
            this.TextEditor.TextChanged += TextEditorOnTextChanged;

        }

        private void TextEditorOnTextChanged(object sender, EventArgs eventArgs)
        {
            this.position = 0;
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyCode == Keys.F && keyEventArgs.Control)
            {
                this.bSearch.Focus();
            }
        }







        void selectText()
        {
            if (this.backgroundWorker1.IsBusy) return;


            var search = this.bSearch.Text;

            var fullText = this.TextEditor.Text;
            var text = fullText.Substring(this.position);




            var indexOf =  text.IndexOf(search, StringComparison.InvariantCultureIgnoreCase);




            if (indexOf < 0)
            {

                if (this.position != 0)
                {

                    this.position = 0;
                    this.selectText();
                }
                
                return;
            }
            indexOf += position;


          



            var leftText = fullText.Substring(0, indexOf);
            this.position = indexOf;




            var leftPosition = leftText.LastIndexOf("\n", StringComparison.Ordinal) + 1;

            int numLines = (leftText.Length - leftText.Replace("\n","").Length) ;


            if (numLines < 0) numLines = 0;
            if (leftPosition < 0) leftPosition = 0;
        


            int startCol = (indexOf) - leftPosition;
            int startLine = numLines;
            TextLocation start = new TextLocation(startCol, startLine);

            // End of selection.
            int endCol = startCol + search.Length;
            int endLine = numLines;
            TextLocation end = new TextLocation(endCol, endLine);

            // Select the second line.
            this.TextEditor.ActiveTextAreaControl.SelectionManager.SetSelection(start, end);

            // Move cursor to end of selection.
            this.TextEditor.ActiveTextAreaControl.Caret.Position = end;


        }



        void assistant_Idled(object sender, EventArgs e)
        {
            this.Invoke(
                new MethodInvoker(() =>
                {
                    this.position = 0;
                    this.selectText();
                }));
        }



        private void BackgroundWorker1OnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {

            try
            {


                if (doWorkEventArgs.Argument is string)
                {
                     var arg = doWorkEventArgs.Argument.ToString();

            this.docxAnalyzer.Open(arg);


                }


                if (doWorkEventArgs.Argument is int)
                {
                    var arg = (int)doWorkEventArgs.Argument;

                   

                    this.docxAnalyzer.Open(this.docxAnalyzer.fileNamePath,this.docxAnalyzer.PossibleContainers[arg]);


                }


                this.Invoke((MethodInvoker) delegate
                {


                    this.documentsToLoad.DataSource = this.docxAnalyzer.PossibleContainers.ToList();
                    var indexOf = this.docxAnalyzer.PossibleContainers.IndexOf(this.docxAnalyzer.Container);
                    this.documentsToLoad.SelectedIndex = indexOf;
                    this.documentsToLoad.Visible = true;
                    this.refresh.Visible = true;
                    this.position = 0;



                    if (this.docxAnalyzer.SQLMode)
                    {


                        this.ResetTextEditor("SQL");
                    }
                    else
                    {
                        this.ResetTextEditor("C#");
                    }


                    this.TextEditor.Text = this.docxAnalyzer.result.Replace("\r", "\n").Replace("\n\n", "\n").Replace("\n", "\r\n");


                    this.TextEditor.PerformAutoScale();
                    this.TextEditor.PerformLayout();
                    this.TextEditor.Refresh();

                   

                });


            }
            catch (Exception ex)
            {

                this.Invoke((MethodInvoker)delegate
                {



                    this.lblFileOpened.Text = ex.Message;
                    this.lblFileOpened.ForeColor = Color.Red;
          

                });



            }
        }

        private void btnOpenWord_Click(object sender, EventArgs e)
        {

            if (this.backgroundWorker1.IsBusy) return;
            this.openFileDialog1.FileName = "";

            this.openFileDialog1.CheckFileExists = true;
            var result = this.openFileDialog1.ShowDialog();



            if (result == DialogResult.OK)
            {
               


                    this.TextEditor.Text = "Chargement...";
                    this.backgroundWorker1.RunWorkerAsync(this.openFileDialog1.FileName);



                    this.lblFileOpened.Text = Path.GetFileName(this.openFileDialog1.FileName);
                    this.lblFileOpened.ForeColor = Color.Black;

               
           
            }



        }

        private void refresh_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(this.openFileDialog1.FileName)) return;


            if (this.backgroundWorker1.IsBusy) return;

            this.TextEditor.Text = "Chargement...";



            this.backgroundWorker1.RunWorkerAsync(this.openFileDialog1.FileName);

        }

        private void documentsToLoad_SelectedIndexChanged(object sender, EventArgs e)
        {



            var selectedItem = this.documentsToLoad.SelectedItem.ToString();
            if (selectedItem == this.docxAnalyzer.Container) return;

            if (this.backgroundWorker1.IsBusy) return;


            this.TextEditor.Text = "Chargement...";

            this.backgroundWorker1.RunWorkerAsync(this.docxAnalyzer.PossibleContainers.IndexOf(this.documentsToLoad.SelectedItem.ToString()));
        }




        private void bSearch_TextChanged(object sender, EventArgs e)
        {


       

            assistant.TextChanged();

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            var pos = this.TextEditor.Text.Substring(0, position).LastIndexOf(this.bSearch.Text);
            if (pos > 0) this.position = pos;
            else this.position = 0;

            this.selectText();

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            

            this.position += this.bSearch.TextLength;
            this.selectText();
        }

        private void bSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.position += this.bSearch.TextLength;
                this.selectText();
            }
        }
    }
}
