using System;
using System.IO.Ports;

class PortDataReceived
{
    static SerialPort _serialPort;

    [STAThread]
    static int Main(string[] args) {
    try {
            if (args.Length == 0) {
                System.Console.WriteLine("Please retry, & enter the name of a [string] serialport argument.");
                return -1;
                }
            else {
                // Create a new SerialPort on indicated serial device (port)
                //    then Set the read/write timeouts
                _serialPort = new SerialPort($"{args[0]}", 9600);
                _serialPort.ReadTimeout = 1500;
                _serialPort.WriteTimeout = 1500;
                Console.WriteLine($"\nQuerying serial-data on {args[0]}... \n");
            }    


           _serialPort.DataReceived += new SerialDataReceivedEventHandler(serialDataReceived);

            _serialPort.Open();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            _serialPort.Close();
    }
    catch (Exception e) {
        Console.WriteLine(e.Message);
    }
    return 0;
}

    static void serialDataReceived( object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        Console.WriteLine(_serialPort.ReadLine());
    }
}