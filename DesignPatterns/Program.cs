using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using DesignPatterns.Builder;
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
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            Console.WriteLine(builder.ToString());
        }


    }
}
