using Microsoft.AspNetCore.Mvc;
using SessionService.Models;
using SessionService.Services.Interfaces;

namespace SessionService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessionController : ControllerBase
{
    private readonly ISessionService _service;

    public SessionController(ISessionService service)
    {
        _service = service;
    }
    
    // Get all articles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SessionModel>>> GetAllSessions()
    {
        return await _service.GetAllSessions();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SessionModel>> GetSessionById(Guid id)
    {
        return await _service.GetSessionById(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSession(Guid id, SessionModel session)
    {
        return await _service.UpdateSession(id, session);
    }

    [HttpPost]
    public async Task<ActionResult<SessionModel>> PostSessionModel(SessionModel session)
    {
        return await _service.CreateSession(session);
    }
    
    // DELETE: api/SessionControllerTest/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSessionModel(Guid id)
    {
        return await _service.DeleteSession(id);
    }

}
