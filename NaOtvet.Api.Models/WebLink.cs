using System.ComponentModel.DataAnnotations;

namespace NaOtvet.Api.Models
{
    public class WebLink
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Url { get; set; }
    }
}
