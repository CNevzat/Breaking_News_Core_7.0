using System.ComponentModel.DataAnnotations;

namespace BreakingNews_Core7._0.Models.Entity
{
	public class Category
	{
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="Kategori ismi boş geçilemez")]
		[MaxLength(25)]
		public string Name { get; set; }
    }
}
