using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Producer.Interface
{
    public interface IBookingProducer
    {
        Task Produce(string message);
    }
}
