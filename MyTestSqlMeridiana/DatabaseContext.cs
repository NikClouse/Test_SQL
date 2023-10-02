
using Microsoft.EntityFrameworkCore;

namespace MyTestSqlMeridiana
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<Exam> Exams { get; set; }

		public DatabaseContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=meridian;Trusted_Connection=True;");
		}


	}
}
