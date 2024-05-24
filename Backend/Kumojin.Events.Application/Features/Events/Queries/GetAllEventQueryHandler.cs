using AutoMapper;
using Kumojin.Events.Application.interfaces;
using MediatR;

namespace Kumojin.Events.Application;

public class GetAllEventQueryHandler : IRequestHandler<GetAllEventQuery,Result<IEnumerable<EventDto>>>
{
    private readonly IEventRepository _repository;
    private readonly IMapper _mapper;
    public GetAllEventQueryHandler(IEventRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<EventDto>>> Handle(GetAllEventQuery request, CancellationToken cancellationToken)
    {
        var events = await _repository.GetAllAsync();
        return  Result<IEnumerable<EventDto>>.Success(_mapper.Map<IEnumerable<EventDto>>(events));
    }
}
