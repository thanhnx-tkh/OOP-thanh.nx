using System;
public class CategoryDemo
{
    /// <summary>
    /// Create category
    /// </summary>
    /// <returns></returns>
    public Category CreateCategoryTest()
    {
        Category category = new Category(1, "Apple");

        return category;
    }
    /// <summary>
    /// print category
    /// </summary>
    /// <param name="category"></param>
    public void PrintCategory(Category category)
    {
        if (category == null)
        {
            Console.WriteLine("Category is null.");
            return;
        }

        Console.WriteLine($"Category ID: {category.Id}");
        Console.WriteLine($"Category Name: {category.Name}");
    }


    //static void Main(string[] args)
    //{
    //    CategoryDemo categoryDemo = new CategoryDemo();

    //    Category category = categoryDemo.CreateCategoryTest();

    //    categoryDemo.PrintCategory(category);

    //    Console.ReadLine();
    //}
}

