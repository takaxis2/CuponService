package com.example.coupon_service.domain;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity()
@Data
@NoArgsConstructor
@AllArgsConstructor
@Table(name = "cupons")
public class Cupon {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @Column(name = "name", table = "cupons")
    private String name;
    @Column(name = "`type`", table = "cupons")
    private String type;
    @Column(name = "discount", table = "cupons")
    private int discount;
    @Column(name = "minPrice", table = "cupons")
    private int minPrice;
    @Column(name = "issued", table = "cupons")
    private boolean issued;
    @Column(name = "`delete`", table = "cupons")
    private boolean delete;
}
