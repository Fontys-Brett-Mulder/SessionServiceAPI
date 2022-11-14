using SessionService.Models;
using SessionService.Data.Repository;
using SessionService.Data.Repository.Interfaces;


namespace SessionService.Tests;

public class SessionServiceSessionTest
{
    
    private readonly List<SessionModel> _sessions;

    // private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mock<ISessionRepository> _repository = new Mock<ISessionRepository>();
    
    [Fact]
    public void Test1()
    {
    }
}
