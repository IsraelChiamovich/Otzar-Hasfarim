using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otzar_Hasfarim.Data;
using Otzar_Hasfarim.Models;
using Otzar_Hasfarim.ViewModels;

namespace Otzar_Hasfarim.Service
{
	public class LibraryService : ILibraryService
	{
		private readonly ApplicationDbContext _context;

        public LibraryService(ApplicationDbContext context)
        {
            _context = context;
        }

		public void CreateLibrary(LibraryVM libraryVM)
		{
			LibraryModel model = new() { Genre = libraryVM.Genre };

			_context.Libraries.Add(model);
			_context.SaveChanges();
		}

		public List<LibraryModel> GetAllLibraries()
		{
			return _context.Libraries
				.Include(l => l.Shelves)
				.ToList();
		}

		

	}
}
