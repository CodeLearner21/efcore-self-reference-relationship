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
    public class MemberController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public MemberController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMemberDto memberDto)
        {
            try
            {
                if (memberDto == null)
                    return BadRequest();

                var member = _mapper.Map<Member>(memberDto);

                _context.Members.Add(member);

                await _context.SaveChangesAsync();

                return Ok(member.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}