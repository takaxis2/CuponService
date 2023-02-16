package com.example.coupon_service.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.coupon_service.domain.Cupon;
import com.example.coupon_service.domain.User;
import com.example.coupon_service.domain.UserCupon;

public interface UserCuponRepository extends JpaRepository<UserCupon, Long> {
    List<UserCupon> findByCuponAndUserAndUsedFalse(Cupon cupon, User user );
}
