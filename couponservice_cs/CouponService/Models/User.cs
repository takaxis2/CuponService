namespace CouponService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long id {get; set;}
    public string? name {get; set;}

    // public List<UserCupon>? userCupons {get; set;}
    
}