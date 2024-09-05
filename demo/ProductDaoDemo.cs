using System;
using System.Collections.Generic;

public class ProductDaoDemo
{
    private Database db;
    private ProductDAO productDAO = new ProductDAO();

    public ProductDaoDemo()
    {
        db = Database.Instance;
        db.InitDatabase();
    }

    public void InsertTest()
    {
        productDAO.Insert(new Product(11, "Product 11",1));
    }

    public void UpdateTest()
    {
        productDAO.Update(new Product(11, "Product 11111111", 1));
    }

    public void DeleteTest()
    {
        productDAO.Delete(new Product(11, "", 0));
    }

    public void FindAllTest()
    {
        List<BaseRow> products = productDAO.FindAll();
        foreach (Product item in products)
        {
            Console.WriteLine($"product Id: {item.Id}");
            Console.WriteLine($"product Name: {item.Name}");
            Console.WriteLine($"product: {item.CategoryId}");
        }
    }

    public void FindByIdTest()
    {
        Product product = productDAO.FindById(1);
        if (product != null)
        {
            Console.WriteLine($"product Id: {product.Id}");
            Console.WriteLine($"product Name: {product.Name}");
            Console.WriteLine($"product: {product.CategoryId}");

        }
        else
        {
            Console.WriteLine("Không tìm thấy");
        }
    }
    public void FindByNameTest()
    {
        Product product = productDAO.FindByName("product 10");
        if (product != null)
        {
            Console.WriteLine($"product Id: {product.Id}");
            Console.WriteLine($"product Name: {product.Name}");
            Console.WriteLine($"product: {product.CategoryId}");

        }
        else
        {
            Console.WriteLine("Không tìm thấy");
        }
    }
    public void FindSearchTest()
    {
        List<BaseRow> productsSearch = productDAO.Search("pro");

        foreach (var product in productsSearch)
        {
            Console.WriteLine($"product Id: {product.Id}");
            Console.WriteLine($"product Name: {product.Name}");
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
                    Console.WriteLine($"Product Product Id: {item.CategoryId}");
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
        ProductDaoDemo productDaoDemo = new ProductDaoDemo();
        //productDaoDemo.InsertTest();
        //productDaoDemo.UpdateTest();
        //productDaoDemo.DeleteTest();
        //productDaoDemo.FindAllTest();
        //productDaoDemo.FindByIdTest();
        //productDaoDemo.FindByNameTest();
        //productDaoDemo.FindSearchTest();
        //productDaoDemo.printAllTableTest();
        Console.ReadLine();
    }
}

