using lesson_17.Models;
using lesson_17.Repositories;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace lesson_17.Repositoryies
{
    public class AuthorRepository : IAuthorRepository
    {
        private static List<Author> authors = new List<Author>
        {
              
        };

        public void Add(Author author)
        {
            authors.Add(author);
            Save();
        }

        public void Delete(Author author)
        {

            Save();
        }

        public void Get(Author author)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAll()
        {
            return authors;
        }

        public void Update(Author author)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> Save()
        {
            try
            {
                string path = "D:\\Project\\TMS_HW\\lesson_17\\Json\\Authors.json";

                var optionsJson = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                };

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    await JsonSerializer.SerializeAsync<List<Author>>(fs, authors, optionsJson);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<bool> Update()
        {
            try
            {
                string path = "D:\\Project\\TMS_HW\\lesson_17\\Json\\Authors.json";

                var optionsJson = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    AllowTrailingCommas = true
                };

                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    List<Author>? _authors = await JsonSerializer.DeserializeAsync<List<Author>>(fs, optionsJson);
                    if (_authors != null)
                    {
                        authors = _authors;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public AuthorRepository()
        {
            Update();
        }
    }   
}
