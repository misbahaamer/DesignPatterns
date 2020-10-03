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
        public static int Area(Rectangle r) => r.Height * r.Width;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2,3);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            Square sq = new Square();
            sq.Width = 4;

            Console.WriteLine($"{sq} has area : {Area(sq)}");

            //if we say square is also a rectangle and reference a square by a rectangle then nothing should change but obviously the result is not the same
            Rectangle sc = new Square();
            sc.Width = 4;

            Console.WriteLine($"{sq} has area : {Area(sc)}");
            //because when we change the width we are only change the width , not the height
            //to be able to upcast the square, the fix is to make the properties virtual and replace the new keyword with override in inheritance
        }

       
    }
}
