using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace SwEngHomework.WebApp.Models
{
    public class IndexViewModel
    {
        public DateTime CurrentDateTimeUtc { get; set; }
        public int CurrentMinute { get; set; }
        public bool IsWithin30Seconds { get; set; }
    }
    
}
