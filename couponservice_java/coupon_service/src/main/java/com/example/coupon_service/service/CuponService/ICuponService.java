package com.example.coupon_service.service.CuponService;

import java.util.Collection;

import com.example.coupon_service.domain.Cupon;
import com.example.coupon_service.domain.UserCupon;
import com.example.coupon_service.dto.CuponDto;
import com.example.coupon_service.dto.Response;
import com.example.coupon_service.dto.UserCuponDto;

public interface ICuponService {
    public abstract Response<Collection<Cupon>> get(int page);
    public abstract Response<Cupon> post(CuponDto cuponDto);
    public abstract Response<UserCupon> issue(UserCuponDto userCuponDto);
    public abstract Response<Cupon> delete(Long id);
}
