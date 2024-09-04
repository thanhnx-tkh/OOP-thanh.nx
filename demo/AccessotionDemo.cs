using System;

public class AccessotionDemo
{
    public Accessotion CreateAccessotionTest()
    {
        Accessotion accessotion = new Accessotion(1, "Charger");

        return accessotion;
    }

    public void PrintAccessotion(Accessotion accessotion)
    {
        if (accessotion == null)
        {
            Console.WriteLine("Accessotion is null.");
            return;
        }

        Console.WriteLine($"Accessotion ID: {accessotion.Id}");
        Console.WriteLine($"Accessotion Name: {accessotion.Name}");
    }

    //static void Main(string[] args)
    //{
    //    AccessotionDemo accessotionDemo = new AccessotionDemo();

    //    Accessotion accessotion = accessotionDemo.CreateAccessotionTest();

    //    accessotionDemo.PrintAccessotion(accessotion);

    //    Console.ReadLine();
    //}
}