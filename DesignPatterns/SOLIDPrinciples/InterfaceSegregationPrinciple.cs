using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SOLIDPrinciples
{
    class InterfaceSegregationPrinciple
    {
        //interfaces should be segregated so that no one who implements your interfaces has to implement functions that they dont need
    }
    public class Document
    {

    }
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }
    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }

        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
    }
    //an old fashined printer can only print documents so Print() is valid but the Scan adn FAx methods are not used and hence a redundancy
    //Imachine has implemented methods that it is not using
    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }

        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
    }
    //to fix this problem have smaller interfaces
    public interface IPrinter
    {
        void Print(Document d);
    }
    public interface IScanner
    {
        void Scan(Document d);
    }
    public interface IFax
    {
        void Fax(Document d);
    }
    //if you have a photocopier you will need scan and print, now it is easy to implement these two methods. fax is not needed
    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
    //or have a multifunction interface for multifunction devices
    public interface IMultifunctionDevice : IPrinter, IScanner, IFax
    {

    }

    public class MultifunctionDevice : IMultifunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;
        private IFax fax;

        public MultifunctionDevice(IPrinter printer, IScanner scanner)
        {
            this.printer = printer;
            this.scanner = scanner;
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }
        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
        public void Fax(Document d)
        {
            fax.Fax(d);
        }
    }
}
