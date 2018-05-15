  /*
  Mini Traceur Arduino (CNC Plotter)
  Test X Axis
  Projets DIY 02/2016
*/
#include <Stepper.h>      // Include the stepper Motor librarie 
 
const int pasParRotation = 24;          // Number of steps by turn. Standard value for CD/DVD
 
// Indicate X axis stepper motor Pins 
Stepper myStepperX(pasParRotation, 2,3,4,5); 
 
void setup() {
  myStepperX.setSpeed(100);    // Stepper motor speed
}
 
void loop() {
 
 // Indicate the number of steps the drive need to do. 
 // CD/DVD drive can do about 250 steps max.
 // Negative number to reverse direction of the movement
 myStepperX.step(200);            // Measure the distance the pencil move to calculate X calibration value  
 delay(100);
 myStepperX.step(-200);
 delay(100);
 }
