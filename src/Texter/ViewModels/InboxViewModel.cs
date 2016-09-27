using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Models;

namespace Texter.ViewModels
{
    public class InboxViewModel
    {
        public List<Message> incomingMessages { get; set; }
        public List<Message> sentMessages { get; set; }
    }
}
