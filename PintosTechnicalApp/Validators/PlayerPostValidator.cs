using FluentValidation;
using PintosTechnicalApp.DTOs;
using PintosTechnicalApp.Interfaces.Repositories;

namespace PintosTechnicalApp.Validators;

public class PlayerPostValidator : AbstractValidator<PlayerPostDTO>
{
    public PlayerPostValidator(ITeamRepository teamRepository)
    {
        RuleFor(r => r.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(r => r.LastName).NotEmpty().MaximumLength(100);
        RuleFor(r => r.Nationality).NotEmpty().MaximumLength(100);
        RuleFor(r => r.Position).NotEmpty().MaximumLength(100);

        When(W => W.TeamId.HasValue, () => RuleFor(r => r.TeamId).Must(Id => teamRepository.GetById((Guid)Id).Result != null));
    }
}
