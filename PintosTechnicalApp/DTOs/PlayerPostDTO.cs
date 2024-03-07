using AutoMapper;
using PintosTechnicalApp.Entities;
using PintosTechnicalApp.Interfaces;

namespace PintosTechnicalApp.DTOs;

public class PlayerPostDTO : IMapFrom<Player>
{
    public Guid? TeamId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Position { get; set; }
    public string? Nationality { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<PlayerPostDTO, Player>().ReverseMap();
}
