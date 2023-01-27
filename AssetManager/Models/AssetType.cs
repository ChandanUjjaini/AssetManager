using System.ComponentModel.DataAnnotations;

namespace AssetManager.Models
{
    public class AssetType
    {
        public int Id { get; set; }
        [Display(Name = "Asset Type")]
        public string Name { get; set; }

    }
}
