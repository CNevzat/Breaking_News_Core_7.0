using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreakingNews_Core7._0.Models.Entity
{
	public class News
	{
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Başlık boş geçilemez")]
        public string Title { get; set; }

		[Required(ErrorMessage = "İçerik boş geçilemez")]
        [MinLength(10)]
        public string Content { get; set; }
		
		[Required]
		public string ImageURL { get; set; }

		[Required]
		public DateTime Date { get; set; }

		//Foreign Key
		[ValidateNever]
		public int CategoryID { get; set; }

		[ForeignKey("CategoryID")]
		[ValidateNever]
		public Category Category { get; set; }

    }
}
