using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Data;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options)
        : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seeding Persons
        modelBuilder.Entity<Person>().HasData(
            new Person { Id = Guid.NewGuid(), FirstName = "Công", LastName = "Đặng Phan Thành", Gender = Gender.Male, DateOfBirth = new DateTime(2000, 6, 15), PhoneNumber = "0375.284.637", BirthPlace = "Lâm Đồng", IsGraduated = true },
            new Person { Id = Guid.NewGuid(), FirstName = "Linh", LastName = "Nguyễn Mỹ", Gender = Gender.Female, DateOfBirth = new DateTime(1995, 7, 4), PhoneNumber = "0375.284.636", BirthPlace = "Hà Nội", IsGraduated = true },
            new Person { Id = Guid.NewGuid(), FirstName = "Phương", LastName = "Nguyễn Thị Mai", Gender = Gender.Female, DateOfBirth = new DateTime(2002, 4, 7), PhoneNumber = "0375.284.635", BirthPlace = "Hải Phòng", IsGraduated = false },
            new Person { Id = Guid.NewGuid(), FirstName = "Thu", LastName = "Phan Thị Hà", Gender = Gender.Female, DateOfBirth = new DateTime(2003, 2, 27), PhoneNumber = "0375.284.634", BirthPlace = "Huế", IsGraduated = false },
            new Person { Id = Guid.NewGuid(), FirstName = "Quang", LastName = "Trần Huy", Gender = Gender.Male, DateOfBirth = new DateTime(1994, 4, 20), PhoneNumber = "0375.284.633", BirthPlace = "Hà Nội", IsGraduated = false }
        );
    }
}