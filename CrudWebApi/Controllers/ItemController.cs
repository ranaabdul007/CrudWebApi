using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemContext _context;

        public ItemController(ItemContext context)
        {
            _context = context;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblItem>>> GetTblItem()
        {
            return await _context.TblItem.ToListAsync();

        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblItem>> GetTblItem(int id)
        {
            var tblItem = await _context.TblItem.FindAsync(id);

            if (tblItem == null)
            {
                return NotFound();
            }

            return tblItem;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblItem(int id, TblItem tblItem)
        {
            if (id != tblItem.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(tblItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblItemxists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TblItem>> PostTblItem(TblItem tblItem)
        {
            _context.TblItem.Add(tblItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblItem", new { id = tblItem.ItemId }, tblItem);
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblItem>> DeleteTblItem(int id)
        {
            var tblItem = await _context.TblItem.FindAsync(id);
            if (tblItem == null)
            {
                return NotFound();
            }

            _context.TblItem.Remove(tblItem);
            await _context.SaveChangesAsync();

            return tblItem;
        }

        private bool TblItemxists(int id)
        {
            return _context.TblItem.Any(e => e.ItemId == id);
        }
    }
}
