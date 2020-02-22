using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfRefExtityExample.Data;
using SelfRefExtityExample.Data.Entities;
using SelfRefExtityExample.Dtos;

namespace SelfRefExtityExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public InvitationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateInvitationDto invitationDto)
        {
            try
            {
                if (invitationDto.FromId == null || invitationDto.ToId == null)
                    return BadRequest();

                var invitation = _mapper.Map<Invitation>(invitationDto);

                _context.Invitations.Add(invitation);
                await _context.SaveChangesAsync();

                return Ok(invitation.Id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(string memberId)
        {
            try
            {
                if (memberId == null)
                    return BadRequest();

                var invitations = await _context.Members
                    .Include(m => m.FromInviations)
                    .Include(m => m.ToInvitations).ToListAsync();

                var memberInvitation = invitations.Where(i => i.Id == Guid.Parse(memberId)).FirstOrDefault();                    

                if (memberInvitation == null)
                    return NotFound();

                var member = _mapper.Map<MemberInvitationDto>(memberInvitation);
                return Ok(member);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}