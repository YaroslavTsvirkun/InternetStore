using BusinessLogicDomain.Entities;
using System.Data.Entity;

namespace BusinessLogicDomain.Concrete.Context
{
    /// <summary>
    /// Класс EFDbContextSnippingDetail осуществляет подключение к базе данных посредством EF
    /// </summary>
    public class EFDbContextSnippingDetail : DbContext
    {
        // public EFDbContextSnippingDetail() : base("EFDbContext") { }

        /// <summary>
        /// Свойство SnippingDetail проэцирует поля модели User на поля таблицы SnippingDetails базы данных
        /// </summary>
        // public DbSet<SnippingDetails> SnippingDetail { get; set; }
    }
}