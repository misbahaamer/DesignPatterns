using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using DesignPatterns.Builder;


namespace DesignPatterns
{

    
    public class Program
    {
        
        static void Main(string[] args)
        {
            var me = Person.New.Called("Misbah").WorksAsA("Dev").Build();
            Console.WriteLine(me);

        }


    }
}
