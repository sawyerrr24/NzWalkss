using Microsoft.EntityFrameworkCore;
using NzWalks.Api.Models.Domain;
using static System.Net.WebRequestMethods;

namespace NzWalks.Api.Data
{
    public class NZWalksDbContext:DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext>dbContextOptions): base(dbContextOptions)
        {
            
        }



        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for difficulties
            //Easy,Medium,Hard

            var difficulties = new List<Difficulty>()
            {
               new Difficulty()
               {
                   Id = Guid.Parse("9a8abb6a-f43a-4ad2-a4ed-8b8f70a5d044"),
                   Name = "Easy"
               },

                 new Difficulty()
                 {
                      Id = Guid.Parse("b8089471-c863-4eb0-a411-657fd7df70ac"),
                     Name = "Medium"

                 },

                   new Difficulty()
                   {
                      Id = Guid.Parse("20625c99-f559-4ed4-bbe7-8dfafc7ab601"),
                      Name = "Hard"
                   },
            };


            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //seed data for Regions
            var regions = new List<Region>
            {
               new Region
               {
                   Id=Guid.Parse("2b43b626-e631-4958-abcb-b4756f94dacf"),
                   Name="Auckland",
                   Code="AKL",
                   RegionImageUrl= "https://images.pexels.com/photos/18915027/pexels-photo-18915027/free-photo-of-new-zealand-urban-landscape.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
               },

               new Region
               {
                   Id=Guid.Parse("10f1ee64-ecda-4de3-8741-215469e044c1"),
                   Name="Northland",
                   Code="NTL",
                   RegionImageUrl= null
               },

               new Region
               {
                   Id=Guid.Parse("87d5f0fc-a8a4-4013-a76d-3f5d46e51a85"),
                   Name="Bay Of Plenty",
                   Code="BOP",
                   RegionImageUrl= null
               },

               new Region
               {
                   Id=Guid.Parse("e4107db2-e8b7-42cc-a520-e442a32c7c0b"),
                   Name="Wellington",
                   Code="WGN",
                   RegionImageUrl= "https://images.pexels.com/photos/18915027/pexels-photo-18915027/free-photo-of-new-zealand-urban-landscape.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
               },

                new Region
               {
                   Id=Guid.Parse("c42de26e-d673-440e-812b-d5fab236a1af"),
                   Name="Nelson",
                   Code="NSN",
                   RegionImageUrl= "https://images.pexels.com/photos/18915027/pexels-photo-18915027/free-photo-of-new-zealand-urban-landscape.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
               },

                 new Region
               {
                   Id=Guid.Parse("4868d396-75ca-4eda-916d-3e2741d07f86"),
                   Name="Southland",
                   Code="STL",
                   RegionImageUrl= null
               },
            };


            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
