using AutoMapper;
using EnglishProject.Data.DTOs;
using EnglishProject.Data.Entities;

namespace EnglishProject.Data
{
    public class MyMapper:Profile
    {
        public MyMapper()
        {
            CreateMap<Transaction, CreateTransactionDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, PostUserDto>().ReverseMap();
            CreateMap<Test, CreateTestDto>().ReverseMap();




        }
    }
}
