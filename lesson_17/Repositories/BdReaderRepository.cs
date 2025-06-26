using lesson_17.Repositories;
using lesson_25.Data;
using lesson_25.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace lesson_25.Repositories
{
    public class BdReaderRepository : IReaderRepository
    {
        private readonly ApplicationContex contex;

        public BdReaderRepository(ApplicationContex _contex)
        {
            contex = _contex;
        }

        public void Add(Reader reader)
        {
            using (contex)
            {
                contex.Readers.Add(reader);
                contex.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (contex)
            {
                contex.Readers.Where(x => x.Id == Id).ExecuteDelete();
            }
        }

        public Reader Get(int Id)
        {
            using (contex)
            {
                var reader = contex.Readers.First(x => x.Id == Id);
                if (reader != null) return reader;
                else return new Reader();
            }
        }

        public List<Reader> GetAll()
        {
            using (contex)
            {
                return contex.Readers.ToList();
            }
        }

        public void Update(Reader reader)
        {
            var id = reader.Id;
            using (contex)
            {
                var newReader = contex.Readers.First(x => x.Id == id);
                if (newReader != null)
                {
                    newReader = reader;
                    contex.SaveChanges();
                }
            }
        }
    }
}
