using BusinessLogicDomain.Abstract;
using StoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreWebUI.Controllers
{
    /// <summary>
    /// Класс BooksController содержит логику получения и вывода информации о книгах
    /// </summary>
    public class BooksController : Controller
    {
        private IBookRepository repository;
        public Int32 pageSize = 4;

        /// <summary>
        /// Конструктор для заполнения репозитория книгами
        /// </summary>
        /// <param name="repo">Ссылкаьна репозиторий</param>
        public BooksController(IBookRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Метод List выводит товары на представление: GET: Books
        /// </summary>
        /// <param name="page">Указывает сколько книг отображать на странице, по умолчанию 1</param>
        /// <returns>Возращает представление книг</returns>
        [HttpGet]
        public ViewResult List(String genre, Int32 page = 1)
        {
            BooksListViewModel model = new BooksListViewModel
            {
                Books = repository.Books
                .Where(b => genre == null || b.Genre == genre)
                .OrderBy(book => book.BookId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = genre == null ? 
                        repository.Books.Count() : 
                        repository.Books.Where(book => book.Genre == genre).Count()
                },
                CurrentGenre = genre
            };
            return View(model);
        }
    }
}