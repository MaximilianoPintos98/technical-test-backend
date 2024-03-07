using AutoMapper;
using PintosTechnicalApp.Entities;
using PintosTechnicalApp.Interfaces;

namespace PintosTechnicalApp.DTOs;

public class StadiumDTO : BaseDTO, IMapFrom<Stadium>
{
    public string? Name { get; set; }
    public string? City { get; set; }
    public TeamDTO? Team { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<Stadium, StadiumDTO>().ReverseMap();
}
