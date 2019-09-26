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
        }

        private void btn_OpenLocalFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            // fileDialog.Title = "请选择文件";
            fileDialog.Title = "Please choose file";
            // fileDialog.Filter = "所有文件(*.txt)|*.txt";
            fileDialog.Filter = "All files (*.json)|*.json";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                // MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // MessageBox.Show("You have chosen:" + file, "Prompt for file choice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbox_FilePath.Text = file;


                jsonFilePath = file;
            }
        }

        private void btn_OpenLocalFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select a folder save the index";
            //folderBrowserDialog1.ShowNewFolderButton = true;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    txtbox_FolderPath.Text = folderName;
                }

                indexPath = folderName;
            }
        }

        private void btn_CreateIndex_Click(object sender, EventArgs e)
        {

            DateTime startIndex = System.DateTime.Now;
            // myLuceneApp = new LuceneInteractive(@"Z:\Desktop\QUT\IFN647\Project\collection_sample.json", @"Z:\Desktop\647_Searching_Engine_Index");
            myLuceneApp=new LuceneInteractive(jsonFilePath,indexPath);
            DateTime endIndex = System.DateTime.Now;

            string indexTime = "Index Time:" + (endIndex - startIndex);
            lbl_IndexTime.Text = indexTime;

            // form_Search searchForm = new form_Search(myLuceneApp);
            // Hide();
            // searchForm.Show();

        }

        private void btn_GoToSearchPage_Click(object sender, EventArgs e)
        {
            form_Search searchForm = new form_Search(myLuceneApp,this);
            Hide();
            searchForm.Show();
        }
    }
}
