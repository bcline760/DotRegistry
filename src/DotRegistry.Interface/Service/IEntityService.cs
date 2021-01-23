using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DotRegistry.Contract;

namespace DotRegistry.Interface.Service
{
    public interface IEntityService<TE>
        where TE: EntityContract
    {
        /// <summary>
        /// Delete's a record from the database by marking it inactive. Record persists
        /// </summary>
        /// <param name="slug">The slug to delete</param>
        /// <returns></returns>
        Task DeleteAsync(string slug);

        /// <summary>
        /// Returns all collections from the database. This could be an expensive procedure. Handle with care
        /// </summary>
        /// <returns>All records in the given table</returns>
        Task<IEnumerable<TE>> GetAllAsync();

        /// <summary>
        /// Gets a single document matching the slug
        /// </summary>
        /// <param name="slug">The slug of the document to match</param>
        /// <returns></returns>
        Task<TE> GetAsync(string slug);

        /// <summary>
        /// Save a record to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task SaveAsync(TE entity);
    }
}
