using SessionService.Data.Repository.Interfaces;
using SessionService.Models;

namespace SessionService.Tests.Repositories;

public class SessionRepositoryTest
{
    private readonly List<SessionModel> _sessions;

    // private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mock<ISessionRepository> _repository = new Mock<ISessionRepository>();

    public SessionRepositoryTest()
    {
        List<PlayerModel> _players1 = new List<PlayerModel>()
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
        List<PlayerModel> _players2 = new List<PlayerModel>()
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

    [Fact]
    public async void CheckIfSessionAmountIsEqual()
    {
        _repository.Setup(m => m.GetAllSessions()).ReturnsAsync(_sessions);
        
    }
}
