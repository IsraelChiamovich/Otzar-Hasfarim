using System.ComponentModel.DataAnnotations;

namespace Otzar_Hasfarim.Models
{
	public class BookModel
	{
		public long Id { get; set; }

		[Required, StringLength(100)]
		public required string Name { get; set; }

		[Required, StringLength(100)]
		public required string Genre { get; set; }

		[Required]
		public required int Width { get; set; }

		[Required]
		public required int Height { get; set; }

		public SetModel Set { get; set; }

		public long SetId { get; set; }


	}
}
