using lesson_17.Models;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using static System.Reflection.Metadata.BlobBuilder;

namespace lesson_17.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private static List<Reader> readers = new List<Reader> {};

        public void Add(Reader reader)
        {
            readers.Add(reader);
            Save();
        }

        public void Update(Reader reader)
        {
            var index = readers.FindIndex(item => item.Id == reader.Id);
            readers[index] = reader;
            Save();
        }

        public void Delete(int Id)
        {
            var reader = readers.First(item => item.Id == Id);
            if (reader != null)
            {
                readers.Remove(reader);
                Save();
            }
        }

        public Reader Get(int Id)
        {
            var reader = readers.First(item => item.Id == Id);
            if (reader != null) return reader;
            return new Reader();
        }

        public List<Reader> GetAll()
        {
            Update();
            return readers;
        }

        private async Task<bool> Save()
        {
            try
            {
                string path = "D:\\Project\\TMS_HW\\lesson_17\\Json\\Readers.json";

                var optionsJson = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                };

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    await JsonSerializer.SerializeAsync<List<Reader>>(fs, readers, optionsJson);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private async Task<bool> Update()
        {
            try
            {
                string path = "D:\\Project\\TMS_HW\\lesson_17\\Json\\Readers.json";

                var optionsJson = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    AllowTrailingCommas = true
                };

                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    List<Reader>? _readers = await JsonSerializer.DeserializeAsync<List<Reader>>(fs, optionsJson);
                    if (_readers != null)
                    {
                        readers = _readers;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ReaderRepository() { Update(); }
    }
}
