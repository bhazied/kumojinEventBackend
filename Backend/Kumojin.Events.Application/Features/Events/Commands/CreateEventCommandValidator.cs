using FluentValidation;

namespace Kumojin.Events.Application;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(v => v.Name).NotEmpty().MaximumLength(32);
    }
}
