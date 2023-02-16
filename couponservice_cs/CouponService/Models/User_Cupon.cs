namespace CouponService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

// [Keyless]
public class UserCupon{
    // [ForeignKey("id")]
    // public virtual User? userId {get; set;}
    
    // [ForeignKey("id")]
    // public virtual Cupon? cuponId {get; set;}

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long id {get; set;}

    public User user {get; set;}
    public Cupon cupon {get; set;}

    public bool used {get; set;}
}