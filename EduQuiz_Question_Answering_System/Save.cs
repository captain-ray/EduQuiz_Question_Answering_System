using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        Form indexForm;
        public Save(LuceneInteractive luceneApp, string queryText, Form previousForm)
        {
            InitializeComponent();
            myLuceneApp = luceneApp;
            myqueryText = queryText;
            indexForm = previousForm;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "Please choose file";
            fileDialog.Filter = "All (*.txt)|*.txt";
            
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                
                MessageBox.Show("You have chosen:" + file, "Prompt for file choice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbox_FilePath.Text = file;


                //jsonFilePath = file;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (txtbox_FilePath.Text != "")
            {
                
                string txtFileName = ".txt";
                bool tr = txtbox_FilePath.Text.Contains(txtFileName);

                if (tr == true)
                {
                    myLuceneApp.SaveResult(myqueryText, txtbox_FilePath.Text);
                    Close();
                    indexForm.Show();
                }
                else {
                    MessageBox.Show("Please select a txt file");
                }
                
 
            }
            else {
                MessageBox.Show("Please select a txt file");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
            indexForm.Show();
        }
    }
}
