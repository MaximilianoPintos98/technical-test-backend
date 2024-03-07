using AutoMapper;
using PintosTechnicalApp.Entities;
using PintosTechnicalApp.Interfaces;

namespace PintosTechnicalApp.DTOs;

public class TrainerDTO : BaseDTO, IMapFrom<Trainer>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Nationality { get; set; }
    public TeamDTO? Team { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<Trainer, TrainerDTO>().ReverseMap();
}
