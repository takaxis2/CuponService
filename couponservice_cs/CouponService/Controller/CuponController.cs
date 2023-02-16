// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using CouponService.Models;

// namespace CouponService.Controller
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class CuponController : ControllerBase
//     {
//         private readonly CServiceContext _context;

//         public CuponController(CServiceContext context)
//         {
//             _context = context;
//         }

//         // GET: api/Cupon
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Cupon>>> GetCupons()
//         {
//           if (_context.Cupons == null)
//           {
//               return NotFound();
//           }
//             return await _context.Cupons.ToListAsync();
//         }

//         // GET: api/Cupon/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Cupon>> GetCupon(long id)
//         {
//           if (_context.Cupons == null)
//           {
//               return NotFound();
//           }
//             var cupon = await _context.Cupons.FindAsync(id);

//             if (cupon == null)
//             {
//                 return NotFound();
//             }

//             return cupon;
//         }

//         // PUT: api/Cupon/5
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutCupon(long id, Cupon cupon)
//         {
//             if (id != cupon.id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(cupon).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!CuponExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }

//         // POST: api/Cupon
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPost]
//         public async Task<ActionResult<Cupon>> PostCupon(Cupon cupon)
//         {
//           if (_context.Cupons == null)
//           {
//               return Problem("Entity set 'CServiceContext.Cupons'  is null.");
//           }
//             _context.Cupons.Add(cupon);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction("GetCupon", new { id = cupon.id }, cupon);
//         }

//         // DELETE: api/Cupon/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteCupon(long id)
//         {
//             if (_context.Cupons == null)
//             {
//                 return NotFound();
//             }
//             var cupon = await _context.Cupons.FindAsync(id);
//             if (cupon == null)
//             {
//                 return NotFound();
//             }

//             _context.Cupons.Remove(cupon);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         private bool CuponExists(long id)
//         {
//             return (_context.Cupons?.Any(e => e.id == id)).GetValueOrDefault();
//         }
//     }
// }
