using AutoMapper;
using PCRanks.Application.ApplicationUser;
using PCRanks.Application.PCRanks;
using PCRanks.Application.PCRanks.Commands.EditPCRanks;
using PCRanks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Application.Mappings
{
    public class PCRanksMappingProfile : Profile
    {
        public PCRanksMappingProfile(IUserContext userContext) 
        {
            var user = userContext.GetCurrentUser();
            CreateMap<PCRanksDto, Domain.Entities.PCRanks>()
                .ForMember(e => e.PCSpecs, opt => opt.MapFrom(src => new PCSpecsDetails()
                {
                    Cpu = src.Cpu,
                    Gpu = src.Gpu,
                    Mobo = src.Mobo,
                    Psu = src.Psu,
                }));

            CreateMap<Domain.Entities.PCRanks, PCRanksDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user!= null && src.CreatedById == user.Id))
                .ForMember(dto => dto.Cpu, opt => opt.MapFrom(src => src.PCSpecs.Cpu))
                .ForMember(dto => dto.Gpu, opt => opt.MapFrom(src => src.PCSpecs.Gpu))
                .ForMember(dto => dto.Mobo, opt => opt.MapFrom(src => src.PCSpecs.Mobo))
                .ForMember(dto => dto.Psu, opt => opt.MapFrom(src => src.PCSpecs.Psu));

            CreateMap<PCRanksDto, EditPCRanksCommand>();

        }
    }
}
