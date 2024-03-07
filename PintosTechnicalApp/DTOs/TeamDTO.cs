using AutoMapper;
using PintosTechnicalApp.Entities;
using PintosTechnicalApp.Interfaces;

namespace PintosTechnicalApp.DTOs;

public class TeamDTO : BaseDTO, IMapFrom<Team>
{
    public string? Name { get; set; }
    public string? City { get; set; }
    public TrainerDTO? Trainer { get; set; }
    public StadiumDTO? Stadium { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<Team, TeamDTO>().ReverseMap();
}
