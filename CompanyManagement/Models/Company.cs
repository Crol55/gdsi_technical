
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManagement.Models;

public class Company
{
    [Column("id")]
    public Guid Id { get; init; } = Guid.NewGuid();

    [Column("name")]
    public string Name { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; } = false;
}
