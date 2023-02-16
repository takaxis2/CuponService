package com.example.coupon_service.dto;

import lombok.Data;

@Data
public class Response<T> {
    private T data;
    private String messaga;
    private boolean success;
    private int statusCode;

}
