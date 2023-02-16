package com.example.coupon_service.service.UserCuponService;

import com.example.coupon_service.domain.UserCupon;
import com.example.coupon_service.dto.Response;
import com.example.coupon_service.dto.UserCuponDto;

public interface IUserCuponService {
    public abstract Response<UserCupon> useCupon(UserCuponDto userCuponDto);
}
