package com.example.coupon_service.controller;

import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.coupon_service.domain.UserCupon;
import com.example.coupon_service.dto.Response;
import com.example.coupon_service.dto.UserCuponDto;
import com.example.coupon_service.service.UserCuponService.IUserCuponService;

import lombok.RequiredArgsConstructor;

@RestController
@RequestMapping("/User")
@RequiredArgsConstructor
public class UserController {
    private final IUserCuponService userCuponService;

    @PutMapping
    public Response<UserCupon> useCupon(@RequestBody UserCuponDto userCuponDto){
        return userCuponService.useCupon(userCuponDto);
    }
}
