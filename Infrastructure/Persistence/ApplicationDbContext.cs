using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;

        }

      
        public DatabaseFacade? Database { get; }


        public DbSet<Country> Countries => Set<Country>();

        public DbSet<Course> Courses => Set<Course>();

        public DbSet<CourseCategory> CourseCategories => Set<CourseCategory>();


        public DbSet<Student> Students => Set<Student>();

        public DbSet<StudentCourse> StudentCourses => Set<StudentCourse>();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
  //public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
  //{
  //  public ApplicationDbContext CreateDbContext(string[] args)
  //  {
  //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
  //    optionsBuilder.UseSqlServer("DatabaseConnection");
  //    return new ApplicationDbContext(optionsBuilder.Options);
  //  }
  //}
}
