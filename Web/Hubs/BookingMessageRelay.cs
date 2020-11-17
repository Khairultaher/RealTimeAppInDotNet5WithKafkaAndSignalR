using Microsoft.AspNetCore.SignalR;
using Streaming.Consumer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Hubs
{
    public class BookingMessageRelay
    {
        private readonly IHubContext<BookingHub> _hubContext;
        public BookingMessageRelay(IHubContext<BookingHub> hubContext, IBookingStream bookingStream)
        {
            _hubContext = hubContext;
            //Task.Factory.StartNew(() =>
            //{
            //    while (true)
            //    {
            //        _hubContext.Clients.All.SendAsync("booking", DateTime.Now.Ticks);                   
            //    }
            //});
            bookingStream.Subscribe("booking", (m) => _hubContext.Clients.All.SendAsync("booking", m.Message));
        }
    }
}
