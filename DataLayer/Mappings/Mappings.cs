using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataLayer.Dtos;
using DataLayer.Models;

namespace DataLayer.Mappings
{
   public class Mappings:Profile
    {
        public Mappings()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(x => x.FullName,
                    d => d.MapFrom(src => $"{src.Name} {src.SecondName} {src.LastName} {src.SecondLastName}"))
                .ForMember(x => x.Age, d => d.MapFrom(src => DateTime.Now.Year - src.BirthDate.Year))
                .ForMember(x => x.ArticleDto, d => d.MapFrom(src => src.Articles));


            CreateMap<Articles, ArticleDto>();
        }
    }
}
