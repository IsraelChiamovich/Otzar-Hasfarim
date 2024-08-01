using Otzar_Hasfarim.Models;

namespace Otzar_Hasfarim.ViewModels
{
    public class SetVM
    {
        public SetModel SetModel { get; set; }

        public BookVM Book { get; set; }

        public long LibraryId { get; set; }
    }
}
