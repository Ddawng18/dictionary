namespace DictionaryUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // single fixed form (no split)
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox listWords;
        private System.Windows.Forms.Label lblTitle; // "Từ:"
        private System.Windows.Forms.Label lblMeaningHeading;
        private System.Windows.Forms.Label lblExamplesHeading;
        private System.Windows.Forms.Label lblSynonymsHeading;
        private System.Windows.Forms.Label lblAntonymsHeading;

        private System.Windows.Forms.Label lblWordDetail;
        private System.Windows.Forms.TextBox lblDefinition;
        private System.Windows.Forms.TextBox lblDescription;
        private System.Windows.Forms.TextBox lblExample;
        private System.Windows.Forms.TextBox lblSynonyms;
        private System.Windows.Forms.TextBox lblAntonyms;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.PictureBox pbFavorite;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // private void InitializeComponent()
        // {
        //     this.splitContainerMain = new System.Windows.Forms.SplitContainer();
        //     this.txtSearch = new System.Windows.Forms.TextBox();
        //     this.btnSearch = new System.Windows.Forms.Button();
        //     this.listWords = new System.Windows.Forms.ListBox();

        //     // (controls for right panel are created below with the expected names)

        //     this.btnAdd = new System.Windows.Forms.Button();
        //     this.btnDelete = new System.Windows.Forms.Button();
        //     this.btnEdit = new System.Windows.Forms.Button();
        //     this.pbFavorite = new System.Windows.Forms.PictureBox();

        //     ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
        //     this.splitContainerMain.Panel1.SuspendLayout();
        //     this.splitContainerMain.Panel2.SuspendLayout();
        //     this.splitContainerMain.SuspendLayout();
        //     ((System.ComponentModel.ISupportInitialize)(this.pbFavorite)).BeginInit();
        //     this.SuspendLayout();

        //     // splitContainerMain
        //     this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
        //     this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
        //     this.splitContainerMain.Name = "splitContainerMain";
        //     // left column width
        //     this.splitContainerMain.SplitterDistance = 40;

        //     // Panel1 (left) - search + list
        //     this.splitContainerMain.Panel1.Controls.Add(this.btnSearch);
        //     this.splitContainerMain.Panel1.Controls.Add(this.txtSearch);
        //     this.splitContainerMain.Panel1.Controls.Add(this.listWords);

        //     // Panel2 (right) - meaning, example, synonyms, antonyms
        //     this.splitContainerMain.Panel2.Controls.Add(this.pbFavorite);
        //     this.splitContainerMain.Panel2.Controls.Add(this.btnEdit);
        //     this.splitContainerMain.Panel2.Controls.Add(this.btnDelete);
        //     this.splitContainerMain.Panel2.Controls.Add(this.btnAdd);

        //     // Right panel background
        //     this.splitContainerMain.Panel2.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        //     this.splitContainerMain.Panel2.AutoScroll = true;

        //     int rightX = 15;
        //     int boxWidth = 530;

        //     // Top action buttons (anchored to top-right)
        //     this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        //     this.btnAdd.Location = new System.Drawing.Point(450, 12);
        //     this.btnAdd.Size = new System.Drawing.Size(35, 30);
        //     this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

        //     this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        //     this.btnDelete.Location = new System.Drawing.Point(490, 12);
        //     this.btnDelete.Size = new System.Drawing.Size(35, 30);
        //     this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

        //     this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        //     this.btnEdit.Location = new System.Drawing.Point(530, 12);
        //     this.btnEdit.Size = new System.Drawing.Size(35, 30);
        //     this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

        //     this.pbFavorite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        //     this.pbFavorite.Location = new System.Drawing.Point(570, 12);
        //     this.pbFavorite.Size = new System.Drawing.Size(28, 28);
        //     this.pbFavorite.Click += new System.EventHandler(this.pbFavorite_Click);

        //     // Word title (label)
        //     this.lblWordDetail = new System.Windows.Forms.Label();
        //     this.lblWordDetail.AutoSize = false;
        //     this.lblWordDetail.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
        //     this.lblWordDetail.Location = new System.Drawing.Point(rightX, 12);
        //     this.lblWordDetail.Size = new System.Drawing.Size(400, 50);
        //     this.lblWordDetail.Text = "";
        //     this.lblWordDetail.ForeColor = System.Drawing.Color.Black;
        //     this.splitContainerMain.Panel2.Controls.Add(this.lblWordDetail);

        //     // "Meaning:" label
        //     var lblMeaningTitle = new System.Windows.Forms.Label();
        //     lblMeaningTitle.AutoSize = true;
        //     lblMeaningTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Italic);
        //     lblMeaningTitle.Location = new System.Drawing.Point(rightX, 68);
        //     lblMeaningTitle.Text = "Meaning:";
        //     this.splitContainerMain.Panel2.Controls.Add(lblMeaningTitle);

        //     // Definition + Description combined (multiline textbox)
        //     this.lblDefinition = new System.Windows.Forms.TextBox();
        //     this.lblDefinition.Location = new System.Drawing.Point(rightX, 95);
        //     this.lblDefinition.Multiline = true;
        //     this.lblDefinition.ReadOnly = true;
        //     this.lblDefinition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        //     this.lblDefinition.Size = new System.Drawing.Size(boxWidth, 85);
        //     this.lblDefinition.BackColor = System.Drawing.Color.White;
        //     this.lblDefinition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //     this.splitContainerMain.Panel2.Controls.Add(this.lblDefinition);

        //     // Description field (kept for code compatibility, hidden)
        //     this.lblDescription = new System.Windows.Forms.TextBox();
        //     this.lblDescription.Visible = false;
        //     this.splitContainerMain.Panel2.Controls.Add(this.lblDescription);

        //     // "Examples:" label
        //     var lblExampleTitle = new System.Windows.Forms.Label();
        //     lblExampleTitle.AutoSize = true;
        //     lblExampleTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Italic);
        //     lblExampleTitle.Location = new System.Drawing.Point(rightX, 190);
        //     lblExampleTitle.Text = "Examples:";
        //     this.splitContainerMain.Panel2.Controls.Add(lblExampleTitle);

        //     // Examples (multiline)
        //     this.lblExample = new System.Windows.Forms.TextBox();
        //     this.lblExample.Location = new System.Drawing.Point(rightX, 215);
        //     this.lblExample.Multiline = true;
        //     this.lblExample.ReadOnly = true;
        //     this.lblExample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        //     this.lblExample.Size = new System.Drawing.Size(boxWidth, 100);
        //     this.lblExample.BackColor = System.Drawing.Color.White;
        //     this.lblExample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //     this.splitContainerMain.Panel2.Controls.Add(this.lblExample);

        //     // "Synonyms:" label
        //     var labelSynText = new System.Windows.Forms.Label();
        //     labelSynText.AutoSize = true;
        //     labelSynText.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Italic);
        //     labelSynText.Location = new System.Drawing.Point(rightX, 330);
        //     labelSynText.Text = "Synonyms:";
        //     this.splitContainerMain.Panel2.Controls.Add(labelSynText);

        //     // Synonyms (multiline, beige background)
        //     this.lblSynonyms = new System.Windows.Forms.TextBox();
        //     this.lblSynonyms.Location = new System.Drawing.Point(rightX, 355);
        //     this.lblSynonyms.Multiline = true;
        //     this.lblSynonyms.ReadOnly = true;
        //     this.lblSynonyms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        //     this.lblSynonyms.Size = new System.Drawing.Size(boxWidth, 80);
        //     this.lblSynonyms.BackColor = System.Drawing.Color.FromArgb(255, 250, 200); // beige
        //     this.lblSynonyms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //     this.splitContainerMain.Panel2.Controls.Add(this.lblSynonyms);

        //     // "Antonyms:" label
        //     var labelAntText = new System.Windows.Forms.Label();
        //     labelAntText.AutoSize = true;
        //     labelAntText.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Italic);
        //     labelAntText.Location = new System.Drawing.Point(rightX, 445);
        //     labelAntText.Text = "Antonyms:";
        //     this.splitContainerMain.Panel2.Controls.Add(labelAntText);

        //     // Antonyms (multiline)
        //     this.lblAntonyms = new System.Windows.Forms.TextBox();
        //     this.lblAntonyms.Location = new System.Drawing.Point(rightX, 470);
        //     this.lblAntonyms.Multiline = true;
        //     this.lblAntonyms.ReadOnly = true;
        //     this.lblAntonyms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        //     this.lblAntonyms.Size = new System.Drawing.Size(boxWidth, 80);
        //     this.lblAntonyms.BackColor = System.Drawing.Color.White;
        //     this.lblAntonyms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //     this.splitContainerMain.Panel2.Controls.Add(this.lblAntonyms);

        //     // Left - txtSearch
        //     this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        //     | System.Windows.Forms.AnchorStyles.Right)));
        //     this.txtSearch.Location = new System.Drawing.Point(12, 12);
        //     this.txtSearch.Name = "txtSearch";
        //     this.txtSearch.Size = new System.Drawing.Size(220, 26);
        //     this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

        //     // Left - btnSearch (magnifier)
        //     this.btnSearch.Location = new System.Drawing.Point(240, 10);
        //     this.btnSearch.Name = "btnSearch";
        //     this.btnSearch.Size = new System.Drawing.Size(40, 28);
        //     this.btnSearch.Text = "🔍";
        //     this.btnSearch.Click += (s, e) => { /* optional: focus or trigger search */ };

        //     // Left - listWords
        //     this.listWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        //     | System.Windows.Forms.AnchorStyles.Left)
        //     | System.Windows.Forms.AnchorStyles.Right)));
        //     this.listWords.Location = new System.Drawing.Point(12, 48);
        //     this.listWords.Name = "listWords";
        //     this.listWords.Size = new System.Drawing.Size(280, 540);
        //     this.listWords.SelectedIndexChanged += new System.EventHandler(this.listWords_SelectedIndexChanged);

        //     // Form1
        //     this.ClientSize = new System.Drawing.Size(900, 600);
        //     this.Controls.Add(this.splitContainerMain);
        //     this.Text = "Dictionary";

        //     this.splitContainerMain.Panel1.ResumeLayout(false);
        //     this.splitContainerMain.Panel1.PerformLayout();
        //     this.splitContainerMain.Panel2.ResumeLayout(false);
        //     this.splitContainerMain.Panel2.PerformLayout();
        //     ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
        //     ((System.ComponentModel.ISupportInitialize)(this.pbFavorite)).EndInit();
        //     this.splitContainerMain.ResumeLayout(false);
        //     this.ResumeLayout(false);
        // }
        private void InitializeComponent()
        {
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.listWords = new ListBox();
            this.lblWordDetail = new Label();
            this.lblDefinition = new TextBox();
            this.lblDescription = new TextBox();
            this.lblExample = new TextBox();
            this.lblSynonyms = new TextBox();
            this.lblAntonyms = new TextBox();
            this.btnAdd = new Button();
            this.btnDelete = new Button();
            this.btnEdit = new Button();
            this.pbFavorite = new PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.pbFavorite)).BeginInit();
            this.SuspendLayout();

            // FORM PROPERTIES
            this.ClientSize = new Size(1000, 800);
            this.MinimumSize = new Size(1000, 800);
            this.MaximumSize = new Size(1000, 800);
            this.Text = "Dictionary";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // FIXED MARGINS & SPACING
            const int margin = 20;
            const int labelHeight = 22;
            const int boxGap = 24;
            const int leftColWidth = 260;

            // === LEFT COLUMN: SEARCH + LIST ===
            this.lblTitle = new Label();
            this.lblTitle.Text = "Từ:";
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.Location = new Point(margin, margin);
            this.lblTitle.Size = new Size(100, labelHeight);

            this.txtSearch.Location = new Point(margin, margin + labelHeight + 6);
            this.txtSearch.Size = new Size(leftColWidth - 56 - margin, 28);
            this.txtSearch.Font = new Font("Segoe UI", 12F);
            this.txtSearch.BorderStyle = BorderStyle.FixedSingle;
            this.txtSearch.TextChanged += txtSearch_TextChanged;
            this.txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.btnSearch.Location = new Point(leftColWidth - 48, margin + labelHeight + 6);
            this.btnSearch.Size = new Size(44, 28);
            this.btnSearch.Text = "🔍";
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.BackColor = Color.FromArgb(30, 144, 255);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.Font = new Font("Segoe UI", 12F);
            this.btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnSearch.Cursor = Cursors.Hand;

            this.listWords.Location = new Point(margin, margin + labelHeight + 6 + 28 + 12);
            this.listWords.Size = new Size(leftColWidth - margin * 2, 692);
            this.listWords.Font = new Font("Segoe UI", 11F);
            this.listWords.BackColor = Color.White;
            this.listWords.BorderStyle = BorderStyle.FixedSingle;
            this.listWords.SelectedIndexChanged += listWords_SelectedIndexChanged;
            this.listWords.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

            // === RIGHT COLUMN: CONTENT ===
            int rightX = leftColWidth;
            int rightAvailWidth = this.ClientSize.Width - rightX - margin;

            // Word title
            this.lblWordDetail.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblWordDetail.Location = new Point(rightX + 8, margin + 8);
            this.lblWordDetail.Size = new Size(rightAvailWidth - 200, 40);
            this.lblWordDetail.ForeColor = Color.FromArgb(20, 20, 20);
            this.lblWordDetail.AutoEllipsis = true;
            this.lblWordDetail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Action buttons (top right)
            int btnY = margin + 8;
            this.btnAdd.Location = new Point(this.ClientSize.Width - margin - 140, btnY);
            this.btnAdd.Size = new Size(32, 32);
            this.btnAdd.Text = "+";
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.BackColor = Color.FromArgb(60, 179, 113);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnAdd.Cursor = Cursors.Hand;
            this.btnAdd.Click += btnAdd_Click;
            this.btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.btnDelete.Location = new Point(this.ClientSize.Width - margin - 104, btnY);
            this.btnDelete.Size = new Size(32, 32);
            this.btnDelete.Text = "−";
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.BackColor = Color.FromArgb(220, 20, 60);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.btnDelete.Cursor = Cursors.Hand;
            this.btnDelete.Click += btnDelete_Click;
            this.btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.btnEdit.Location = new Point(this.ClientSize.Width - margin - 68, btnY);
            this.btnEdit.Size = new Size(32, 32);
            this.btnEdit.Text = "✎";
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.BackColor = Color.FromArgb(255, 165, 0);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnEdit.Cursor = Cursors.Hand;
            this.btnEdit.Click += btnEdit_Click;
            this.btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.pbFavorite.Location = new Point(this.ClientSize.Width - margin - 32, btnY);
            this.pbFavorite.Size = new Size(32, 32);
            this.pbFavorite.BackColor = Color.Transparent;
            this.pbFavorite.Cursor = Cursors.Hand;
            this.pbFavorite.Click += pbFavorite_Click;
            this.pbFavorite.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // === CONTENT BOXES ===
            int boxX = rightX + 8;
            int boxWidth = rightAvailWidth - 16;
            int contentY = margin + 60;

            // Meaning heading & box
            this.lblMeaningHeading = new Label();
            this.lblMeaningHeading.Text = "Meaning:";
            this.lblMeaningHeading.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblMeaningHeading.Location = new Point(boxX, contentY);
            this.lblMeaningHeading.Size = new Size(boxWidth, labelHeight);
            this.lblMeaningHeading.ForeColor = Color.FromArgb(40, 40, 40);
            this.lblMeaningHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.lblDefinition.Location = new Point(boxX, contentY + labelHeight + 6);
            this.lblDefinition.Size = new Size(boxWidth, 160);
            this.lblDefinition.Multiline = true;
            this.lblDefinition.ReadOnly = true;
            this.lblDefinition.ScrollBars = ScrollBars.Vertical;
            this.lblDefinition.BackColor = Color.White;
            this.lblDefinition.BorderStyle = BorderStyle.FixedSingle;
            this.lblDefinition.Font = new Font("Segoe UI", 10F);
            this.lblDefinition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Examples heading & box
            contentY += labelHeight + 6 + 160 + boxGap;
            this.lblExamplesHeading = new Label();
            this.lblExamplesHeading.Text = "Examples:";
            this.lblExamplesHeading.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblExamplesHeading.Location = new Point(boxX, contentY);
            this.lblExamplesHeading.Size = new Size(boxWidth, labelHeight);
            this.lblExamplesHeading.ForeColor = Color.FromArgb(40, 40, 40);
            this.lblExamplesHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.lblExample.Location = new Point(boxX, contentY + labelHeight + 6);
            this.lblExample.Size = new Size(boxWidth, 180);
            this.lblExample.Multiline = true;
            this.lblExample.ReadOnly = true;
            this.lblExample.ScrollBars = ScrollBars.Vertical;
            this.lblExample.BackColor = Color.White;
            this.lblExample.BorderStyle = BorderStyle.FixedSingle;
            this.lblExample.Font = new Font("Segoe UI", 10F);
            this.lblExample.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Synonyms/Antonyms: use TableLayoutPanel to ensure exact widths and spacing
            contentY += labelHeight + 6 + 180 + boxGap;

            var tableSynAnt = new TableLayoutPanel();
            tableSynAnt.Location = new Point(boxX, contentY);
            tableSynAnt.Size = new Size(boxWidth, labelHeight + 2 + 160);
            tableSynAnt.ColumnCount = 2;
            tableSynAnt.RowCount = 2;
            tableSynAnt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableSynAnt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableSynAnt.RowStyles.Add(new RowStyle(SizeType.Absolute, labelHeight));
            tableSynAnt.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableSynAnt.BackColor = Color.Transparent;
            tableSynAnt.Padding = new Padding(0);
            tableSynAnt.Margin = new Padding(0);
            tableSynAnt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableSynAnt.MinimumSize = new Size(0, labelHeight + 2 + 140);

            // Headings
            this.lblSynonymsHeading = new Label();
            this.lblSynonymsHeading.Text = "Synonyms:";
            this.lblSynonymsHeading.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblSynonymsHeading.ForeColor = Color.FromArgb(40, 40, 40);
            this.lblSynonymsHeading.Dock = DockStyle.Fill;
            this.lblSynonymsHeading.TextAlign = ContentAlignment.MiddleLeft;

            this.lblAntonymsHeading = new Label();
            this.lblAntonymsHeading.Text = "Antonyms:";
            this.lblAntonymsHeading.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblAntonymsHeading.ForeColor = Color.FromArgb(40, 40, 40);
            this.lblAntonymsHeading.Dock = DockStyle.Fill;
            this.lblAntonymsHeading.TextAlign = ContentAlignment.MiddleLeft;

            // Boxes
            this.lblSynonyms = new TextBox();
            this.lblSynonyms.Multiline = true;
            this.lblSynonyms.ReadOnly = true;
            this.lblSynonyms.ScrollBars = ScrollBars.Vertical;
            this.lblSynonyms.BackColor = Color.White;
            this.lblSynonyms.BorderStyle = BorderStyle.FixedSingle;
            this.lblSynonyms.Font = new Font("Segoe UI", 11F);
            this.lblSynonyms.Dock = DockStyle.Fill;
            this.lblSynonyms.Margin = new Padding(10, 4, 10, 10);

            this.lblAntonyms = new TextBox();
            this.lblAntonyms.Multiline = true;
            this.lblAntonyms.ReadOnly = true;
            this.lblAntonyms.ScrollBars = ScrollBars.Vertical;
            this.lblAntonyms.BackColor = Color.White;
            this.lblAntonyms.BorderStyle = BorderStyle.FixedSingle;
            this.lblAntonyms.Font = new Font("Segoe UI", 11F);
            this.lblAntonyms.Dock = DockStyle.Fill;
            this.lblAntonyms.Margin = new Padding(10, 4, 10, 10);

            tableSynAnt.Controls.Add(this.lblSynonymsHeading, 0, 0);
            tableSynAnt.Controls.Add(this.lblAntonymsHeading, 1, 0);
            tableSynAnt.Controls.Add(this.lblSynonyms, 0, 1);
            tableSynAnt.Controls.Add(this.lblAntonyms, 1, 1);

            this.Controls.Add(tableSynAnt);

            // Add all controls
            this.Controls.AddRange(new Control[] {
                this.lblTitle, this.txtSearch, this.btnSearch, this.listWords,
                this.lblWordDetail, this.btnAdd, this.btnDelete, this.btnEdit, this.pbFavorite,
                this.lblMeaningHeading, this.lblDefinition,
                this.lblExamplesHeading, this.lblExample
            });

            ((System.ComponentModel.ISupportInitialize)(this.pbFavorite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}