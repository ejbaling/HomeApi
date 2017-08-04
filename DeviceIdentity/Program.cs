using System;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;
using System.Threading.Tasks;

namespace DeviceIdentity
{
    class Program
    {
        static RegistryManager registryManager;
        const string connectionString = "HostName=home-device-hub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=3IybZwWdoQ4f658xu5cljzCxsnBTl91aC/5lOPMQibY=";

        static void Main(string[] args)
        {
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            AddDeviceAsync().Wait();
            Console.ReadLine();

            // Output
            // Generated device key: dWSbjnYFpGAz2bLWercEmKRBV6h0yHUi5fe0wTO0qlc=
        }

        private static async Task AddDeviceAsync()
        {
            string deviceId = "Toshiba-C665";
            Device device;
            try
            {
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                device = await registryManager.GetDeviceAsync(deviceId);
            }
            Console.WriteLine("Generated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);
        }
    }
}