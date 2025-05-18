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
            Update();
            authors.Add(author);
            Save();
        }

        public void Delete(int Id)
        {
            Update();
            var author = authors.First(item => item.Id == Id);
            if(author != null)
            {
                authors.Remove(author);
                Save();
            }
        }

        public Author Get(int Id)
        {
            var author = authors.First(item => item.Id == Id);
            if (author != null) return author;
            else return new Author();
        }

        public void Update(Author author)
        {
            var index = authors.FindIndex(item => item.Id == author.Id);
            authors[index] = author;
            Save();
        }

        public List<Author> GetAll()
        {
            Update();
            return authors;
        }

        private async Task<bool> Save()
        {
            try
            {
                string path = "D:\\Project\\TMS_HW\\lesson_17\\Json\\Authors.json";

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

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
