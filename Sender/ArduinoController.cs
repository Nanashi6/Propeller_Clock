using InTheHand.Net.Sockets;
using Mods;
using Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sender
{
    public class ArduinoController
    {
        private BluetoothTerminal _terminal;
        private ClockMode _clockMode = new ClockMode();
        private TextMode _textMode = new TextMode();
        private byte[,] _data = new byte[60, 2];
        private byte[,] _buffer = new byte[30, 2];

        public void ConnectToArduino(BluetoothDeviceInfo device)
        {
            _terminal = new BluetoothTerminal(device);
        }

        public void DisconnectFromArduino()
        {
            _terminal.Dispose();
        }

        public void SetClockMode() 
        {
            _data = _clockMode.GetDataArray();
            for (int i = 0; i < _buffer.GetLength(0); i++)
            {
                for (int j = 0; j < _buffer.GetLength(1); j++)
                {
                    _buffer[i, j] = _data[i, j];
                }
            }
            _terminal.SendMessage(_buffer);
            Thread.Sleep(1000);
            for (int i = 0; i < _buffer.GetLength(0); i++)
            {
                for (int j = 0; j < _buffer.GetLength(1); j++)
                {
                    _buffer[i, j] = _data[i + 30, j];
                }
            }
            _terminal.SendMessage(_buffer);
        }

        public void SetTextMode(string message)
        {
            _textMode.TextToMatrix(message);

            _data = _textMode.GetDataArray();

            for (int i = 0; i < _buffer.GetLength(0); i++)
            {
                for (int j = 0; j < _buffer.GetLength(1); j++)
                {
                    _buffer[i, j] = _data[i, j];
                }
            }
            _terminal.SendMessage(_buffer);
            Thread.Sleep(1000);
            for (int i = 0; i < _buffer.GetLength(0); i++)
            {
                for (int j = 0; j < _buffer.GetLength(1); j++)
                {
                    _buffer[i, j] = _data[i + 30, j];
                }
            }
            _terminal.SendMessage(_buffer);
        }
    }
}
