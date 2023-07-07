using System;
using System.Threading.Tasks;
using VG.CDF.Client.Application.Enums;
using VG.CDF.Client.Models.ExcelModels;

namespace VG.CDF.Client.Application.Interfaces.Services;

public interface IReportDataService<T>
{
    Task<ExcelReportData?> GetExcelReportData(T reportDataInfo);
}