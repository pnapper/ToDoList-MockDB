using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    [Table("Categories")]
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual Item Item { get; set; }
    }
}