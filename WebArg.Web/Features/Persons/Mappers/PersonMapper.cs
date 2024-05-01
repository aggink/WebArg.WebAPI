﻿using AutoMapper;
using WebArg.Logic.DtoModels;
using WebArg.Storage.Models;
using WebArg.Web.Features.Masters.Queries;
using WebArg.Web.Features.Persons.DtoModels;

namespace WebArg.Web.Features.Persons.Mappers;

/// <summary>
/// Настройка проецирования моделей <see cref="Person"/>, <see cref="PersonDto"/>, <see cref="EditPersonDto"/>
/// </summary>
public sealed class PersonMapper : Profile
{
    public PersonMapper()
    {
        CreateMap<PersonDto, Person>();
        CreateMap<Person, PersonDto>();

        CreateMap<EditPersonDto, Person>();
        CreateMap<Person, EditPersonDto>();

        CreateMap<PersonFilter, GetListMasterQuery>();
        CreateMap<GetListMasterQuery, PersonFilter>();
    }
}
