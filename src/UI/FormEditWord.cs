using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using Dictionary.Services;
using Dictionary.Models;

namespace DictionaryUI
{
    // Cần tạo Form này trong VS
    public partial class FormEditWord : Form
    {
        private readonly string DATA_PATH;
        private readonly string SYNANT_PATH;

        private readonly string _wordToEdit;

        public FormEditWord(string word)
        {
            InitializeComponent();

            var baseDir = AppContext.BaseDirectory;
            var dataDir = Path.Combine(baseDir, "Data");
            DATA_PATH = Path.Combine(dataDir, "MeaningWordData.txt");
            SYNANT_PATH = Path.Combine(dataDir, "SynAntWordData.txt");

            _wordToEdit = word;
            this.Text = $"Chỉnh Sửa Từ: {word}";
            txtWord.Text = word;
            txtWord.ReadOnly = true; // Không cho phép sửa từ khóa
            LoadWordData();
        }

        private void LoadWordData()
        {
            // Lấy nghĩa, mô tả, ví dụ từ DictionaryService
            if (DictionaryService.dictionary.TryGetValue(_wordToEdit, out Meaning meaning))
            {
                txtDefinition.Text = meaning.Definition;
                txtDescription.Text = meaning.Description;
                txtExample.Text = meaning.Example;
            }

            // Lấy từ đồng nghĩa
            if (SynAntMeaning.Synonyms.TryGetValue(_wordToEdit.ToLower(), out List<string> syns))
            {
                txtSynonyms.Text = string.Join(", ", syns);
            }

            // Lấy từ trái nghĩa
            if (SynAntMeaning.Antonyms.TryGetValue(_wordToEdit.ToLower(), out List<string> ants))
            {
                txtAntonyms.Text = string.Join(", ", ants);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newDef = txtDefinition.Text.Trim();
            string newDesc = txtDescription.Text.Trim();
            string newEx = txtExample.Text.Trim();
            string newSyns = txtSynonyms.Text.Trim();
            string newAnts = txtAntAntonyms.Text.Trim(); // Giả định tên control

            if (string.IsNullOrEmpty(newDef))
            {
                MessageBox.Show("Nghĩa của từ không được để trống.", "Lỗi");
                return;
            }

            // 1. Cập nhật file chính
            DictionaryService.UpdateToFile(DATA_PATH, _wordToEdit, newDef, newDesc, newEx);

            // 2. Cập nhật Synonyms và Antonyms
            
            // Xóa tất cả Synonyms/Antonyms cũ khỏi bộ nhớ trước
            if (SynAntMeaning.Synonyms.ContainsKey(_wordToEdit.ToLower())) 
                SynAntMeaning.Synonyms[_wordToEdit.ToLower()].Clear();

            if (SynAntMeaning.Antonyms.ContainsKey(_wordToEdit.ToLower()))
                SynAntMeaning.Antonyms[_wordToEdit.ToLower()].Clear();
            
            // Ghi lại Synonyms mới
            if (!string.IsNullOrEmpty(newSyns))
            {
                string[] synList = newSyns.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var syn in synList.Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)))
                {
                    SynAntDictionary.AddSyn(SYNANT_PATH, _wordToEdit, syn);
                }
            }

            // Ghi lại Antonyms mới
            if (!string.IsNullOrEmpty(newAnts))
            {
                string[] antList = newAnts.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var ant in antList.Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)))
                {
                    SynAntDictionary.AddAnt(SYNANT_PATH, _wordToEdit, ant);
                }
            }
            
            // Note: AddSyn/AddAnt đã tự động cập nhật cả file và bộ nhớ
            
            // 3. Sắp xếp lại file chính
            DictionaryService.SortFile(DATA_PATH); 

            MessageBox.Show($"Chỉnh sửa từ '{_wordToEdit}' thành công.", "Hoàn tất");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}