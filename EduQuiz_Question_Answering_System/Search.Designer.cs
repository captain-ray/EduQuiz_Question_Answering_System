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
            this.SuspendLayout();
            // 
            // txtbox_SearchingQuery
            // 
            this.txtbox_SearchingQuery.Location = new System.Drawing.Point(321, 274);
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
            this.lbl_FinalQuery.Location = new System.Drawing.Point(651, 448);
            this.lbl_FinalQuery.Name = "lbl_FinalQuery";
            this.lbl_FinalQuery.Size = new System.Drawing.Size(154, 24);
            this.lbl_FinalQuery.TabIndex = 2;
            this.lbl_FinalQuery.Text = "Final Query:";
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(125, 50);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(123, 53);
            this.btn_Back.TabIndex = 3;
            this.btn_Back.Text = "BACK";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // form_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1714, 1429);
            this.Controls.Add(this.btn_Back);
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
        private System.Windows.Forms.Button btn_Back;
    }
}