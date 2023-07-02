using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace BensModManager.Api.Models
{
    public class Mod
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public int ID { get; set; }

        [Required]
        public required string ModName { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public required string ModType { get; set; }

        [Required]
        public required bool Obsolete { get; set; }
        public string Notes { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        public string FileType { get; set; } = string.Empty;

        public string FileExtension { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;
    }
}
