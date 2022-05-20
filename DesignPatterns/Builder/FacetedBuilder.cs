﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder
{
    class FacetedBuilder
    {
    }

    public partial class Person
    {
        //address
        public string StreetAddress, Postcode, City;
        //employment
        public string CompanyName, Post;
        public int AnnualIncome;


        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Post)}: {Post}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public  class PersonBuilder1
    {
        protected Person person1 = new Person();

        
    }
    public class PersonJobBuilder : PersonBuilder1
    {
        public PersonJobBuilder(Person person)
        {
            this.person1 = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person1.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person1.Position = position;
            return this;
        }
        public PersonJobBuilder Earning(int amount)
        {
            person1.AnnualIncome = amount;
            return this;
        }

    }

}
