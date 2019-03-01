using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Director
    {
        private Builder builder = new ConcreteBuilder();
        public Product Construct()
        {
            for (int i = 0; i < 5; i++)
                builder.BuildPart();

            return builder.Construct();
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Simple Builder
            var director = new Director();
            var product = director.Construct();
            product.Parts.ForEach((part) => Console.WriteLine(part));

            // Fluent Builder
            var builder = new FluentBuilder();
            product = builder.Begin()
                .Engine
                .SteeringWheel
                .Tire()
                .Tire()
                .Build();
            product.Parts.ForEach((part) => Console.WriteLine(part));

            Console.ReadLine();
        }
    }
}
