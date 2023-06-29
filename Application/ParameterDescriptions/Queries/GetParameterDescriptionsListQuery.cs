using System;

namespace VG.CDF.Client.Application.ParameterDescriptions.Queries;

public class GetParameterDescriptionsListQuery
{
    public Guid? Id { get; set; } = null;
    public string? Description { get; set; } = null;
    public Guid? ParameterId { get; set; }= null;
    public Guid? DescriptionsLanguageId { get; set; }= null;
}