using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using DesignPatterns.SOLIDPrinciples;

namespace DesignPatterns
{

    /// <summary>
    /// Single Responsibility Principle:
    /// Any class should have a single reason to change
    /// 
    /// </summary>
    /// <param name="args"></param>
    
    public class Program
    {
        
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree  = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house};

            
            Console.WriteLine("Green products (old method): ");
            foreach (var p in ProductFilter.FilterByColor(products, Color.Green))
            {
                Console.WriteLine("Green Product is: " + p.Name);
            }

            Console.WriteLine("Green Products(new): ");

            var bf = new BetterFilter();

            foreach (var p in bf.Filter(products, new ColorSpecification(color:Color.Green)))
            {
                Console.WriteLine("Green Product is : " + p.Name);
            }

            Console.WriteLine("Large Blue Items:");

            foreach (var p in bf.Filter(products, new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SIzeSpecification(Size.Large) )))
            {
                Console.WriteLine("Large Blue item is: " + p.Name);
            }

        }

       
    }
}
