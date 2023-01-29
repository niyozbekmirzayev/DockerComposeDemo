using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ColorAPI.Models
{
    public class Colour
    {
        [Key]
        public Guid Id { get; set; }
        
        [NotNull]
        public string Name { get; set; }
    }
}
