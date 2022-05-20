using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using DesignPatterns.Builder;
using DesignPatterns.Creational.Singleton;

namespace DesignPatterns
{

    
    public class Program
    {
        
        static void Main(string[] args)
        {
            //singleton
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            Console.WriteLine($"{city} : {db.GetPopulation(city)}");


        }


    }
}
