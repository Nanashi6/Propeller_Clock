using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.IO.Ports;

namespace ArduinoBluethooth
{
    public class BluetoothConnection
    {
        private readonly string _portName;
        private SerialPort _serialPort;

        public BluetoothConnection(string portName)
        {
            _portName = portName;
        }
        /*
        public static List<string> Search()
        {
            var ports = SerialPort.GetPortNames();
            var result = new List<string>();

            foreach (var port in ports)
            {
                try
                {
                    var serialPort = new SerialPort(port);
                    serialPort.Open();
                    var name = serialPort.ReadExisting();
                    serialPort.Close();
                    if (!string.IsNullOrEmpty(name))
                    {
                        result.Add(name.Trim());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading from port {port}: {ex.Message}");
                }
            }

            return result;
        }
        */
        public bool Connect()
        {
            var ports = SerialPort.GetPortNames();

            if (!ports.Contains(_portName))
            {
                Console.WriteLine($"Error: Port {_portName} not found");
                return false;
            }

            _serialPort = new SerialPort(_portName, 9600, Parity.None, 8, StopBits.One);
            _serialPort.Open();

            Console.WriteLine($"Connected to {_portName}");

            return true;
        }

        public void Disconnect()
        {
            if (_serialPort == null)
            {
                Console.WriteLine($"Error: Port {_portName} not connected");
                return;
            }

            _serialPort.Close();

            Console.WriteLine($"Disconnected from {_portName}");
        }

        public string Read()
        {
            if (_serialPort == null)
            {
                Console.WriteLine($"Error: Port {_portName} not connected");
                return null;
            }

            var message = _serialPort.ReadLine();

            Console.WriteLine($"Received message: {message}");

            return message;
        }

        public void Write(string message)
        {
            if (_serialPort == null)
            {
                Console.WriteLine($"Error: Port {_portName} not connected");
                return;
            }

            _serialPort.WriteLine(message);

            Console.WriteLine($"Sent message: {message}");
        }
    }
}
