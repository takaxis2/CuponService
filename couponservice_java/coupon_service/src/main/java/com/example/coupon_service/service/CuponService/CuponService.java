package com.example.coupon_service.service.CuponService;

import java.util.Collection;
import java.util.List;
import java.util.Objects;

import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;

import com.example.coupon_service.domain.Cupon;
import com.example.coupon_service.domain.User;
import com.example.coupon_service.domain.UserCupon;
import com.example.coupon_service.dto.CuponDto;
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
public class CuponService implements ICuponService {
    private final CuponRepository cuponRepository;
    private final UserRepository userRepository;
    private final UserCuponRepository userCuponRepository;

    @Override
    public Response<Collection<Cupon>> get(int page) {
        
        Response<Collection<Cupon>> res = new Response<>();
        res.setMessaga("invalid page number");
        res.setStatusCode(400);
        res.setSuccess(false);

        PageRequest pageRequest = PageRequest.of(page, 10);
        List<Cupon> cupons = cuponRepository.findByDeleteFalse(pageRequest);

        if(cupons == null) return res;

        res.setData(cupons);
        res.setMessaga("found cupons");
        res.setStatusCode(200);
        res.setSuccess(true);

        return res;
    }

    @Override
    public Response<Cupon> post(CuponDto cuponDto) {
        
        Response<Cupon> res = new Response<>();
        res.setMessaga("fail to create cupon");
        res.setStatusCode(400);
        res.setSuccess(false);

        Cupon exist = cuponRepository.findByName(cuponDto.getName());
        if(exist != null){
            res.setMessaga("cupon name already exist");
            return res;
        }
        if(cuponDto.getDiscount() < 0 || cuponDto.getMinPrice() < 0){
            res.setMessaga("wrong price/discount");
            return res;
        }
        if(Objects.equals(cuponDto.getType(), "amount"))
            if(cuponDto.getDiscount() > cuponDto.getMinPrice()) return res;
        else if(Objects.equals(cuponDto.getType(), "rate"))
            if(cuponDto.getDiscount() > 50) return res;
        else return res;

        Cupon cupon = new Cupon();
        cupon.setDelete(false);
        cupon.setIssued(false);
        cupon.setDiscount(cuponDto.getDiscount());
        cupon.setMinPrice(cuponDto.getMinPrice());
        cupon.setName(cuponDto.getName());
        cupon.setType(cuponDto.getType());

        cuponRepository.save(cupon);

        res.setData(cupon);
        res.setMessaga("cupon created");
        res.setStatusCode(200);
        res.setSuccess(true);

        return res;
    }

    @Override
    public Response<UserCupon> issue(UserCuponDto userCuponDto) {
        
        Response<UserCupon> res = new Response<>();
        res.setMessaga("fail to delete cupon");
        res.setStatusCode(400);
        res.setSuccess(false);

        User user = userRepository.findById(userCuponDto.getUserId()).get();
        Cupon cupon = cuponRepository.findById(userCuponDto.getCuponId()).get();

        if(user == null || cupon == null) return res;

        UserCupon userCupon = new UserCupon();
        userCupon.setUsed(false);
        userCupon.setUser(user);
        userCupon.setCupon(cupon);

        userCuponRepository.save(userCupon);

        res.setData(userCupon);
        res.setStatusCode(200);
        res.setMessaga("cupon issued");
        res.setSuccess(true);

        return res;
    }

    @Override
    public Response<Cupon> delete(Long id) {

        Response<Cupon> res = new Response<>();
        res.setMessaga("fail to delete cupon");
        res.setStatusCode(400);
        res.setSuccess(false);

        Cupon cupon = cuponRepository.findById(id).get();
        
        if(cupon.isIssued()) return res;

        cupon.setDelete(true);
        cuponRepository.save(cupon);

        res.setData(cupon);
        res.setMessaga("cupon deleted");
        res.setStatusCode(200);
        res.setSuccess(true);

        return res;
    }
}
