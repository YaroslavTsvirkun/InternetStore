using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace BusinessLogicDomain.Entities
{
    /// <summary>
    /// Класс Book предствляет модель книги
    /// </summary>
    [Table("Books", Schema = "dbo")]
    public class Book
    {
        /// <summary>
        /// Свойство BookId это идентификатор книги
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        [Key]
        public Int32? BookId { get; set; }

        /// <summary>
        /// Свойство Name это название книги
        /// </summary>
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название книги")]
        public String Name { get; set; }

        /// <summary>
        /// Свойство Author это автор книги
        /// </summary>
        [Display(Name = "Автор")]
        [Required(ErrorMessage = "Пожалуйста, введите имя автора")]
        public String Author { get; set; }

        /// <summary>
        /// Свойство Description это описание книги
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите описание книги")]
        public String Description { get; set; }

        /// <summary>
        /// Свойство Genre это жанр книги
        /// </summary>
        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, введите категорию книги")]
        public String Genre { get; set; }

        /// <summary>
        /// Свойство Price это цена книги
        /// </summary>
        [Display(Name = "Цена (грн)")]
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение цены")]
        public Int32 Price { get; set; }
    }
}