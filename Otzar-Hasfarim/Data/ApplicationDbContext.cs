using Microsoft.EntityFrameworkCore;
using Otzar_Hasfarim.Models;

namespace Otzar_Hasfarim.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
			Seed();
        }

		private void Seed()
		{
			if (!Libraries.Any())
			{
				LibraryModel FirstLibrary = new()
				{
					Genre = "Halacha",
					Shelves = [
						new()
						{
							Width = 150,
							Height = 50,
							Sets = [
								new()
								{
									Name = "Shulchan Aruch",
									Books = [
										new()
										{
											Name = "Orach Chaim",
											Height = 45,
											Width = 7,
											Genre = "Halacha",
										},
										new()
										{
											Name = "Yore Dea",
											Height = 45,
											Width = 7,
											Genre = "Halacha",
										},
										new()
										{
											Name = "Choshen Mishpat",
											Height = 45,
											Width = 7,
											Genre = "Halacha",
										},
										new()
										{
											Name = "Even Haezer",
											Height = 45,
											Width = 7,
											Genre = "Halacha",
										}
									]
								}
							]
						}
					]
				};
				Libraries.Add( FirstLibrary );
				SaveChanges();
			}
		}

		public DbSet<LibraryModel> Libraries {  get; set; }
		public DbSet<ShelfModel> Shelves {  get; set; }
        public DbSet<SetModel> Sets {  get; set; }
        public DbSet<BookModel> Books {  get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<LibraryModel>()
				.HasMany(l => l.Shelves)
				.WithOne(s => s.Library)
				.HasForeignKey(s => s.LibraryId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<ShelfModel>()
				.HasMany(s => s.Sets)
				.WithOne(s => s.Shelf)
				.HasForeignKey(s => s.ShelfId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<SetModel>()
				.HasMany(s => s.Books)
				.WithOne(b => b.Set)
				.HasForeignKey(b => b.SetId)
				.OnDelete(DeleteBehavior.Cascade);
				
		}
	}
}
