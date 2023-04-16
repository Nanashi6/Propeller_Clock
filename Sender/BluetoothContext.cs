using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InTheHand.Net;
using InTheHand.Net.Sockets;

namespace Sender
{
    public class BluetoothContext
    {
        public BluetoothContext() { }


    }
    public class BluetoothTerminal
    {
        private Guid _guid = new Guid("00001101-0000-1000-8000-00805f9b34fb"); // UUID для сервиса SPP
        private BluetoothClient _client;
        private BluetoothDeviceInfo _device;
        private Stream _stream;
        private Thread _receiveThread;

        public BluetoothTerminal(string macAddress)
        {
            // Подключаемся к устройству
            _client = new BluetoothClient();
            _device = new BluetoothDeviceInfo(BluetoothAddress.Parse(macAddress));
            _client.Connect(_device.DeviceAddress, _guid);

            // Получаем поток для обмена данными
            _stream = _client.GetStream();

            // Запускаем поток для приема сообщений
            _receiveThread = new Thread(ReceiveThread);
            _receiveThread.Start();
        }

        // Метод для отправки сообщения
        public void SendMessage(string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            _stream.Write(buffer, 0, buffer.Length);
        }

        // Поток для приема сообщений
        private void ReceiveThread()
        {
            while (true)
            {
                byte[] buffer = new byte[1024];
                int length = _stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.ASCII.GetString(buffer, 0, length);

                // Обработка полученного сообщения
                Console.WriteLine(message);
            }
        }
        //Поиск мак адресов устройств
        public static List<string> GetAvailableMacAddresses()
        {
            List<string> macAddresses = new List<string>();

            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();

            foreach (BluetoothDeviceInfo device in devices)
            {
                macAddresses.Add(device.DeviceAddress.ToString());
            }

            return macAddresses;
        }
    }
}
