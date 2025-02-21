using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace phuu11
{
    [Table("MyProduct")]
    public class Product{
        [Key]
        public int ProductId {get ; set;}
        
        [StringLength(50)]
        [Required]
        [Column("Tensanpham",TypeName = "ntext")]
        public required string ProductName {get ; set;}

        [StringLength(50)]
        public required string Provider {get ; set;}

        [Column(TypeName = "money")]
        public decimal Price {set; get;}

        public  int CateId {get; set;}

        [ForeignKey("CateId")]
        public  virtual  Category Category {get; set;} //FK -> PK


        public  int? CateId2 {get; set;}

        [ForeignKey("CateId2")]
        [InverseProperty("Products")]
        public  virtual  Category Category2 {get; set;} //FK -> PK

        public void PrinInfo() => Console.WriteLine($"{ProductId} - {ProductName} - {Provider} - {Price}");


    }
}