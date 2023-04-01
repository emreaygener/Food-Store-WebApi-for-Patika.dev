using AutoMapper;
using FoodApi.Common;
using FoodApi.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public FoodStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<FoodStoreDbContext>().UseInMemoryDatabase(databaseName: "MovieStoreTestDB").Options;
            Context = new FoodStoreDbContext(options);
            Context.Database.EnsureCreated();
            Context.Initialize();
            Context.SaveChanges();
            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}
