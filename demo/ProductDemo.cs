﻿using System;
public class ProductDemo
{
    /// <summary>
    /// Create product
    /// </summary>
    /// <returns>product new</returns>
    public Product CreateProductTest()
    {
        Product product = new Product(1, "Iphone 15 promax", 1);

        return product;
    }
    /// <summary>
    /// print product
    /// </summary>
    /// <param name="product"></param>
    public void PrintProduct(Product product)
    {
        if (product == null)
        {
            Console.WriteLine("Product is null.");
            return;
        }

        Console.WriteLine($"Product ID: {product.Id}");
        Console.WriteLine($"Product Name: {product.Name}");
        Console.WriteLine($"Category ID: {product.CategoryId}");
    }

    //static void Main(string[] args)
    //{
    //    ProductDemo productDemo = new ProductDemo();

    //    Product product = productDemo.CreateProductTest();

    //    productDemo.PrintProduct(product);

    //    Console.ReadLine();
    //}
}

