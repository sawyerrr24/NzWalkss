using Microsoft.EntityFrameworkCore;
using NzWalks.Api.Data;
using NzWalks.Api.Models.Domain;

namespace NzWalks.Api.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public WalkRepository(NZWalksDbContext dbContext ) 
        {
            this.dbContext = dbContext;
        }



        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
          var existingWalk=  await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk != null)
            {
                dbContext.Walks.Remove(existingWalk);
                await dbContext.SaveChangesAsync();
                return existingWalk;

            }

            return null;
        }

        public async Task<List<Walk>> GetAllAsync(string filterOn = null, string? filterQuery = null)
        {
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            //filtering
            if(string.IsNullOrEmpty(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            return await walks.ToListAsync();

         // return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }


        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
             var exstingWalk=await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (exstingWalk == null)
            {
                return null;
            }


            exstingWalk.Name = walk.Name;
            exstingWalk.Description = walk.Description;
            exstingWalk.LengthInKm = walk.LengthInKm;
            exstingWalk.WalkImageUrl = walk.WalkImageUrl;
            exstingWalk.DifficultyId = walk.DifficultyId;
            exstingWalk.RegionId = walk.RegionId;


            await dbContext.SaveChangesAsync();
            return exstingWalk;
        }
    }
}
