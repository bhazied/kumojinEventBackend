using AutoMapper;
using Kumojin.Events.Application.interfaces;
using MediatR;

namespace Kumojin.Events.Application;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Result<int>>
{
    private readonly IDbContext _context;
    private readonly IMapper _mapper;

    public CreateEventCommandHandler(IDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        return await Result<int>.SuccessAsync(1);
    }
}
