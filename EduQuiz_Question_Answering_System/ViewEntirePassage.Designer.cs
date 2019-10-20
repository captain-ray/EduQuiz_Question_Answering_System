namespace EduQuiz_Question_Answering_System
{
    partial class form_ViewEntirePassage
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
            this.lbl_PassageText = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_PassageText
            // 
            this.lbl_PassageText.Location = new System.Drawing.Point(64, 164);
            this.lbl_PassageText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PassageText.Name = "lbl_PassageText";
            this.lbl_PassageText.Size = new System.Drawing.Size(1200, 401);
            this.lbl_PassageText.TabIndex = 0;
            this.lbl_PassageText.Text = "PassageText";
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(68, 54);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(156, 44);
            this.btn_Back.TabIndex = 1;
            this.btn_Back.Text = "BACK";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // form_ViewEntirePassage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 783);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.lbl_PassageText);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "form_ViewEntirePassage";
            this.Text = "Custom_EduQuiz Question Answering System---ViewEntirePassage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_ViewEntirePassage_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_PassageText;
        private System.Windows.Forms.Button btn_Back;
    }
}