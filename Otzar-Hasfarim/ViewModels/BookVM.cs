using System.ComponentModel.DataAnnotations;

namespace Otzar_Hasfarim.ViewModels
{
    public class BookVM
    {
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Book name should be in a range of 3 - 100")]
        public string Name { get; set; } = string.Empty;

        public int Width { get; set; } = 0;

        public int Height { get; set; } = 0;
    }
}
