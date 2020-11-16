using System;
using System.ComponentModel.DataAnnotations;

namespace NaOtvet.Api.Models
{
    public class ApplicationVersion
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Version { get; set; }
        public int DownloadsCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}