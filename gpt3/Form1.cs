using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gpt3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textInput = tb_textInput.Text.ToLower();
            textAnalizer textAnalizer = new textAnalizer(textInput);
            foreach(string word in textAnalizer.usedWord)
            {
                String[] strArray = new String[] { word, textAnalizer.wordCount[word].ToString() };
                ListViewItem lvt = new ListViewItem(strArray);
                listView1.Items.Add(lvt);
            }
        }
    }

    public class textAnalizer
    {
        public Dictionary<string, int> wordCount = new Dictionary<string, int> { };
        public string[] usedWord = new string[] { };

        public textAnalizer(string text)
        {
            string[] saperatedWords = getSaperateWord(text);

            // delete overlap
            HashSet<string> wordSet = new HashSet<string>(saperatedWords);
            usedWord = wordSet.ToArray<string>();

            foreach(string word in saperatedWords)
            {
                countWord(word);
            }
        }

        public string[] getSaperateWord(string text)
        {
            string[] saperatedWords = text.Split(' ');
            return saperatedWords;
        }

        public void countWord(string word)
        {
            List<string> foundWord = new List<string>(wordCount.Keys);
            if (foundWord.Contains(word))
            {
                wordCount[word] += 1;
            }
            else
            {
                wordCount[word] = 1;
            }
        }
    }

    
}
