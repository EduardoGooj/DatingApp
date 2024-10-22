namespace API.Helpers;

using API.DataEntities;
using API.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberResponse>()
            .ForMember(d => d.PhotoUrl,
             ori => ori.MapFrom(s => s.Photos.FirstOrDefault(p => p.IsMain)!.Url));
        CreateMap<Photo, PhotosResponse>();
    }
}