using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Hubs
{
    public class BookingMessageRelay
    {
        private readonly IHubContext<BookingHub, IBookingHub> hubContext;
        public BookingMessageRelay(IHubContext<BookingHub, IBookingHub> hubContext)
        {
            this.hubContext = hubContext;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    hubContext.Clients.All.InvokeAsync("booking", DateTime.Now.Ticks);
                }
            });
        }
    }
}
