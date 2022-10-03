using System.ComponentModel.DataAnnotations;

namespace GamesService.Models
{
    public class GameModel
    {
        [Key] public Guid Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Difficulty { get; set; }
        public int? MinPlayers { get; set; }
        public int? MaxPlayers { get; set; }
    }
}
