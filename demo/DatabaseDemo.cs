using System;
using System.Collections.Generic;

public class DatabaseDemo
{
    private Database db;

    public DatabaseDemo()
    {
        db = Database.Instance;
        initDatabase();
    }

    public void insertTableTest()
    { 
        db.InsertTable("product", new Product(11, "Product 11", 1));
    }

    public void selectTableTest()
    {
        List<object> products = db.SelectTable("product");
    }

    public void updateTableTest()
    {
        db.UpdateTable("product", new Product(1, "Updated Product", 2));
    }

    public void deleteTableTest()
    {
        db.DeleteTable("product", new Product { Id = 1 });
    }

    public void truncateTableTest()
    {
        db.TruncateTable("product");
    }

    public void initDatabase()
    {
        for (int i = 1; i <= 10; i++)
        {
            db.InsertTable("product", new Product(i, $"Product {i}", i));
            db.InsertTable("category", new Category(i, $"Category {i}"));
            db.InsertTable("accessotion", new Accessotion(i, $"Accessotion {i}"));
        }
    }
    public void printTableTest(string name)
    {
        switch (name)
        {
            case "product":
                List<Product> products = db.SelectTable("product").ConvertAll(obj => (Product)obj);

                foreach (var item in products)
                {
                    Console.WriteLine($"Product Id: {item.Id}");
                    Console.WriteLine($"Product Name: {item.Name}");
                    Console.WriteLine($"Product Category Id: {item.CategoryId}");
                }
                break;
            case "category":
                List<Category> categories = db.SelectTable("category").ConvertAll(obj => (Category)obj);

                foreach (var item in categories)
                {
                    Console.WriteLine($"Category Id: {item.Id}");
                    Console.WriteLine($"Category Name: {item.Name}");
                }
                break;
            case "accessotion":
                List<Accessotion> accessotions = db.SelectTable("accessotion").ConvertAll(obj => (Accessotion)obj);

                foreach (var item in accessotions)
                {
                    Console.WriteLine($"Accessotion Id: {item.Id}");
                    Console.WriteLine($"Accessotion Name: {item.Name}");
                }
                break;
            default:
                throw new ArgumentException("Tên bảng ko đúng");
        }
    }
    public void printAllTableTest()
    {
        printTableTest("product");
        Console.WriteLine("-------------------------------");
        printTableTest("category");
        Console.WriteLine("-------------------------------");
        printTableTest("accessotion");

    }

    //public static void Main(string[] args)
    //{
    //    DatabaseDemo demo = new DatabaseDemo();
    //    demo.insertTableTest();
    //    demo.selectTableTest();
    //    demo.updateTableTest();
    //    demo.deleteTableTest();
    //    demo.truncateTableTest();
    //    demo.printAllTableTest();
    //    Console.ReadLine();
    //}
}
