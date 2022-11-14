using Microsoft.AspNetCore.Mvc;
using SessionService.Models;
using SessionService.Services.Interfaces;

namespace SessionService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _service;

    public PlayerController(IPlayerService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerModel>>> GetAllPlayers()
    {
        return await _service.GetAllPlayers();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<PlayerModel>>> GetAllPlayersBySessionId(Guid id)
    {
        return await _service.GetAllPlayersBySessionId(id);
    }

    [HttpPost("{gamePin}")]
    public async Task<ActionResult<PlayerModel>> AddPlayerToSession(PlayerModel playerModel, int gamePin)
    {
        return await _service.AddPlayerToSession(playerModel, gamePin);
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePlayerFromSession(Guid playerId, Guid sessionId)
    {
        return await _service.DeletePlayerFromSession(playerId, sessionId);
    }
}
