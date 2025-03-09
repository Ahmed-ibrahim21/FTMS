using System.ComponentModel.DataAnnotations;

namespace FTMS.DTOs;

public class GroupDto
{
    [Required]
    [MaxLength(100)]
    public string GroupName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsPrivate { get; set; }
}
