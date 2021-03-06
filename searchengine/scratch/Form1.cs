using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Lucene.Net.Index;
using Store = Lucene.Net.Store;
using Lucene.Net.Search;
using Documents = Lucene.Net.Documents;
using Lucene.Net.QueryParsers;

namespace scratch
{

    //using Word = Microsoft.Office.Interop.Word;

    using Lucene.Net.Analysis;
    using Lucene.Net.Util;

    public partial class Form1 : Form
    {
        Dictionary<string, string> map = new Dictionary<string, string>();

        public Form1()
        {
            //foreach (FileInfo fi in new DirectoryInfo(".").GetFiles())
            //{
            //    MessageBox.Show(fi.Extension);
            //    break;
            //}


            int day = new DateTime(2007, 6, 16).DayOfYear;
            //int day = DateTime.Today.DayOfYear;
            //DateTime date2 = new DateTime(3057, 6, 3);
            //TimeSpan diff = date2.Subtract(date1);
            
            MessageBox.Show((365-day).ToString());

            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //object oMissing = System.Reflection.Missing.Value;
            //object oTrue = true;
            //object oFalse = false;

            //Word.Application app = new Microsoft.Office.Interop.Word.Application();
            //Word.Document doc = new Microsoft.Office.Interop.Word.Document();

            ////app.Visible = true;
            ////doc = app.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            //object oFileName = "c:\\test.doc";
            //doc = app.Documents.Open(ref oFileName, ref oFalse, ref oFalse, ref oTrue, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            //textBox1.Clear();
            //textBox1.Text = doc.Content.Text;
            
            

        }
        string bismillah = "بِسْمِ اللّهِ الرَّحْمنِ الرَّحِيمِ";
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = bismillah.Replace("\u0650", "").Replace("\u0651", "").Replace("\u064E", "").Replace("\u0652", "");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            byte[] bytes = UnicodeEncoding.Unicode.GetBytes("بِسْمِ اللّهِ الرَّحْمنِ الرَّحِيمِ");
            string temp = string.Empty;

            foreach (byte b in bytes)
            {
                temp += Convert.ToInt32(b).ToString() + Environment.NewLine;

            }
            textBox1.Text = temp;
            MessageBox.Show(Convert.ToString((int)'ب', 16));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            StringReader reader = new StringReader("بِسْمِ اللّهِ الرَّحْمنِ الرَّحِيمِ");
            StringReader reader2 = new StringReader("في من بسم الله عن اعوذ عثمان");
            
            //string test = reader.ReadToEnd();
            //foreach (string s in FilterData.stopChars)
            //{
            //    test = test.Replace(s, "");
            //}
            //textBox1.Text = test + Environment.NewLine;

            //Analyzer analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(FilterData.stopWords);
            //Lucene.Net.Analysis.TokenStream ts = analyzer.TokenStream(reader2);
            //Token tok = null;
            //while ((tok = ts.Next()) != null)
            //{
            //    textBox1.AppendText(tok.TermText() + Environment.NewLine);
            //}

            Analyzer analyzer2 = new DiacriticAnalyzer(FilterData.stopWords);
            Lucene.Net.Analysis.TokenStream ts2 = analyzer2.TokenStream(reader);
            Token tok2 = null;
            while ((tok2 = ts2.Next()) != null)
            {
                textBox1.AppendText(tok2.TermText() + Environment.NewLine);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            FilterData.PrepareCharMap();
            textBox1.Clear();
            DiacriticAnalyzer analyzer = new DiacriticAnalyzer(FilterData.stopWords);
            string contents = File.ReadAllText("c:\\1.txt");
            TokenStream stream = analyzer.TokenStream(new StringReader(contents));
            Token t = null;
            while ((t = stream.Next()) != null)
            {
                textBox1.AppendText(t.TermText() + Environment.NewLine);
            }

            Store.RAMDirectory dir = new Store.RAMDirectory();
            IndexWriter indexer = new IndexWriter(dir, analyzer, true);
            Documents.Document doc = new Lucene.Net.Documents.Document();
            doc.Add(Documents.Field.Text("contents", contents));
            indexer.AddDocument(doc);
            indexer.Close();

            IndexSearcher searcher = new IndexSearcher(dir);
            Hits hits = searcher.Search(QueryParser.Parse("انعمت", "contents", analyzer));
            MessageBox.Show(hits.Length().ToString());
            searcher.Close();

            dir.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            string input = "اللہ";
            char c = '\uFDF2';
            string test = "الله";
            string test2 = "\uFDF2";
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(test);
            string temp = string.Empty;
            foreach (byte byt in bytes)
            {
                temp += Convert.ToString(byt, 16) + Environment.NewLine;

            }

            string output = "\u0627\u0644\u0644\u06C1";
            
            bool b = (c.ToString() == output);
            bool b2 = (c.ToString() == input);
            bool b3 = (output == input);
            bool b4 = (output == test2);

            MessageBox.Show(temp);
            MessageBox.Show(c.ToString());
            MessageBox.Show(c.ToString());
            MessageBox.Show(output);
            
            MessageBox.Show(b.ToString());
            MessageBox.Show(b2.ToString());
            MessageBox.Show(b3.ToString());
            MessageBox.Show(b4.ToString());
            MessageBox.Show(input.Contains("\u0627\u0644\u0644\u06C1").ToString());
            MessageBox.Show((test2.Replace("\uFDF2", "\u0627\u0644\u0644\u06C1") == output).ToString());

        }
    }
}