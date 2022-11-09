using Microsoft.AspNetCore.Mvc;
using SessionService.Models;

namespace SessionService.Services.Interfaces;

public interface IPlayerService
{
    Task<ActionResult<IEnumerable<PlayerModel>>> GetAllPlayers();
    Task<ActionResult<IEnumerable<PlayerModel>>> GetAllPlayersBySessionId(Guid id);
    Task<ActionResult<PlayerModel>> AddPlayerToSession(PlayerModel playerModel);
    Task<IActionResult> DeletePlayerFromSession(Guid playerId, Guid sessionId);
}
