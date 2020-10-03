using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SOLIDPrinciples
{
    class OpenClosedPrinciple
    {
        //any class should be open for extension but should be claosed for modification
    }

    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Huge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        #region Violation of open closed principle because class Product filter should be open for extension but closed for modification. here it is modified 3 times
        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                {
                    yield return p;
                }
            }
        }

        public static IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                {
                    yield return p;
                }
            }
        }

        public static IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color && p.Size == size)
                {
                    yield return p;
                }
            }
        } 
        #endregion

    }

    /// <summary>
    /// to satisfy the open closed principle make interfaces
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IIFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, IISpecification<T> spec);
    }

    public class ColorSpecification : IISpecification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }
    public class SIzeSpecification : IISpecification<Product>
    {
        private Size size;

        public SIzeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }
    public class AndSpecification<T> : IISpecification<T>
    {
        private IISpecification<T> first, second;

        public AndSpecification(IISpecification<T> first, IISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }
        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    public class BetterFilter : IIFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, IISpecification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                {
                    yield return i;
                }
            }
        }
    }
}
