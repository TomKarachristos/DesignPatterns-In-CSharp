using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simple Factory
            IFanFactorySimple simpleFactory = new SimpleFanFactory();
            // Creation of a Fan using Simple Factory
            IFan fan = simpleFactory.CreateFan(FanType.TableFan);
            // Use created object
            fan.SwitchOn();

            // Methods Factory
            IFanFactoryMethod fanFactory = new PropellerFanFactory();

            // Creation of a Fan using Factory Method
            IFan fanMethod = fanFactory.CreateFan();

            // Use created object 
            fanMethod.SwitchOn();

            // Abstract Methods Factory
            IElectricalFactory electricalFactory =
               new IndianElectricalFactory();
            //IElectricalFactory electricalFactory = new USElectricalFactory();
            IFan fanAbstract = electricalFactory.GetFan();
            fanAbstract.SwitchOn();

            Console.ReadKey();
        }
    }
}
