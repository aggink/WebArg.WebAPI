﻿using Microsoft.EntityFrameworkCore;
using WebArg.Logic.DtoModels;
using WebArg.Logic.Exceptions;
using WebArg.Logic.Interfaces.Services;
using WebArg.Storage.Database;
using WebArg.Storage.Models;

namespace WebArg.Logic.Services;

/// <summary>
/// Сервис для <see cref="Person"/>
/// </summary>
public sealed class PersonService : IPersonService
{
    public IQueryable<Person> GetPersonQueryable(DataContext dataContext, PersonFilter filter)
    {
        IQueryable<Person> customerQuery = dataContext.Persons
            .AsNoTracking();

        if (filter.IsnStudio.HasValue)
            customerQuery = customerQuery.Where(x => x.IsnStudio == filter.IsnStudio.Value);

        return customerQuery;
    }

    public async Task<Person> GetInfoPersonAsync(DataContext dataContext, Guid isnPerson, CancellationToken cancellationToken)
    {
        var person = await dataContext.Persons
            .AsNoTracking()
            .Include(x => x.Studio)
            .Include(x => x.PersonMasters)
                .ThenInclude(x => x.Master)
            .FirstOrDefaultAsync(x => x.IsnNode == isnPerson, cancellationToken)
                ?? throw new LogicException($"Гостя с таким идентификатором {isnPerson} не существует");

        return person;
    }
}
