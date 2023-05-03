using InTheHand.Net.Sockets;
using Sender;
using Mods;
using System.Threading;
using System.Windows;
using System;

namespace SenderUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BluetoothDeviceInfo[] devices;
        ArduinoController controller = new ArduinoController();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                devices = BluetoothTerminal.Search();
                foreach (BluetoothDeviceInfo device in devices)
                {
                    Devices_ComboBox.Items.Add(device.DeviceName);
                }
                Devices_ComboBox.Text = Devices_ComboBox.Items[0].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Connect_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (BluetoothDeviceInfo device in devices)
                {
                    if (device.DeviceName == Devices_ComboBox.Text)
                    {
                        controller.ConnectToArduino(device);
                        break;
                    }
                }
                Disconnect_Button.Visibility = Visibility.Visible;
                Connect_Button.Visibility = Visibility.Hidden;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Disconnect_Button_Click(object sender, RoutedEventArgs e)
        {
            controller.DisconnectFromArduino();
            Disconnect_Button.Visibility = Visibility.Hidden;
            Connect_Button.Visibility = Visibility.Visible;
        }

        private void ClockMode_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.SetClockMode();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Отсутствует связь с устройством");
            }
        }

        private void TextMode_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.SetTextMode(MainText.Text);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Отсутствует связь с устройством");
            }
        }
    }
}
