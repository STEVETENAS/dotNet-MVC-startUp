using HeroAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly HeroDbContext _context;
        public CategoryController(HeroDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Category>> Get()
        { return Ok(await _context.categories.ToListAsync()); }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int? id)
        {
            var category = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound("Unknown ID");
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Add(Category category)
        {
            await _context.categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok(await _context.categories.ToListAsync()); 
        }

        [HttpPut]
        public async Task<ActionResult<Category>> Update(Category request)
        {
            var category = await _context.categories.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (category == null)
                return NotFound("Unknown ID");
            category.DisplayOrder = request.DisplayOrder;
            category.Name = request.Name ?? category.Name;
            category.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok(await _context.categories.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(int? id)
        {
            var category = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound("Unknown ID");
            _context.Remove(category);
            return Ok(await _context.categories.ToListAsync());
        }
    }
}
