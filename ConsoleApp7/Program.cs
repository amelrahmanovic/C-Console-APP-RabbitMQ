using RabbitMQHelper;
using System;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RabbitMQCRUD rabbitMQHelper = new RabbitMQCRUD("localhost", "rabbitmq", "rabbitmq");

            int opcija=1;
            do
            {
                bool succesInput;
                do
                {
                    try
                    {
                        Console.WriteLine("0-Add:");
                        Console.WriteLine("1-Read + Ack:");
                        Console.WriteLine("2-Read:");
                        Console.WriteLine("3-Check Queue:");
                        Console.WriteLine("4-Check Queue number Messages:");
                        Console.WriteLine("5-Delete Queue:");
                        Console.WriteLine("10-EXIT:");
                        Console.WriteLine("Option:");
                        opcija = int.Parse(Console.ReadLine());
                        Console.Clear();
                        succesInput = true;
                    }
                    catch (Exception)
                    {
                        succesInput = false;
                        Console.Clear();
                        Console.WriteLine("This is not number...");
                    }
                } while (!succesInput);
                

                switch (opcija)
                {
                    case 0:
                        Random random = new Random();
                        rabbitMQHelper.NewQueues("test", "test" + random.Next().ToString());
                        break;
                    case 1:
                        Console.WriteLine(rabbitMQHelper.GetQueues("test", false, true));
                        break;
                    case 2:
                        Console.WriteLine(rabbitMQHelper.GetQueues("test", false, false));
                        break;
                    case 3: 
                        Console.WriteLine("Queue: "+rabbitMQHelper.ExistQueue("test"));
                        break;
                    case 4:
                        Console.WriteLine("Messages:"+rabbitMQHelper.CountQueuesMessages("test"));
                        break;
                    case 5:
                        rabbitMQHelper.DeleteQueue("test");
                        break;

                    case 10: Environment.Exit(0); break;
                    default: break;
                }
            } while (true);
        }
    }
}
