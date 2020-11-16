using System.ComponentModel.DataAnnotations;

namespace NaOtvet.Api.Models
{
    public class WebSiteAccount
    {
        public int Id { get; set; }
        [StringLength(500)]
        public string WebSite { get; set; }
        [StringLength(30)]
        public string Login { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
    }
}
