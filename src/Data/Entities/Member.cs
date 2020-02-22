using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfRefExtityExample.Data.Entities
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Invitation> ToInvitations { get; set; }
        public virtual ICollection<Invitation> FromInviations { get; set; }

    }
}
