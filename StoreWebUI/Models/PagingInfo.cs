using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreWebUI.Models
{
    /// <summary>
    /// Класс PagingInfo для построения навигации по страницам магазина книг
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// Свойство TotalItems указывает на общее количество книг
        /// </summary>
        public Int32 TotalItems { get; set; }

        /// <summary>
        /// Свойство ItemsPerPage указывает количество книг на странице
        /// </summary>
        public Int32 ItemsPerPage { get; set; }

        /// <summary>
        /// Свойство CurrentPage указывает номер текущей страницы
        /// </summary>
        public Int32 CurrentPage { get; set; }

        /// <summary>
        /// Свойство TotalPages указывает общее количество страниц
        /// </summary>
        public Int32 TotalPages 
        {
            get => (Int32)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }
}