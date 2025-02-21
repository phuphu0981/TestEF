using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Microsoft.EntityFrameworkCore;
using phuu11;
using phuu11.Models;

public class Program
{

    static  void CreateDb(){
        using var DbContext = new ShopDbContext();
        var dbname = DbContext.Database.GetDbConnection().Database;

        var kq = DbContext.Database.EnsureCreated();
        if(kq)
        {
            Console.WriteLine($"tao {dbname} thanh cong");
        }
        else 
        {
            Console.WriteLine($"khong tao duoc {dbname}");
        }

    }
    static  void DeleteDb(){

        using var DbContext = new ShopDbContext();
        var dbname = DbContext.Database.GetDbConnection().Database;

        var kq = DbContext.Database.EnsureDeleted();
        if(kq)
        {
            Console.WriteLine($"xoa {dbname} thanh cong");
        }
        else 
        {
            Console.WriteLine($"khong xoa duoc {dbname}");
        }

    }


    static void InsertCate(){

        using var dbcontext = new ShopDbContext(); 

        Category c1 = new Category() {Name = "Dien Thoai", Description = "Cac Loai Dien thoai"};
        Category c2 = new Category() {Name = "Do Uong", Description = "Cac Loai Do Uong"};
        dbcontext.Add(c1);
        dbcontext.Add(c2);

        dbcontext.SaveChanges();

    }
    static void InsertProduct(){

        using var dbcontext = new ShopDbContext(); 

        var dt = (from c in dbcontext.categories where c.CategoryID == 1 select c).FirstOrDefault();
        var nc = (from c in dbcontext.categories where c.CategoryID == 2 select c).FirstOrDefault();

#pragma warning disable CS8601 // Possible null reference assignment.
        dbcontext.Add(new Product(){ ProductName = "Iphone", Provider = "Apple", Price= 1000, Category = dt });

        dbcontext.Add(new Product(){ ProductName = "Nokia", Provider = "VN", Price= 2000, Category = dt });
        dbcontext.Add(new Product(){ ProductName = "Sua", Provider = "TH TrueMilk", Price= 200, Category = nc });

#pragma warning restore CS8601 // Possible null reference assignment.
        dbcontext.SaveChanges();

    }
    private static void Main(string[] args)
    {   
        // DeleteDb();
        // CreateDb();
        // CRUD -> Create, Read, Update, Delete

        // InsertCate();
        // InsertProduct();

        using var dbcontext = new ShopDbContext();

        var category = (from p in dbcontext.categories where p.CategoryID == 1 select p ).FirstOrDefault();
        dbcontext.Remove(category);
        dbcontext.SaveChanges();

        // if(category.Products != null){
        //     Console.WriteLine($"So san pham:{category.Products.Count()}");
        //     category.Products.ForEach(p => p.PrinInfo());
        // }
        // else Console.WriteLine("category == null");

       
    }
}
