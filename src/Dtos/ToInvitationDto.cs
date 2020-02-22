using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfRefExtityExample.Dtos
{
    public class ToInvitationDto
    {
        public string MemberId { get; set; }

        public ICollection<InvitationDto> ToList { get; set; }
    }
}
