using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfRefExtityExample.Dtos
{
    public class MemberInvitationDto
    {
        public string MemberId { get; set; }
        public ICollection<InviteFromDto> FromInviations { get; set; }
        public ICollection<InviteToDto> ToInvitations { get; set; }
    }
}
