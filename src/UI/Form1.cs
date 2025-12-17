// using System;
// using System.Linq;
// using System.Windows.Forms;
// using Dictionary.Services;
// using Dictionary.Data; // Cần dùng FileHelper
// using System.IO;
// using System.Runtime.InteropServices;

// namespace DictionaryUI
// {
//     public partial class Form1 : Form
//     {
//         private string DATA_PATH;
//         private string SYNANT_PATH;
//         private string FAVORITE_PATH;
//         private double _aspectRatio = 0.0;

//         public Form1()
//         {
//             try { System.IO.File.AppendAllText(Path.Combine(AppContext.BaseDirectory, "form_trace.log"), DateTime.Now + " - Form1 ctor start\n"); } catch { }
//             InitializeComponent();
//             try { System.IO.File.AppendAllText(Path.Combine(AppContext.BaseDirectory, "form_trace.log"), DateTime.Now + " - InitializeComponent done\n"); } catch { }
//             // Use output Data folder so paths work on Windows
//             var baseDir = AppContext.BaseDirectory;
//             var dataDir = Path.Combine(baseDir, "Data");
//             DATA_PATH = Path.Combine(dataDir, "MeaningWordData.txt");
//             SYNANT_PATH = Path.Combine(dataDir, "SynAntWordData.txt");
//             FAVORITE_PATH = Path.Combine(dataDir, "FavoriteWordData.txt");

//             LoadInitialData();
//             try { System.IO.File.AppendAllText(Path.Combine(AppContext.BaseDirectory, "form_trace.log"), DateTime.Now + " - After LoadInitialData\n"); } catch { }
//             SetupUI();
//             try { System.IO.File.AppendAllText(Path.Combine(AppContext.BaseDirectory, "form_trace.log"), DateTime.Now + " - After SetupUI\n"); } catch { }

//             // Record the initial aspect ratio once layout is ready so we can enforce it during resize.
//             try
//             {
//                 // Aspect ratio for 1000x800 = 1.25
//                 _aspectRatio = 1.25; // 1000 / 800
//             }
//             catch { _aspectRatio = 0.0; }
//         }

//         // Enforce aspect ratio lock during resize to prevent boxes from shrinking
//         protected override void WndProc(ref Message m)
//         {
//             const int WM_SIZING = 0x214;
//             const int WMSZ_LEFT = 1;
//             const int WMSZ_RIGHT = 2;
//             const int WMSZ_TOP = 3;
//             const int WMSZ_BOTTOM = 6;
//             const int WMSZ_TOPLEFT = 4;
//             const int WMSZ_TOPRIGHT = 5;
//             const int WMSZ_BOTTOMLEFT = 7;
//             const int WMSZ_BOTTOMRIGHT = 8;

//             if (m.Msg == WM_SIZING && _aspectRatio > 0.0)
//             {
//                 RECT rect = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT))!;
//                 int width = rect.Right - rect.Left;
//                 int height = rect.Bottom - rect.Top;
//                 double currentRatio = (double)width / Math.Max(1, height);

//                 // Adjust to maintain aspect ratio
//                 if (currentRatio > _aspectRatio)
//                 {
//                     // Too wide, adjust height
//                     int newHeight = (int)(width / _aspectRatio);
//                     int wParam = (int)m.WParam;
//                     if (wParam == WMSZ_BOTTOM || wParam == WMSZ_BOTTOMLEFT || wParam == WMSZ_BOTTOMRIGHT)
//                         rect.Bottom = rect.Top + newHeight;
//                     else
//                         rect.Top = rect.Bottom - newHeight;
//                 }
//                 else
//                 {
//                     // Too tall, adjust width
//                     int newWidth = (int)(height * _aspectRatio);
//                     int wParam = (int)m.WParam;
//                     if (wParam == WMSZ_RIGHT || wParam == WMSZ_TOPRIGHT || wParam == WMSZ_BOTTOMRIGHT)
//                         rect.Right = rect.Left + newWidth;
//                     else
//                         rect.Left = rect.Right - newWidth;
//                 }

//                 Marshal.StructureToPtr(rect, m.LParam, false);
//             }

//             base.WndProc(ref m);
//         }

//         [StructLayout(LayoutKind.Sequential)]
//         private struct RECT
//         {
//             public int Left;
//             public int Top;
//             public int Right;
//             public int Bottom;
//         }

//         // Draw a subtle vertical gradient background
//         protected override void OnPaintBackground(PaintEventArgs e)
//         {
//             try
//             {
//                 using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.FromArgb(250, 250, 252), Color.FromArgb(238, 246, 255), 90F))
//                 {
//                     e.Graphics.FillRectangle(brush, this.ClientRectangle);
//                 }
//             }
//             catch
//             {
//                 base.OnPaintBackground(e);
//             }
//         }

//         private void LoadInitialData()
//         {
//             try
//             {
//                 DictionaryService.LoadFromFile(DATA_PATH);
//                 SynAntDictionary.LoadFromFile(SYNANT_PATH);
//             }
//             catch (Exception ex)
//             {
//                 MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi");
//                 // Khởi tạo file rỗng nếu chưa có
//                 File.WriteAllText(DATA_PATH, "");
//                 File.WriteAllText(SYNANT_PATH, "");
//                 File.WriteAllText(FAVORITE_PATH, "");
//             }
//         }

//         private void SetupUI()
//         {
//             // Display all words from dictionary on startup
//             UpdateWordListUI();
//             ClearDetailPanel();
//         }
        
//         private void UpdateWordListUI()
//         {
//             listWords.Items.Clear();
//             var allWords = DictionaryService.dictionary.Keys.OrderBy(w => w).ToList();
//             listWords.Items.AddRange(allWords.ToArray());
//         }

//         private void ClearDetailPanel()
//         {
//             lblWordDetail.Text = "";
//             lblDefinition.Text = "";
//             lblDescription.Text = "";
//             lblExample.Text = "";
//             lblSynonyms.Text = "";
//             lblAntonyms.Text = "";
//             pbFavorite.Visible = false; 
//             btnEdit.Visible = false;
//         }

//         // ------------------------------------
//         // CHỨC NĂNG TÌM KIẾM VÀ LỌC DANH SÁCH TỪ
//         // ------------------------------------
//         private void txtSearch_TextChanged(object sender, EventArgs e)
//         {
//             string searchText = txtSearch.Text.Trim().ToLower();
//             listWords.Items.Clear();

//             if (string.IsNullOrEmpty(searchText))
//             {
//                 // Nếu thanh tìm kiếm trống, hiển thị tất cả (hoặc chỉ "dictionary-s" nếu bạn muốn)
//                 var allWords = DictionaryService.dictionary.Keys.OrderBy(w => w).ToList();
//                 listWords.Items.AddRange(allWords.ToArray());
//                 // Nếu yêu cầu ban đầu chỉ là "dictionary-s" khi mới chạy/search trống
//                 // listWords.Items.Add("dictionary-s"); 
//             }
//             else
//             {
//                 // Lọc theo chữ cái bắt đầu
//                 var filteredWords = DictionaryService.dictionary.Keys
//                     .Where(word => word.ToLower().StartsWith(searchText))
//                     .OrderBy(w => w)
//                     .ToList();

//                 listWords.Items.AddRange(filteredWords.ToArray());
//             }
//         }

//         // ------------------------------------
//         // HIỂN THỊ CHI TIẾT TỪ KHI CHỌN
//         // ------------------------------------
//         private void listWords_SelectedIndexChanged(object sender, EventArgs e)
//         {
//             if (listWords.SelectedItem == null) 
//             {
//                 ClearDetailPanel();
//                 return;
//             }

//             string selectedWord = listWords.SelectedItem.ToString();
            
//             // 1. Hiển thị chi tiết chính
//             string detail = DictionaryService.Search(selectedWord);
//             if (!detail.Contains("not found"))
//             {
//                 string[] parts = detail.Split('\n');
//                 // parts[0] = "Từ: word"
//                 // parts[1] = "Nghĩa: definition"
//                 // parts[2] = "Mô tả: description"
//                 // parts[3] = "Ví dụ: example"
                
//                 lblWordDetail.Text = selectedWord;
                
//                 // Combine meaning + description for the Meaning box
//                 string meaning = (parts.Length > 1 ? parts[1].Replace("Nghĩa: ", "") : "") + Environment.NewLine +
//                                  (parts.Length > 2 ? parts[2].Replace("Mô tả: ", "") : "");
//                 lblDefinition.Text = meaning.Trim();
                
//                 // Example sentences
//                 lblExample.Text = (parts.Length > 3 ? parts[3].Replace("Ví dụ: ", "") : "");
//             }
//             else
//             {
//                 ClearDetailPanel();
//                 return; // Không tìm thấy từ trong từ điển chính
//             }
            
//             // 2. Hiển thị Đồng nghĩa/Trái nghĩa
//             string syns = SynAntDictionary.SearchSyn(selectedWord);
//             lblSynonyms.Text = (syns == "notfound" ? "" : syns);

//             string ants = SynAntDictionary.SearchAnt(selectedWord);
//             lblAntonyms.Text = (ants == "notfound" ? "" : ants);
            
//             // 3. Cập nhật trạng thái Yêu thích và hiển thị nút chức năng
//             UpdateFavoriteIcon(selectedWord);
//             pbFavorite.Visible = true;
//             btnEdit.Visible = true;
//         }
        
//         // ------------------------------------
//         // CHỨC NĂNG YÊU THÍCH (TRÁI TIM)
//         // ------------------------------------
//         private void UpdateFavoriteIcon(string word)
//         {
//             // Đọc file yêu thích để kiểm tra trạng thái
//             if (!System.IO.File.Exists(FAVORITE_PATH))
//                 System.IO.File.WriteAllText(FAVORITE_PATH, "");
            
//             var favorites = System.IO.File.ReadAllLines(FAVORITE_PATH)
//                                 .Select(l => l.Trim().ToLower())
//                                 .ToList();

//             if (favorites.Contains(word.ToLower()))
//             {
//                 // If you have Resources, set the image; otherwise leave null
//                 pbFavorite.Image = null;
//                 pbFavorite.Tag = "Favorited";
//             }
//             else
//             {
//                 pbFavorite.Image = null;
//                 pbFavorite.Tag = "NotFavorited";
//             }
//         }

//         private void pbFavorite_Click(object sender, EventArgs e)
//         {
//             if (listWords.SelectedItem == null) return;
//             string selectedWord = listWords.SelectedItem.ToString();

//             if (pbFavorite.Tag.ToString() == "Favorited")
//             {
//                 // Đang yêu thích -> Xóa khỏi yêu thích
//                 DictionaryMyFavorite.RemoveFavorite(FAVORITE_PATH, selectedWord);
//             }
//             else
//             {
//                 // Chưa yêu thích -> Thêm vào yêu thích
//                 DictionaryMyFavorite.AddFavorite(FAVORITE_PATH, selectedWord);
//             }
            
//             // Cập nhật lại biểu tượng
//             UpdateFavoriteIcon(selectedWord); 
//         }
        
//         // ------------------------------------
//         // NÚT THÊM (+)
//         // ------------------------------------
//         private void btnAdd_Click(object sender, EventArgs e)
//         {
//             // Giả định FormAddWord đã được tạo
//             using (FormAddWord addForm = new FormAddWord())
//             {
//                 if (addForm.ShowDialog() == DialogResult.OK)
//                 {
//                     // Hàm SortFile đã được gọi trong FormAddWord
//                     // Cập nhật lại danh sách từ trên UI
//                     UpdateWordListUI(); 
//                 }
//             }
//         }
        
//         // ------------------------------------
//         // NÚT XÓA (-)
//         // ------------------------------------
//         private void btnDelete_Click(object sender, EventArgs e)
//         {
//             if (listWords.SelectedItem == null)
//             {
//                 MessageBox.Show("Vui lòng chọn một từ để xóa.", "Lỗi");
//                 return;
//             }

//             string selectedWord = listWords.SelectedItem.ToString();
            
//             // Hiển thị hộp thoại xác nhận
//             DialogResult result = MessageBox.Show(
//                 $"Bạn có muốn xoá từ '{selectedWord}' này không?", 
//                 "Xác nhận xóa", 
//                 MessageBoxButtons.YesNo, 
//                 MessageBoxIcon.Warning
//             );

//             if (result == DialogResult.Yes)
//             {
//                 // Xóa từ file chính
//                 DictionaryService.DeleteFromFile(DATA_PATH, selectedWord);
                
//                 // (Tùy chọn) Xóa từ khỏi file yêu thích nếu có
//                 DictionaryMyFavorite.RemoveFavorite(FAVORITE_PATH, selectedWord);
                
//                 // Cập nhật lại danh sách từ trên UI
//                 UpdateWordListUI();
//                 ClearDetailPanel();
//             }
//         }

//         // ------------------------------------
//         // NÚT CHỈNH SỬA (RĂNG CƯA)
//         // ------------------------------------
//         private void btnEdit_Click(object sender, EventArgs e)
//         {
//             if (listWords.SelectedItem == null)
//             {
//                 MessageBox.Show("Vui lòng chọn một từ để chỉnh sửa.", "Lỗi");
//                 return;
//             }

//             string selectedWord = listWords.SelectedItem.ToString();
            
//             // Giả định FormEditWord đã được tạo
//             using (FormEditWord editForm = new FormEditWord(selectedWord))
//             {
//                 if (editForm.ShowDialog() == DialogResult.OK)
//                 {
//                     // Hàm SortFile đã được gọi trong FormEditWord
//                     // Cập nhật lại danh sách từ trên UI
//                     UpdateWordListUI(); 
//                     // Tự động chọn lại từ vừa sửa để hiển thị chi tiết
//                     listWords.SelectedItem = selectedWord; 
//                 }
//             }
//         }
//     }
// }
using System;
using System.Linq;
using System.Windows.Forms;
using Dictionary.Services;
using Dictionary.Data;
using System.IO;

namespace DictionaryUI
{
    public partial class Form1 : Form
    {
        private string DATA_PATH;
        private string SYNANT_PATH;
        private string FAVORITE_PATH;

        public Form1()
        {
            InitializeComponent();

            var baseDir = AppContext.BaseDirectory;
            var dataDir = Path.Combine(baseDir, "Data");
            DATA_PATH = Path.Combine(dataDir, "MeaningWordData.txt");
            SYNANT_PATH = Path.Combine(dataDir, "SynAntWordData.txt");
            FAVORITE_PATH = Path.Combine(dataDir, "FavoriteWordData.txt");

            LoadInitialData();
            SetupUI();
        }

        private void LoadInitialData()
        {
            try
            {
                DictionaryService.LoadFromFile(DATA_PATH);
                SynAntDictionary.LoadFromFile(SYNANT_PATH);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi");
                File.WriteAllText(DATA_PATH, "");
                File.WriteAllText(SYNANT_PATH, "");
                File.WriteAllText(FAVORITE_PATH, "");
            }
        }

        private void SetupUI()
        {
            UpdateWordListUI();
            ClearDetailPanel();
        }

        // ✔ FIX dùng GetAll() thay cho Keys
        private void UpdateWordListUI()
        {
            listWords.Items.Clear();

            var allWords = DictionaryService.dictionary
                .GetAll()
                .Select(e => e.Key)
                .OrderBy(w => w)
                .ToList();

            listWords.Items.AddRange(allWords.ToArray());
        }

        private void ClearDetailPanel()
        {
            lblWordDetail.Text = "";
            lblDefinition.Text = "";
            lblDescription.Text = "";
            lblExample.Text = "";
            lblSynonyms.Text = "";
            lblAntonyms.Text = "";
            pbFavorite.Visible = false;
            btnEdit.Visible = false;
        }

        // ------------------------------------
        // TÌM KIẾM
        // ------------------------------------
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            listWords.Items.Clear();

            var allKeys = DictionaryService.dictionary
                .GetAll()
                .Select(e => e.Key);

            if (string.IsNullOrEmpty(searchText))
            {
                var allWords = allKeys.OrderBy(w => w).ToList();
                listWords.Items.AddRange(allWords.ToArray());
            }
            else
            {
                var filteredWords = allKeys
                    .Where(word => word.ToLower().StartsWith(searchText))
                    .OrderBy(w => w)
                    .ToList();

                listWords.Items.AddRange(filteredWords.ToArray());
            }
        }

        // ------------------------------------
        // HIỂN THỊ CHI TIẾT
        // ------------------------------------
        private void listWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedWord = listWords.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedWord))
            {
                ClearDetailPanel();
                return;
            }

            string detail = DictionaryService.Search(selectedWord);
            if (!detail.Contains("not found"))
            {
                string[] parts = detail.Split('\n');

                lblWordDetail.Text = selectedWord;

                string meaning = (parts.Length > 1 ? parts[1].Replace("Nghĩa: ", "") : "") + Environment.NewLine +
                                 (parts.Length > 2 ? parts[2].Replace("Mô tả: ", "") : "");

                lblDefinition.Text = meaning.Trim();

                lblExample.Text = (parts.Length > 3 ? parts[3].Replace("Ví dụ: ", "") : "");
            }
            else
            {
                ClearDetailPanel();
                return;
            }

            lblSynonyms.Text = (SynAntDictionary.SearchSyn(selectedWord) == "notfound" ? "" :
                                SynAntDictionary.SearchSyn(selectedWord));

            lblAntonyms.Text = (SynAntDictionary.SearchAnt(selectedWord) == "notfound" ? "" :
                                SynAntDictionary.SearchAnt(selectedWord));

            UpdateFavoriteIcon(selectedWord);
            pbFavorite.Visible = true;
            btnEdit.Visible = true;
        }

        // ------------------------------------
        // YÊU THÍCH
        // ------------------------------------
        private void UpdateFavoriteIcon(string word)
        {
            if (!File.Exists(FAVORITE_PATH))
                File.WriteAllText(FAVORITE_PATH, "");

            var favorites = File.ReadAllLines(FAVORITE_PATH)
                                .Select(l => l.Trim().ToLower())
                                .ToList();

            if (favorites.Contains(word.ToLower()))
            {
                pbFavorite.Image = null;
                pbFavorite.Tag = "Favorited";
            }
            else
            {
                pbFavorite.Image = null;
                pbFavorite.Tag = "NotFavorited";
            }
        }

        private void pbFavorite_Click(object sender, EventArgs e)
        {
            string? selectedWord = listWords.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedWord)) return;

            if (pbFavorite.Tag?.ToString() == "Favorited")
            {
                DictionaryMyFavorite.RemoveFavorite(FAVORITE_PATH, selectedWord);
            }
            else
            {
                DictionaryMyFavorite.AddFavorite(FAVORITE_PATH, selectedWord);
            }

            UpdateFavoriteIcon(selectedWord);
        }

        // ------------------------------------
        // THÊM
        // ------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FormAddWord addForm = new FormAddWord())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateWordListUI();
                }
            }
        }

        // ------------------------------------
        // XÓA
        // ------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string? selectedWord = listWords.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedWord))
            {
                MessageBox.Show("Vui lòng chọn một từ để xóa.", "Lỗi");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có muốn xoá từ '{selectedWord}' này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                DictionaryService.DeleteFromFile(DATA_PATH, selectedWord);
                DictionaryMyFavorite.RemoveFavorite(FAVORITE_PATH, selectedWord);
                UpdateWordListUI();
                ClearDetailPanel();
            }
        }

        // ------------------------------------
        // CHỈNH SỬA
        // ------------------------------------
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string? selectedWord = listWords.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedWord))
            {
                MessageBox.Show("Vui lòng chọn một từ để chỉnh sửa.", "Lỗi");
                return;
            }

            using (FormEditWord editForm = new FormEditWord(selectedWord))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateWordListUI();
                    listWords.SelectedItem = selectedWord;
                }
            }
        }
    }
}
