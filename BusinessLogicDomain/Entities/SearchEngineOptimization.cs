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
    /// Класс SearchEngineOptimization предоставляет модель SEO атрибутов
    /// </summary>
    [Table("SearchEngineOptimization", Schema = "dbo")]
    public class SearchEngineOptimization
    {
        /// <summary>
        /// Свойство SEOId это идентификатор атрибута
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        [Key]
        [Column("SEO_ID")]
        public Int32 SeoId { get; set; }

        /// <summary>
        /// Свойство TagId это индификатор внешнего ключа на таблицу Tag
        /// </summary>
        [ForeignKey("TagId")]
        [Column("TAG_ID")]
        public IEnumerable<Tag> TagId { get; set; }

        /// <summary>
        /// Свойство TagContent для хранения контента атрибутов
        /// </summary>
        [Column("TAG_CONTENT")]
        public String TagContent { get; set; }

        /// <summary>
        /// Свойство TagProperty для хранения свойст в атрибутов
        /// </summary>
        [Column("TAG_PROPERTY")]
        public String TagProperty { get; set; }
    }

    /// <summary>
    /// Класс Tag предоставляет модель атрибутов
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Свойство TagId это идентификатор тэга атрибута
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        [Key]
        [Column("TAG_ID")]
        public Int32 TagId { get; set; }

        /// <summary>
        /// Свойство TagName это имя тэга атрибута
        /// </summary>
        [Column("TAG_NAME")]
        public String TagName { get; set; }
    }
}