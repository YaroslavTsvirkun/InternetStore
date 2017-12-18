using BusinessLogicDomain.Entities;
using System;
using System.Collections.Generic;

namespace BusinessLogicDomain.Abstract
{
    /// <summary>
    /// Интерфейс IBookRepository предназначен для роботы с моделью Book
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Свойство Books предназначенное для извлечения объектов Book
        /// </summary>
        IEnumerable<Book> Books { get; }

        /// <summary>
        /// Метод SaveBook предназначен для сохранения редактирования описания товара в базе данных
        /// </summary>
        /// <param name="book">Редактируемая книга</param>
        void SaveBook(Book book);

        /// <summary>
        /// Метод CreateBook предназначен для добавления книги в базу данных
        /// </summary>
        /// <param name="book">Добавляемая книга</param>
        void CreateBook(Book book);

        /// <summary>
        /// Метод DeleteBook предназначен для удаления книги с базы данных
        /// </summary>
        /// <param name="book">Идентификатор товара или удаляемая книга</param>
        void DeleteBook(Book book);
    }
}