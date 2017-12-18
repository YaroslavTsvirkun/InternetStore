using BusinessLogicDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreWebUI.Models
{
    /// <summary>
    /// Класс CartIndexViewModel представляет модель 
    /// для построения метода-действия Index в CartController
    /// которое будет отображать содержимое корзины
    /// </summary>
    public class CartIndexViewModel
    {
        /// <summary>
        /// Свойство Cart содержит информацию об объекте Cart
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Свойство ReturnUrl содержит URL для отображения, 
        /// когда пользователь щелкает на кнопке "Продолжить покупку"
        /// </summary>
        public String ReturnUrl { get; set; }
    }
}