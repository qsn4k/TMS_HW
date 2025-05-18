using lesson_17.Models;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace lesson_17.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private static List<Reader> readers = new List<Reader>
        {

        };

        public void Add(Reader reader)
        {
            readers.Add(reader);
        }

        public void Update(Reader reader)
        {

        }

        public void Delete(int id)
        {

        }

        public Reader Get(int id)
        {
            return new Reader();
        }

        public List<Reader> GetAll()
        {
            return readers;
        }

        private async Task<bool> SaveAsync()
        {
            try
            {
                string path = "Readers.json";

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
                string path = "Reader.json";

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
    }
}
