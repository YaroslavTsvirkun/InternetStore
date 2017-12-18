using BusinessLogicDomain.Abstract;
using System.Collections.Generic;
using BusinessLogicDomain.Entities;
using BusinessLogicDomain.Concrete.Context;

namespace BusinessLogicDomain.Concrete.Repository
{
    /// <summary>
    /// Класс EFSnippingDetailRepository это хранилище книг
    /// </summary>
    public class EFSnippingDetailRepository : ISnippingDetailRepository
    {
        // EFDbContextSnippingDetail context = new EFDbContextSnippingDetail();

        /// <summary>
        /// Свойство SnippingDetail для чтения записей с базы данных, с таблицы SnippingDetails
        /// </summary>
        //IEnumerable<SnippingDetails> ISnippingDetailRepository.SnippingDetail
        //{
        //    get => context.SnippingDetail;
        //}
    }
}