using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    interface ITubelight { }

    class IndianFan : IFan
    {
        public void SwitchOff()
        {
            throw new NotImplementedException();
        }

        public void SwitchOn()
        {
            Console.WriteLine("IndianFan Switch ON");
        }

    }

    class IndianTubelight : ITubelight { }

    class USFan : IFan
    {
        public void SwitchOff()
        {
            throw new NotImplementedException();
        }

        public void SwitchOn()
        {
            throw new NotImplementedException();
        }

    }
    class USTubelight : ITubelight { }

    interface IElectricalFactory
    {
        IFan GetFan();
        ITubelight GetTubeLight();
    }

    class IndianElectricalFactory : IElectricalFactory
    {
        public IFan GetFan()
        {
            return new IndianFan();
        }

        public ITubelight GetTubeLight()
        {
            return new IndianTubelight();
        }
    }

    class USElectricalFactory : IElectricalFactory
    {
        public IFan GetFan()
        {
            return new USFan();
        }

        public ITubelight GetTubeLight()
        {
            throw new NotImplementedException();
        }
    }
}
