using Microsoft.AspNetCore.Mvc;
using SessionService.Data.Repository.Interfaces;
using SessionService.Models;
using SessionService.Services.Interfaces;

namespace SessionService.Services;

public class PlayerService : ControllerBase, IPlayerService
{
    private readonly IPlayerRepository _repository;

    public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ActionResult<IEnumerable<PlayerModel>>> GetAllPlayers()
    {
        return await _repository.GetAllPlayers();
    }

    public async Task<ActionResult<IEnumerable<PlayerModel>>> GetAllPlayersBySessionId(Guid id)
    {
        return await _repository.GetAllPlayersBySessionId(id);
    }

    public async Task<ActionResult<PlayerModel>> AddPlayerToSession(PlayerModel playerModel, int gamePin)
    {
        return await _repository.AddPlayerToSession(playerModel, gamePin);
    }

    public async Task<IActionResult> DeletePlayerFromSession(Guid playerId, Guid sessionId)
    {
        return await _repository.DeletePlayerFromSession(playerId, sessionId);
    }
}
