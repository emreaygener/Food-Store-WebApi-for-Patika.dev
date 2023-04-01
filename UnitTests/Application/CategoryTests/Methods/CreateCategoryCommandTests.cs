using AutoMapper;
using FluentAssertions;
using UnitTests.TestSetup;
using FoodApi.DbOperations;
using FoodApi.Entities;
using FoodApi.Application.CategoryOperations.Commands.CreateCategory;
using static FoodApi.Common.ViewModels;

namespace UnitTests.Application.CategoryTests.Methods
{
    public class CreateCategoryCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly FoodStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCategoryCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistsCategoryTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var category = new Category() { CategoryName = "Test" };
            _context.Categories.Add(category);
            _context.SaveChanges();

            CreateCategoryCommand command = new(_context);
            command.Model = new() { CategoryName = "Test" };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Category already available!");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Category_ShouldBeCreated()
        {
            //Arrange
            CreateCategoryCommand command = new(_context);
            CategoryViewModel model = new() { CategoryName = "Hobbit"};
            command.Model = model;
            //Act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            //Assert
            var category = _context.Categories.SingleOrDefault(category => category.CategoryName == model.CategoryName);
            category.Should().NotBeNull();
        }
    }
}
