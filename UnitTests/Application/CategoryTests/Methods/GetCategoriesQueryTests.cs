using AutoMapper;
using FluentAssertions;
using FoodApi.Application.CategoryOperations.Queries.GetCategories;
using FoodApi.Application.FoodOperations.Queries.GetFoods;
using FoodApi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.TestSetup;

namespace UnitTests.Application.CategoryTests.Methods
{
    public class GetCategoriesQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly FoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCategoriesQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenExecuted_Categories_ShouldBeReturned()
        {
            GetCategoriesQuery query = new(_context, _mapper);
            FluentActions.Invoking(() => query.Handle()).Should().NotThrow<Exception>();
        }
    }
}
