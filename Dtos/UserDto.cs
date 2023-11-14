using System.ComponentModel.DataAnnotations;
using AutoMapper;
using XTradesRecrutationTask.Models;

namespace XTradesRecrutationTask.Dtos;

public class UserDto
{    
    [Required]
    public required string Name { get; set; }
    [Required]
	[EmailAddress]
    public required string Email { get; set; }
    [Required]
    [RegularExpression("^[0-9]{9}", ErrorMessage = "Number is required and must have 9 digits (ex. 123456789).")]
    public required string Phone { get; set;}
}

public class UserAutomapperProfile : Profile
{
    public UserAutomapperProfile()
    {
        CreateMap<UserDto, User>();
    }
}