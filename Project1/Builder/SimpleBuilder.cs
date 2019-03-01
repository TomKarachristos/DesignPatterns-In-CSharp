using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Product
    {
        public List<string> Parts = new List<String>();
    }

    abstract class Builder
    {
        public abstract void BuildPart();
        public abstract Product Construct();
    }

    class ConcreteBuilder : Builder
    {
        private Product product = new Product();
        private int part = 0;

        public override void BuildPart()
        {
            product.Parts.Add("Adding part #" + (part++));
        }

        public override Product Construct()
        {
            return product;
        }
    }
}
