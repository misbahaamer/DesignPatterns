using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesignPatterns.Creational.Singleton
{
    public class SingletonDatabase : IDataBase
    {
        private Dictionary<string, int> cities;

        private SingletonDatabase()
        {
            this.cities = File.ReadAllLines("Creational/Singleton/Cities.txt").Batch(2).ToDictionary(x => x.ElementAt(0).Trim(), y => int.Parse(y.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return cities[name];
        }

        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>( () => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;
    }
}
