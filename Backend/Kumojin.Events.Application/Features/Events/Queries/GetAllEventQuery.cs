using MediatR;

namespace Kumojin.Events.Application;

public class GetAllEventQuery: IRequest<Result<IEnumerable<EventDto>>>
{

}
