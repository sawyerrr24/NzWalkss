using NzWalks.Api.Models.Domain;
using System.Globalization;

namespace NzWalks.Api.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string filterOn=null,string? filterQuery=null);
        Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk?> UpdateAsync(Guid id,Walk walk);
        
        Task<Walk?> DeleteAsync(Guid id);
    }
}
