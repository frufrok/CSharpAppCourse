using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2
{
    public class Device : IControllable
    {
        public bool IsOn { get; private set; }
        public void Off()
        {
            if (IsOn) 
            {
                IsOn = false;
                Console.WriteLine("Device was turned off");
            }
            else Console.WriteLine("Device is already off");
        }

        public void On()
        {
            if (IsOn) Console.WriteLine("Device is already on");
            else 
            {
                IsOn = true;
                Console.WriteLine("Device was turned on");
            }
        }

        public override string ToString()
        {
            return this.IsOn ? "1" : "0";
        }
    }

    public class Devices
    {
        public List<IControllable> DevicesList {get; init;}
        public Devices()
        {
            DevicesList = new List<IControllable>();
        }
        public void TurnAll(Bits bits)
        {
            for (int i = 0; i< DevicesList.Count; i++)
            {
                if (bits[i]) DevicesList[i].On();
                else DevicesList[i].Off();
            }
        }

        public override string ToString()
        {
            return string.Join(", ", DevicesList.Select(x => x.ToString()));
        }
    }
}