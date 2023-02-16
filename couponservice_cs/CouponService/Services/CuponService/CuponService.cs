using CouponService.Dtos;
using CouponService.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CouponService.Services.CuponService;

public class CuponService : ICuponService
{
    public readonly CServiceContext _context;

    public CuponService(CServiceContext context){
        _context = context;
    }

    // public Response CheckCuponContext(Response res){
    //     if(_context.Cupons == null)
        
    //     return res;
    // }

    public async Task<Response<Cupon>> deleteCupons(long id)
    {
        var res = new Response<Cupon>();
            res.Success = false;
            res.StatusCode = 400;

        if(_context.Cupons == null){
            res.Message = "no cupons";
            return res;
        }

        var result = _context.Cupons.Single(c => c.id == id);

        if(result == null){
            res.Message = "cupon not exist";
            return res;
        }

        if(result.issued){
            res.Message = "cupon already issued";
            return res;
        }

        result.delete = true;
        await _context.SaveChangesAsync();

        res.Success = true;
        res.Data = result;
        res.Message = "delete success";
        res.StatusCode = 200;

        return res;
    }

    public async Task<Response<IEnumerable<Cupon>>> getCupons(int page)
    {
        var res = new Response<IEnumerable<Cupon>>();

        if(_context.Cupons == null){
            res.Success = false;
            res.Message = "no cupons";
            res.StatusCode = 400;
            return res;
        }

        var cupons =  _context.Cupons
        // .Select(c => new {
        //     c.id,
        //     c.delete,
        //     c.discount,
        //     c.issued,
        //     c.minPrice,
        //     c.name,
        //     c.type
        // })
        .Skip(page * 10)
        .Take(10)
        .Where(c => c.delete == false)
        .ToList();

        res.Data = cupons;
        res.Success = true;
        res.Message = "find success";
        res.StatusCode =200;
        
        return res;
    }

    public async Task<Response<Cupon>> postCupons(CuponDto cuponDto)
    {
        var res = new Response<Cupon>();

        res.Success = false;
        res.Message = "no cupons";
        res.StatusCode =400;
        if(_context.Cupons == null){
            return res;
        }

        var exist = _context.Cupons.FirstOrDefault(c => c.name == cuponDto.name);
        if(exist != null) return res;
        if(cuponDto.discount < 0 || cuponDto.minPrice < 0) return res;
        if(cuponDto.type == "amount")
            if(cuponDto.discount > cuponDto.minPrice) return res;
        else if(cuponDto.type == "rate")
            if(cuponDto.discount > 50) return res;
        else return res;

        Cupon cupon = new Cupon();
        cupon.delete=false;
        cupon.issued = false;
        cupon.discount = cuponDto.discount;
        cupon.minPrice = cuponDto.minPrice;
        cupon.name = cuponDto.name;
        cupon.type = cuponDto.type;
        
        _context.Cupons.Add(cupon);
        await _context.SaveChangesAsync();

        res.Data = cupon;
        res.Success = true;
        res.Message = "new cupon established";
        res.StatusCode =200;

        return res;
    }

    public async Task<Response<UserCupon>> postUserCupon(UserCuponDto userCuponDto)
    {
        var res  = new Response<UserCupon>();
        res.Success = false;
        res.Message = "issuing failed";
        res.StatusCode =400;
        if(_context.userCupon == null) return res;

        // user, cupon객체 찾기
        var user = _context.Users.SingleOrDefault(u => u.id == userCuponDto.userId);
        var cupon = _context.Cupons.SingleOrDefault(c => c.id == userCuponDto.cuponId);

        // 없으면 에러
        if(user == null || cupon == null) return res;

        var userCupons = _context.userCupon.Where(uc => uc.user.Equals(user) && uc.cupon.Equals(cupon) && !uc.used).Count();

        if(userCupons >= 10) return res;

        cupon.issued = true;

        var userCupon = new UserCupon();
        userCupon.user = user;
        userCupon.cupon = cupon;
        userCupon.used = false;

        await _context.userCupon.AddAsync(userCupon);
        await _context.SaveChangesAsync();

        res.Success = true;
        res.Message = "cupon issuing success";
        res.Data = userCupon;
        res.StatusCode =200;

        return res;
    }

    public async Task<Response<IEnumerable<Cupon>>> putCupon(long id, Cupon cupon)
    {
        throw new NotImplementedException();
    }
}