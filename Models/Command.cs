using System.ComponentModel.DataAnnotations;

namespace VersedApi.Models;

public class Command
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DataType(DataType.Text)]
    [MinLength(3)]
    public string CommandString { get; set; } = string.Empty;
    [DataType(DataType.Text)]
    [MinLength(10)]
    public string Description { get; set; } = string.Empty;
    [DataType(DataType.Text)]
    public string Platform { get; set; } = string.Empty;
    [DataType(DataType.Date)]
    public DateOnly CreatedOn { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
}
