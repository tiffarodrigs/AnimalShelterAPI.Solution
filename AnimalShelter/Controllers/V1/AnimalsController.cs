using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using System.Linq;

namespace AnimalShelter.Controllers.V1
{

  [ApiController]
  [ApiVersion("1.0")]
  //[Route("api/[controller]")]--do not use this route format while versioning
  //[Route("api/{v:apiVersion}/animals")] 
  [Route("api/v{version:apiVersion}/[controller]")]   
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }
    //GET api/animals
    [MapToApiVersion("1.0")]
    [HttpGet]
    //public async Task<ActionResult<IEnumerable<Animal>>> Get(string species,string gender,string name,int minimumAge)
    public async Task<ActionResult<IEnumerable<Animal>>> Get(string species,string gender,string name,int minimumAge,[FromQuery] PaginationFilter filter)
    
    {
      var query = _db.Animals.AsQueryable();
      if(species!=null)
      {
        query = query.Where(entry => entry.Species == species);
      }
      if(gender!=null)
      {
        query = query.Where(entry => entry.Gender == gender);
      }
      if(name!=null)
      {
        //Can use quey.Where or db.Animals.Where
        query = _db.Animals.Where(entry => entry.Name == name);
      }
      if(minimumAge > 0)
      {
        query = query.Where(e => e.Age == minimumAge);
      }
     // return await query.ToListAsync();
    var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
    var pagedData = await _db.Animals
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToListAsync();
    var totalRecords = await _db.Animals.CountAsync();
    return Ok(new PagedResponse<List<Animal>>(pagedData, validFilter.PageNumber, validFilter.PageSize));

    }
    // POST api/animals
    [MapToApiVersion("1.0")]
    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();

    
      return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal); 
    }
    //GET : api/Animals/5
    [MapToApiVersion("1.0")]
    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }
      //return animal;
      return Ok(new Response<Animal>(animal));
    }
    // PUT: api/Animals/5
    [MapToApiVersion("1.0")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id,Animal animal)
    {
      if(id != animal.AnimalId)
      {
        return BadRequest();
      }
      _db.Entry(animal).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch(DbUpdateConcurrencyException)
      {
        if(!AnimalExists(id))
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
    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }
    // DELETE: api/Animals/5
    [MapToApiVersion("1.0")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}
