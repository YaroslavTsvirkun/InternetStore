using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicDomain.Entities
{
    /// <summary>
    /// Класс Cart представляет модель корзины покупок
    /// </summary>
    public class Cart
    {
        // Список товаров помещенных в корзину
        private List<CartLine> lineCollection = new List<CartLine>();

        /// <summary>
        /// Свойство Lines позволяет обращатся к содержимому корзины
        /// </summary>
        public IEnumerable<CartLine> Lines { get => lineCollection; }

        /// <summary>
        /// Метод AddItem для добавления товаров в корзину
        /// </summary>
        /// <param name="book">Товар</param>
        /// <param name="quantity">Количество</param>
        public void AddItem(Book book, Int32 quantity)
        {
            CartLine line = lineCollection
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null) lineCollection.Add(new CartLine { Book = book, Quantity = quantity });
            else line.Quantity += quantity;
            
        }

        /// <summary>
        /// Метод RemoveLine для удаления товаров с корзины
        /// </summary>
        /// <param name="book">Товар</param>
        public void RemoveLine(Book book) => lineCollection.RemoveAll(del => del.Book.BookId == book.BookId);

        /// <summary>
        /// Метод ComputeTotalValue для вычисления общей стоимости товаров
        /// </summary>
        /// <returns>Возращает сумму денег</returns>
        public decimal ComputeTotalValue() => lineCollection.Sum(e => e.Book.Price * e.Quantity);

        /// <summary>
        /// Метод Clear для очистки корзины путем удаления всех элементов
        /// </summary>
        public void Clear() => lineCollection.Clear();
    }

    /// <summary>
    /// Класс CartLine представляет товар выбранный пользователем, а также его количество
    /// </summary>
    public class CartLine
    {
        /// <summary>
        /// Свойство Book представляет выбранный товар
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// Свойство Quantiry представляет количество товара
        /// </summary>
        public Int32 Quantity { get; set; }
    }
}