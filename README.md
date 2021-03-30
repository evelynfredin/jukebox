# Jukebox Singing Wars

![ezgif-1-ba9328b49388](https://user-images.githubusercontent.com/45714191/112944139-b9692480-9132-11eb-99d4-73398ae4559f.gif)

The crowd is going insane, this party can't stop now. This **Jukebox T-1000** is filled with greatest-hits, but its up to you to decide who is going to sing.

To mess around with this project, you can use an Arduino with an LCD screen, or simply use the Command Line. (Command line is the default, but if you have a board, just pass the `uno` variable to `cli`.)

## To use this program with the Command Line:

**On `Program.cs:17`**

Make sure this line is correct and you should be good to go:

```CSharp
var cli = new Cli(cmd);
```

## To use this program with the Arduino Uno:

If you have an Arduino lying around simply follow the illustration below to hook the scree to the board. You'll need:

- A single 220 OHM resistor
- 1 Potentiometer
- An LCD screen (duh!)
- Some jumper wires

![LCD-Demo-Hookup](https://user-images.githubusercontent.com/45714191/112905963-a97a2200-90eb-11eb-8b86-089b129027db.jpeg)

Image taken from [DroneBotWorkshop.com](https://dronebotworkshop.com/lcd-displays-arduino/)

**On `Program.cs:17`**

Update the following:

```CSharp
var cli = new Cli(uno);
```

**On `ArduinoSinger.cs:11`**

Figure out the name of your port and add it

```CSharp
private SerialPort port = new SerialPort("YOUR/PORT/NAME", 9600, Parity.None, 8, StopBits.One);
```

Enjoy!
