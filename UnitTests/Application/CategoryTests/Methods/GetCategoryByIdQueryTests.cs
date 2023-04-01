using AutoMapper;
using FluentAssertions;
using UnitTests.TestSetup;
using FoodApi.DbOperations;
using FoodApi.Application.CategoryOperations.Queries.GetCategoryById;

namespace UnitTests.Application.CategoryTests.Methods
{
    public class GetCategoryByIdQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly FoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCategoryByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenInvalidIdGiven_InvalidOperationException_ShouldBeThrown()
        {
            GetCategoryByIdQuery query = new(_context, _mapper);
            query.Id = _context.Categories.OrderBy(x => x.Id).LastOrDefault().Id + 1;
            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Wrong Id!");
        }
        [Fact]
        public void WhenValidIdGiven_InvalidOperationException_ShouldNotBeThrown()
        {
            GetCategoryByIdQuery query = new(_context, _mapper);
            query.Id = _context.Categories.FirstOrDefault().Id;
            FluentActions.Invoking(() => query.Handle()).Invoke();
            var movie = _context.Categories.FirstOrDefault(x => x.Id == query.Id);
            movie.Should().NotBeNull();
        }
    }
}
