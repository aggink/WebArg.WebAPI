﻿using WebArg.Storage.Models;
using WebArg.Web.Features.Persons.DtoModels;
using WebArg.Web.Features.Persons.Queries;
using X.PagedList;

namespace WebArg.Web.Features.Persons.Managers.Interfaces;

/// <summary>
/// Интерфейс обработчика <see cref="Person"/>
/// </summary>
public interface IPersonManager
{
    /// <summary>
    /// Создать клиента
    /// </summary>
    /// <param name="source">Клиент</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные об операции</returns>
    Task CreatePersonAsync(EditPersonDto source, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить данные клиента
    /// </summary>
    /// <param name="source">Клиент</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные об операции</returns>
    Task UpdatePersonAsync(EditPersonDto source, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить клиента
    /// </summary>
    /// <param name="isnPerson">Идентификатор клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Удаленный клиент</returns>
    Task<PersonDto> DeletePersonAsync(Guid isnPerson, CancellationToken cancellationToken);

    /// <summary>
    /// Получить данные клиента
    /// </summary>
    /// <param name="isnPerson">Идентификатор клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные клиента</returns>
    Task<EditPersonDto> GetPersonAsync(Guid isnPerson, CancellationToken cancellationToken);

    /// <summary>
    /// Получить список клиентов
    /// </summary>
    /// <param name="query">Параметры запроса</param>
    /// <returns></returns>
    Task<IPagedList<PersonDto>> GetListPersonAsync(GetListPersonQuery query);

    /// <summary>
    /// Получить полные данные о клиенте
    /// </summary>
    /// <param name="isnPerson">Идентификатор клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Полные данные о клиенте</returns>
    Task<InfoPersonDto> GetInfoPersonAsync(Guid isnPerson, CancellationToken cancellationToken);
}
