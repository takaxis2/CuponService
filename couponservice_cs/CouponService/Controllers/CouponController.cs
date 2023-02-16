using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CouponService.Models;
using CouponService.Services.CuponService;
using CouponService.Dtos;

namespace CouponService.Controllers;

[ApiController]
[Route("[controller]")]
public class CuponController : ControllerBase
{

    public readonly ICuponService _service;
    public readonly ILogger<CuponController> _logger;

    public CuponController(ILogger<CuponController> logger, ICuponService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("{page}")]
    public async Task<ActionResult<Response<IEnumerable<Cupon>>>> getCupons(int page)
    {
        // if (_context.Cupons == null)
        // {
        //     return NotFound();
        // }
        // return await _context.Cupons
        // .ToListAsync();
        var result = await _service.getCupons(page);

        if(result.Data == null) return NotFound(result);
        
        return Ok(result);
    }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<Cupon>> getCupon(long id)
    // {
    //     if (_context.Cupons == null)
    //     {
    //         return NotFound();
    //     }
    //     var cupon = await _context.Cupons.FindAsync(id);

    //     if (cupon == null)
    //     {
    //         return NotFound();
    //     }

    //     return cupon;
    // }

    // PUT: api/Cupon/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<ActionResult<Response<Cupon>>> PutCupon(long id, CuponDto cuponDto)
    {
        // if (id != cupon.id)
        // {
        //     return BadRequest();
        // }

        // _context.Entry(cupon).State = EntityState.Modified;

        // try
        // {
        //     await _context.SaveChangesAsync();
        // }
        // catch (DbUpdateConcurrencyException)
        // {
        //     if (!CuponExists(id))
        //     {
        //         return NotFound();
        //     }
        //     else
        //     {
        //         throw;
        //     }
        // }

        return NoContent();
    }

    // // POST: api/Cupon
    // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Response<Cupon>>> PostCupon(CuponDto cuponDto)
    {
        var cupon = await _service.postCupons(cuponDto);

        if (cupon.Data == null)
        {
            // return Problem("parameters are incorrect");
            return ValidationProblem();
        }

        // return CreatedAtAction("GetCupon", new { id = cupon.id }, cupon);
        return Created("cupon created",cupon);
    }

    [HttpPost("issue")]
    public async Task<ActionResult<Response<UserCupon>>> PostUserCupon(UserCuponDto userCuponDto) {
        var userCupon = await _service.postUserCupon(userCuponDto);

        if(userCupon.Data == null) return ValidationProblem();
        
        return userCupon;
    }
    // DELETE: api/Cupon/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Response<Cupon>>> DeleteCupon(long id)
    {
        
        var cupon = await _service.deleteCupons(id);

        if (cupon.Data == null)
        {
            // return NotFound();
            return Problem("no content");
        }


        return NoContent();
    }

    // private bool CuponExists(long id)
    // {
    //     return (_context.Cupons?.Any(e => e.id == id)).GetValueOrDefault();
    // }
}

