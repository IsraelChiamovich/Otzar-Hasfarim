using Otzar_Hasfarim.Models;
using Otzar_Hasfarim.ViewModels;
using System.Collections;

namespace Otzar_Hasfarim.Service
{
	public interface ILibraryService
	{
		List<LibraryModel> GetAllLibraries();

		void CreateLibrary(LibraryVM libraryVM);
	}
}
