using Microsoft.AspNetCore.Mvc;
using SessionService.Data.Repository.Interfaces;
using SessionService.Models;
using SessionService.Services.Interfaces;

namespace SessionService.Services;

public class SessionService : ControllerBase, ISessionService
{
    private readonly ISessionRepository _repository;

    public SessionService(ISessionRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ActionResult<IEnumerable<SessionModel>>> GetAllSessions()
    {
        return await _repository.GetAllSessions();
    }

    public async Task<ActionResult<SessionModel>> GetSessionById(Guid id)
    {
        return await _repository.GetSessionById(id);
    }

    public async Task<IActionResult> UpdateSession(Guid id, SessionModel session)
    {
        return await _repository.UpdateSession(id, session);
    }

    public async Task<ActionResult<SessionModel>> CreateSession(SessionModel session)
    {
        return await _repository.CreateSession(session);
    }

    public async Task<IActionResult> DeleteSession(Guid id)
    {
        return await _repository.DeleteSession(id);
    }
}
