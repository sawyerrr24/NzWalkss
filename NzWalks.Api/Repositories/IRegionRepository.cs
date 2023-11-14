using NzWalks.Api.Models.Domain;
using NzWalks.Api.Models.DTO;

namespace NzWalks.Api.Repositories
{
    public interface IRegionRepository
    {
      Task<List<Region>> GetAllAsync();

        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> CreateAsync(Region region);

        Task<Region?> UpdateAsync(Guid id,Region region);

        Task<Region?> DeleteAsync(Guid id);
        
    }
}
