using Microsoft.EntityFrameworkCore;
namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options) : base(options)
    {    
    }
    public DbSet<Animal> Animals {get;set;}

    protected override void OnModelCreating(ModelBuilder builder)
{
  builder.Entity<Animal>()
      .HasData(
          new Animal { AnimalId = 1, Name = "Mat", Species = "Dog", Age = 7, Gender = "Female" },
          new Animal { AnimalId = 2, Name = "Rex", Species = "Cat", Age = 10, Gender = "Female" },
          new Animal { AnimalId = 3, Name = "Snow", Species = "Cat", Age = 2, Gender = "Female" },
          new Animal { AnimalId = 4, Name = "Spark", Species = "Dog", Age = 4, Gender = "Male" },
          new Animal { AnimalId = 5, Name = "Grace", Species = "Cat", Age = 22, Gender = "Male" }
      );
}
  }
}