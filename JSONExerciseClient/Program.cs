using System;
using System.IO;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text.Json;
using JsonCarExercise;

namespace JSONExerciseClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the car client");
            TcpClient socket = new TcpClient("localhost", 10002);


            Console.WriteLine("Car Model:");
            string Model = Console.ReadLine();

            Console.WriteLine("Car Color:");
            string Color = Console.ReadLine();

            Console.WriteLine("Car Registration Number:");
            string registrationNumber = Console.ReadLine();

            Car myCar = new Car(Model, Color, registrationNumber);
            string serializedCar = JsonSerializer.Serialize(myCar);


            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);

            writer.WriteLine(serializedCar);
            writer.Flush();

            string response = reader.ReadLine();
            Console.WriteLine("Server says:" + response);
            socket.Close();

            //handwritten JSON {"Model":"Porsche", "Color":"Pink", "registrationNumber":"AB1234"}
        }
    }
}
