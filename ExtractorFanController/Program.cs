using DeviceController;
using DeviceController.Contract;
using DeviceController.Implementation;
using System;
using System.Timers;

namespace ExtractorFanController
{
    class Program
    {
        #region Variable Declarations
        private static Timer timer;
        private const int TURNED_ON_DELAY = 10000;  // 10 seconds
        private const int TURNED_OFF_DELAY = 5000;  //  5 seconds
        //private const int TURNED_ON_DELAY = 600000;  // 10 minutes
        //private const int TURNED_OFF_DELAY = 300000; //  5 minutes
        //private const int TURNED_ON_DELAY = 600000;    // 10 minutes
        //private const int TURNED_OFF_DELAY = 3600000;  //  1 hour
        private static int counter;
        private static Status currentStatus;
        private static IDevice device;
        #endregion

        #region Enums
        private enum Status
        {
            OFF,
            ON
        }
        #endregion

        static void Main(string[] args)
        {
            device = DeviceFactory.Create<Arduino>();
            // device = DeviceFactory.Create<RaspberryPi>();

            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            CheckHumidity();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            counter = 1000;
            currentStatus = Status.OFF;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            counter += 1000;

            if (currentStatus == Status.ON)
            {
                if (counter > TURNED_ON_DELAY)
                {
                    device.TurnOff();
                    counter = 1000;
                    currentStatus = Status.OFF;
                    return;
                }
            }

            if (currentStatus == Status.OFF)
            {
                if (counter > TURNED_OFF_DELAY)
                {
                    CheckHumidity();
                    counter = 1000;
                    currentStatus = Status.ON;
                }
            }
        }

        private static void CheckHumidity()
        {
            device.TurnOn();
            currentStatus = Status.ON;
        }
    }
}