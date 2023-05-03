#include <SoftwareSerial.h>
SoftwareSerial btSerial(A5, A6); // RX, TX пины для модуля Bluetooth

const int pins[] = {3,4,5,6,7,8,9,10,11,12,A3,A2,A1,A0};  // Пины светодиодных сегментов
int hallPin = 2;                                          // Пин для считывания значения датчика Холла

int i, j;

unsigned char minSecArrow[] = {0x1E,0xFE}; //Макет минутной и секундной стрелок
int secIndex = 2;  
int minIndex = 45; 

unsigned char hourArrow[] = {0x00,0x3E}; //Макет часовой стрелки
int hourIndex = 0;

unsigned long lastTime = 0;     // Время последнего изменения положения стрелок
unsigned long currentTime = 0;  // Текущее время
unsigned long elapsedTime = 0;  // Время, прошедшее с последнего изменения положения стрелок
long double pause = 1000;      // Задержка

unsigned char ledMatrix[120] =
  {
    0xE0,0x00, //0 
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0xC0,0x00, //1
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0xC0,0x00,  //2
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0xE0,0x00, //3
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0xC0,0x00, //4
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0xC0,0x00,  //5
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0xE0,0x00, //6
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0xC0,0x00, //7
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0xC0,0x00,  //8
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0xE0,0x00, //9
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0xC0,0x00, //10
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0xC0,0x00,  //11
    0x80,0x00,
    0x80,0x00,
    0x80,0x00,
    0x80,0x00
  };

byte buffer[60];
int index = 0;
bool isClock = true;

void setup() 
{
  // Инициализация последовательного порта для Bluetooth
  btSerial.begin(9600);
  Serial.begin(9600);
  for(i = 0; i < 14; i++)
  {
    pinMode(pins[i], OUTPUT);    
  }

  pinMode(hallPin, INPUT);

  //FALLING - регистрация изменения сигнала от HIGH к LOW    
  //attachInterrupt(digitalPinToInterrupt(hallPin), draw, FALLING); // Настраиваем прерывание для подсчета оборотов
}

void loop() 
{
  if(btSerial.available() > 0) {
    while(btSerial.available() < 60);
    btSerial.readBytes((byte*)buffer, 60);
    if(index == 0) {
      memcpy(ledMatrix + 0, buffer + 0, 60);
      index = 1;
    }
    else if(index == 1) {
      memcpy(ledMatrix + 60, buffer + 0, 60);
      index = 0;
      if(bitRead(ledMatrix[0], 0) == 1){
        isClock = true;
        for(i = 0; i < 8; i++){
          bitWrite(hourIndex, i, bitRead(ledMatrix[(i + 1) * 2], 0));
          bitWrite(minIndex, i, bitRead(ledMatrix[(i + 9) * 2], 0));
          bitWrite(secIndex, i, bitRead(ledMatrix[(i + 17) * 2], 0));
        }
      }
      else {
        isClock = false;
      }
    }
  }
  while(digitalRead(hallPin) != 0);
  draw();
}

void countRevolutions() {
  //revolutions++;  
  currentTime = millis(); //МБ через rpm делать?
  elapsedTime += currentTime - lastTime;
  pause = (currentTime - lastTime); //60 //120;
  lastTime = currentTime;
  /*for (i = 0; i < 60; i++){
    drawClock();    
  }*/
  draw();
}

// Отрисовка дисплея
void draw() {
  if(isClock){
    currentTime = millis();
    elapsedTime += currentTime - lastTime;
    //pause = (currentTime - lastTime) / 500;
    lastTime = currentTime;
    if (elapsedTime > 1000){
      elapsedTime = 0;
      secIndex-=2;
      if(secIndex < 0){
        secIndex = 118;
        minIndex-=2;
        if(minIndex < 0){
          minIndex = 118;
          hourIndex-=10;
          if(hourIndex < 0){
            hourIndex = 110;                                        
          }                
        }
      }
    }
  }
    
  for (i = 0; i < 120; i+=2) {
    for (j = 0; j < 7; j++) { 
      digitalWrite(pins[j], bitRead(ledMatrix[i], 7 - j));
      digitalWrite(pins[j+7], bitRead(ledMatrix[i + 1], 7 - j));
    }
    if(isClock) {
      if(i == secIndex || i == minIndex){
        for (j = 6; j > -1; j--) {               
          digitalWrite(pins[j], bitRead(minSecArrow[0], 7 - j));
          digitalWrite(pins[j+7], bitRead(minSecArrow[1], 7 - j));
        } 
      }
      else if(i == hourIndex){
        for (j = 6; j > -1; j--) {              
          digitalWrite(pins[j], bitRead(hourArrow[0], 7 - j));
          digitalWrite(pins[j+7], bitRead(hourArrow[1], 7 - j));
        }   
      } 
    }      
    
    delayMicroseconds(100);
    
    for (j = 0; j < 14; j++) { // перебираем элементы массива                                                      
      digitalWrite(pins[j], LOW); 
    }
    
    delayMicroseconds(pause);
  }
}
