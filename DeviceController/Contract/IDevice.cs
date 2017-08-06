using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceController.Contract
{
    public interface IDevice
    {
        void TurnOn();

        void TurnOff();
    }
}
