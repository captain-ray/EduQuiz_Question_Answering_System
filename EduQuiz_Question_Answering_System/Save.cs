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
    public partial class Save : Form
    {
        LuceneInteractive myLuceneApp;
        string myqueryText;
        public Save(LuceneInteractive luceneApp, string queryText)
        {
            InitializeComponent();
            myLuceneApp = luceneApp;
            myqueryText = queryText;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            // fileDialog.Title = "请选择文件";
            fileDialog.Title = "Please choose file";
             fileDialog.Filter = "所有文件(*.txt)|*.txt";
            
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                // MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // MessageBox.Show("You have chosen:" + file, "Prompt for file choice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbox_FilePath.Text = file;


                //jsonFilePath = file;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (txtbox_FilePath.Text != "") {
                myLuceneApp.SaveRusult(myqueryText, txtbox_FilePath.Text);
            }
        }
    }
}
