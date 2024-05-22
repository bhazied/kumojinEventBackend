using FluentValidation;

namespace Kumojin.Events.Application;

public class CreateEventCommandValidator : AbstractValidator<EventDto>
{
    public CreateEventCommandValidator()
    {
        
    }
}
