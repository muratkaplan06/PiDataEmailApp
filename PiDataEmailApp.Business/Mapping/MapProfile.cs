using AutoMapper;
using PiDataEmailApp.Business.Models;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.Business.Mapping;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<EpostaGonderim, EpostaGonderimModel>().ReverseMap();
        CreateMap<EpostaAdresi, EpostaAdresiModel>().ReverseMap();
        CreateMap<Kisi, KisiModel>().ReverseMap();
        CreateMap<EpostaGonderimDetay, EpostaGonderimDetayModel>().ReverseMap();
        CreateMap<EpostaGonderimDetay, EpostaGonderimDetayWithIncludeModel>().ReverseMap();
    }
    
}