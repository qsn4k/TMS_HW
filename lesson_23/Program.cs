using lesson_23.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
 
namespace lesson_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var contex = new AppContext())
            {
                var author = new Author
                {
                    Name = "Пушкин"
                };
                contex.Authors.Add(author);

                var book = new Book
                {
                    Title = "Золотая рыбка",
                    AuthorId = 1
                };
                contex.Books.Add(book);

                var reader = new Reader
                {
                    Name = "Даниил",
                    BookId = 1
                };
                contex.Readers.Add(reader);

                contex.SaveChanges();

            }

            using (var contex = new AppContext())
            {
                var reader = contex.Readers.FirstOrDefault();
                var book = contex.Books.FirstOrDefault();
                var author = contex.Authors.FirstOrDefault();
                Console.WriteLine($"Имя читателя: {reader.Name}, читает: {book.Title}, {author.Name}");
            }

        }

    }

}