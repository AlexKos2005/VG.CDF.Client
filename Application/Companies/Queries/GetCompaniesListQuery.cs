using System;

namespace VG.CDF.Client.Application.Companies.Queries;

public class GetCompaniesListQuery
{
    public Guid? Id { get; set; } = null;

    public string? Name { get; set; } = null;
}