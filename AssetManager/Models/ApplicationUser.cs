using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AssetManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Asset Owner")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Asset> Assets { get; set; }
    }
}
