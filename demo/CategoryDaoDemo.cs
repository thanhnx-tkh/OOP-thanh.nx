using System;
using System.Collections.Generic;

public class CategoryDaoDemo
{
    private Database db;
    private CategoryDAO categoryDAO = new CategoryDAO();

    public CategoryDaoDemo()
    {
        db = Database.Instance;
        db.InitDatabase();
    }
    /// <summary>
    /// Test insert data in the table category
    /// </summary>
    public void InsertTest()
    {
        categoryDAO.Insert(new Category(11, "Product 11"));
    }
    /// <summary>
    /// Test update data in the table category
    /// </summary>
    public void UpdateTest()
    {
        categoryDAO.Update(new Category(11, "Product 110000"));
    }
    /// <summary>
    /// Test delete data in the table category
    /// </summary>
    public void DeleteTest()
    {
        categoryDAO.Delete(new Category(11, ""));
    }
    /// <summary>
    /// Test find all data table category
    /// </summary>
    public void FindArrayTest()
    {
        List<BaseRow> categories = categoryDAO.FindAll();
        foreach (Category item in categories)
        {
            Console.WriteLine($"category Id: {item.Id}");
            Console.WriteLine($"category Name: {item.Name}");
        }
    }
    /// <summary>
    /// Test find product in the table by id
    /// </summary>
    public void FindByIdTest()
    {
        Category category = categoryDAO.FindById(1);
        if (category != null)
        {
            Console.WriteLine($"category Id: {category.Id}");
            Console.WriteLine($"category Name: {category.Name}");
        }
        else
        {
            Console.WriteLine("Không tìm thấy");
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

    //public static void Main(string[] args)
    //{
    //    CategoryDaoDemo categoryDaoDemo = new CategoryDaoDemo();
    //    categoryDaoDemo.InsertTest();
    //    categoryDaoDemo.UpdateTest();
    //    categoryDaoDemo.DeleteTest();
    //    categoryDaoDemo.FindArrayTest();
    //    categoryDaoDemo.FindByIdTest();
    //    categoryDaoDemo.printAllTableTest();
    //    Console.ReadLine();
    //}
}
