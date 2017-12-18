using BusinessLogicDomain.Abstract;
using BusinessLogicDomain.Entities;
using StoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreWebUI.Controllers
{
    /// <summary>
    /// Класс CartController предназначен для работы с козиной
    /// </summary>
    public class CartController : Controller
    {
        /// <summary>
        /// Ссылка для роботы с моделью Book
        /// </summary>
        private IBookRepository repository;

        /// <summary>
        /// Ссылка для работы со службой отправки заказов по эл.почте
        /// </summary>
        private IOrderProcessor orderProcessor;

        public CartController(IBookRepository repository, IOrderProcessor orderProcessor)
        {
            this.repository = repository;
            this.orderProcessor = orderProcessor;
        } 

        /// <summary>
        /// Метод Index выводит корзину на представление
        /// </summary>
        /// <param name="returnUrl">Ссылка на товар</param>
        /// <returns></returns>
        public ViewResult Index(Cart cart, String returnUrl) => View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });

        /// <summary>
        /// Метод AddToCart позволяет добавить товар в корзину
        /// </summary>
        /// <param name="bookId">Идентификатор товара</param>
        /// <param name="returnUrl">Ссылка на страницу</param>
        /// <returns>Возращает ссылку перенаправления на заданое действие</returns>
        public RedirectToRouteResult AddToCart(Cart cart, Int32 bookId, String returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            if (book != null) cart.AddItem(book, 1);

            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Метод RemoveFromCart позволяет удалить товар из корзины
        /// </summary>
        /// <param name="bookId">Идентификатор товара</param>
        /// <param name="returnUrl">Ссылка на страницу</param>
        /// <returns>Возращает ссылку перенаправления на заданое действие</returns>
        public RedirectToRouteResult RemoveFromCart(Cart cart, Int32 bookId, String returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            if (book != null) cart.RemoveLine(book);

            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Метод Summery производит сводку по корзине
        /// </summary>
        /// <param name="cart">Ссылка на корзину</param>
        /// <returns>Возращает итого по всей корзине</returns>
        public PartialViewResult Summary(Cart cart) => PartialView(cart);

        /// <summary>
        /// Метод Checkout производит отправку формы заказа пользователю
        /// </summary>
        /// <returns>Возращает форму заказа</returns>
        [HttpGet]
        public ViewResult Checkout() => View(new SnippingDetails());

        /// <summary>
        /// Метод Checkout производит отправку данных о заказа на сервер
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="snippingDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Checkout(Cart cart, SnippingDetails snippingDetails)
        {
            if (cart.Lines.Count() == 0) ModelState.AddModelError("", "Извините, корзина пуста!");
            if(ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, snippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else return View(new SnippingDetails());
        }
    }
}