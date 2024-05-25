using AutoMapper;
using Kumojin.Events.Application;
using Kumojin.Events.Application.interfaces;
using Kumojin.Events.Model.Entities.Event;
using NSubstitute;
using FluentAssertions;
using System.Reflection;
namespace Kumojin.Events.Test.Application;

public class CreateEventCommandTest
{
    private readonly IEventRepository _repositoryMock;
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public CreateEventCommandTest()
    {
        _repositoryMock = Substitute.For<IEventRepository>();
        var profile = new EventMapping();
        _configuration =
            new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetAssembly(typeof(IEventRepository))));
        _mapper = new Mapper(_configuration);
    }

    [Fact]
    public async Task Handle_Should_ReturnError_WhenNameIsToLong()
    {
        //Arrang
        CreateEventCommand invalidCommand = new(
            "je suis un nom de très lomg et je dépasse les trente deux caractères (32)",
            "Description","Program","Location","UTC-4",DateTime.Today, DateTime.Today
        );
        CreateEventCommandHandler _handler = new CreateEventCommandHandler(_repositoryMock, _mapper);
        //Act
        var result = await _handler.Handle(invalidCommand, default);
        //Assert
        result.Succeeded.Should().BeFalse();
        result.ErrorMessage.Should().Contain("No Event Added");
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccess_WhenRequestIsOK()
    {
        //Arrang
        CreateEventCommand Command = new ("Name","Description","Program","Location","UTC-4",DateTime.Today, DateTime.Today);       
        var @event = _mapper.Map<Event>(Command);
        _repositoryMock.AddAsync(@event).Returns(1);
        CreateEventCommandHandler _handler = new CreateEventCommandHandler(_repositoryMock, _mapper);
        //Act
        var result = await _handler.Handle(Command, default);
        //Assert
        result.Succeeded.Should().BeTrue();
        result.ErrorMessage.Should().BeEmpty();
        result.Data.Should().BeGreaterThan(0);
    }
}
