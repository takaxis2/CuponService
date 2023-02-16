using Microsoft.EntityFrameworkCore;

namespace CouponService.Models;

public class CServiceContext : DbContext{

    public CServiceContext(DbContextOptions<CServiceContext> options) : base(options){}

    public DbSet<User>? Users {get; set;}
    public DbSet<Cupon>? Cupons {get; set;}
    public DbSet<UserCupon>? userCupon {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseMySql(ServerVersion.AutoDetect("server=127.0.0.1; user=root; password=1q2w3e4r!;database=coupon_service"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        // modelBuilder.Entity<Cupon>()
        // .HasMany(c => c.userCupons)
        // .WithOne();

        // modelBuilder.Entity<User>()
        // .HasMany(u => u.userCupons)
        // .WithOne();
    }
    
}