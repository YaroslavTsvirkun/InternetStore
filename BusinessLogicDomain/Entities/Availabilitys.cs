using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLogicDomain.Entities
{
    /// <summary>
    /// Класс Availabilitys предоставляет модель доступности категорий
    /// </summary>
    public class Availabilitys
    {
        /// <summary>
        /// Свойство AvailabilityId это идентификатор доступности категории
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        [Key]
        public Int32 AvailabilityId { get; set; }

        /// <summary>
        /// Свойстово Availability это доступность категории
        /// </summary>
        [Display(Name = "Дрступна ли категория?")]
        [Required(ErrorMessage = "Пожалуйста, введите доступность категории: Да или Нет")]
        public Boolean Availability { get; set; }
    }
}