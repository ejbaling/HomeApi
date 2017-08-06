using DeviceController.Contract;
using System;
using System.Diagnostics;
using System.IO.Ports;

namespace DeviceController.Implementation
{
    public class Arduino : IDevice
    {
        public Arduino()
        {
            SetComPort();
        }

        private void SetComPort()
        {
            var ports = SerialPort.GetPortNames();
            foreach (var port in ports)
                Debug.WriteLine(port);
        }

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
