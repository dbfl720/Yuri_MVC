using System.ComponentModel.DataAnnotations;

namespace YuriWeb.Models
{
    public class Category
    {
        //1.
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
