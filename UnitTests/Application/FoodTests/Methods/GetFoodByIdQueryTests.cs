using AutoMapper;
using FluentAssertions;
using FoodApi.Application.FoodOperations.Queries.GetFoodById;
using FoodApi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.TestSetup;

namespace UnitTests.Application.FoodTests.Methods
{
    public class GetFoodByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly IFoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetFoodByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenInvalidIdGiven_InvalidOperationException_ShouldBeThrown()
        {
            GetFoodByIdQuery query = new(_context, _mapper);
            query.Id = _context.Foods.OrderBy(x => x.Id).LastOrDefault().Id + 1;
            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Id given is NOT related to any food!");
        }
        [Fact]
        public void WhenValidIdGiven_InvalidOperationException_ShouldNotBeThrown()
        {
            GetFoodByIdQuery query = new(_context, _mapper);
            query.Id = _context.Foods.FirstOrDefault().Id;
            FluentActions.Invoking(() => query.Handle()).Invoke();
            var movie = _context.Foods.FirstOrDefault(x => x.Id == query.Id);
            movie.Should().NotBeNull();
        }
    }
}
