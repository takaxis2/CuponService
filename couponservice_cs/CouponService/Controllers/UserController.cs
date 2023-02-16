using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CouponService.Models;
using CouponService.Services.UserService;

namespace CouponService.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase{

    private readonly ILogger<UserController> _logger;

    private readonly IUserService _service;
    public UserController(ILogger<UserController> logger, IUserService service){
        _logger = logger;
        _service = service;
    }

    [HttpPut]
    public async Task<IActionResult> UseCupon(){
        return null;
    }
}