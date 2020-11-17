using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Hubs
{
    public interface IBookingHub
    {
        Task SendAsync(string msg, object obj);
    }

    public class BookingHub: Hub<IBookingHub>
    {
    }
}
