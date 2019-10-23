using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduQuiz_Question_Answering_System
{
    public partial class form_Index : Form
    {
        private string jsonFilePath { get; set; }
        private string indexPath { get; set; }
        public static LuceneInteractive myLuceneApp;

        public form_Index()
        {
            InitializeComponent();
            myLuceneApp = null;
            jsonFilePath = "";
            indexPath = "";

        }

        private void btn_OpenLocalFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "Please choose file";
            fileDialog.Filter = "All files (*.json)|*.json";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                MessageBox.Show("You have chosen:" + file, "Prompt for file choice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbox_FilePath.Text = file;


                jsonFilePath = file;
            }
        }

        private void btn_OpenLocalFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select a folder save the index";

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    txtbox_FolderPath.Text = folderName;
                    MessageBox.Show("You have chosen:" + folderName, "Prompt for index folder choice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                indexPath = folderName;
            }
        }

        private void btn_CreateIndex_Click(object sender, EventArgs e)
        {
            if (jsonFilePath == "" || indexPath == "")
            {
                MessageBox.Show("You have not chosen Collection Path or Index Path");
                return;
            }

            DateTime startIndex = System.DateTime.Now;
            // myLuceneApp = new LuceneInteractive(@"Z:\Desktop\QUT\IFN647\Project\collection_sample.json", @"Z:\Desktop\647_Searching_Engine_Index");
            myLuceneApp = new LuceneInteractive(jsonFilePath, indexPath);
            DateTime endIndex = System.DateTime.Now;

            string indexTime = "Index Time: " + (endIndex - startIndex).TotalSeconds + " seconds";
            lbl_IndexTime.Text = indexTime;


        }

        private void btn_GoToSearchPage_Click(object sender, EventArgs e)
        {
            if (myLuceneApp == null)
            {
                MessageBox.Show("You should index first!");
                return;
            }
            form_Search searchForm = new form_Search(myLuceneApp, this);
            Hide();
            searchForm.Show();
        }
    }
}
