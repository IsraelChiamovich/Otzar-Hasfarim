using System.ComponentModel.DataAnnotations;

namespace Otzar_Hasfarim.Models
{
	public class SetModel
	{
		public long Id { get; set; }

		[Required, StringLength(100)]
		public required string Name { get; set; }

		public ShelfModel Shelf { get; set; }

		public long ShelfId { get; set; }

		public List<BookModel> Books { get; set; } = [];
	}
}
