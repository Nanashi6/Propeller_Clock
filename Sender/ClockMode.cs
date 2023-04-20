﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    public class ClockMode
    {
        private byte[,] _data = {
                                {0b11100000, 0b00000000 }, //12       
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
                                {0b10000000, 0b00000000 },        
                               };
        public ClockMode() { }

        /// <summary>
        /// Метод возвращает массив, готовый к отрисовке
        /// </summary>
        /// <returns></returns>
        public byte[,] GetDataArray()
        {
            return _data;
        }
    }
}
