using Aqarak.Dtos;
using AqarakCore.Entities;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aqarak.Helper
{
    public class profilesMaper: Profile
    {
        public profilesMaper()
        {

            CreateMap<MyProperty, propDto>()
                .ForMember(d => d.PhotoUrl, o => o.MapFrom<PicUrlResolve>());


        }
    }
}
