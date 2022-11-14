using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SessionService.Models;

public class PlayerModel
{
    [Key] public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    [DefaultValue(false)] public bool IsHost { get; set; }
    
    [ForeignKey("SessionModel")]
    public Guid SessionModelId { get; set; }
}
