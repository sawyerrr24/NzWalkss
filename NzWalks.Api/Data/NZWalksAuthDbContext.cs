using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NzWalks.Api.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext>options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);

            var readerRoleId = "dbf8c562-252a-416e-a16b-5f0727db3d0f";
            var writerRoleId = "c73af0f1-5e9d-4f3e-9d15-8e34a46c21aa";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),

                },

                new IdentityRole
                {
                    Id = writerRoleId, 
                    ConcurrencyStamp = writerRoleId,
                    Name= "Writer",
                    NormalizedName="Writer".ToUpper(),
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
