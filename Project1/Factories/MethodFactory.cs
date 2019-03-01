using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    interface IFanFactoryMethod
    {
        IFan CreateFan(); //factory method
    }

    class TableFanFactory : IFanFactoryMethod
    {

        public IFan CreateFan()
        {
            return new TableFan();
        }
    }
    class CeilingFanFactory : IFanFactoryMethod
    {

        public IFan CreateFan()
        {
            return new CeilingFan();
        }
    }
    class ExhaustFanFactory : IFanFactoryMethod
    {
        public IFan CreateFan()
        {
            return new ExhaustFan();
        }
    }
    class PropellerFanFactory : IFanFactoryMethod
    {
        public IFan CreateFan()
        {
            return new PropellerFan();
        }
    }
}
