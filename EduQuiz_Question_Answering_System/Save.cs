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
using Lucene.Net.Search; // for IndexSearcher

namespace EduQuiz_Question_Answering_System
{
    public partial class Save : Form
    {
        LuceneInteractive myLuceneApp;

        Form indexForm;


        public Save(LuceneInteractive luceneApp, Form previousForm)
        {
            InitializeComponent();
            myLuceneApp = luceneApp;
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
                    myLuceneApp.SaveResult(txtbox_FilePath.Text);
                    MessageBox.Show("Results have been saved!");
                
                    Close();
                    indexForm.Show();
                }
                else
                {
                    MessageBox.Show("Please select a txt file");
                }


            }
            else
            {
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
