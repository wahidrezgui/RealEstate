using FluentValidation;

namespace CleanArchitecture.Application.Proprietes.Queries;

public class GetPropertyDetailsQueryValidator : AbstractValidator<GetPropertyDetailsQuery>
{
    public GetPropertyDetailsQueryValidator()
    {
        RuleFor(x => x.propertyid)
            .GreaterThanOrEqualTo(1).WithMessage("property ref should at least greater than or equal to 1.");
    }
}