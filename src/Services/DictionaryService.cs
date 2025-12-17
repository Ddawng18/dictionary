using System;
using System.Collections.Generic;
using System.Linq;
using Dictionary.Models;
using Dictionary.Data;
using Dictionary.Services;

namespace Dictionary.Services
{

    public class DictionaryList<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private List<TKey> keys = new List<TKey>();
        private List<TValue> values = new List<TValue>();

        public int Count => keys.Count;

        public IEnumerable<TKey> Keys => keys.AsReadOnly();


        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = keys.IndexOf(key);
            if (index == -1)
            {
                value = default!;
                return false;
            }
            value = values[index];
            return true;
        }

        // Support foreach over key/value pairs
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        // --- kiểm tra tồn tại key ---
        public bool ContainsKey(TKey key)
        {
            return keys.Contains(key);
        }

        // --- indexer giống Dictionary[key] ---
        public TValue this[TKey key]
        {
            get
            {
                int index = keys.IndexOf(key);
                if (index == -1) throw new KeyNotFoundException();
                return values[index];
            }
            set
            {
                int index = keys.IndexOf(key);
                if (index == -1)
                {
                    keys.Add(key);
                    values.Add(value);
                }
                else
                {
                    values[index] = value;
                }
            }
        }

        // --- thêm ---
        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key)) return;
            keys.Add(key);
            values.Add(value);
        }

        // --- xóa ---
        public bool Remove(TKey key)
        {
            int index = keys.IndexOf(key);
            if (index == -1) return false;

            keys.RemoveAt(index);
            values.RemoveAt(index);
            return true;
        }

        // --- duyệt foreach như Dictionary ---
        public IEnumerable<KeyValuePair<TKey, TValue>> GetAll()
        {
            for (int i = 0; i < keys.Count; i++)
                yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
        }

        public void Clear()
        {
            keys.Clear();
            values.Clear();
        }
    }
}
public static class DictionaryService
    {
        public static DictionaryList<string, Meaning> dictionary = new DictionaryList<string, Meaning>();
        public static bool forSort = false;

        public static void Add(string word, string definition, string description, string example)
        {
            if (dictionary.ContainsKey(word))
                return;

            dictionary.Add(word, new Meaning(definition, description, example));
        }

        public static void Remove(string word)
        {
            dictionary.Remove(word);
        }

        // -------------------------
        //  PRINT LIST OF WORDS
        // -------------------------
        public static string PrintListOfWord()
        {
            if (dictionary.Count == 0)
            {
                return "null";
            }

            string result = "List of words:\n";
            result += new string('-', 40) + "\n";

            foreach (var entry in dictionary.GetAll())
            {
                result += entry.Key + "\n";
            }

            return result;
        }

        // -------------------------
        //  SEARCH WORD
        // -------------------------
        public static string Search(string word)
        {
            if (!dictionary.ContainsKey(word))
            {
                return $"not found {word}";
            }

            var meaning = dictionary[word];

            return
                $"Từ: {word}\n" +
                $"Nghĩa: {meaning.Definition}\n" +
                $"Mô tả: {meaning.Description}\n" +
                $"Ví dụ: {meaning.Example}";
        }

        // -------------------------
        // LOAD FILE
        // -------------------------
        public static string LoadFromFile(string path)
        {
            var lines = FileHelper.ReadAllLines(path);
            int lineIndex = 0;

            foreach (var line in lines)
            {
                lineIndex++;
                var parts = line.Split('|');
                if (parts.Length < 4) continue;

                Add(parts[0], parts[1], parts[2], parts[3]);
            }

            if (lineIndex == 0)
                return "Not found any data";

            if (!forSort)
                return $"Load success {lineIndex + 1} word";

            return "Sorted successfully";
        }

        // -------------------------
        // ADD TO FILE
        // -------------------------
        public static string AddToFile(string path, string word, string definition, string description, string example)
        {
            if (dictionary.ContainsKey(word))
            {
                return $"{word} exists, cannot add";
            }

            string line = $"{word}|{definition}|{description}|{example}";

            try
            {
                FileHelper.AppendLine(path, line);
                dictionary[word] = new Meaning(definition, description, example);
                return "Saved successfully";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        // -------------------------
        // DELETE WORD FROM FILE
        // -------------------------
        public static string DeleteFromFile(string path, string word)
        {
            var lines = FileHelper.ReadAllLines(path);

            var newLines = lines
                .Where(line => !line.StartsWith(word + "|", StringComparison.OrdinalIgnoreCase))
                .ToList();

            FileHelper.WriteAllLines(path, newLines);

            if (dictionary.ContainsKey(word))
            {
                dictionary.Remove(word);
                return $"Deleted '{word}' from file successfully.";
            }

            return $"{word} not found in file";
        }

        // -------------------------
        // SORT FILE
        // -------------------------
        public static string SortFile(string path)
        {
            var lines = FileHelper.ReadAllLines(path);
            forSort = true;

            lines = lines
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .OrderBy(l => l.Split('|')[0], StringComparer.OrdinalIgnoreCase)
                .ToList();

            FileHelper.WriteAllLines(path, lines);

            dictionary.Clear();
            return LoadFromFile(path);
        }

        // -------------------------
        // UPDATE TO FILE
        // -------------------------
        public static string UpdateToFile(string path, string word, string newDefinition, string newDescription, string newExample)
        {
            var lines = FileHelper.ReadAllLines(path);
            string newLine = $"{word}|{newDefinition}|{newDescription}|{newExample}";
            bool found = false;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith(word + "|", StringComparison.OrdinalIgnoreCase))
                {
                    lines[i] = newLine;
                    found = true;
                    break;
                }
            }

            if (found)
            {
                FileHelper.WriteAllLines(path, lines);

                dictionary[word] = new Meaning(newDefinition, newDescription, newExample);

                return $"Updated '{word}' successfully.";
            }

            return $"{word} not found for update.";
        }
    }

