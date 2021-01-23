using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using log4net;

using DotRegistry.Contract;
using DotRegistry.Core.Logging;
using DotRegistry.Interface.Repository;
using DotRegistry.Interface.Service;

namespace DotRegistry.Service
{
    public abstract class EntityService<TE> : IEntityService<TE>
        where TE : EntityContract
    {
        protected EntityService(IRepository<TE> repository, ILog log)
        {
            Repository = repository;
            Log = log;
        }

        public virtual async Task DeleteAsync(string slug)
        {
            await Repository.DeleteAsync(slug);
        }

        public virtual async Task<IEnumerable<TE>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        public virtual async Task<TE> GetAsync(string slug)
        {
            return await Repository.GetAsync(slug);
        }

        public virtual async Task SaveAsync(TE entity)
        {
            await Repository.SaveAsync(entity);
        }

        /// <summary>
        /// Get a reference to the underlying repository
        /// </summary>
        protected IRepository<TE> Repository { get; }

        /// <summary>
        /// 
        /// </summary>
        protected ILog Log { get; }
    }
}
