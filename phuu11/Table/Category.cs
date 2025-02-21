using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace phuu11
{

   [Table("Category")]
   public class Category {
        [Key]
        public int CategoryID {get ; set;}
        [StringLength(200)]
        public required string Name {get ; set;}
        [Column(TypeName = "ntext")]
        public required string Description {get ; set;}

        public virtual  List<Product>? Products {get; set;}
        
    }
}