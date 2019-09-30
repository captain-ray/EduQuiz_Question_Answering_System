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
            this.SuspendLayout();
            // 
            // txtbox_SearchingQuery
            // 
            this.txtbox_SearchingQuery.Location = new System.Drawing.Point(160, 148);
            this.txtbox_SearchingQuery.Margin = new System.Windows.Forms.Padding(2);
            this.txtbox_SearchingQuery.Name = "txtbox_SearchingQuery";
            this.txtbox_SearchingQuery.Size = new System.Drawing.Size(535, 20);
            this.txtbox_SearchingQuery.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(390, 187);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(98, 35);
            this.btn_Search.TabIndex = 1;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // lbl_FinalQuery
            // 
            this.lbl_FinalQuery.AutoSize = true;
            this.lbl_FinalQuery.Location = new System.Drawing.Point(326, 243);
            this.lbl_FinalQuery.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FinalQuery.Name = "lbl_FinalQuery";
            this.lbl_FinalQuery.Size = new System.Drawing.Size(63, 13);
            this.lbl_FinalQuery.TabIndex = 2;
            this.lbl_FinalQuery.Text = "Final Query:";
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(62, 27);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(62, 29);
            this.btn_Back.TabIndex = 3;
            this.btn_Back.Text = "BACK";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(535, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save result";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // form_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(857, 770);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.lbl_FinalQuery);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txtbox_SearchingQuery);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button button2;
    }
}