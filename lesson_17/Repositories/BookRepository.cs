using lesson_17.Models;
using lesson_17.ModelView;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace lesson_17.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new List<Book>
        {

        };

        public void Add(Book book)
        {
            books.Add(book);
            Save();
        }


        public void Delete(int Id)
        {
            var book = books.First(item => item.Id == Id);
            if(book != null)
            {
                books.Remove(book);
                Save();
            }
        }

        public void Update(Book book)
        {
            var index = books.FindIndex(item => item.Id == book.Id);
            books[index] = book;
            Save();
        }

        public Book Get(int Id)
        {
            var book = books.First(item => item.Id == Id);
            if (book != null) return book;
            else return new Book();
        }

        public List<Book> GetAll()
        {
            return books;
        }

        private async Task<bool> Save()
        {
            try
            {
                string path = "D:\\Project\\TMS_HW\\lesson_17\\Json\\Books.json";

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
                    await JsonSerializer.SerializeAsync<List<Book>>(fs, books, optionsJson);
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
                string path = "D:\\Project\\TMS_HW\\lesson_17\\Json\\Books.json";

                var optionsJson = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    AllowTrailingCommas = true
                };

                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    List<Book>? _books = await JsonSerializer.DeserializeAsync<List<Book>>(fs, optionsJson);
                    if (_books != null)
                    {
                        books = _books;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public BookRepository() { }
    }
}
