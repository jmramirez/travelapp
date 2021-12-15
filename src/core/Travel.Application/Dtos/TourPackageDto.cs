using AutoMapper;
using Travel.Application.Common.Mapping;
using Travel.Domain.Entities;

namespace Travel.Application.Dtos
{
    public class TourPackageDto : ImapFrom<TourPackage>
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public bool InstantConfirmation { get; set; }
        public int Currency { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TourPackage, TourPackageDto>()
                .ForMember(d => 
                    d.Currency, opt =>
                        opt.MapFrom(s => (int)s.Currency));
        }
        
    }
}