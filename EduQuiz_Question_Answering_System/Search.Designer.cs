namespace EduQuiz_Question_Answering_System
{
    partial class form_Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbox_SearchingQuery = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.lbl_FinalQuery = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox_SearchingOption = new System.Windows.Forms.GroupBox();
            this.radio_AsItIs = new System.Windows.Forms.RadioButton();
            this.radio_MultiTerm = new System.Windows.Forms.RadioButton();
            this.lbl_SearchingTime_and_NumOfResults = new System.Windows.Forms.Label();
            this.checkbox_QueryExpansion = new System.Windows.Forms.CheckBox();
            this.groupBox_SearchingOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbox_SearchingQuery
            // 
            this.txtbox_SearchingQuery.Location = new System.Drawing.Point(320, 273);
            this.txtbox_SearchingQuery.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_SearchingQuery.Name = "txtbox_SearchingQuery";
            this.txtbox_SearchingQuery.Size = new System.Drawing.Size(1066, 35);
            this.txtbox_SearchingQuery.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(780, 399);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(196, 65);
            this.btn_Search.TabIndex = 1;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // lbl_FinalQuery
            // 
            this.lbl_FinalQuery.AutoSize = true;
            this.lbl_FinalQuery.Location = new System.Drawing.Point(648, 493);
            this.lbl_FinalQuery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_FinalQuery.Name = "lbl_FinalQuery";
            this.lbl_FinalQuery.Size = new System.Drawing.Size(154, 24);
            this.lbl_FinalQuery.TabIndex = 2;
            this.lbl_FinalQuery.Text = "Final Query:";
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(124, 50);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(124, 54);
            this.btn_Back.TabIndex = 3;
            this.btn_Back.Text = "BACK";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1178, 524);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 65);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save result";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // groupBox_SearchingOption
            // 
            this.groupBox_SearchingOption.Controls.Add(this.radio_AsItIs);
            this.groupBox_SearchingOption.Controls.Add(this.radio_MultiTerm);
            this.groupBox_SearchingOption.Location = new System.Drawing.Point(632, 316);
            this.groupBox_SearchingOption.Name = "groupBox_SearchingOption";
            this.groupBox_SearchingOption.Size = new System.Drawing.Size(496, 76);
            this.groupBox_SearchingOption.TabIndex = 6;
            this.groupBox_SearchingOption.TabStop = false;
            // 
            // radio_AsItIs
            // 
            this.radio_AsItIs.AutoSize = true;
            this.radio_AsItIs.Location = new System.Drawing.Point(285, 30);
            this.radio_AsItIs.Name = "radio_AsItIs";
            this.radio_AsItIs.Size = new System.Drawing.Size(137, 28);
            this.radio_AsItIs.TabIndex = 1;
            this.radio_AsItIs.Text = "As it is";
            this.radio_AsItIs.UseVisualStyleBackColor = true;
            // 
            // radio_MultiTerm
            // 
            this.radio_MultiTerm.AutoSize = true;
            this.radio_MultiTerm.Checked = true;
            this.radio_MultiTerm.Location = new System.Drawing.Point(34, 30);
            this.radio_MultiTerm.Name = "radio_MultiTerm";
            this.radio_MultiTerm.Size = new System.Drawing.Size(161, 28);
            this.radio_MultiTerm.TabIndex = 0;
            this.radio_MultiTerm.TabStop = true;
            this.radio_MultiTerm.Text = "Multi Term";
            this.radio_MultiTerm.UseVisualStyleBackColor = true;
            // 
            // lbl_SearchingTime_and_NumOfResults
            // 
            this.lbl_SearchingTime_and_NumOfResults.AutoSize = true;
            this.lbl_SearchingTime_and_NumOfResults.Location = new System.Drawing.Point(10, 524);
            this.lbl_SearchingTime_and_NumOfResults.Name = "lbl_SearchingTime_and_NumOfResults";
            this.lbl_SearchingTime_and_NumOfResults.Size = new System.Drawing.Size(0, 24);
            this.lbl_SearchingTime_and_NumOfResults.TabIndex = 7;
            // 
            // checkbox_QueryExpansion
            // 
            this.checkbox_QueryExpansion.AutoSize = true;
            this.checkbox_QueryExpansion.Location = new System.Drawing.Point(1207, 346);
            this.checkbox_QueryExpansion.Name = "checkbox_QueryExpansion";
            this.checkbox_QueryExpansion.Size = new System.Drawing.Size(222, 28);
            this.checkbox_QueryExpansion.TabIndex = 8;
            this.checkbox_QueryExpansion.Text = "Query Expansion";
            this.checkbox_QueryExpansion.UseVisualStyleBackColor = true;
            // 
            // form_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1714, 1422);
            this.Controls.Add(this.checkbox_QueryExpansion);
            this.Controls.Add(this.lbl_SearchingTime_and_NumOfResults);
            this.Controls.Add(this.groupBox_SearchingOption);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.lbl_FinalQuery);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txtbox_SearchingQuery);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "form_Search";
            this.Text = "Custom_EduQuiz Question Answering System---Search";
            this.groupBox_SearchingOption.ResumeLayout(false);
            this.groupBox_SearchingOption.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox_SearchingQuery;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label lbl_FinalQuery;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox_SearchingOption;
        private System.Windows.Forms.RadioButton radio_AsItIs;
        private System.Windows.Forms.RadioButton radio_MultiTerm;
        private System.Windows.Forms.Label lbl_SearchingTime_and_NumOfResults;
        private System.Windows.Forms.CheckBox checkbox_QueryExpansion;
    }
}