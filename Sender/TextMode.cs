﻿using System;
using System.Collections;

namespace Sender
{
    public class TextMode
    {
        private byte[,] _font =
        {
         {0x00,0x00,0x00,0x00,0x00, 0x00},   //   0x20 32
         {0x00,0x00,0x6f,0x00,0x00, 0x00},   // ! 0x21 33
         {0x00,0x07,0x00,0x07,0x00, 0x00},   // " 0x22 34
         {0x14,0x7f,0x14,0x7f,0x14, 0x00},   // # 0x23 35
         {0x00,0x07,0x04,0x1e,0x00, 0x00},   // $ 0x24 36
         {0x23,0x13,0x08,0x64,0x62, 0x00},   // % 0x25 37
         {0x36,0x49,0x56,0x20,0x50, 0x00},   // & 0x26 38
         {0x00,0x00,0x07,0x00,0x00, 0x00},   // ' 0x27 39
         {0x00,0x1c,0x22,0x41,0x00, 0x00},   // ( 0x28 40
         {0x00,0x41,0x22,0x1c,0x00, 0x00},   // ) 0x29 41
         {0x14,0x08,0x3e,0x08,0x14, 0x00},   // * 0x2a 42
         {0x08,0x08,0x3e,0x08,0x08, 0x00},   // + 0x2b 43
         {0x00,0x50,0x30,0x00,0x00, 0x00},   // , 0x2c 44
         {0x08,0x08,0x08,0x08,0x08, 0x00},   // - 0x2d 45
         {0x00,0x60,0x60,0x00,0x00, 0x00},   // . 0x2e 46
         {0x20,0x10,0x08,0x04,0x02, 0x00},   // / 0x2f 47
         {0x3e,0x51,0x49,0x45,0x3e, 0x00},   // 0 0x30 48
         {0x00,0x42,0x7f,0x40,0x00, 0x00},   // 1 0x31 49
         {0x42,0x61,0x51,0x49,0x46, 0x00},   // 2 0x32 50
         {0x21,0x41,0x45,0x4b,0x31, 0x00},   // 3 0x33 51
         {0x18,0x14,0x12,0x7f,0x10, 0x00},   // 4 0x34 52
         {0x27,0x45,0x45,0x45,0x39, 0x00},   // 5 0x35 53
         {0x3c,0x4a,0x49,0x49,0x30, 0x00},   // 6 0x36 54
         {0x01,0x71,0x09,0x05,0x03, 0x00},   // 7 0x37 55
         {0x36,0x49,0x49,0x49,0x36, 0x00},   // 8 0x38 56
         {0x06,0x49,0x49,0x29,0x1e, 0x00},   // 9 0x39 57
         {0x00,0x36,0x36,0x00,0x00, 0x00},   // : 0x3a 58
         {0x00,0x56,0x36,0x00,0x00, 0x00},   // ; 0x3b 59
         {0x08,0x14,0x22,0x41,0x00, 0x00},   // < 0x3c 60
         {0x14,0x14,0x14,0x14,0x14, 0x00},   // = 0x3d 61
         {0x00,0x41,0x22,0x14,0x08, 0x00},   // > 0x3e 62
         {0x02,0x01,0x51,0x09,0x06, 0x00},   // ? 0x3f 63
         {0x3e,0x41,0x5d,0x49,0x4e, 0x00},   // @ 0x40 64
         {0x7e,0x09,0x09,0x09,0x7e, 0x00},   // A 0x41 65
         {0x7f,0x49,0x49,0x49,0x36, 0x00},   // B 0x42 66
         {0x3e,0x41,0x41,0x41,0x22, 0x00},   // C 0x43 67
         {0x7f,0x41,0x41,0x41,0x3e, 0x00},   // D 0x44 68
         {0x7f,0x49,0x49,0x49,0x41, 0x00},   // E 0x45 69
         {0x7f,0x09,0x09,0x09,0x01, 0x00},   // F 0x46 70
         {0x3e,0x41,0x49,0x49,0x7a, 0x00},   // G 0x47 71
         {0x7f,0x08,0x08,0x08,0x7f, 0x00},   // H 0x48 72
         {0x00,0x41,0x7f,0x41,0x00, 0x00},   // I 0x49 73
         {0x20,0x40,0x41,0x3f,0x01, 0x00},   // J 0x4a 74
         {0x7f,0x08,0x14,0x22,0x41, 0x00},   // K 0x4b 75
         {0x7f,0x40,0x40,0x40,0x40, 0x00},   // L 0x4c 76
         {0x7f,0x02,0x0c,0x02,0x7f, 0x00},   // M 0x4d 77
         {0x7f,0x04,0x08,0x10,0x7f, 0x00},   // N 0x4e 78
         {0x3e,0x41,0x41,0x41,0x3e, 0x00},   // O 0x4f 79
         {0x7f,0x09,0x09,0x09,0x06, 0x00},   // P 0x50 80
         {0x3e,0x41,0x51,0x21,0x5e, 0x00},   // Q 0x51 81
         {0x7f,0x09,0x19,0x29,0x46, 0x00},   // R 0x52 82
         {0x46,0x49,0x49,0x49,0x31, 0x00},   // S 0x53 83
         {0x01,0x01,0x7f,0x01,0x01, 0x00},   // T 0x54 84
         {0x3f,0x40,0x40,0x40,0x3f, 0x00},   // U 0x55 85
         {0x0f,0x30,0x40,0x30,0x0f, 0x00},   // V 0x56 86
         {0x3f,0x40,0x30,0x40,0x3f, 0x00},   // W 0x57 87
         {0x63,0x14,0x08,0x14,0x63, 0x00},   // X 0x58 88
         {0x07,0x08,0x70,0x08,0x07, 0x00},   // Y 0x59 89
         {0x61,0x51,0x49,0x45,0x43, 0x00},   // Z 0x5a 90
         {0x3c,0x4a,0x49,0x29,0x1e, 0x00},   // [ 0x5b 91
         {0x02,0x04,0x08,0x10,0x20, 0x00},   // \ 0x5c 92
         {0x00,0x41,0x7f,0x00,0x00, 0x00},   // ] 0x5d 93
         {0x04,0x02,0x01,0x02,0x04, 0x00},   // ^ 0x5e 94
         {0x40,0x40,0x40,0x40,0x40, 0x00},   // _ 0x5f 95
         {0x00,0x00,0x03,0x04,0x00, 0x00},   // ` 0x60 96
         {0x20,0x54,0x54,0x54,0x78, 0x00},   // a 0x61 97
         {0x7f,0x48,0x44,0x44,0x38, 0x00},   // b 0x62 98
         {0x38,0x44,0x44,0x44,0x20, 0x00},   // c 0x63 99
         {0x38,0x44,0x44,0x48,0x7f, 0x00},   // d 0x64 100
         {0x38,0x54,0x54,0x54,0x18, 0x00},   // e 0x65 101
         {0x08,0x7e,0x09,0x01,0x02, 0x00},   // f 0x66 102
         {0x0c,0x52,0x52,0x52,0x3e, 0x00},   // g 0x67 103
         {0x7f,0x08,0x04,0x04,0x78, 0x00},   // h 0x68 104
         {0x00,0x44,0x7d,0x40,0x00, 0x00},   // i 0x69 105
         {0x20,0x40,0x44,0x3d,0x00, 0x00},   // j 0x6a 106
         {0x00,0x7f,0x10,0x28,0x44, 0x00},   // k 0x6b 107
         {0x00,0x41,0x7f,0x40,0x00, 0x00},   // l 0x6c 108
         {0x7c,0x04,0x18,0x04,0x78, 0x00},   // m 0x6d 109
         {0x7c,0x08,0x04,0x04,0x78, 0x00},   // n 0x6e 110
         {0x38,0x44,0x44,0x44,0x38, 0x00},   // o 0x6f 111
         {0x7c,0x14,0x14,0x14,0x08, 0x00},   // p 0x70 112
         {0x08,0x14,0x14,0x18,0x7c, 0x00},   // q 0x71 113
         {0x7c,0x08,0x04,0x04,0x08, 0x00},   // r 0x72 114
         {0x48,0x54,0x54,0x54,0x20, 0x00},   // s 0x73 115
         {0x04,0x3f,0x44,0x40,0x20, 0x00},   // t 0x74 116
         {0x3c,0x40,0x40,0x20,0x7c, 0x00},   // u 0x75 117
         {0x1c,0x20,0x40,0x20,0x1c, 0x00},   // v 0x76 118
         {0x3c,0x40,0x30,0x40,0x3c, 0x00},   // w 0x77 119
         {0x44,0x28,0x10,0x28,0x44, 0x00},   // x 0x78 120
         {0x0c,0x50,0x50,0x50,0x3c, 0x00},   // y 0x79 121
         {0x44,0x64,0x54,0x4c,0x44, 0x00},   // z 0x7a 122
         {0x00,0x08,0x36,0x41,0x41, 0x00},   // { 0x7b 123
         {0x00,0x00,0x7f,0x00,0x00, 0x00},   // | 0x7c 124
         {0x41,0x41,0x36,0x08,0x00, 0x00},   // } 0x7d 125
         {0x04,0x02,0x04,0x08,0x04, 0x00},   // ~ 0x7e 126
        };
        private int _charWidth = 5;
        private int _charHeight = 8;

        public TextMode(/*int charWidth, int charHeigth*/)
        {
            /*_charWidth = charWidth;
            _charHeight = charHeigth;*/
        }

        //Метод для преобразования текста в матричное изображение   +
        //Метод для возврата массива со значениями, либо сразу метод для отправки этого массива на ардуино

        //Массив можно отрисовывать на экране для проверки (или в консоли)

        /*private int[,] PrintLetterBoven(char ch)
        {
            int[,] matrix = new int[_charWidth, _charHeight];

            int charIndex = (int)ch;
            if (charIndex < 32 || charIndex > 126)
            {
                charIndex = 32;
            }
            charIndex -= 32;
            int x = 0;
            for (int i = _charWidth - 1; i > -1; i--)
            {
                byte b = _font[charIndex, i];
                for (int j = 0; j < _charHeight; j++)
                {
                    matrix[x + i, j] = Convert.ToInt32(new BitArray(new byte[] { b })[j]);
                }
            }

            return matrix;
        }*/

        private int[,] PrintLetter(char ch)
        {
            int[,] matrix = new int[_charWidth, _charHeight];

            int charIndex = ch;
            if (charIndex < 32 || charIndex > 126)
            {
                charIndex = 32;
            }
            charIndex -= 32;
            for (int i = 0; i < _charWidth; i++)
            {
                byte b = _font[charIndex, i];
                for (int j = 0; j < _charHeight; j++)
                {
                    matrix[i, j] = Convert.ToInt32(new BitArray(new byte[] { b })[7 - j]);
                }
            }

            return matrix;
        }

        public void TextToMatrix(string text, out int[,] result)
        {
            int[,] matrix;
            result = new int[60, 14];

            int x = 0;
            foreach (char ch in text)
            {
                matrix = PrintLetter(ch);

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        result[x + i, j] = matrix[i, j];
                    }
                }
                x += _charWidth;
            }
        }
    }
}
