using System.ComponentModel.DataAnnotations;

namespace BlazorBase.Model
{
    public class Truc
    {
        public string Id { get; set; }

        [Required]
        [Range(0.0, 100.0, ErrorMessage = "Value must be between {1} and {2}")]
        public int Numeric { get; set; }

        [Required]
        [MaxLength(10)]
        public string Data { get; set; }

        public DateTime Now { get; set; }
    }
}
