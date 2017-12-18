using BusinessLogicDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreWebUI.Infrastructure
{
    public class CartModelBinder : IModelBinder
    {
        private const String sessionKey = "Cart";
        /// <summary>
        /// Метод BindModel создает объект модели предметной области
        /// </summary>
        /// <param name="controllerContext">Обеспечивает доступ к информации которой располагает класс контролер</param>
        /// <param name="bindingContext">Предоставляет сведения об объекте модели</param>
        /// <returns></returns>
        object IModelBinder.BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = null;
            if(controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }
            if(cart == null)
            {
                cart = new Cart();
                if(controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            return cart;
        }
    }
}