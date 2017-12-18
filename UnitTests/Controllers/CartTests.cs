using BusinessLogicDomain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Controllers
{
    /// <summary>
    /// Класс CartTests предназначен для тестирования корзины товаров
    /// </summary>
    [TestClass]
    class CartTests
    {
        /// <summary>
        /// Метод CanAddNewLines предназначен для тестирования добавления товаров в корзину
        /// </summary>
        [TestMethod]
        public void CanAddNewLines()
        {
            // Организация
            Book bookOne = new Book { BookId = 1, Name = "Book1" };
            Book bookTwo = new Book { BookId = 2, Name = "Book2" };

            Cart cart = new Cart();

            // Действие
            cart.AddItem(bookOne, 1);
            cart.AddItem(bookTwo, 1);
            List<CartLine> results = cart.Lines.ToList();

            // Утвержденик
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].Book, bookOne);
            Assert.AreEqual(results[1].Book, bookTwo);
        }

        /// <summary>
        /// Метод CanAddQuantityForExistingLines предназначен для тестирования уже добавленных товаров в корзину
        /// </summary>
        [TestMethod]
        public void CanAddQuantityForExistingLines()
        {
            // Организация
            Book bookOne = new Book { BookId = 1, Name = "Book1" };
            Book bookTwo = new Book { BookId = 2, Name = "Book2" };

            Cart cart = new Cart();

            // Действие
            cart.AddItem(bookOne, 1);
            cart.AddItem(bookTwo, 1);
            cart.AddItem(bookOne, 5);
            List<CartLine> results = cart.Lines.OrderBy(c => c.Book.BookId).ToList();

            // Утвержденик
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].Quantiry, 6);
            Assert.AreEqual(results[1].Quantiry, 1);
        }

        [TestMethod]
        public void CanRemoveLine()
        {
            // Организация
            Book bookOne = new Book { BookId = 1, Name = "Book1" };
            Book bookTwo = new Book { BookId = 2, Name = "Book2" };
            Book bookThree = new Book { BookId = 3, Name = "Book3" };

            Cart cart = new Cart();

            // Действие
            cart.AddItem(bookOne, 1);
            cart.AddItem(bookTwo, 1);
            cart.AddItem(bookOne, 5);
            cart.AddItem(bookThree, 2);
            cart.RemoveLine(bookTwo);

            // Утвержденик
            Assert.AreEqual(cart.Lines.Where(c => c.Book == bookTwo).Count(), 0);
            Assert.AreEqual(cart.Lines.Count(), 2);
        }

        [TestMethod]
        public void CalculateCartTotal()
        {
            // Организация
            Book bookOne = new Book { BookId = 1, Name = "Book1", Price = 100 };
            Book bookTwo = new Book { BookId = 2, Name = "Book2", Price = 55 };

            Cart cart = new Cart();

            // Действие
            cart.AddItem(bookOne, 1);
            cart.AddItem(bookTwo, 1);
            cart.AddItem(bookOne, 5);
            decimal result = cart.ComputeTotalValue();

            // Утвержденик
            Assert.AreEqual(result, 655);
        }

        [TestMethod]
        public void CanClearContents()
        {
            // Организация
            Book bookOne = new Book { BookId = 1, Name = "Book1", Price = 100 };
            Book bookTwo = new Book { BookId = 2, Name = "Book2", Price = 55 };

            Cart cart = new Cart();

            // Действие
            cart.AddItem(bookOne, 1);
            cart.AddItem(bookTwo, 1);
            cart.AddItem(bookOne, 5);
            cart.Clear();

            // Утвержденик
            Assert.AreEqual(cart.Lines.Count(), 0);
        }
    }
}