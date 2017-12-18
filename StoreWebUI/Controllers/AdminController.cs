using BusinessLogicDomain.Abstract;
using BusinessLogicDomain.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace StoreWebUI.Controllers
{
    /// <summary>
    /// Класс AdminController предоставляет панель администрирования товаров
    /// </summary>
    /// Create
    /// Read
    /// Update
    /// Delete
    public class AdminController : Controller
    {
        IBookRepository repository;

        public AdminController(IBookRepository repository) => this.repository = repository;

        /// <summary>
        /// Метод Index строит список товаров магазина
        /// </summary>
        /// <returns>Возращает список товаров для изменения</returns>
        [HttpGet]
        public ViewResult Index() => View(repository.Books);

        /// <summary>
        /// Метод Edit ищет товар для редактирования в базе данных
        /// </summary>
        /// <param name="bookId">Идентификатор редактируемой книги</param>
        /// <returns>Находит товар для редактирования</returns>
        [HttpGet, ActionName("Edit")]
        public ViewResult Read(Int32 bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            return View(book);
        }

        /// <summary>
        /// Метод Edit производит сохранения информации о товаре в базе данных
        /// </summary>
        /// <param name="book">Редактируемый товар</param>
        /// <returns>Возращает сообщение о редактировании информации о товаре и сохраняет результат в базу данных</returns>
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if(ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] = String.Format($"Изменение информации о книги \"{book.Name}\" сохранены");
                return RedirectToAction("Index");
            }
            else return View(book);
        }

        /// <summary>
        /// Метод Create открывает форму для добавления информации о новой книге
        /// </summary>
        /// <param name="bookId">Идентификатор новой книги</param>
        /// <returns>Возращает пустую форму</returns>
        [HttpGet]
        public ViewResult Create(Int32? bookId)
        {
            Book book = repository.Books.FirstOrDefault(predicate: b =>  Equals(b.BookId == bookId));
            return View(book); 
        }
        

        /// <summary>
        /// Метод Create производит сохранения информации о товаре в базе данных
        /// </summary>
        /// <param name="book">Добавляемый товар</param> 
        /// <returns>Возращает сообщение о добавлении информации о товаре и сохраняет результат в базу данных</returns>
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.CreateBook(book);
                TempData["message"] = String.Format($"Информации о книге \"{book.Name}\" добавленна");
                return RedirectToAction("Index");
            }
            else return View(book);
        }

        /// <summary>
        /// Метод Edit ищет товар для редактирования в базе данных
        /// </summary>
        /// <param name="bookId">Идентификатор редактируемой книги</param>
        /// <returns>Находит товар для редактирования</returns>
        [HttpGet]
        public ViewResult Delete(Int32 bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            return View(book);
        }

        /// <summary>
        /// Метод Delete производит удаление информации о товаре в базе данных
        /// </summary>
        /// <param name="book">Удаляемая книга</param>
        /// <returns>Возращает сообщение о удалении информации о товаре и сохраняет результат в базу данных</returns>
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteBook(book);
                TempData["message"] = String.Format($"Информации о книге \"{book.Name}\" удалена");
                return RedirectToAction("Index");
            }
            else return View(book);
        }
    }
}