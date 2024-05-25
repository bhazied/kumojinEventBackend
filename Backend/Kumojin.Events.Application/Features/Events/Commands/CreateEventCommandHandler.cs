using AutoMapper;
using Kumojin.Events.Application.interfaces;
using Kumojin.Events.Model.Entities.Event;
using MediatR;

namespace Kumojin.Events.Application;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Result<int>>
{
    private readonly IEventRepository _repository;
    private readonly IMapper _mapper;

    public CreateEventCommandHandler(IEventRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = _mapper.Map<Event>(request);
        @event.EventId = Guid.NewGuid().ToString();
        int result = await _repository.AddAsync(@event);
        if(result > 0)
        {
            return await Result<int>.SuccessAsync(result);
        }
        return await Result<int>.FailureAsync(["No Event Added"]);
        
    }
}
