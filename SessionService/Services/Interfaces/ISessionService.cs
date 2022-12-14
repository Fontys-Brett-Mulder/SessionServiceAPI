using Microsoft.AspNetCore.Mvc;
using SessionService.Models;

namespace SessionService.Services.Interfaces;

public interface ISessionService
{
    Task<ActionResult<IEnumerable<SessionModel>>> GetAllSessions();
    Task<ActionResult<SessionModel>> GetSessionById(Guid id);
    Task<IActionResult> UpdateSession(Guid id, SessionModel sessionModel);
    Task<ActionResult<SessionModel>> CreateSession(SessionModel sessionModel);
    Task<IActionResult> DeleteSession(Guid id);
    Task<ActionResult<IEnumerable<PlayerModel>>> GetPlayersFromSession(int gamepin);
    Task<ActionResult<SessionModel>> GetSessionByGamePin(int gamepin);
    Task<ActionResult<bool>> StartGameByPin(int gamepin);
}
