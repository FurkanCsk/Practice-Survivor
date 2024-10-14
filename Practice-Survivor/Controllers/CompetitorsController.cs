using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice_Survivor.Data;
using Practice_Survivor.Entities;

namespace Practice_Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CompetitorsController(SurvivorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompetitorEntity>>> GetAll()
        {
            var competitors = await _context.Competitors.ToListAsync();

            if (competitors is null) return NotFound();

            return Ok(competitors);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CompetitorEntity>> GetById(int id)
        {
            var competitors = await _context.Competitors.FirstOrDefaultAsync(x => x.Id == id);

            if (competitors is null) return NotFound();

            return Ok(competitors);
        }

        [HttpGet("categories/{CategoryId:int}")]
        public async Task<ActionResult<List<CompetitorEntity>>> GetByCategoryId([FromRoute(Name = "categoryId")] int categoryId)
        {
            var competitors = await _context.Competitors.Where(x => x.CategoryId.Equals(categoryId)).ToListAsync();

            if (competitors is null) return NotFound();

            return Ok(competitors);
        }

        [HttpPost]
        public async Task<ActionResult<CompetitorEntity>> Create([FromBody] CompetitorEntity competitor)
        {
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == competitor.CategoryId);
            if (!categoryExists)
            {
                return BadRequest();
            }

            var newCompetitor = new CompetitorEntity()
            {
                FirstName = competitor.FirstName,
                LastName = competitor.LastName,
                CategoryId = competitor.CategoryId,
            };

            _context.Add(newCompetitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newCompetitor.Id }, newCompetitor);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<CompetitorEntity>> Update([FromRoute(Name = "categoryId")] int id, [FromBody] CompetitorEntity competitor)
        {
            var updatedCompetitor = await _context.Competitors.FirstOrDefaultAsync(x => x.Id == id);
            
            if (updatedCompetitor is null) return BadRequest();

            updatedCompetitor.ModifiedDate = DateTime.UtcNow;
            updatedCompetitor.FirstName = competitor.FirstName;
            updatedCompetitor.LastName = competitor.LastName;
            updatedCompetitor.CategoryId = competitor.CategoryId;

            _context.Competitors.Update(updatedCompetitor);

            await _context.SaveChangesAsync();

            return Ok(updatedCompetitor);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CompetitorEntity>> Delete (int id)
        {
            var competitor = await _context.Competitors.FirstOrDefaultAsync(x => x.Id == id);

            if (competitor is null) return NotFound();

            competitor.ModifiedDate = DateTime.UtcNow;
            competitor.IsDeleted = true;

            _context.Competitors.Update(competitor);

            await _context.SaveChangesAsync();

            return Ok(competitor);
        }


    }
}
