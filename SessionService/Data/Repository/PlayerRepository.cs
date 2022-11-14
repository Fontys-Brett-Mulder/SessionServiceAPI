using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessionService.Data.Repository.Interfaces;
using SessionService.Models;

namespace SessionService.Data.Repository;

public class PlayerRepository : ControllerBase, IPlayerRepository
{
    private readonly ApplicationDbContext _db;

    public PlayerRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Getting all players
    /// </summary>
    /// <returns></returns>
    public async Task<ActionResult<IEnumerable<PlayerModel>>> GetAllPlayers()
    {
        return await _db.Player.ToListAsync();
    }

    /// <summary>
    /// Get all players from specific session
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ActionResult<IEnumerable<PlayerModel>>> GetAllPlayersBySessionId(Guid id)
    {
       return await _db.Player.Where(x => x.SessionModelId == id).ToListAsync();
    }

    /// <summary>
    /// Add player to session
    /// </summary>
    /// <param name="playerModel"></param>
    /// <param name="gamePin"></param>
    /// <returns></returns>
    public async Task<ActionResult<PlayerModel>> AddPlayerToSession(PlayerModel playerModel, int gamePin)
    {
        if (!CheckIfSessionWithGamePinExists(gamePin))
        {
            return NotFound();
        }

        playerModel.SessionModelId = GetGuidFromGamePin(gamePin);
        
        _db.Player.Add(playerModel);
        await _db.SaveChangesAsync();
        
        return Ok();
    }

    /// <summary>
    /// Delete player from session
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="sessionId"></param>
    /// <returns></returns>
    public async Task<IActionResult> DeletePlayerFromSession(Guid playerId, Guid sessionId)
    {
        var playerToDelete = _db.Player.FirstOrDefault(x => (x.Id == playerId) && (x.SessionModelId == sessionId));
        
        if (playerToDelete == null)
        {
            return NotFound();
        }

        _db.Player.Remove(playerToDelete);
        await _db.SaveChangesAsync();

        return Ok();
    }

    /// <summary>
    /// Check if the Session exists
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private bool CheckIfSessionWithGamePinExists(int gamePin)
    {
        var session = _db.Session.FirstOrDefault(x => x.GamePin == gamePin);

        if (session == null)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Get Guid from gamepin
    /// </summary>
    /// <param name="gamePin"></param>
    /// <returns></returns>
    private Guid GetGuidFromGamePin(int gamePin)
    {
        var session = _db.Session.FirstOrDefault(x => x.GamePin == gamePin);

        return session.Id;
    }
}
