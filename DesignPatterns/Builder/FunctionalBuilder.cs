using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Builder
{
    class FunctionalBuilder
    {
    }
    public sealed class FunctionalPerson
    {
        public string Name, Position;
    }

    //public sealed class FunctionalPersonBuilder
    //{
    //    private readonly List<Func<FunctionalPerson,FunctionalPerson>> actions = new List<Func<FunctionalPerson, FunctionalPerson>>();

    //    public FunctionalPersonBuilder Called(string name) => Do(p => p.Name = name);
    //    public FunctionalPersonBuilder Do(Action<FunctionalPerson> action) => AddAction(action);
    //    private FunctionalPersonBuilder AddAction(Action<FunctionalPerson> action)
    //    {
    //        actions.Add(p => { action(p);
    //            return p;
    //        });
    //        return this;
    //    }

    //    public FunctionalPerson Build() => actions.Aggregate(new FunctionalPerson(), (p, f) => f(p));
    //}
    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf> where TSubject : new()
    {
        private readonly List<Func<FunctionalPerson, FunctionalPerson>> actions = new List<Func<FunctionalPerson, FunctionalPerson>>();

        public TSelf Do(Action<FunctionalPerson> action) => AddAction(action);
        private TSelf AddAction(Action<FunctionalPerson> action)
        {
            actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf)this;
        }
        public FunctionalPerson Build() => actions.Aggregate(new FunctionalPerson(), (p, f) => f(p));

    }

    public sealed class FunctionalPersonBuilder : FunctionalBuilder<FunctionalPerson, FunctionalPersonBuilder>
    {
        public FunctionalPersonBuilder Called(string name) => Do(p => p.Name = name);
    }

    public static class FunctionalPersonBuilderExtensions
    {
        public static FunctionalPersonBuilder WorksAs(this FunctionalPersonBuilder builder, string position) =>
            builder.Do(p => p.Position = position);
    }
    
}

