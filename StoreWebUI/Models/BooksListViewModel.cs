using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreWebUI.Models;
using BusinessLogicDomain.Entities;

namespace StoreWebUI.Models
{
    /// <summary>
    /// Класс BooksListViewModel являеться контейнером для книг
    /// </summary>
    public class BooksListViewModel
    {
        /// <summary>
        /// Свойство Books позволяет получить список книг
        /// </summary>
        public IEnumerable<Book> Books { get; set; }

        /// <summary>
        /// Свойство PagingInfo производит навигацию страниц где расположенны книги
        /// </summary>
        public PagingInfo PagingInfo { get; set; }

        /// <summary>
        /// Свойство CurrentGenre производит навигацию по категориям
        /// </summary>
        public String CurrentGenre { get; set; }
    }
}