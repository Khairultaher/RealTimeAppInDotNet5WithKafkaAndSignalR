using Streaming.Producer.Implementation;
using System;
using System.Threading.Tasks;

namespace Streaming.Producer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter your message. Enter q for quitting");
            string message = default(string);

            while ((message = Console.ReadLine()) != "q")
            {
                //message = Console.ReadLine().ToString();
                var producer = new BookingProducer();
                await producer.Produce(message);
            }
        }
    }
}
