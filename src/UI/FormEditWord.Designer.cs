using System;
using System.Windows.Forms;

namespace DictionaryUI
{
    partial class FormEditWord
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtWord;
        private TextBox txtDefinition;
        private TextBox txtDescription;
        private TextBox txtExample;
        private TextBox txtSynonyms;
        private TextBox txtAntonyms;
        private TextBox txtAntAntonyms; // keep name matching usage in code
        private Button btnSave;
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
            this.txtAntAntonyms = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // txtWord
            this.txtWord.Location = new System.Drawing.Point(20, 20);
            this.txtWord.Size = new System.Drawing.Size(400, 26);

            // txtDefinition
            this.txtDefinition.Location = new System.Drawing.Point(20, 60);
            this.txtDefinition.Size = new System.Drawing.Size(400, 26);

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(20, 100);
            this.txtDescription.Size = new System.Drawing.Size(400, 26);

            // txtExample
            this.txtExample.Location = new System.Drawing.Point(20, 140);
            this.txtExample.Size = new System.Drawing.Size(400, 26);

            // txtSynonyms
            this.txtSynonyms.Location = new System.Drawing.Point(20, 180);
            this.txtSynonyms.Size = new System.Drawing.Size(400, 26);

            // txtAntonyms
            this.txtAntonyms.Location = new System.Drawing.Point(20, 220);
            this.txtAntonyms.Size = new System.Drawing.Size(400, 26);

            // txtAntAntonyms (alias kept for code compatibility)
            this.txtAntAntonyms.Location = new System.Drawing.Point(20, 260);
            this.txtAntAntonyms.Size = new System.Drawing.Size(400, 26);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(20, 260);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(140, 260);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            // FormEditWord
            this.ClientSize = new System.Drawing.Size(460, 320);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAntAntonyms);
            this.Controls.Add(this.txtAntonyms);
            this.Controls.Add(this.txtSynonyms);
            this.Controls.Add(this.txtExample);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtDefinition);
            this.Controls.Add(this.txtWord);
            this.Text = "Chỉnh sửa từ";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
