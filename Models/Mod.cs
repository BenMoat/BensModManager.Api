using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BensModManager.Api.Models
{
    public class Mod
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Display(Name = "Mod Name")]
        [Required]
        public required string ModName { get; set; } 

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Mod Type")]
        [Required]
        public required string ModType { get; set; }

        [Required]
        public required bool Obsolete { get; set; }
        public string Notes { get; set; } = string.Empty;

        [Display(Name = "File Name")]
        public string FileName { get; set; } = string.Empty;

        [Display(Name = "File Type")]
        public string FileType { get; set; } = string.Empty;

        [Display(Name = "File Extension")]
        public string FileExtension { get; set; } = string.Empty;

        [Display(Name = "File Path")]
        public string FilePath { get; set; } = string.Empty;
    }
}
