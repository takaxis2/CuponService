package com.example.coupon_service.repository;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import com.example.coupon_service.domain.Cupon;


public interface CuponRepository extends JpaRepository<Cupon, Long>{
    @Query("select c from Cupon c")
    List<Cupon> findByDeleteFalse(Pageable pageable);
    Cupon findByName(String name);
}
