using BusinessLogicDomain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreWebUI.Controllers
{
    /// <summary>
    /// Класс NavigationController содержит логику для построения меню
    /// </summary>
    public class NavigationController : Controller
    {
        private IBookRepository repository;

        public NavigationController(IBookRepository repository) => this.repository = repository;

        /// <summary>
        /// Метод Menu выводит меню сортировки книг по категориям
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public PartialViewResult Menu(String genre = null)
        {
            ViewBag.SelectedGenre = genre;
            IEnumerable<String> genres = repository.Books
                .Select(book => book.Genre)
                .Distinct()
                .OrderBy(x => x);
           
            return PartialView("FlexMenu", genres);
        }
    }
}