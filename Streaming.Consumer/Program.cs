using Streaming.Consumer.Implementation;
using System;

namespace Streaming.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookingStrem = new BookingStream();
            var bookingConsumer = new BookingConsumer(bookingStrem);

            bookingStrem.Subscribe("sub1", (m) => Console.WriteLine($"sub1 message: {m.Message}"));
            bookingStrem.Subscribe("sub2", (m) => Console.WriteLine($"sub2 message: {m.Message}"));

            bookingConsumer.Listen();
        }
    }
}
