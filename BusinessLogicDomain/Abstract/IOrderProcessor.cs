using BusinessLogicDomain.Entities;

namespace BusinessLogicDomain.Abstract
{
    /// <summary>
    /// Интерфейс IOrderProcessor производит обработку заказов
    /// </summary>
    public interface IOrderProcessor
    {
        /// <summary>
        /// Метод ProcessOrder для обработки заказов
        /// </summary>
        /// <param name="cart">Объект корзина</param>
        /// <param name="shippingDetails">Информация о заказе</param>
        void ProcessOrder(Cart cart, SnippingDetails shippingDetails);
    }
}