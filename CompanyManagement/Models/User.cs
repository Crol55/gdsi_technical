using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManagement.Models;

public class User
{
    [Column("user_id")]
    public Guid UserId { get; init; } = Guid.NewGuid();

    [Column("user_code")]
    [StringLength(50)]
    public string UserCode { get; set; }

    [Column("full_name")]
    [StringLength(200)]
    public string FullName { get; set; }

    [Column("COMPANY_id")]
    public Guid CompanyId { get; set; }  // Foreign key

    public Company Company { get; set; } //reference-navigation 
}
