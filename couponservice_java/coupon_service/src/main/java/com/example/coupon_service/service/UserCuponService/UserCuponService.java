package com.example.coupon_service.service.UserCuponService;

import org.springframework.stereotype.Service;

import com.example.coupon_service.domain.Cupon;
import com.example.coupon_service.domain.User;
import com.example.coupon_service.domain.UserCupon;
import com.example.coupon_service.dto.Response;
import com.example.coupon_service.dto.UserCuponDto;
import com.example.coupon_service.repository.CuponRepository;
import com.example.coupon_service.repository.UserCuponRepository;
import com.example.coupon_service.repository.UserRepository;

import jakarta.transaction.Transactional;
import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
@Transactional
public class UserCuponService implements IUserCuponService {
    private final UserCuponRepository userCuponRepository;
    private final CuponRepository cuponRepository;
    private final UserRepository userRepository;

    @Override
    public Response<UserCupon> useCupon(UserCuponDto userCuponDto) {
        Response<UserCupon> res = new Response<>();
        res.setStatusCode(400);
        res.setMessaga("fail to use cupon");
        res.setSuccess(false);

        User user = userRepository.findById(userCuponDto.getUserId()).get();
        Cupon cupon = cuponRepository.findById(userCuponDto.getCuponId()).get();

        if(user == null || cupon == null) return res;

        UserCupon userCupon = userCuponRepository.findByCuponAndUserAndUsedFalse(cupon, user).get(0);
        if(userCupon == null) return res;

        userCupon.setUsed(true);

        userCuponRepository.save(userCupon);

        res.setData(userCupon);
        res.setMessaga("cupon used");
        res.setStatusCode(200);
        res.setSuccess(true);

        return res;
    }

}
