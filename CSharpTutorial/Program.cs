using System;
using SystemStatus;
using Shapes;

public class MainClass
{
    static void Main()
    {
        var sq = new Square(12);

        var rect = new Rectangle(4, 5);

        var circ = new Circle(6);

        Console.WriteLine($"我有三個形狀，\n{sq}\n{rect}\n{circ}。");
        //可以試試看把class Shape裡面，ToString前面的 "overwride" 改成 "virtual new", 看這裡印出來的東西有什麼不同。
        //""

        Console.WriteLine($"RSSI: {Bluetooth.SignalStrength} dBm");

    }
}