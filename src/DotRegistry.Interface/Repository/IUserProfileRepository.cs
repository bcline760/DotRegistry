using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DotRegistry.Contract;
namespace DotRegistry.Interface.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        /// <summary>
        /// Get a profile by their login
        /// </summary>
        /// <param name="login">Their GitHub login</param>
        /// <returns>A profile matching their login or null if none found</returns>
        Task<UserProfile> GetByLogin(string login);
    }
}
