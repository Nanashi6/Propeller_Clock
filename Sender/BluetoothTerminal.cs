using InTheHand.Net;
using InTheHand.Net.Sockets;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Sender
{
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

        /// <summary>
        /// Метод для отправки сообщения
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            _stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Метод для отправки сообщения
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(byte[,] message)
        {
            byte[] buffer = new byte[message.Length];
            int index = 0;
            for (int i = 0; i < message.GetLength(0); i++)
            {
                for (int j = 0; j < message.GetLength(1); j++)
                {
                    _stream.WriteByte(message[i, j]);
                    buffer[index] = message[i, j];
                    index++;
                }
            }
            _stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Поток для приема сообщений
        /// </summary>
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

        /// <summary>
        /// Поиск устройств
        /// </summary>
        public static BluetoothDeviceInfo[] Search()
        {
            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();
            /*BluetoothClient bluetoothClient = new BluetoothClient();
            string authenticated;
            string classOfDevice;
            string connected;
            string deviceAddress;
            string deviceName;
            string installedServices;
            string lastSeen;
            string lastUsed;
            string remembered;
            string rssi;
            foreach (BluetoothDeviceInfo device in devices)
            {
                authenticated = device.Authenticated.ToString();
                classOfDevice = device.ClassOfDevice.ToString();
                connected = device.Connected.ToString();
                deviceAddress = device.DeviceAddress.ToString();
                deviceName = device.DeviceName.ToString();
                installedServices = device.InstalledServices.ToString();
                lastSeen = device.LastSeen.ToString();
                lastUsed = device.LastUsed.ToString();
                remembered = device.Remembered.ToString();
                rssi = device.Rssi.ToString();
                string[] row = new string[] { authenticated, classOfDevice, connected, deviceAddress, deviceName, installedServices, lastSeen, lastUsed, remembered, rssi };
                foreach (string str in row)
                {
                    Console.WriteLine(str);
                }
            }*/
            return devices;
        }

        /// <summary>
        /// Метод отключения от устройства
        /// </summary>
        public void Dispose()
        {
            _receiveThread.Abort();
            _stream.Dispose();
            _client.Dispose();
        }
    }
}
