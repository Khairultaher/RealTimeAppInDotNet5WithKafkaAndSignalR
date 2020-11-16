using Confluent.Kafka;
using Streaming.Producer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Streaming.Producer.Implementation
{
    public class BookingProducer : IBookingProducer
    {
        public async Task Produce(string msg)
        {

            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            var producer = new ProducerBuilder<Null, string>(config).Build();
            var message = new Message<Null, string>
            {
                Value = msg
            };
            await producer.ProduceAsync("booking", message);
            //_ = Console.ReadLine();

        }

        #region New Example
        //public async Task Produce(string msg)
        //{
        //    var config = new ProducerConfig
        //    {
        //        BootstrapServers = "localhost:9092"
        //    };
        //    using var p = new ProducerBuilder<Null, string>(config).Build();
        //    var i = 0;

        //    while (true)
        //    {
        //        var message = new Message<Null, string>
        //        {
        //            Value = $"Message #{++i}"
        //        };

        //        var dr = await p.ProduceAsync("booking", message);
        //        Console.WriteLine($"Produced message '{dr.Value}' to topic {dr.Topic}, partition {dr.Partition}, offset {dr.Offset}");
        //        Thread.Sleep(5000);
        //    }
        //    _ = Console.ReadLine();
        //}
        #endregion
    }
}
