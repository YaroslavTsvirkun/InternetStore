using BusinessLogicDomain.Abstract;
using System.Collections.Generic;
using BusinessLogicDomain.Entities;
using BusinessLogicDomain.Concrete.Context;
using System.Web.Mvc;
using System;

namespace BusinessLogicDomain.Concrete.Repository
{   
    /// <summary>
    /// Класс EFBookRepository это хранилище книг
    /// </summary>
    public class EFBookRepository : IBookRepository
    {
        private EFDbContextBooks context = new EFDbContextBooks();

        /// <summary>
        /// Свойство Books для чтения записей с базы данных, с таблицы Books
        /// </summary>
        public IEnumerable<Book> Books
        {
            get => context.Books;
        }

        /// <summary>
        /// Метод CreateBook добавляет запись в БД
        /// </summary>
        /// <param name="book">Модель данных</param>
        public void CreateBook(Book book)
        {
            Book dbEntry = new Book();
            Entry(dbEntry, book);
            context.Books.Add(dbEntry);
            context.SaveChanges();
        }

        /// <summary>
        /// Метод DeleteBook удаляет запись с БД
        /// </summary>
        /// <param name="book">Модель данных</param>
        public void DeleteBook(Book book)
        {
            Book dbEntry = context.Books.Find(book.BookId);
            if (dbEntry != null)
            {
                context.Books.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Метод SaveBook сохраняет изменения в БД
        /// </summary>
        /// <param name="book">Модель данных</param>
        public void SaveBook(Book book)
        {
            if(book.BookId == 0) context.Books.Add(book);
            else
            {
                Book dbEntry = context.Books.Find(book.BookId);
                Entry(dbEntry, book);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Метод Entry проэцирует поля модели на поля БД
        /// </summary>
        /// <param name="dbEntry">Поля БД</param>
        /// <param name="book">Поля модели</param>
        private void Entry(Book dbEntry, Book book)
        {
            if (dbEntry != null)
            {
                dbEntry.Name = book.Name;
                dbEntry.Author = book.Author;
                dbEntry.Description = book.Description;
                dbEntry.Genre = book.Genre;
                dbEntry.Price = book.Price;
            }
        }
    }
}