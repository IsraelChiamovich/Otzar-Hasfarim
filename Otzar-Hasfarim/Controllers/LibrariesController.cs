using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otzar_Hasfarim.Models;
using Otzar_Hasfarim.Service;
using Otzar_Hasfarim.ViewModels;

namespace Otzar_Hasfarim.Controllers
{
	public class LibrariesController : Controller
	{
		private readonly ILibraryService _libraryService;
		private readonly IShelvesService _ShelvesService;
		private readonly ISetService _setService;

		public LibrariesController(ILibraryService libraryService, IShelvesService shelvesService, ISetService setService)
		{
			_libraryService = libraryService;
			_ShelvesService = shelvesService;
			_setService = setService;
		}
        public IActionResult Index()
		{
			var libraries = _libraryService.GetAllLibraries();
			return View(libraries);
		}


		public IActionResult Create() => View(new LibraryVM());


		[HttpPost]
		public IActionResult Create(LibraryVM libraryVM)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Model is invalid");
			}
			_libraryService.CreateLibrary(libraryVM);
			return RedirectToAction("Index");

		}

		public IActionResult Shelves(long id)
		{
            var shelves = _ShelvesService.GetAllShelves(id);
			if (shelves.Any())
				{ return View(shelves); }
			/*throw new Exception("there is no shelves to show");*/
			return RedirectToAction("Index");
            
        }

        public IActionResult CreateShelf(long id)
		{
			ShelfVM shelfVM = new()
			{
				LibraryId = id,
			};
			return View(shelfVM);
		}

		[HttpPost]
		public IActionResult CreateShelf(ShelfVM shelfVM)
		{
			if (!ModelState.IsValid)
			{
				shelfVM.ErrorMessage = "Invalid shelf";
			}
			_ShelvesService.CreateShelf(shelfVM);
			return RedirectToAction("Index");
		}

		public IActionResult AddSet(long libraryId)
		{
			SetVM setVM = new()
			{
				LibraryId = libraryId,
			};
			return View(setVM);
		}


        public IActionResult AddMoreToSet(SetVM setVM)
        {
            SetVM newSetVM = new()
            {
                SetModel = setVM.SetModel,
                LibraryId = setVM.LibraryId
            };
            long id = setVM.LibraryId;
            var Genre = _libraryService.GetAllLibraries()
                .Where(l => l.Id == id)
                .Select(l => l.Genre)
                .FirstOrDefault();
            if (Genre == null)
            {
                throw new Exception("Error");
            }

            BookModel bookModel = new()
            {
                Name = setVM.Book.Name,
                Width = setVM.Book.Width,
                Height = setVM.Book.Height,
                Genre = Genre
            };
            newSetVM.SetModel.Books.Add(bookModel);

            return RedirectToAction("AddSet2", new {setVM = newSetVM});
        }


        public IActionResult AddSet2(SetVM setVM)
        {
            return View(setVM);
        }
        
		
		
		
		
		
		
		[HttpPost]
        public IActionResult AddSet(SetVM setVM)
        {
            long id = setVM.LibraryId;
            var Genre = _libraryService.GetAllLibraries()
                .Where(l => l.Id == id)
                .Select(l => l.Genre)
                .FirstOrDefault();
            if (Genre == null)
            {
                throw new Exception("Error");
            }

            BookModel bookModel = new()
            {
                Name = setVM.Book.Name,
                Width = setVM.Book.Width,
                Height = setVM.Book.Height,
                Genre = Genre
            };
            setVM.SetModel.Books.Add(bookModel);
            _setService.CreateSet(setVM);
            return RedirectToAction("Index");
        }
    }
}
