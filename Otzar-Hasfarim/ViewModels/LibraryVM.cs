using System.ComponentModel.DataAnnotations;

namespace Otzar_Hasfarim.ViewModels
{
	public class LibraryVM
	{
		public long Id { get; set; }

		[StringLength(100, MinimumLength = 3, ErrorMessage = "Genre should be in a range of 3 - 100")]
		public string Genre { get; set; } = string.Empty;
	}
}
