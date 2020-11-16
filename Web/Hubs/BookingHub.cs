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
        Task InvokeAsync(string msg, object com);
    }

    [EnableCors]
    public class BookingHub: Hub<IBookingHub>
    {
    }
}
