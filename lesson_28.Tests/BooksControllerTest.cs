using lesson_28.Controllers;
using lesson_28.Models;
using lesson_28.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace lesson_28.Tests
{
    public class BooksControllerTest
    {
        [Fact]
        public void GetByIdResultTrue()
        {
            //Arrange
            var mockService = new Mock<IGet>();
            var initialData = new List<Book> { new Book { Id = 1, Author = "test", Title = "TESTING" } };
            var finalData = new List<Book> { new Book { Id = 1, Author = "test", Title = "TESTING" } };
            mockService
                .Setup(s => s.GetBooks())
                .Returns(initialData);
            var controller = new BooksController(mockService.Object);

            int id = 1;
            //Act
            var actionResult = controller.GetById(id);
            var bookModel = actionResult.Value as Book;
            
            //Assert
            var model = Assert.IsAssignableFrom<Book>(actionResult.Value);
            Assert.Equal(finalData[0].Id, model.Id);

        }
    }
}