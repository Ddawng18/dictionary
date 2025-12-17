using System;
using System.Windows.Forms;

namespace DictionaryUI
{
    partial class FormAddWord
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtWord;
        private TextBox txtDefinition;
        private TextBox txtDescription;
        private TextBox txtExample;
        private TextBox txtSynonyms;
        private TextBox txtAntonyms;
        private Button btnAdd;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtWord = new System.Windows.Forms.TextBox();
            this.txtDefinition = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtExample = new System.Windows.Forms.TextBox();
            this.txtSynonyms = new System.Windows.Forms.TextBox();
            this.txtAntonyms = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // txtWord
            this.txtWord.Location = new System.Drawing.Point(20, 20);
            this.txtWord.Size = new System.Drawing.Size(400, 26);
            this.txtWord.PlaceholderText = "Word";

            // txtDefinition
            this.txtDefinition.Location = new System.Drawing.Point(20, 60);
            this.txtDefinition.Size = new System.Drawing.Size(400, 26);
            this.txtDefinition.PlaceholderText = "Definition";

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(20, 100);
            this.txtDescription.Size = new System.Drawing.Size(400, 26);
            this.txtDescription.PlaceholderText = "Description";

            // txtExample
            this.txtExample.Location = new System.Drawing.Point(20, 140);
            this.txtExample.Size = new System.Drawing.Size(400, 26);
            this.txtExample.PlaceholderText = "Example";

            // txtSynonyms
            this.txtSynonyms.Location = new System.Drawing.Point(20, 180);
            this.txtSynonyms.Size = new System.Drawing.Size(400, 26);
            this.txtSynonyms.PlaceholderText = "Synonyms (comma separated)";

            // txtAntonyms
            this.txtAntonyms.Location = new System.Drawing.Point(20, 220);
            this.txtAntonyms.Size = new System.Drawing.Size(400, 26);
            this.txtAntonyms.PlaceholderText = "Antonyms (comma separated)";

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(20, 260);
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(140, 260);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // FormAddWord
            this.ClientSize = new System.Drawing.Size(460, 320);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtAntonyms);
            this.Controls.Add(this.txtSynonyms);
            this.Controls.Add(this.txtExample);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtDefinition);
            this.Controls.Add(this.txtWord);
            this.Text = "Thêm từ mới";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
