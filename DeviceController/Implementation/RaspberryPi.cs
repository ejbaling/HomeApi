using DeviceController.Contract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DeviceController.Implementation
{
    public class RaspberryPi : IDevice
    {
        public void TurnOff()
        {
            Debug.WriteLine(string.Format("{0} Appliance turned off.", DateTime.Now));
        }

        public void TurnOn()
        {
            Debug.WriteLine(string.Format("{0} Appliance turned on.", DateTime.Now));
        }
    }
}
