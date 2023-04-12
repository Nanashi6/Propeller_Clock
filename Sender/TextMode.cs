using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    public class TextSender
    {
        public string text { get; private set; }

        public TextSender(string text)
        {
            this.text = text;
        }

        public void SetText(string text)
        {
            this.text = text;
        }

        //Метод для преобразования текста в матричное изображение   +
        //Метод для возврата массива со значениями, либо сразу метод для отправки этого массива на ардуино

        //Массив можно отрисовывать на экране для проверки (или в консоли)

        private Image GetLetterImage(char letter)
        {
            // здесь вы можете создать изображение пикселей для каждой буквы,
            // используя ваш выбранный шрифт и размер
            Bitmap bmp = new Bitmap(8, 5);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawString(letter.ToString(), new Font("Arial", 8), Brushes.White, 0, 0);
            return bmp;
        }

        // затем вы можете создать функцию, которая отображает текст на матрице светодиодов
        private void DisplayTextOnLEDMatrix(string text)
        {
            // создайте массив пикселей для матрицы светодиодов
            int[,] pixels = new int[60, 14];

            // цикл по всем символам в тексте
            int x = 0;
            foreach (char letter in text)
            {
                // получить изображение для буквы
                Image letterImage = GetLetterImage(letter);

                // цикл по всем пикселям в изображении буквы
                for (int i = 0; i < letterImage.Width; i++)
                {
                    for (int j = 0; j < letterImage.Height; j++)
                    {
                        // получить значение пикселя в изображении буквы
                        Color pixelColor = ((Bitmap)letterImage).GetPixel(i, j);

                        // преобразовать цвет пикселя в значение яркости (0 или 1)
                        int brightness = (pixelColor.R + pixelColor.G + pixelColor.B) / 3 > 128 ? 0 : 1;

                        // установить значение пикселя на матрице светодиодов
                        pixels[x + i, j] = brightness;
                    }
                }

                // переместить указатель X на следующую позицию для следующей буквы
                x += letterImage.Width + 1; // добавляем единицу для отступа между буквами
            }
        }

    }
}
