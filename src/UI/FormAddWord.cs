using System;
using System.Windows.Forms;
using System.IO;
using Dictionary.Services;

namespace DictionaryUI
{
    // Cần tạo Form này trong VS
    public partial class FormAddWord : Form
    {
        private readonly string DATA_PATH;
        private readonly string SYNANT_PATH;
        public FormAddWord()
        {
            InitializeComponent();
            this.Text = "Thêm Từ Mới";

            var baseDir = AppContext.BaseDirectory;
            var dataDir = Path.Combine(baseDir, "Data");
            DATA_PATH = Path.Combine(dataDir, "MeaningWordData.txt");
            SYNANT_PATH = Path.Combine(dataDir, "SynAntWordData.txt");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string word = txtWord.Text.Trim();
            string def = txtDefinition.Text.Trim();
            string desc = txtDescription.Text.Trim();
            string ex = txtExample.Text.Trim();
            string syns = txtSynonyms.Text.Trim();
            string ants = txtAntonyms.Text.Trim();

            if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(def))
            {
                MessageBox.Show("Vui lòng nhập Từ và Nghĩa.", "Lỗi");
                return;
            }

            // 1. Thêm từ vào file chính và cập nhật dictionary trong bộ nhớ
            string result = DictionaryService.AddToFile(DATA_PATH, word, def, desc, ex);
            
            if (result.Contains("exists"))
            {
                MessageBox.Show($"{word} đã tồn tại trong từ điển.", "Lỗi");
                return;
            }

            // 2. Thêm Từ đồng nghĩa (nếu có)
            if (!string.IsNullOrEmpty(syns))
            {
                string[] synList = syns.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var syn in synList)
                {
                    SynAntDictionary.AddSyn(SYNANT_PATH, word, syn.Trim());
                }
            }

            // 3. Thêm Từ trái nghĩa (nếu có)
            if (!string.IsNullOrEmpty(ants))
            {
                string[] antList = ants.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var ant in antList)
                {
                    SynAntDictionary.AddAnt(SYNANT_PATH, word, ant.Trim());
                }
            }
            
            // 4. Sắp xếp lại file chính 
            DictionaryService.SortFile(DATA_PATH); 

            MessageBox.Show($"Thêm từ '{word}' thành công.", "Hoàn tất");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}