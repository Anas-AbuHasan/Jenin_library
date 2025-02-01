using System.ComponentModel.DataAnnotations;

namespace Jenin_library.Models
{
    public class Authors
    {
        [Key]
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
    }
}
