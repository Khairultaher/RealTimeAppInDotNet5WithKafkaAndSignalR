using Streaming.Consumer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Consumer.Interface
{
    public interface IBookingStream
    {
        void Publish(BookingMessage bookingMessage);

        void Subscribe(string subscriberName, Action<BookingMessage> action);
    }
}
