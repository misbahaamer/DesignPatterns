using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
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
        /// <summary>
        /// in this design a private field relations is exposed as public field for this class to access it. its  violation of DIP
        /// </summary>
        /// <param name="relationships"></param>
        //public Program(Relationships relationships)
        //{
        //    var relations = relationships.Relations;
        //    foreach (var r in relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
        //    {
        //        Console.WriteLine($"John has a child called {r.Item3.Name}");
        //    }
        //}
        public Program(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine(p.Name);
            }
        }

        static void Main(string[] args)
        {
            var parent = new Person {Name = "John"};
            var child1 = new Person { Name = "chris" };
            var child2 = new Person { Name = "mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Relationships();
        }


    }
}
