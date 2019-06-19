#include "pins_arduino.h" // Arduino pre-1.0 needs this

int serialconnected = 1;
String serialrx = "";
String Cversion = "sta:V0.1b:";
int up_old = 0;
int down_old = 0;
int left_old = 0;
int right_old = 0;
int up_curr = 0;
int down_curr = 0;
int left_curr = 0;
int right_curr = 0;
const int threshold = 13; //threshold
const int up_threshold = 15; //threshold up arrow
const int down_threshold = threshold;
const int left_threshold = threshold;
const int right_threshold = threshold;
const int up_pin = 2;
const int down_pin = 3;
const int left_pin = 4;
const int right_pin = 5;
const int serial_speed = 19200;  //serial baud
/*const String up_press = ".u_p.";        //old protocol
const String down_press = ".d_p.";
const String left_press = ".l_p.";
const String right_press = ".r_p.";
const String up_release = ".u_r.";
const String down_release = ".d_r.";
const String left_release = ".l_r.";
const String right_release = ".r_r.";*/

const String up_press = ".up";
const String down_press = ".dp";
const String left_press = ".lp";
const String right_press = ".rp";

const String up_release = ".ur";
const String down_release = ".dr";
const String left_release = ".lr";
const String right_release = ".rr";

long lastDebounceTime_up = 0;  // the last time the output pin was toggled
long debounceDelay_up = 50;    // the debounce time; increase if the output flickers
long lastDebounceTime_down = 0;  // the last time the output pin was toggled
long debounceDelay_down = 50;    // the debounce time; increase if the output flickers
long lastDebounceTime_left = 0;  // the last time the output pin was toggled
long debounceDelay_left = 50;    // the debounce time; increase if the output flickers
long lastDebounceTime_right = 0;  // the last time the output pin was toggled
long debounceDelay_right = 50;    // the debounce time; increase if the output flickers


void setup() {
  // put your setup code here, to run once:
Serial.begin(serial_speed);
Serial.print(Cversion);
serialrx.reserve(200);
while(!Serial){}
delay(2000);
}



void loop() {
up();
down();
left();
right();
}

void up(){
    up_curr = readCapacitivePin(up_pin);
  //Serial.println(up_curr);
  if ( (millis() - lastDebounceTime_up) > debounceDelay_up) {
  if(up_curr>=up_threshold){
    up_curr=1;
  }else{
    up_curr=0;
  }
  //Serial.println(up_curr);
  if(up_curr!=up_old){
    if(up_curr==1){
      Serial.print(up_press);
      lastDebounceTime_up = millis();
    }else{
      Serial.print(up_release);
      lastDebounceTime_up = millis();
    }
  }
  up_old=up_curr;
  }
}

void down(){
  down_curr = readCapacitivePin(down_pin);
  //Serial.println(down_curr);
  if ( (millis() - lastDebounceTime_down) > debounceDelay_down) {
  if(down_curr>=threshold){
    down_curr=1;
  }else{
    down_curr=0;
  }
  //Serial.println(down_curr);
  if(down_curr!=down_old){
    if(down_curr==1){
      Serial.print(down_press);
      lastDebounceTime_down = millis();
    }else{
      Serial.print(down_release);
      lastDebounceTime_down = millis();
    }
  }
  down_old=down_curr;
  }
}

void left(){
    left_curr = readCapacitivePin(left_pin);
  //Serial.println(left_curr);
  if ( (millis() - lastDebounceTime_left) > debounceDelay_left) {
  if(left_curr>=threshold){
    left_curr=1;
  }else{
    left_curr=0;
  }
  //Serial.println(left_curr);
  if(left_curr!=left_old){
    if(left_curr==1){
      Serial.print(left_press);
      lastDebounceTime_left = millis();
    }else{
      Serial.print(left_release);
      lastDebounceTime_left = millis();
    }
  }
  left_old=left_curr;
  }
}

void right(){
    right_curr = readCapacitivePin(right_pin);
  //Serial.println(right_curr);
  if ( (millis() - lastDebounceTime_right) > debounceDelay_right) {
  if(right_curr>=threshold){
    right_curr=1;
  }else{
    right_curr=0;
  }
  //Serial.println(right_curr);
  if(right_curr!=right_old){
    if(right_curr==1){
      Serial.print(right_press);
      lastDebounceTime_right = millis();
    }else{
      Serial.print(right_release);
      lastDebounceTime_right = millis();
    }
  }
  right_old=right_curr;
  }
}

uint8_t readCapacitivePin(int pinToMeasure) {
  // Variables used to translate from Arduino to AVR pin naming
  volatile uint8_t* port;
  volatile uint8_t* ddr;
  volatile uint8_t* pin;
  // Here we translate the input pin number from
  //  Arduino pin number to the AVR PORT, PIN, DDR,
  //  and which bit of those registers we care about.
  byte bitmask;
  port = portOutputRegister(digitalPinToPort(pinToMeasure));
  ddr = portModeRegister(digitalPinToPort(pinToMeasure));
  bitmask = digitalPinToBitMask(pinToMeasure);
  pin = portInputRegister(digitalPinToPort(pinToMeasure));
 // Discharge the pin first by setting it low and output
  *port &= ~(bitmask);
  *ddr  |= bitmask;
  delay(1);
  uint8_t SREG_old = SREG; //back up the AVR Status Register
  // Prevent the timer IRQ from disturbing our measurement
  noInterrupts();
  // Make the pin an input with the internal pull-up on
  *ddr &= ~(bitmask);
  *port |= bitmask;

  // Now see how long the pin to get pulled up. This manual unrolling of the loop
  // decreases the number of hardware cycles between each read of the pin,
  // thus increasing sensitivity.
  uint8_t cycles = 17;
  if (*pin & bitmask) { cycles =  0;}
  else if (*pin & bitmask) { cycles =  1;}
  else if (*pin & bitmask) { cycles =  2;}
  else if (*pin & bitmask) { cycles =  3;}
  else if (*pin & bitmask) { cycles =  4;}
  else if (*pin & bitmask) { cycles =  5;}
  else if (*pin & bitmask) { cycles =  6;}
  else if (*pin & bitmask) { cycles =  7;}
  else if (*pin & bitmask) { cycles =  8;}
  else if (*pin & bitmask) { cycles =  9;}
  else if (*pin & bitmask) { cycles = 10;}
  else if (*pin & bitmask) { cycles = 11;}
  else if (*pin & bitmask) { cycles = 12;}
  else if (*pin & bitmask) { cycles = 13;}
  else if (*pin & bitmask) { cycles = 14;}
  else if (*pin & bitmask) { cycles = 15;}
  else if (*pin & bitmask) { cycles = 16;}

  // End of timing-critical section; turn interrupts back on if they were on before, or leave them off if they were off before
  SREG = SREG_old;

  // Discharge the pin again by setting it low and output
  //  It's important to leave the pins low if you want to 
  //  be able to touch more than 1 sensor at a time - if
  //  the sensor is left pulled high, when you touch
  //  two sensors, your body will transfer the charge between
  //  sensors.
  *port &= ~(bitmask);
  *ddr  |= bitmask;

  return cycles;
}

void serialEvent() {
  while (Serial.available()) {
    if(Serial.readString()=="rst"){
      Serial.print(Cversion);
    }
  }
}

