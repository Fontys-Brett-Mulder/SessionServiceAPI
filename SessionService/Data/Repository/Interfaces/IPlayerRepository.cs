using Microsoft.AspNetCore.Mvc;
using SessionService.Models;

namespace SessionService.Data.Repository.Interfaces;

public interface IPlayerRepository
{
    Task<ActionResult<IEnumerable<PlayerModel>>> GetAllPlayers();
    Task<ActionResult<IEnumerable<PlayerModel>>> GetAllPlayersBySessionId(Guid id);
    Task<ActionResult<PlayerModel>> AddPlayerToSession(PlayerModel playerModel, int gamePin);
    Task<IActionResult> DeletePlayerFromSession(Guid playerId, Guid sessionId);
}
