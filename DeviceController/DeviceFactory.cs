using DeviceController.Contract;
using DeviceController.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceController
{
    public static class DeviceFactory
    {
        public static T Create<T>() where T : IDevice
        {
            return (T)SpawnObject(typeof(T));
        }

        private static object SpawnObject(Type objType)
        {
            return Activator.CreateInstance(objType);
        }
    }
}
