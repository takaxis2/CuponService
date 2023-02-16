package com.example.coupon_service.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.coupon_service.domain.User;

public interface UserRepository extends JpaRepository<User, Long> {
    
}
