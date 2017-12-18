using BusinessLogicDomain.Abstract;
using BusinessLogicDomain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StoreWebUI.Controllers;
using StoreWebUI.HtmlHelpers;
using StoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace UnitTests.Controllers
{
    [TestClass]
    public class BooksControllerTest
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IBookRepository> repository = new Mock<IBookRepository>();
            repository.Setup(m => m.Books).Returns(new List<Book>
            {
                new Book { BookId = 1, Name = "Book1"},
                new Book { BookId = 2, Name = "Book2"},
                new Book { BookId = 3, Name = "Book3"},
                new Book { BookId = 4, Name = "Book4"},
                new Book { BookId = 5, Name = "Book5"}
            });
            BooksController controller = new BooksController(repository.Object);
            controller.pageSize = 3;

            BooksListViewModel result = (BooksListViewModel)controller.List(null, 2).Model;

            List<Book> books = result.Books.ToList();
            Assert.IsTrue(books.Count == 2);
            Assert.AreEqual(books[0].Name, "Book4");
            Assert.AreEqual(books[1].Name, "Book5");
        }

        [TestMethod]
        public void CanGeneratePageLinks()
        {
            // Организация
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            Func<Int32, string> pageUrlDelegate = i => "Page" + i;
            // Действие
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
            // Утверждение
            Assert.AreEqual(@"<a class=""btn btn-default"" href=Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=Page2"">1</a>"
                + @"<a class=""btn btn-default"" href=Page3"">1</a>",
                result.ToString());
        }

        [TestMethod]
        public void CanSendPaginationViewModel()
        {
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new List<Book>
            {
                new Book { BookId = 1, Name = "Book1"},
                new Book { BookId = 2, Name = "Book2"},
                new Book { BookId = 3, Name = "Book3"},
                new Book { BookId = 4, Name = "Book4"},
                new Book { BookId = 5, Name = "Book5"}
            });
            BooksController controller = new BooksController(mock.Object);
            controller.pageSize = 3;

            BooksListViewModel result = (BooksListViewModel)controller.List(null, 2).Model;

            PagingInfo pagingInfo = result.PagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 5);
            Assert.AreEqual(pagingInfo.TotalPages, 2);
        }

        [TestMethod]
        public void CanFiltersBooks()
        {
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new List<Book>
            {
                new Book { BookId = 1, Name = "Book1", Genre = "Genre1" },
                new Book { BookId = 2, Name = "Book2", Genre = "Genre2" },
                new Book { BookId = 3, Name = "Book3", Genre = "Genre1" },
                new Book { BookId = 4, Name = "Book4", Genre = "Genre3" },
                new Book { BookId = 5, Name = "Book5", Genre = "Genre2" }
            });
            BooksController controller = new BooksController(mock.Object);
            controller.pageSize = 3;

            List<Book> result = ((BooksListViewModel)controller.List("Genre2", 2).Model).Books.ToList();

            Assert.AreEqual(result.Count(), 2);
            Assert.IsTrue(result[0].Name == "Book2" && result[0].Genre == "Genre2");
            Assert.IsTrue(result[0].Name == "Book5" && result[0].Genre == "Genre2");
        }

        [TestMethod]
        public void CanCreateCategories()
        {
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new List<Book>
            {
                new Book { BookId = 1, Name = "Book1", Genre = "Genre1" },
                new Book { BookId = 2, Name = "Book2", Genre = "Genre2" },
                new Book { BookId = 3, Name = "Book3", Genre = "Genre1" },
                new Book { BookId = 4, Name = "Book4", Genre = "Genre3" },
                new Book { BookId = 5, Name = "Book5", Genre = "Genre2" }
            });
            NavigationController controller = new NavigationController(mock.Object);


            List<String> result = ((IEnumerable<String>)controller.Menu().Model).ToList();

            Assert.AreEqual(result.Count(), 3);
            Assert.AreEqual(result[0], "Genre1");
            Assert.AreEqual(result[1], "Genre2");
            Assert.AreEqual(result[2], "Genre3");
        }


        [TestMethod]
        public void GenerateGenreSpecificBookCount()
        {
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new List<Book>
            {
                new Book { BookId = 1, Name = "Book1", Genre = "Genre1" },
                new Book { BookId = 2, Name = "Book2", Genre = "Genre2" },
                new Book { BookId = 3, Name = "Book3", Genre = "Genre1" },
                new Book { BookId = 4, Name = "Book4", Genre = "Genre3" },
                new Book { BookId = 5, Name = "Book5", Genre = "Genre2" }
            });

            BooksController controller = new BooksController(mock.Object);
            controller.pageSize = 3;
            Int32 res1 = ((BooksListViewModel)controller.List("Genre1").Model).PagingInfo.TotalItems;
            Int32 res2 = ((BooksListViewModel)controller.List("Genre2").Model).PagingInfo.TotalItems;
            Int32 res3 = ((BooksListViewModel)controller.List("Genre3").Model).PagingInfo.TotalItems;
            Int32 resAll= ((BooksListViewModel)controller.List(null).Model).PagingInfo.TotalItems;

            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);
        }
    }
}