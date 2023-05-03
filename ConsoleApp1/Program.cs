using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using Sender;
using Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ConsoleApp1
{
    internal class Program
    {
        private static byte[,] _dataClock = {
                                {0b11100001, 0b00000000 }, //12       
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b11000000, 0b00000000 }, //1 //11       
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b11000000, 0b00000000 }, //2 //10      
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b11100000, 0b00000000 }, //3 //9      
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b11000000, 0b00000000 }, //4 //8       
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b11000000, 0b00000000 }, //5 //7      
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b11100000, 0b00000000 }, //6 //6      
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b11000000, 0b00000000 }, //7 //5       
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b11000000, 0b00000000 }, //8 //4      
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b11100000, 0b00000000 }, //9 //3      
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b11000000, 0b00000000 }, //10 //2       
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b11000000, 0b00000000 }, //11 //1     
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 },
                                {0b10000000, 0b00000000 }
                               };
        private static byte[,] _data = new byte[60, 2];
        static void Main(string[] args)
        {
            /*TextMode textMode = new TextMode();
            int[,] ints = new int[60, 8];
            int[,] ints1;

            for (int i = 0; i < ints.GetLength(0); ++i)
            {
                for (int j = 0; j < ints.GetLength(1); ++j)
                {
                    ints[i, j] = 0;
                }
            }

            for (int i = 0; i < ints.GetLength(0); ++i)
            {
                for (int j = 0; j < ints.GetLength(1); ++j)
                {
                    Console.Write(ints[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            textMode.TextToMatrix("Example", out ints1);

            for (int i = 0; i < ints.GetLength(0); ++i)
            {
                for (int j = 0; j < ints.GetLength(1); ++j)
                {
                    ints[i, j] = ints1[i, j];
                }
            }

            for (int i = 0; i < ints.GetLength(0); ++i)
            {
                for (int j = 0; j < ints.GetLength(1); ++j)
                {
                    Console.Write(ints[i, j] + " ");
                }
                Console.WriteLine();
            }*/
            TextMode textMode = new TextMode();
            BluetoothDeviceInfo[] devices = BluetoothTerminal.Search();
            foreach (BluetoothDeviceInfo device in devices)
            {
                Console.WriteLine(device.DeviceAddress + ":" + device.DeviceName);
            }
            Console.ReadLine();

            BluetoothTerminal terminal = new BluetoothTerminal("00:21:13:01:43:B5");

            while (true)
            {
                // Ожидание ввода сообщения
                Console.Write("Enter message: ");
                string message = Console.ReadLine();
                if(message == "Clock")
                {
                    //terminal.SendMessage("1,");
                    byte[,] buffer = new byte[30, 2];
                    for(int i = 0; i < buffer.GetLength(0); i++)
                    {
                        for(int j = 0; j < buffer.GetLength(1); j++)
                        {
                            buffer[i, j] = _dataClock[i, j];
                        }
                    }
                    terminal.SendMessage(buffer);
                    Thread.Sleep(2500);
                    for (int i = 0; i < buffer.GetLength(0); i++)
                    {
                        for (int j = 0; j < buffer.GetLength(1); j++)
                        {
                            buffer[i, j] = _dataClock[i + 30, j];
                            Console.WriteLine(_dataClock[i + 30, j]);
                        }
                    }
                    terminal.SendMessage(buffer);
                    //terminal.SendMessage(_dataClock);
                    //terminal.SendMessage("12, 17, 30 ");
                }
                else
                {
                    //terminal.SendMessage("2,");
                    textMode.TextToMatrix(message, out _data);
                    
                    byte[,] buffer = new byte[30, 2];
                    for (int i = 0; i < buffer.GetLength(0); i++)
                    {
                        for (int j = 0; j < buffer.GetLength(1); j++)
                        {
                            buffer[i, j] = _data[i, j];
                        }
                    }
                    /*for (int i = 0; i < buffer.GetLength(0); i++)
                    {
                        for (int j = 0; j < buffer.GetLength(1); j++)
                        {
                            Console.Write(buffer[i, j] + " ");
                        }
                        Console.WriteLine();
                    }*/
                    terminal.SendMessage(buffer);
                    buffer = new byte[30, 2];
                    Thread.Sleep(2500);
                    for (int i = 0; i < buffer.GetLength(0); i++)
                    {
                        for (int j = 0; j < buffer.GetLength(1); j++)
                        {
                            buffer[i, j] = 0/*_data[i + 30, j]*/;
                        }
                    }
                    /*for (int i = 0; i < buffer.GetLength(0); i++)
                    {
                        for (int j = 0; j < buffer.GetLength(1); j++)
                        {
                            Console.Write(buffer[i, j] + " ");
                        }
                        Console.WriteLine();
                    }*/
                    terminal.SendMessage(buffer);
                    //terminal.SendMessage(_data);
                }
            }
        }
    }
}
