using AutoMapper;
using SelfRefExtityExample.Data.Entities;
using SelfRefExtityExample.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfRefExtityExample.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name));
            
            CreateMap<CreateMemberDto, Member>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CreateInvitationDto, Invitation>()
                .ForMember(des => des.FromId, opt => opt.MapFrom(src => src.FromId))
                .ForMember(des => des.ToId, opt => opt.MapFrom(src => src.ToId));

            CreateMap<Invitation, InviteToDto>()
                .ForMember(des => des.InvitationId, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(des => des.MemberId, opt => opt.MapFrom(src => src.ToMember.Id.ToString()))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.ToMember.Name));

            CreateMap<Invitation, InviteFromDto>()
                .ForMember(des => des.InvitationId, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(des => des.MemberId, opt => opt.MapFrom(src => src.FromMember.Id.ToString()))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.FromMember.Name));

            CreateMap<Member, MemberInvitationDto>()
                .ForMember(des => des.MemberId, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.ToInvitations, opt => opt.MapFrom(src => src.ToInvitations))
                .ForMember(des => des.FromInviations, opt => opt.MapFrom(src => src.FromInviations));

        }
    }
}
