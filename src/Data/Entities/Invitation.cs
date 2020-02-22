using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfRefExtityExample.Data.Entities
{
    public class Invitation
    {
        public Guid Id { get; set; }

        public Guid FromId { get; set; }
        public virtual Member FromMember { get; set; }

        public Guid ToId { get; set; }
        public virtual Member ToMember { get; set; }

    }
}
