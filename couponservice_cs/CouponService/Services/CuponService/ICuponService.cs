namespace CouponService.Services.CuponService;

using CouponService.Dtos;
using CouponService.Models;

public interface ICuponService{
    Task<Response<IEnumerable<Cupon>>> getCupons(int page);
    Task<Response<IEnumerable<Cupon>>> putCupon(long id, Cupon cupon);
    Task<Response<Cupon>> postCupons(CuponDto cuponDto);
    Task<Response<Cupon>> deleteCupons(long id);
    Task<Response<UserCupon>> postUserCupon(UserCuponDto userCuponDto);

}
