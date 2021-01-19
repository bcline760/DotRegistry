using System;
using DotRegistry.Core;

namespace DotRegistry.Contract
{
    public static class ContractExtensions
    {
        /// <summary>
        /// Make the necessary slug as the "application key" for the record.
        /// </summary>
        /// <param name="entity">The entity to generate the slug</param>
        public static void Slugify(this EntityContract entity)
        {
            entity.Slug = entity.SlugProperties.MakeSlug();
        }
    }
}
