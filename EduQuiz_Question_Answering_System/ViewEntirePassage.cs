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
    public partial class form_ViewEntirePassage : Form
    {
        Form searchForm;
        public form_ViewEntirePassage(string passage_text,Form previousForm)
        {
            InitializeComponent();
            lbl_PassageText.Text=passage_text;
            searchForm=previousForm;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Close();
            searchForm.Show();
        }

        private void form_ViewEntirePassage_FormClosing(object sender, FormClosingEventArgs e)
        {
            searchForm.Show();
        }
    }
}
