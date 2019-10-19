using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lucene.Net.Search; // for IndexSearcher

namespace EduQuiz_Question_Answering_System
{
    public partial class form_Search : Form
    {

        LuceneInteractive myLuceneApp;

        Form indexForm;

        List<Panel> panels = null; //store panels, for removing them later for the subsequent searching

        public form_Search(LuceneInteractive luceneApp, Form previousForm)
        {
            InitializeComponent();
            myLuceneApp = luceneApp;
            indexForm = previousForm;

            panels = new List<Panel>();
        }


        private void btn_Search_Click(object sender, EventArgs e)
        {
            foreach (Panel panel in panels)
            {
                this.Controls.Remove(panel); //remove the previous result panels
            }

            DateTime start = System.DateTime.Now;

            bool searchingOption_multiTerm = radio_MultiTerm.Checked; // with pre-processing

            string queryText = txtbox_SearchingQuery.Text;

            if (searchingOption_multiTerm)
            {
                queryText = Utils.Pre_Process_Query(queryText); // pre-process query by tokenizing and stopwords removal
            }




            if (queryText != "")
            {
                Query query = myLuceneApp.GetQueryBasedOnQueryText(queryText);
                lbl_FinalQuery.Text = "Final Query:" + query.ToString();

                List<string> resultList = myLuceneApp.GetResults(queryText);

                //---------//
                int i = 0;
                int panelX = 10, panelY = 180, panelWidth = 1000, panelHeight = 110;
                foreach (string result in resultList)
                {
                    i++;
                    Panel panel = new Panel();
                    panel.Name = "panel_result" + i;
                    // panel.AutoScroll = true;
                    panel.Location = new System.Drawing.Point(panelX, panelY + panelHeight * i);
                    panel.Size = new System.Drawing.Size(panelWidth, panelHeight);

                    int splitPosition = result.IndexOf(" "); // url + " " + passage_text

                    string url = result.Substring(0, splitPosition); //url

                    string tempUrl = url;
                    if (tempUrl[tempUrl.Length - 1] == '/') // situation like https://www.slimvapepen.com/rebuildable-atomizer-rba/ , need to remove '/'
                    {
                        tempUrl = tempUrl.Remove(tempUrl.Length - 1);
                    }
                    int indexOfForwardSlash = tempUrl.LastIndexOf('/'); //https://en.wikipedia.org/wiki/Reserve_Bank_of_Australia
                    string title = tempUrl.Substring(indexOfForwardSlash + 1); //title 

                    string passage_text = result.Substring(splitPosition + 1); //passage text


                    //Show Title
                    Label titleLabel = new Label();
                    titleLabel.Text = title;
                    titleLabel.Location = new System.Drawing.Point(0, 0);
                    titleLabel.Size = new System.Drawing.Size(300, 12);
                    panel.Controls.Add(titleLabel);


                    //Add button to view entire passage
                    Button btn_viewAllPassage = new Button();
                    btn_viewAllPassage.Text = "View All Passage";
                    btn_viewAllPassage.Location = new System.Drawing.Point(0, 65);
                    btn_viewAllPassage.Size = new System.Drawing.Size(150, 25);

                    btn_viewAllPassage.Tag = passage_text;
                    btn_viewAllPassage.Click += new EventHandler(p_Click);
                    panel.Controls.Add(btn_viewAllPassage);

                    //Show URL
                    LinkLabel urlLabel = new LinkLabel();
                    urlLabel.Text = url;
                    urlLabel.Location = new System.Drawing.Point(0, 12);
                    urlLabel.Size = new System.Drawing.Size(panelWidth, 12);
                    panel.Controls.Add(urlLabel);

                    //Show passage_text
                    Label passageTextLabel = new Label();
                    passageTextLabel.Text = passage_text;
                    passageTextLabel.Location = new System.Drawing.Point(0, 24);
                    passageTextLabel.Size = new System.Drawing.Size(panelWidth, 40);
                    panel.Controls.Add(passageTextLabel);

                    // panel.BringToFront();

                    panels.Add(panel);

                    this.Controls.Add(panel);
                }
                button2.Visible = true;

                DateTime end = System.DateTime.Now;
                lbl_SearchingTime_and_NumOfResults.Text = resultList.Count + " results," + " in " + (end - start).TotalSeconds + "seconds";
            }


        }


        //the panel clicking event handler
        void p_Click(object sender, EventArgs e)
        {

            string passage_text = (sender as System.Windows.Forms.Button).Tag.ToString();

            form_ViewEntirePassage viewEntirePassageForm = new form_ViewEntirePassage(passage_text, this);
            Hide();
            viewEntirePassageForm.Show();




        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Close();
            indexForm.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Save saveForm = new Save(myLuceneApp, txtbox_SearchingQuery.Text, this);
            Hide();
            saveForm.Show();
        }
    }
}
