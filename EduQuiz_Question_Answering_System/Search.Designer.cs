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
            this.lbl_Results = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbox_SearchingQuery
            // 
            this.txtbox_SearchingQuery.Location = new System.Drawing.Point(329, 276);
            this.txtbox_SearchingQuery.Name = "txtbox_SearchingQuery";
            this.txtbox_SearchingQuery.Size = new System.Drawing.Size(1066, 35);
            this.txtbox_SearchingQuery.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(781, 346);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(197, 65);
            this.btn_Search.TabIndex = 1;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // lbl_FinalQuery
            // 
            this.lbl_FinalQuery.AutoSize = true;
            this.lbl_FinalQuery.Location = new System.Drawing.Point(649, 474);
            this.lbl_FinalQuery.Name = "lbl_FinalQuery";
            this.lbl_FinalQuery.Size = new System.Drawing.Size(154, 24);
            this.lbl_FinalQuery.TabIndex = 2;
            this.lbl_FinalQuery.Text = "Final Query:";
            // 
            // lbl_Results
            // 
            this.lbl_Results.AutoSize = true;
            this.lbl_Results.Location = new System.Drawing.Point(209, 612);
            this.lbl_Results.Name = "lbl_Results";
            this.lbl_Results.Size = new System.Drawing.Size(106, 24);
            this.lbl_Results.TabIndex = 3;
            this.lbl_Results.Text = "Results:";
            // 
            // form_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1716, 1102);
            this.Controls.Add(this.lbl_Results);
            this.Controls.Add(this.lbl_FinalQuery);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txtbox_SearchingQuery);
            this.Name = "form_Search";
            this.Text = "EduQuiz Question Answering System---Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox_SearchingQuery;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label lbl_FinalQuery;
        private System.Windows.Forms.Label lbl_Results;
    }
}