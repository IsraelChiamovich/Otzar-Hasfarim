namespace Otzar_Hasfarim.ViewModels
{
    public class ShelfVM
    {
        public long Id { get; set; }

        public int Width { get; set; } = 0;

        public int Height { get; set; } = 0;

        public long LibraryId { get; set; }

        public string? ErrorMessage { get; set; }
    }
}

