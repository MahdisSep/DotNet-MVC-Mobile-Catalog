using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models;

public class Mobile
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string? Name { get; set; }
    
    [Column(TypeName = "varchar(150)")]
    public string? Description { get; set; }

    [Column(TypeName = "varchar(10)")]
    public string? Color { get; set; }

    // public string? Image { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public string? MobileImage { get; set;}
}