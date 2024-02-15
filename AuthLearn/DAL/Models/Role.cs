using System.ComponentModel.DataAnnotations;

namespace AuthLearn.DAL.Models;

public class Role
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;  
}
