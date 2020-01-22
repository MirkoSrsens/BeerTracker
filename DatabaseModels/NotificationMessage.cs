using Kernel.Database;
using System.Collections.Generic;

namespace DatabaseModels
{
    public class NotificationMessage : HasOid
    {
        public string ErrorCode { get; set; }

        public List<NotificationMessageUser> NotificationMessageUsers { get; set; }
    }
}
