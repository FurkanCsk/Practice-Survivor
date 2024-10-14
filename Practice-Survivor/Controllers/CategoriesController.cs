using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice_Survivor.Data;
using Practice_Survivor.Entities;

namespace Practice_Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CategoriesController(SurvivorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryEntity>>> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();

            if(categories is null) return NotFound();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryEntity>> GetById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if(category is null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryEntity>> Create([FromBody] CategoryEntity category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            category.IsDeleted = false;


            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryEntity>> Update([FromBody] CategoryEntity category, int id)
        {
            var updatedCategory = await _context.Categories.FirstOrDefaultAsync(x =>x.Id == id);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            updatedCategory.ModifiedDate = DateTime.UtcNow;
            updatedCategory.Name = category.Name;

            _context.Categories.Update(updatedCategory);
            await _context.SaveChangesAsync();


            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryEntity>> Delete (int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category is null) return BadRequest();

            category.ModifiedDate = DateTime.UtcNow;
            category.IsDeleted = true;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }
    }
}
