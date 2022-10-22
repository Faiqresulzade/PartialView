using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace front_to_back.Models
{
    public class Category
    {
        public Category()
        {
            CategoryComponents = new List<CategoryComponent>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad mutleq daxil edilmelidir!!!"),MinLength(3,ErrorMessage ="Bashliq en azi 3 olmalidir!!!")]
        public string Title { get; set; }
        public ICollection<CategoryComponent> CategoryComponents { get; set; }
    }
}
