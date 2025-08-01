using AutoMapper;
using UserService.Application.DTOs.UserDTOs;
using UserService.Domain.Entities;

namespace UserService.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserForCreationDTO>().ReverseMap();
        CreateMap<User, UserForResultDTO>().ReverseMap();
        CreateMap<User, UserForUpdateDTO>().ReverseMap();
    }
}
