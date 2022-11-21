using Microsoft.AspNetCore.Mvc;
using SessionService.Data.Repository.Interfaces;
using SessionService.Models;

namespace SessionService.Tests.Repositories;

public class SessionRepositoryTest
{
    private readonly List<SessionModel> _sessions;
    private readonly List<PlayerModel> _players1;
    private readonly List<PlayerModel> _players2;

    private readonly SessionModel _sessionUpdated = new SessionModel()
    {
        Id = new Guid("7ea98e9a-7364-4b7a-af16-8a8b478ca58a"),
        GamePin = 112233,
        GameId = new Guid("1b6a49c1-52df-44e8-85dd-3a7a5d6a0779"),
        Started = true,
        CurrentPlayer = new Guid("ef6fc5e3-23d3-4ab2-95c6-4856b3b78bbd"),
        PlayerWon = null,
    };

    // private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mock<ISessionRepository> _sessionRepository = new Mock<ISessionRepository>();
    private readonly Mock<IPlayerRepository> _playerRepository = new Mock<IPlayerRepository>();

    
    public SessionRepositoryTest()
    {
        _players1 = new List<PlayerModel>()
        {
            new PlayerModel()
            {
                Id = new Guid("5d42f601-d31e-45d4-afee-619a6f751389"),
                Name = "Player 1",
                IsHost = true,
                SessionModelId = new Guid("7ea98e9a-7364-4b7a-af16-8a8b478ca58a"),
            },
            new PlayerModel()
            {
                Id = new Guid("ef6fc5e3-23d3-4ab2-95c6-4856b3b78bbd"),
                Name = "Player 2",
                IsHost = true,
                SessionModelId = new Guid("7ea98e9a-7364-4b7a-af16-8a8b478ca58a"),
            },
        };
        _players2 = new List<PlayerModel>()
        {
            new PlayerModel()
            {
                Id = new Guid("5d42f601-d31e-45d4-afee-619a6f751389"),
                Name = "Player 1",
                IsHost = true,
                SessionModelId = new Guid("b17fd75f-a0c5-416d-a26d-b56d9731d665"),
            },
            new PlayerModel()
            {
                Id = new Guid("ef6fc5e3-23d3-4ab2-95c6-4856b3b78bbd"),
                Name = "Player 2",
                IsHost = true,
                SessionModelId = new Guid("b17fd75f-a0c5-416d-a26d-b56d9731d665"),
            },
        };

        _sessions = new List<SessionModel>()
        {
            new SessionModel()
            {
                Id = new Guid("7ea98e9a-7364-4b7a-af16-8a8b478ca58a"),
                GamePin = 123456,
                GameId = new Guid("1b6a49c1-52df-44e8-85dd-3a7a5d6a0779"),
                Started = false,
                CurrentPlayer = new Guid("ef6fc5e3-23d3-4ab2-95c6-4856b3b78bbd"),
                PlayerWon = null,
                Players = _players1,
            },
            new SessionModel()
            {
                Id = new Guid("b17fd75f-a0c5-416d-a26d-b56d9731d665"),
                GamePin = 987654,
                GameId = new Guid("1b6a49c1-52df-44e8-85dd-3a7a5d6a0779"),
                Started = true,
                CurrentPlayer = new Guid("ef6fc5e3-23d3-4ab2-95c6-4856b3b78bbd"),
                PlayerWon = null,
                Players = _players2,
            },
        };
    }

    /// <summary>
    /// Check if the session amount is 2
    /// </summary>
    [Fact]
    public async void CheckIfSessionAmountIsEqual()
    {
        _sessionRepository.Setup(m => m.GetAllSessions()).ReturnsAsync(_sessions);
        
        var _service = new SessionService.Services.SessionService(_sessionRepository.Object);

        var session = await _service.GetAllSessions();
        
        Assert.Equal(2, _sessions.Count);
    }

    /// <summary>
    /// Check if the sessions are of SessionModel
    /// </summary>
    /// <param name="guid"></param>
    [Theory]
    [InlineData("7ea98e9a-7364-4b7a-af16-8a8b478ca58a")]
    [InlineData("b17fd75f-a0c5-416d-a26d-b56d9731d665")]
    public async void CheckIfSessionsAreOfSessionModel(Guid guid)
    {
        // Creating a mock for the GetSpecificGame function
        _sessionRepository.Setup(m => m.GetSessionById(It.IsAny<Guid>()))
            .ReturnsAsync((Guid id) => _sessions.FirstOrDefault(g => g.Id == guid));
            
        var _service = new SessionService.Services.SessionService(_sessionRepository.Object);

        var session = await _service.GetSessionById(guid);
            
        // Check if all the 
        Assert.IsType<SessionModel>(session.Value);
    }

    [Theory]
    [InlineData("7ea98e9a-7364-4b7a-af16-8a8b478ca58a")]
    public void UpdateSessionModel(Guid guid)
    {
        // Creating a mock for the GetSpecificGame function
        _sessionRepository.Setup(m => m.UpdateSession(It.IsAny<Guid>(), _sessionUpdated));

        var _service = new SessionService.Services.SessionService(_sessionRepository.Object);

        var newSession = _service.UpdateSession(guid, _sessionUpdated);

        Assert.True(newSession != null);
    }
}
