﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SOLIDPrinciples
{
    class LiskovSubstitutionPrinciple
    {
        //you should be able to substitute a base type for a sub type
    }

    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        //public  int Width { get; set; }
        //public  int Height { get; set; }

        public Rectangle()
        {
            
        }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set => base.Width = base.Height = value;
        }
        public override int Height
        {
            set => base.Width = base.Height = value;
        }
        //public new int Width
        //{
        //    set => base.Width = base.Height = value;
        //}
        //public new int Height
        //{
        //    set => base.Width = base.Height = value;
        //}
    }
}
