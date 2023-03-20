using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace ArduinoUI
{
    public partial class MainForm : Form
    {
        bool isConnected = false;                               //Переменная отвечающая за состояние подключения: true - подключено, false - отключено

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод опрашивает COM-порты и создаёт список из доступных для ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArduinoButton_Click(object sender, EventArgs e)
        {
            comboBox.Items.Clear();
            
            string[] portnames = SerialPort.GetPortNames();     // Получаем список COM портов доступных в системе

            if (portnames.Length == 0)                          // Проверяем есть ли доступные
            {
                MessageBox.Show("COM порт не найден");
            }
            foreach (string portName in portnames)
            {         
                comboBox.Items.Add(portName);                   //добавляем доступные COM порты в список  
                Console.WriteLine(portnames.Length);
                if (portnames[0] != null)
                {
                    comboBox.SelectedItem = portnames[0];
                }
            }
        }

        /// <summary>
        /// Действия при закрытии окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen) serialPort.Close();          // При закрытии программы, закрываем порт
        }

        /// <summary>
        /// Действия при нажатии на кнопку "Подключится"/"Отключится"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                ConnectToArduino();
            }
            else
            {
                DisconnectFromArduino();
            }
        }

        /// <summary>
        /// Открытие выбранного COM-порта для связи с Arduino
        /// Изменение надписи "Подключится" на "Отключиться"
        /// </summary>
        private void ConnectToArduino()
        {
            isConnected = true;
            string selectedPort = comboBox.GetItemText(comboBox.SelectedItem);
            serialPort.PortName = selectedPort;
            serialPort.Open();
            ConnectButton.Text = "Отключится";
        }

        /// <summary>
        /// Закрытие выбранного COM-порта для связи с Arduino
        /// Изменение надписи "Отключиться" на "Подключится"
        /// </summary>
        private void DisconnectFromArduino()
        {
            isConnected = false;
            serialPort.Close();
            ConnectButton.Text = "Подключится";
        }

        /// <summary>
        /// Метод отправляет в COM-порт заданное сообщение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                serialPort.Write(MessageText.Text);
            }
        }

        /// <summary>
        /// Метод сбрасывает все изменения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                serialPort.Write("");
            }
        }

        /// <summary>
        /// Метод запускает режим аналоговых часов  -__('_')__-
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnalogClockButton_Click(object sender, EventArgs e)
        {
            if (isConnected)                            //МБ ещё время для RTC модуля будет отправлять
            {
                serialPort.Write("1");
            }
        }
    }
}

