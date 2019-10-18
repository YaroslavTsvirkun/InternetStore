﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicDomain.Entities
{
    /// <summary>
    /// Класс SnippingDetails содержит сведения о заказе
    /// </summary>
    public class SnippingDetails
    {
        /// <summary>
        /// Свойство FirstName хранит имя пользователя
        /// </summary>
        [Required(ErrorMessage = "Укажите Ваше имя")]
        [Display(Name = "Имя")]
        public String FirstName { get; set; }

        /// <summary>
        /// Свойство LastName хранит фамилию пользователя
        /// </summary>
        [Required(ErrorMessage = "Укажите Вашу фамилию")]
        [Display(Name = "Фамилия")]
        public String LastName { get; set; }

        /// <summary>
        /// Свойство LineOne хранит адресс доставки
        /// </summary>
        [Required(ErrorMessage = "Укажите адресс доставки")]
        [Display(Name = "Первый адрес")]
        public String LineOne { get; set; }
        [Display(Name = "Второй адрес")]
        public String LineTwo { get; set; }
        [Display(Name = "Третий адрес")]
        public String LineThree { get; set; }

        /// <summary>
        /// Свойство City хранит название города
        /// </summary>
        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Город")]
        public String City { get; set; }

        /// <summary>
        /// Свойство Country хранит название страны
        /// </summary>
        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "Страна")]
        public String Country { get; set; }

        /// <summary>
        /// Свойство Phone хранит номер телефона пользователя
        /// </summary>
        [Required(ErrorMessage = "Укажите номер телефона")]
        [StringLength(18, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 5)]
        [Display(Name = "Номер телефона")]
        [Phone]
        public String Phone { get; set; }

        /// <summary>
        /// Свойство Email хранит адрес эл. почты пользувателя
        /// </summary>
        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public String Email { get; set; }

        /// <summary>
        /// Свойство GiftWrap хранит указатель на надобность подарочной упаковки
        /// </summary>
        public Boolean GiftWrap { get; set; }
    }
}