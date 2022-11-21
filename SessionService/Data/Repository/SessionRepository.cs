using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessionService.Data.Repository.Interfaces;
using SessionService.Models;

namespace SessionService.Data.Repository;

public class SessionRepository : ControllerBase, ISessionRepository
{
    
    private readonly ApplicationDbContext _db;

    public SessionRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    /// <summary>
    /// Getting all sessions
    /// </summary>
    /// <returns></returns>
    public async Task<ActionResult<IEnumerable<SessionModel>>> GetAllSessions()
    {
        if (_db.Session == null)
        {
            return NotFound();
        }

        var sessions = await _db.Session.Include(c => c.Players).ToListAsync();
        
        return sessions;
    }

    /// <summary>
    /// Getting an specific session
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ActionResult<SessionModel>> GetSessionById(Guid id)
    {
        if (_db.Session == null)
        {
            return NotFound();
        }

        var session = await _db.Session.FirstAsync(x => x.Id == id);

        if (session == null)
        {
            return NotFound();
        }

        return session;
    }

    /// <summary>
    /// Update a session
    /// </summary>
    /// <param name="id"></param>
    /// <param name="session"></param>
    /// <returns></returns>
    public async Task<IActionResult> UpdateSession(Guid id, SessionModel session)
    {
        if (id != session.Id)
        {
            return BadRequest("Cannot find any session with id: " + id);
        }

        _db.Entry(session).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SessionModelExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return Ok(session);
    }

    /// <summary>
    /// Creating a new session
    /// </summary>
    /// <param name="session"></param>
    /// <returns></returns>
    public async Task<ActionResult<SessionModel>> CreateSession(SessionModel session)
    {
        if (_db.Session == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Session'  is null.");
        }
        
        _db.Session.Add(session);
        await _db.SaveChangesAsync();

        return CreatedAtAction("GetSessionById", new {id = session.Id}, session);
    }

    /// <summary>
    /// Deleting a session
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> DeleteSession(Guid id)
    {
        if (_db.Session == null)
        {
            return NotFound();
        }
        
        var session = await _db.Session.FindAsync(id);

        if (session == null)
        {
            return NotFound();
        }

        _db.Session.Remove(session);
        await _db.SaveChangesAsync();

        return Ok();

    }
    
    /// <summary>
    /// Check if a session exists
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private bool SessionModelExists(Guid id)
    {
        return (_db.Session?.Any(e => e.Id == id)).GetValueOrDefault();
    }
    
    /// <summary>
    /// Get all players from a specific session
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ActionResult<IEnumerable<PlayerModel>>> GetPlayersFromSession(Guid id)
    {
        var players = await _db.Session.Where(s => s.Id == id).SelectMany(m => m.Players).ToListAsync();

        return players;
    }
    
}
