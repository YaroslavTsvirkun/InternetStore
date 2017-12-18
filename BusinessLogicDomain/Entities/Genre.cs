using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLogicDomain.Entities
{
    /// <summary>
    /// Класс Genre представляет модель категории товара
    /// </summary>
    public class Genres
    {
        /// <summary>
        /// Свойство GenreId это идентификатор товара
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        [Key]
        public Int32? GenreId { get; set; }

        /// <summary>
        /// Свойство Genre это категория товара
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, введите категорию товара")]
        public String Genre { get; set; }

        /// <summary>
        /// Свойство Name это описание категории товара
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание категории товара")]
        [Required(ErrorMessage = "Пожалуйста, введите описание категории товара")]
        public String Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ParidID")]
        [ForeignKey("GenreId")]
        public IEnumerable<Genres> ParidId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "PrevidID")]
        [ForeignKey("GenreId")]
        public IEnumerable<Genres> PrevidId { get; set; }

        /// <summary>
        /// Свойстово Availability это доступность категории
        /// </summary>
        [ForeignKey("AvailabilityId")]
        public IEnumerable<Availabilitys> Availability { get; set; }

        /// <summary>
        /// Свойство Attribute индификтор внешнего ключа на таблицу SEO атрибутов SearchEngineOptimization
        /// </summary>
        [ForeignKey("SeoId")]
        public IEnumerable<SearchEngineOptimization> Attribute { get; set; }
    }
}