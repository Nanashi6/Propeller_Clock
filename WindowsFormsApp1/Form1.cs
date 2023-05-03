using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создаем новое изображение размером 8x5 пикселей
            Bitmap bmp = new Bitmap(5, 8);

            // Создаем объект Graphics на основе нового изображения
            Graphics graphics = Graphics.FromImage(bmp);

            // Создаем новый фонт для вывода текста размером 5 пикселей
            Font font = new Font("Arial", 8);

            // Создаем новую кисть для рисования
            Brush brush = new SolidBrush(Color.Black);

            // Рисуем символ на изображении с отступом 1 пиксель от краев изображения
            graphics.DrawString("A", font, brush, 0, 0);

            // Отображаем изображение на PictureBox
            pictureBox1.Image = bmp;
        }
    }
}
