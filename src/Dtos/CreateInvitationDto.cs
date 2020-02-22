using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfRefExtityExample.Dtos
{
    public class CreateInvitationDto
    {
        public string FromId { get; set; }
        public string ToId { get; set; }
    }
}
