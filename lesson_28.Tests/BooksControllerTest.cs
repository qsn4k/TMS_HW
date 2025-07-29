using lesson_28.Controllers;
using lesson_28.Models;
using Microsoft.AspNetCore.Mvc;

namespace lesson_28.Tests
{
    public class BooksControllerTest
    {
        [Fact]
        public void GetByIdResultTrue()
        {
            //Arrange
            BooksController booksController = new BooksController();
            int id = 1;
            Book resultBook = new Book { Id = 1, Author = "Пушкин", Title = "Золотая рыбка" };
            //Act
            ActionResult<Book> bookModel = booksController.GetById(id);
            var book = bookModel.Value;

            //Assert
            Assert.Equal(book.Author, resultBook.Author);
        }
    }
}