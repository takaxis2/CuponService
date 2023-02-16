namespace CouponService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Cupon{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long id {get;  set;}
    
    public string? name {get; set;}
    public string? type {get; set;}
    public int discount {get; set;}
    public int minPrice {get; set;}
    public bool issued {get; set;}
    public bool delete {get; set;}
    // public List<UserCupon>? userCupons {get; set;}

}