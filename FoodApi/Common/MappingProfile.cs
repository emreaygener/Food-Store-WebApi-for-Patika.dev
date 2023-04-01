using AutoMapper;
using FoodApi.Entities;
using static FoodApi.Common.ViewModels;

namespace FoodApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Food, BasicFoodViewModel>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<Category,CategoryViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>();
            CreateMap<CreateFoodViewModel, Food>();
            CreateMap<CreateUserViewModel, User>();
            CreateMap<Transaction, DetailedTransactionViewModel>()
                .ForMember(dest => dest.Food, opt => opt.MapFrom(src => src.Food.Name))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Food.Price + "$"))
                .ReverseMap();
            CreateMap<PurchaseViewModel, Transaction>();
        }
    }
}
