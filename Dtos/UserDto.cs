using AutoMapper;
using XTradesRecrutationTask.Models;

namespace XTradesRecrutationTask.Dtos;

public class UserDto
{    
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set;}
}

public class UserAutomapperProfile : Profile
{
    public UserAutomapperProfile()
    {
        CreateMap<UserDto, User>();
    }
}