using Microsoft.EntityFrameworkCore;
using Otzar_Hasfarim.Data;
using Otzar_Hasfarim.Models;
using Otzar_Hasfarim.ViewModels;

namespace Otzar_Hasfarim.Service
{
    public class SetService : ISetService
    {
        private readonly ApplicationDbContext _context;

        public SetService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateSet(SetVM setVM)
        {
            SetModel setModel = setVM.SetModel;
            long libraryId = setVM.LibraryId;
            long shelfId = FoundAShelf(setModel, libraryId);
            setModel.ShelfId = shelfId;
            _context.Sets.Add(setModel);
            _context.SaveChanges();
        }

        private long FoundAShelf(SetModel setModel, long libraryId)
        {
            int bookSetMaxHeight = setModel.Books
                .Max(book => book.Height);
            int bookSetWidth = setModel.Books.Sum(book => book.Width);
            var shelfWithSpace = FindAShelf(bookSetMaxHeight, bookSetWidth, libraryId);

            if (shelfWithSpace == null)
            {
                throw new Exception("There is no left space for the set. Add new shelf");
            }
            if (shelfWithSpace.Height > bookSetMaxHeight + 10)
            {

            }
            return shelfWithSpace.Id;


        }

        private ShelfModel? FindAShelf(int bookSetMaxHeight, int bookSetWidth, long libraryId) =>
            _context.Shelves
            .Include(s => s.Sets)
            .ThenInclude(s => s.Books)
            .Where(s => s.LibraryId == libraryId)
            .Where(s => s.Height > bookSetMaxHeight)
            .Where(shelf => ThereIsEnoughSpace(shelf, bookSetWidth))
            .FirstOrDefault();

        private bool ThereIsEnoughSpace(ShelfModel Shelf, int BookSetWidth)
        {
            int usedWidth = Shelf.Sets.Sum(set => set.Books.Sum(book => book.Width));
            int ShelfLeftSpace = Shelf.Width - usedWidth;
            return ShelfLeftSpace >= BookSetWidth;
        }

    }
}
