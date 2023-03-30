const int pins[] = {3,4,5,6,7,8,9,10,11,12,A0,A1,A2,A3}; // Пины светодиодных сегментов
int hallPin = 2;                     // Пин для считывания значения датчика Холла
int hallVal = HIGH;//LOW можно поставить                   // Исходное значение считывания датчика Холла

int i, j;

int minSecArrow[] = {0,0,0,0,1,1,1,1,1,1,1,1,1,1};
int secIndex = 2;
int minIndex = 45;

int hourArrow[] = {0,0,0,0,0,0,0,0,1,1,1,1,1,1};
int hourIndex = 0;

//volatile int revolutions = 0; // Количество оборотов
unsigned long lastTime = 0;     // Время последнего изменения положения стрелок
unsigned long currentTime = 0;  // Текущее время
unsigned long elapsedTime = 0;  // Время, прошедшее с последнего изменения положения стрелок
unsigned long pause = 0;        // Пауза между изменениями положения стрелок

int ledMatrix[60][14] = 
  {
    {HIGH,HIGH,HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW}, //0
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW}, //1
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},  //2
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,HIGH,HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW}, //3
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW}, //4
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},  //5
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,HIGH,HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW}, //6
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW}, //7
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},  //8
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,HIGH,HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW}, //9
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW}, //10
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},  //11
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
    {HIGH,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW,LOW},
  };

void setup() 
{
  for(i = 0; i < 8; i++)
  {
    pinMode(pins[i], OUTPUT);    
  }

  pinMode(hallPin, INPUT);

  //FALLING - регистрация изменения сигнала от HIGH к LOW    
  attachInterrupt(digitalPinToInterrupt(hallPin), countRevolutions, FALLING); // Настраиваем прерывание для подсчета оборотов

  Serial.begin(9600);
}

void loop() 
{
  //drawClock();
  /*
  if (elapsedTime >= 1000) { //Подсчет rmp раз в секунду, МБ понадобится
    float rpm = ((float)revolutions / (float)elapsedTime) * 60000.0;
    Serial.print("RPM: ");
    Serial.println(rpm);
    revolutions = 0;
    lastTime = currentTime;
  }
  */
  
  for (i = 0; i < 60; i++) {
    if(i == secIndex || i == minIndex){
      for (j = 7; j > 2; j--) { // перебираем элементы массива                
        digitalWrite(pins[j], minSecArrow[j]); // зажигаем или гасим светодиод в соответствии с элементом массива
      }     
    }
    else if(i == hourIndex){
      for (j = 7; j > 3; j--) { // перебираем элементы массива                                                    
        digitalWrite(pins[j], hourArrow[j]); // зажигаем или гасим светодиод в соответствии с элементом массива
      }           
    }       
    for (j = 0; j < 3; j++) { // перебираем элементы массива (первые три лампы, т.к. они только они меняются на циферблате)                                                  
      digitalWrite(pins[j], ledMatrix[i][j]); // зажигаем или гасим светодиод в соответствии с элементом массива
    }
    
    if (elapsedTime > 1000){
      elapsedTime = 0;
      secIndex++;
      if(secIndex == 60){
        secIndex = 0;
        minIndex++;
        if(minIndex == 60){
          minIndex = 0;
          hourIndex+=5;
          if(hourIndex == 60){
            hourIndex = 0;                                        
          }                
        }
      }
    }
    
    delayMicroseconds(pause);
    
    for (j = 0; j < 14; j++) { // перебираем элементы массива                                                      
      digitalWrite(pins[j], LOW); // зажигаем или гасим светодиод в соответствии с элементом массива
    }
    
    delayMicroseconds(pause);
  }
}

void countRevolutions() {
  //revolutions++;  
  currentTime = millis();
  elapsedTime += currentTime - lastTime;
  pause = (currentTime - lastTime) / 120;
  lastTime = currentTime;
}

// Отрисовка циферблата
void drawClock() {
  for (i = 0; i < 60; i++) {
    if(i == secIndex || i == minIndex){
      for (j = 7; j > 2; j--) { // перебираем элементы массива                
        digitalWrite(pins[j], minSecArrow[j]); // зажигаем или гасим светодиод в соответствии с элементом массива
      }     
    }
    else if(i == hourIndex){
      for (j = 7; j > 3; j--) { // перебираем элементы массива                                                    
        digitalWrite(pins[j], hourArrow[j]); // зажигаем или гасим светодиод в соответствии с элементом массива
      }           
    }       
    for (j = 0; j < 3; j++) { // перебираем элементы массива (первые три лампы, т.к. они только они меняются на циферблате)                                                  
      digitalWrite(pins[j], ledMatrix[i][j]); // зажигаем или гасим светодиод в соответствии с элементом массива
    }
    
    if (elapsedTime > 1000){
      elapsedTime = 0;
      secIndex++;
      if(secIndex == 60){
        secIndex = 0;
        minIndex++;
        if(minIndex == 60){
          minIndex = 0;
          hourIndex+=5;
          if(hourIndex == 60){
            hourIndex = 0;                                        
          }                
        }
      }
    }
    
    delayMicroseconds(pause);
    
    for (j = 0; j < 14; j++) { // перебираем элементы массива                                                      
      digitalWrite(pins[j], LOW); // зажигаем или гасим светодиод в соответствии с элементом массива
    }
    
    delayMicroseconds(pause);
  }
}