using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using log4net;

using DotRegistry.Contract;
using DotRegistry.Core.Logging;
using DotRegistry.Interface;

namespace DotRegistry.Service
{
    public abstract class EntityService<TE> : IEntityService<TE>
        where TE : EntityContract
    {
        protected EntityService(IRepository<TE> repository)
        {
            Repository = repository;
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

        protected IRepository<TE> Repository { get; }
    }
}
