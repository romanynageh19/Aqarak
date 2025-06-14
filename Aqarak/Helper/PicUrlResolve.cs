using Aqarak.Dtos;
using AqarakCore.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Aqarak.Helper
{
    public class PicUrlResolve : IValueResolver<MyProperty, propDto, string>
    {
        private readonly IConfiguration _configuration;

        public PicUrlResolve(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(MyProperty source, propDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PhotoUrl)) return null;

            
            if (source.PhotoUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                return source.PhotoUrl;

           
            return $"{_configuration["ApiBaseUrl"]}/{source.PhotoUrl}";
        }
    }

}
