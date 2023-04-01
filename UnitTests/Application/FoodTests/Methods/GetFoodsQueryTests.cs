using AutoMapper;
using FluentAssertions;
using FoodApi.Application.FoodOperations.Queries.GetFoods;
using FoodApi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.TestSetup;

namespace UnitTests.Application.FoodTests.Methods
{
    public class GetFoodsQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly FoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetFoodsQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenExecuted_Foods_ShouldBeReturned()
        {
            GetFoodsQuery query = new(_context, _mapper);
            FluentActions.Invoking(() => query.Handle()).Should().NotThrow<Exception>();
        }
    }
}
