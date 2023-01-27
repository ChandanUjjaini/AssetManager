using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AssetManager.Models
{
    public class Asset
    {
        public int Id { get; set; }
        [Display(Name = "Asset Type")]
        public int AssetTypeId { get; set; }
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public string Model { get; set; }
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
       
        public DateTime Pdate { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [Display(Name = "Price (USD)")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public double Price { get; set; }
        [Display(Name = "Local Price")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public double LPrice { get; set; }
        [ForeignKey("ApplicationUser")]
        [Display(Name = "Asset Owner")]
        public string UserId { get; set; }
        [Display(Name = "Image")]        
        public string ImageFile { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
        public AssetType AssetType { get; set; }
        public Brand Brand { get; set; }
        public Country Country { get; set; }
    }
}
