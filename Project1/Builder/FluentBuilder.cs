using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class FluentBuilder
    {
        private Product product;
        public FluentBuilder Begin()
        {
            product = new Product();
            return this; // chain of responsibility
        }

        public FluentBuilder Engine
        {
            get
            {
                product.Parts.Add("Engine");
                return this;
            }
        }

        public FluentBuilder SteeringWheel
        {
            get
            {
                product.Parts.Add("Steering Wheel");
                return this;
            }
        }

        public FluentBuilder Tire()
        {
            product.Parts.Add("Tire");
            return this;
        }

        public Product Build()
        {
            return product;
        }
    }
}
