using Confluent.Kafka;
using Streaming.Consumer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Streaming.Consumer.Implementation
{
    public class BookingConsumer : IBookingConsumer
    {
        private readonly IBookingStream bookingStream;
        public BookingConsumer(IBookingStream bookingStream)
        {
            this.bookingStream = bookingStream;
        }
        public void Listen()
        {

            #region MyRegion New Style
            var config = new ConsumerConfig
            {
                GroupId = "booking",
                BootstrapServers = "localhost:9092",
                EnableAutoCommit = false
            };
            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("booking");
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };
            try
            {
                while (true)
                {
                    var cr = consumer.Consume(cts.Token);
                    bookingStream.Publish(new Model.BookingMessage { Message = cr.Message.Value });
                }
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                consumer.Close();
            }
            #endregion
        }
    }
}