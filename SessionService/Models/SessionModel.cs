using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SessionService.Models;

public class SessionModel
{
    [Key] public Guid Id { get; set; }
    public List<PlayerModel> Players { get; set; }
    public Guid GameId { get; set; }
    [DefaultValue(false)] public bool Started { get; set; }
    public Guid? CurrentPlayer { get; set; }
    public Guid? PlayerWon { get; set; }
}
