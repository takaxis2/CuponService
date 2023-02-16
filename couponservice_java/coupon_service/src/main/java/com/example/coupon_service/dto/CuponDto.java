package com.example.coupon_service.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class CuponDto {
    private String name;
    private String type;
    private int discount;
    private int minPrice;
}
