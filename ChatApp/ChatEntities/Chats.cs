using System.ComponentModel.DataAnnotations;

namespace ChatEntities;

public class Chats
{
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string Username { get; set; }
    public string? Message { get; set; }
    public DateTime SendDate { get; set; }

    public Chats()
    {
        SendDate = DateTime.Now;
    }
}
