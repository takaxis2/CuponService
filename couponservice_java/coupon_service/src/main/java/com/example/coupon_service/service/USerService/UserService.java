package com.example.coupon_service.service.USerService;

import org.springframework.stereotype.Service;

import com.example.coupon_service.repository.UserRepository;

import jakarta.transaction.Transactional;
import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
@Transactional
public class UserService {
    public final UserRepository userRepository;
}
