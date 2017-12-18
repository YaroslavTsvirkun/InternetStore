using BusinessLogicDomain.Entities;
using System.Data.Entity;


namespace BusinessLogicDomain.Concrete.Context
{
    /// <summary>
    /// Класс EFDbContextBooks осуществляет подключение к базе данных посредством EF
    /// </summary>
    public class EFDbContextBooks : DbContext  
    {
        public EFDbContextBooks() : base("EFDbContext") { }

        /// <summary>
        /// Свойство Books проэцирует поля модели Book на поля таблицы Books базы данных
        /// </summary>
        public DbSet<Book> Books { get; set; }
    }
}