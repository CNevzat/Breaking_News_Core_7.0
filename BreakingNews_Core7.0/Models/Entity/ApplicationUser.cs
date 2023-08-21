using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace BreakingNews_Core7._0.Models.Entity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string AdminTC { get; set; }
    }
}
