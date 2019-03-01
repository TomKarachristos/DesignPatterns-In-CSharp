using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * Each time we invoke the “new” command to create a new object, 
 * we violate the “Code to an Interface” design principle
 * 
 */
namespace DesignPatterns
{
    // NO need in factory Method
    enum FanType
    {
        TableFan,
        CeilingFan,
        ExhaustFan
    }

    interface IFanFactorySimple
    {
        IFan CreateFan(FanType type);
    }

    class SimpleFanFactory : IFanFactorySimple
    {
        public IFan CreateFan(FanType type)
        {
            switch (type)
            {
                case FanType.TableFan:
                    return new TableFan();
                case FanType.CeilingFan:
                    return new CeilingFan();
                case FanType.ExhaustFan:
                    return new ExhaustFan();
                default:
                    return new TableFan();
            }
        }
    }
}
