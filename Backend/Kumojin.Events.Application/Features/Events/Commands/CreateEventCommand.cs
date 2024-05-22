using MediatR;

namespace Kumojin.Events.Application;

public class CreateEventCommand : IRequest<Result<int>>
{

}
