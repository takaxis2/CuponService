namespace CouponService.Services.UserService;

using CouponService.Dtos;
using CouponService.Models;

public interface IUserService{

    public Task<Response<UserCupon>> PostUserCupon(UserCuponDto userCuponDto);
}