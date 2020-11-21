using System;
using System.ComponentModel.DataAnnotations;

namespace NaOtvet.Api.Models
{
    public class Download
    {
        public int Id { get; set; }
        [StringLength(15)]
        public string IP { get; set; }
        public int ApplicationVersionId { get; set; }
        public ApplicationVersion ApplicationVersion { get; set; }
        public DateTime DateTime { get; set; }
    }
}
