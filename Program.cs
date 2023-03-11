using System;
using System.Threading;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;

namespace HomeProject
{
      static class Program
    {
        static int Main(string[] args)
        {

            int gpioBank = 1; // todo jyjy
            int gpioLine = 6;

            // /dev/gpiochip[args[0]]
            LibGpiodDriver gpiodDriver = new LibGpiodDriver(gpioBank);
            GpioController gpioController = new GpioController(PinNumberingScheme.Logical, gpiodDriver);

            // open gpiochip[args[0]] line args[1]
            gpioController.OpenPin(gpioLine, PinMode.Output);

            while (true)
            {
                gpioController.Write(gpioLine, PinValue.Low);
                Thread.Sleep(500);
                gpioController.Write(gpioLine, PinValue.High);
                Thread.Sleep(500);
            }
        }
    }
}
