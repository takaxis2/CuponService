package com.example.coupon_service.controller;

import java.util.Collection;

import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.coupon_service.domain.Cupon;
import com.example.coupon_service.domain.UserCupon;
import com.example.coupon_service.dto.CuponDto;
import com.example.coupon_service.dto.Response;
import com.example.coupon_service.dto.UserCuponDto;
import com.example.coupon_service.service.CuponService.ICuponService;

import lombok.RequiredArgsConstructor;

@RestController
@RequestMapping("/Cupon")
@RequiredArgsConstructor
public class CuponContoller {
    private final ICuponService cuponService;

    @GetMapping(value = "/{page}")
    public Response<Collection<Cupon>> get(@PathVariable int page){
        return cuponService.get(page);
    }

    @PostMapping
    public Response<Cupon> post(@RequestBody CuponDto cuponDto){
        return cuponService.post(cuponDto);
    }

    @PostMapping("/issue")
    public Response<UserCupon> issue(@RequestBody UserCuponDto userCuponDto){
        return cuponService.issue(userCuponDto);
    }

    @DeleteMapping("/{id}")
    public Response<Cupon> delete(@PathVariable Long id){
        return cuponService.delete(id);
    }
}
