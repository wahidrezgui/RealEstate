using FluentValidation;

namespace CleanArchitecture.Application.Proprietes.Commands.Create;

public class CreateProprieteCommandValidator : AbstractValidator<CreateProprieteCommand>
{
    public CreateProprieteCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}