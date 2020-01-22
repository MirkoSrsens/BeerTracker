using Kernel.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class NotificationUser : HasId
    {
        public string Email { get; set; }
        public List<NotificationMessageUser> NotificationMessageUsers { get; set; }
    }
}
