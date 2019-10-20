namespace EduQuiz_Question_Answering_System
{
    partial class form_Index
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
            this.lbl_CollectionPath = new System.Windows.Forms.Label();
            this.lbl_IndexPath = new System.Windows.Forms.Label();
            this.txtbox_FilePath = new System.Windows.Forms.TextBox();
            this.btn_OpenLocalFile = new System.Windows.Forms.Button();
            this.txtbox_FolderPath = new System.Windows.Forms.TextBox();
            this.btn_OpenLocalFolder = new System.Windows.Forms.Button();
            this.btn_CreateIndex = new System.Windows.Forms.Button();
            this.lbl_IndexTime = new System.Windows.Forms.Label();
            this.btn_GoToSearchPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_CollectionPath
            // 
            this.lbl_CollectionPath.AutoSize = true;
            this.lbl_CollectionPath.Location = new System.Drawing.Point(105, 145);
            this.lbl_CollectionPath.Name = "lbl_CollectionPath";
            this.lbl_CollectionPath.Size = new System.Drawing.Size(190, 24);
            this.lbl_CollectionPath.TabIndex = 0;
            this.lbl_CollectionPath.Text = "Collection Path";
            // 
            // lbl_IndexPath
            // 
            this.lbl_IndexPath.AutoSize = true;
            this.lbl_IndexPath.Location = new System.Drawing.Point(131, 236);
            this.lbl_IndexPath.Name = "lbl_IndexPath";
            this.lbl_IndexPath.Size = new System.Drawing.Size(130, 24);
            this.lbl_IndexPath.TabIndex = 1;
            this.lbl_IndexPath.Text = "Index Path";
            // 
            // txtbox_FilePath
            // 
            this.txtbox_FilePath.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtbox_FilePath.Location = new System.Drawing.Point(333, 142);
            this.txtbox_FilePath.Name = "txtbox_FilePath";
            this.txtbox_FilePath.Size = new System.Drawing.Size(410, 35);
            this.txtbox_FilePath.TabIndex = 2;
            this.txtbox_FilePath.Text = "Insert local file path";
            // 
            // btn_OpenLocalFile
            // 
            this.btn_OpenLocalFile.Location = new System.Drawing.Point(791, 127);
            this.btn_OpenLocalFile.Name = "btn_OpenLocalFile";
            this.btn_OpenLocalFile.Size = new System.Drawing.Size(232, 60);
            this.btn_OpenLocalFile.TabIndex = 3;
            this.btn_OpenLocalFile.Text = "Open Local File";
            this.btn_OpenLocalFile.UseVisualStyleBackColor = true;
            this.btn_OpenLocalFile.Click += new System.EventHandler(this.btn_OpenLocalFile_Click);
            // 
            // txtbox_FolderPath
            // 
            this.txtbox_FolderPath.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtbox_FolderPath.Location = new System.Drawing.Point(333, 233);
            this.txtbox_FolderPath.Name = "txtbox_FolderPath";
            this.txtbox_FolderPath.Size = new System.Drawing.Size(410, 35);
            this.txtbox_FolderPath.TabIndex = 4;
            this.txtbox_FolderPath.Text = "Insert local folder path";
            // 
            // btn_OpenLocalFolder
            // 
            this.btn_OpenLocalFolder.Location = new System.Drawing.Point(791, 223);
            this.btn_OpenLocalFolder.Name = "btn_OpenLocalFolder";
            this.btn_OpenLocalFolder.Size = new System.Drawing.Size(232, 58);
            this.btn_OpenLocalFolder.TabIndex = 5;
            this.btn_OpenLocalFolder.Text = "Open Local Folder";
            this.btn_OpenLocalFolder.UseVisualStyleBackColor = true;
            this.btn_OpenLocalFolder.Click += new System.EventHandler(this.btn_OpenLocalFolder_Click);
            // 
            // btn_CreateIndex
            // 
            this.btn_CreateIndex.Location = new System.Drawing.Point(435, 386);
            this.btn_CreateIndex.Name = "btn_CreateIndex";
            this.btn_CreateIndex.Size = new System.Drawing.Size(263, 63);
            this.btn_CreateIndex.TabIndex = 6;
            this.btn_CreateIndex.Text = "Create Index";
            this.btn_CreateIndex.UseVisualStyleBackColor = true;
            this.btn_CreateIndex.Click += new System.EventHandler(this.btn_CreateIndex_Click);
            // 
            // lbl_IndexTime
            // 
            this.lbl_IndexTime.AutoSize = true;
            this.lbl_IndexTime.Location = new System.Drawing.Point(329, 508);
            this.lbl_IndexTime.Name = "lbl_IndexTime";
            this.lbl_IndexTime.Size = new System.Drawing.Size(142, 24);
            this.lbl_IndexTime.TabIndex = 7;
            this.lbl_IndexTime.Text = "Index Time:";
            // 
            // btn_GoToSearchPage
            // 
            this.btn_GoToSearchPage.Location = new System.Drawing.Point(471, 554);
            this.btn_GoToSearchPage.Name = "btn_GoToSearchPage";
            this.btn_GoToSearchPage.Size = new System.Drawing.Size(189, 51);
            this.btn_GoToSearchPage.TabIndex = 8;
            this.btn_GoToSearchPage.Text = "Go Searching";
            this.btn_GoToSearchPage.UseVisualStyleBackColor = true;
            this.btn_GoToSearchPage.Click += new System.EventHandler(this.btn_GoToSearchPage_Click);
            // 
            // form_Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 1268);
            this.Controls.Add(this.btn_GoToSearchPage);
            this.Controls.Add(this.lbl_IndexTime);
            this.Controls.Add(this.btn_CreateIndex);
            this.Controls.Add(this.btn_OpenLocalFolder);
            this.Controls.Add(this.txtbox_FolderPath);
            this.Controls.Add(this.btn_OpenLocalFile);
            this.Controls.Add(this.txtbox_FilePath);
            this.Controls.Add(this.lbl_IndexPath);
            this.Controls.Add(this.lbl_CollectionPath);
            this.Name = "form_Index";
            this.Text = "Custom_EduQuiz Question Answering System---Index";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_CollectionPath;
        private System.Windows.Forms.Label lbl_IndexPath;
        private System.Windows.Forms.TextBox txtbox_FilePath;
        private System.Windows.Forms.Button btn_OpenLocalFile;
        private System.Windows.Forms.TextBox txtbox_FolderPath;
        private System.Windows.Forms.Button btn_OpenLocalFolder;
        private System.Windows.Forms.Button btn_CreateIndex;
        private System.Windows.Forms.Label lbl_IndexTime;
        private System.Windows.Forms.Button btn_GoToSearchPage;
    }
}

