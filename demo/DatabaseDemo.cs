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
        db.InsertTable(Entity.product, new Product(11, "Product 11", 1));
    }

    public void selectTableTest()
    {
        List<object> products = db.SelectTable(Entity.product);
    }

    public void updateTableTest()
    {
        db.UpdateTableById(2, new Product(1, "Updated Product", 99));
    }

    public void deleteTableTest()
    {
        db.DeleteTable(Entity.product, new Product { Id = 1 });
    }

    public void truncateTableTest()
    {
        db.TruncateTable(Entity.product);
    }

    public void initDatabase()
    {
        for (int i = 1; i <= 10; i++)
        {
            db.InsertTable(Entity.product, new Product(i, $"Product {i}", i));
            db.InsertTable(Entity.category, new Category(i, $"Category {i}"));
            db.InsertTable(Entity.accessotion, new Accessotion(i, $"Accessotion {i}"));
        }
    }

    public void printTableTest(Entity name)
    {
        switch (name)
        {
            case Entity.product:
                List<Product> products = db.SelectTable(Entity.product).ConvertAll(obj => (Product)obj);

                foreach (var item in products)
                {
                    Console.WriteLine($"Product Id: {item.Id}");
                    Console.WriteLine($"Product Name: {item.Name}");
                    Console.WriteLine($"Product Category Id: {item.CategoryId}");
                }
                break;
            case Entity.category:
                List<Category> categories = db.SelectTable(Entity.category).ConvertAll(obj => (Category)obj);

                foreach (var item in categories)
                {
                    Console.WriteLine($"Category Id: {item.Id}");
                    Console.WriteLine($"Category Name: {item.Name}");
                }
                break;
            case Entity.accessotion:
                List<Accessotion> accessotions = db.SelectTable(Entity.accessotion).ConvertAll(obj => (Accessotion)obj);

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
        printTableTest(Entity.product);
        Console.WriteLine("-------------------------------");
        printTableTest(Entity.category);
        Console.WriteLine("-------------------------------");
        printTableTest(Entity.accessotion);

    }

    public static void Main(string[] args)
    {
        DatabaseDemo demo = new DatabaseDemo();
        demo.insertTableTest();
        //demo.selectTableTest();
        //demo.updateTableTest();
        //demo.deleteTableTest();
        //demo.truncateTableTest();
        demo.printAllTableTest();
        Console.ReadLine();
    }
}
