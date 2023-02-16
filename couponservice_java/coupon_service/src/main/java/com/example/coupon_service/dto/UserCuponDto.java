package com.example.coupon_service.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class UserCuponDto {
    private Long userId;
    private Long cuponId;
}
