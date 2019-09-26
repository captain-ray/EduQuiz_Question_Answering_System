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
            this.lbl_PassageText.Location = new System.Drawing.Point(65, 164);
            this.lbl_PassageText.Name = "lbl_PassageText";
            this.lbl_PassageText.Size = new System.Drawing.Size(1200, 400);
            this.lbl_PassageText.TabIndex = 0;
            this.lbl_PassageText.Text = "PassageText";
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(69, 54);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(155, 45);
            this.btn_Back.TabIndex = 1;
            this.btn_Back.Text = "BACK";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // form_ViewEntirePassage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 782);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.lbl_PassageText);
            this.Name = "form_ViewEntirePassage";
            this.Text = "EduQuiz Question Answering System---ViewEntirePassage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_ViewEntirePassage_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_PassageText;
        private System.Windows.Forms.Button btn_Back;
    }
}