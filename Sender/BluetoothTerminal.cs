using InTheHand.Net;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Sender
{
    public class BluetoothTerminal
    {
        private Guid _guid = new Guid("00001101-0000-1000-8000-00805f9b34fb"); // UUID для сервиса SPP
        private BluetoothClient _client;
        private Stream _stream;
        //private Thread _receiveThread;

        public BluetoothTerminal(BluetoothDeviceInfo device)
        {
            // Подключаемся к устройству
            _client = new BluetoothClient();
            _client.Connect(device.DeviceAddress, _guid);

            // Получаем поток для обмена данными
            _stream = _client.GetStream();

            // Запускаем поток для приема сообщений
            //_receiveThread = new Thread(ReceiveThread);
            //_receiveThread.Start();
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
            List<byte> buffer = new List<byte>();
            for (int i = 0; i < message.GetLength(0); i++)
            {
                for (int j = 0; j < message.GetLength(1); j++)
                {      
                    buffer.Add(message[i, j]);
                }
            }
            _stream.Write(buffer.ToArray(), 0, buffer.Count);
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
        /// Метод для поиска устройств
        /// </summary>
        /// <returns>Список устройств, доступных для подключения</returns>
        public static BluetoothDeviceInfo[] Search()
        {
            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();
            return devices;
        }

        /// <summary>
        /// Метод отключения от устройства
        /// </summary>
        public void Dispose()
        {
            //_receiveThread.Abort();
            _stream.Dispose();
            _client.Dispose();
        }
    }
}
