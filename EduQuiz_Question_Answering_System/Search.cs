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
    public partial class form_Search : Form
    {

        LuceneInteractive myLuceneApp;

        public form_Search(LuceneInteractive luceneApp)
        {
            InitializeComponent();
            myLuceneApp = luceneApp;
        }


        private void btn_Search_Click(object sender, EventArgs e)
        {
            string query = txtbox_SearchingQuery.Text;
            string resultsStr = myLuceneApp.GetResults(query);

            lbl_Results.Text = resultsStr;

        }
    }
}
