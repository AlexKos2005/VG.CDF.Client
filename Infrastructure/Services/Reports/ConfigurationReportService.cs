using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Dto.Reports.ConfigurationReports;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Application.Processes.Queries;
using VG.CDF.Client.Infrastructure.Services.RestApi.Admin;
using VG.CDF.Client.Models.ExcelModels;

namespace VG.CDF.Client.Services.RestApi.Services.Reports;

public class ConfigurationReportService : IReportDataService<ProjectConfigurationReportDataInfo>
{
    #region ReportPattern
        //имя проекта
        private int ROW_NAMEPROJECT = 1;
        private int COLLUMN_NAMEPROJECT = 2;

        //внешний идентификатор
        private int ROW_PROJECTEXTERNALID = 2;
        private int COLLUMN_PROJECTID = 2;

        //время отправки
        private int ROW_TIMERECIVE = 3;
        private int COLLUMN_TIMERECIVE = 2;

        //параметры процессов
        private int START_ROW_PARAM_PROCESS = 5;

        private int START_ROW_PROCESS_ID = 6;
        
        private int START_ROW_PROCESS_EXTERNAL_ID = 7;

        private int START_COLLUMN_NAMEPROCESS = 1;

        private int START_COLLUMN_IPPROCESS = 2;

        private int START_COLLUMN_CODEPROCESS = 3;

        private int START_COLLUMN_NAMESCOLS = 4;

        private int START_COLLUMN_PROCESS_EXTERNAL_ID = 2;

        private int COUNT_PROCESS = 10;

        //параметры столбцов
        private int  ROW_NAMES_IN_PROCESS= 0;

        private int ROW_WIDTH_IN_PROCESS = 1;

        private int ROW_DIVIDE_VALUE_IN_PROCESS = 2;

        private int ROW_TAG_PARAM_TYPE_IN_PROCESS = 3;

        private int ROW_TAG_PARAM_EXTERNAL_ID_IN_PROCESS = 4;

        private int COUNT_COLL_PARAMS = 51;

        //количество столбцов с названиями
        private int COUNT_COLLUMNS_NAMES = 42;

        //параметры дозаторов
        private int START_ROW_PARAM_DOSIER = 60;

        private int START_COLLUMN_NAMEDOSIER = 1;

        private int START_COLLUMN_CODEDOSIER = 2;

        private int START_COLLUMN_BLOWERBRAND = 3;

        private int START_COLLUMN_POWER = 4;

        private int START_COLLUMN_PRESSURE = 5;

        private int START_COLLUMN_PRODUCTIVITY = 6;

        private int COUNT_DOSIER = 10;

        //параметры продукта
        private int START_ROW_PARAM_PRODUCT = 73;

        private int START_COLLUMN_NAMEPRODUCT = 1;

        private int START_COLLUMN_CODEPRODUCT = 2;

        private int START_COLLUMN_ROTARYFEEDER = 3;

        private int START_COLLUMN_DRIVE = 4;

        private int START_COLLUMN_GEARBOX = 5;
        private int COUNT_PRODUCT = 10;

        //параметры операторов
        private int START_ROW_PARAM_OPERATOR = 85;

        private int START_COLLUMN_NAMEOPERATOR = 1;

        private int START_COLLUMN_CODEOPERATOR = 2;

        private int START_COLLUMN_ALARM_EVENT_EXTERNAL_ID = 3;

        private int COUNT_OPERATOR = 56;

    #endregion
       
    private readonly IProcessService _processService;
    private readonly IProcessDescriptionService _processDescriptionService;
    private readonly IParameterService _parameterService;
    private readonly IParameterDescriptionService _parameterDescriptionService;
    public ConfigurationReportService(IProcessService processService, IProcessDescriptionService processDescriptionService, IParameterService parameterService, IParameterDescriptionService parameterDescriptionService)
    {
        _processService = processService;
        _processDescriptionService = processDescriptionService;
        _parameterService = parameterService;
        _parameterDescriptionService = parameterDescriptionService;
        
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial; 
    }
    public async Task<ExcelReportData> GetExcelReportData(ProjectConfigurationReportDataInfo reportDataInfo)
    {
        var report = new ExcelReportData();
        using (var excelPackage = new ExcelPackage())
        {
            var processes = await _processService.GetList<GetProcessesListQuery>(new GetProcessesListQuery()
                { ProjectId = reportDataInfo.ProjectId });

            if (processes.Any() == false)
            {
                return report;
            }
            
            


        }
        

    }

    private void SetProjectInfo(ProjectDto projectDto, ExcelWorksheet excelWorksheet)
    {
        excelWorksheet.Cells[ROW_NAMEPROJECT, 1].Value = "Название проекта";
        excelWorksheet.Cells[ROW_NAMEPROJECT, COLLUMN_NAMEPROJECT].Value = projectDto.Description;
        
        excelWorksheet.Cells[ROW_PROJECTEXTERNALID, 1].Value = "ИД проекта";
        excelWorksheet.Cells[COLLUMN_PROJECTID, COLLUMN_PROJECTID].Value = projectDto.Id;
        
        excelWorksheet.Cells[ROW_TIMERECIVE, 1].Value = "Время отправки отчета";
        excelWorksheet.Cells[ROW_TIMERECIVE, COLLUMN_TIMERECIVE].Value = "23:55";
    }
}