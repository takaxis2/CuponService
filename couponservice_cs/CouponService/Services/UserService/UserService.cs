namespace CouponService.Services.UserService;

using System.Threading.Tasks;
using CouponService.Models;
using CouponService.Dtos;

public class UserService: IUserService { 

    public readonly CServiceContext _context;

    public UserService(CServiceContext context){
        _context = context;
    }

    public async Task<Response<UserCupon>> PostUserCupon(UserCuponDto userCuponDto)
    {
        var res = new Response<UserCupon>();

        res.Success = false;
        res.Message = "no userCupon data";
        res.StatusCode=400;
        if (_context.userCupon == null) return res;

        var user = _context.Users.SingleOrDefault(u => u.id == userCuponDto.userId);
        var cupon = _context.Cupons.SingleOrDefault(c => c.id == userCuponDto.cuponId);

        if(user == null || cupon == null) return res;
        

        var userCupon = _context.userCupon
        .Single(uc => uc.user.Equals(user) && uc.cupon.Equals(cupon));

        userCupon.used = true;

        await _context.SaveChangesAsync();

        res.Success = true;
        res.StatusCode=200;
        res.Data = userCupon;
        res.Message ="cupon used";

        return res;
    }
}