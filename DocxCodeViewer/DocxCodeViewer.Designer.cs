namespace DocxCodeViewer
{
    partial class DocxCodeViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenWord = new System.Windows.Forms.Button();
            this.lblFileOpened = new System.Windows.Forms.Label();
            this.EditorContainer = new System.Windows.Forms.Panel();
            this.refresh = new System.Windows.Forms.Button();
            this.documentsToLoad = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bSearch = new System.Windows.Forms.TextBox();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.btnOpenWord, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFileOpened, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.EditorContainer, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.refresh, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.documentsToLoad, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(810, 911);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnOpenWord
            // 
            this.btnOpenWord.Location = new System.Drawing.Point(13, 13);
            this.btnOpenWord.Name = "btnOpenWord";
            this.btnOpenWord.Size = new System.Drawing.Size(145, 23);
            this.btnOpenWord.TabIndex = 0;
            this.btnOpenWord.Text = "Ouvrir document word";
            this.btnOpenWord.UseVisualStyleBackColor = true;
            this.btnOpenWord.Click += new System.EventHandler(this.btnOpenWord_Click);
            // 
            // lblFileOpened
            // 
            this.lblFileOpened.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFileOpened.AutoSize = true;
            this.lblFileOpened.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileOpened.Location = new System.Drawing.Point(164, 19);
            this.lblFileOpened.Name = "lblFileOpened";
            this.lblFileOpened.Size = new System.Drawing.Size(288, 13);
            this.lblFileOpened.TabIndex = 1;
            this.lblFileOpened.Text = "Ouvrir un fichier en cliquant sur \"Ouvrir un document Word\"";
            // 
            // EditorContainer
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.EditorContainer, 4);
            this.EditorContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditorContainer.Location = new System.Drawing.Point(13, 45);
            this.EditorContainer.Name = "EditorContainer";
            this.EditorContainer.Size = new System.Drawing.Size(784, 823);
            this.EditorContainer.TabIndex = 2;
            // 
            // refresh
            // 
            this.refresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.refresh.Location = new System.Drawing.Point(727, 13);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(70, 26);
            this.refresh.TabIndex = 3;
            this.refresh.Text = "Rafraichir";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // documentsToLoad
            // 
            this.documentsToLoad.FormattingEnabled = true;
            this.documentsToLoad.Location = new System.Drawing.Point(458, 13);
            this.documentsToLoad.Name = "documentsToLoad";
            this.documentsToLoad.Size = new System.Drawing.Size(120, 21);
            this.documentsToLoad.TabIndex = 4;
            this.documentsToLoad.SelectedIndexChanged += new System.EventHandler(this.documentsToLoad_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.bSearch);
            this.flowLayoutPanel1.Controls.Add(this.btnLeft);
            this.flowLayoutPanel1.Controls.Add(this.btnRight);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 874);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(439, 34);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // bSearch
            // 
            this.bSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bSearch.Location = new System.Drawing.Point(3, 4);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(201, 20);
            this.bSearch.TabIndex = 0;
            this.bSearch.TextChanged += new System.EventHandler(this.bSearch_TextChanged);
            this.bSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bSearch_KeyDown);
            // 
            // btnLeft
            // 
            this.btnLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLeft.Location = new System.Drawing.Point(210, 3);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRight.Location = new System.Drawing.Point(291, 3);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 911);
            this.panel1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // XpertDocAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(810, 911);
            this.Controls.Add(this.panel1);
            this.Name = "XpertDocAnalyzer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XpertDocAnalyzer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpenWord;
        private System.Windows.Forms.Label lblFileOpened;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel EditorContainer;
        private System.Windows.Forms.Button refresh;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox documentsToLoad;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox bSearch;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
    }
}

