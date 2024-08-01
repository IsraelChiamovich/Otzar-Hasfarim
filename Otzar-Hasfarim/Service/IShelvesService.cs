using Otzar_Hasfarim.Models;
using Otzar_Hasfarim.ViewModels;

namespace Otzar_Hasfarim.Service
{
    public interface IShelvesService
    {
        List<ShelfModel> GetAllShelves(long id);

        void CreateShelf(ShelfVM shelfVM);
    }
}
