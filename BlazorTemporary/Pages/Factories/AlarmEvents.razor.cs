using BreadCommunityWeb.Blz.Application.Dto.Client;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services.RestApi;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Client.Pages.Factories
{
    public partial class AlarmEvents
    {
        [Parameter] public string FactoryId { get; set; }

        [Parameter] public string Name { get; set; }
        [Inject] IUserDataRestApiService UserDataRestApiService { get; set; }
        [Inject] protected IJSRuntime Js { get; set; }

        [Inject] IStringLocalizer<AlarmEvents> Localizer { get; set; }
        protected DateTime? StartReportDate { get; set; }

        protected DateTime? EndReportDate { get; set; }
        protected string CurrentLanguageLabel { get; set; }

        protected int CurrentLanguageExternalId { get; set; }

        protected List<string> LanguageLabels { get; set; } = new List<string>();

        protected List<LanguageResponseDto> Languages { get; set; } = new List<LanguageResponseDto>();

        protected List<DeviceWithDescriptionsDto> Devices { get; set; } = new List<DeviceWithDescriptionsDto>();

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(FactoryId, out int factoryId);
            Devices = await UserDataRestApiService.GetUserDevices(factoryId);
            Languages = await UserDataRestApiService.GetLanguages();
            foreach (var lang in Languages)
            {
                LanguageLabels.Add(lang.LanguageLabel);
            }
        }

            protected void ChangeLanguageLabel(string tt)
        {
            CurrentLanguageLabel = tt;

            CurrentLanguageExternalId = Languages.Where(c => c.LanguageLabel == tt).FirstOrDefault().LanguageExternalId;
        }

        protected void DropCheck(int deviceExternalId)
        {
            var device = Devices.Where(c => c.ExternalId == deviceExternalId).FirstOrDefault();
            device.IsEnabled = device.IsEnabled == true ? false : true;

        }

        protected async Task ReportDownload()
        {
            var reportData = new AlarmEventsReportDataInfo();
            int.TryParse(FactoryId, out int factoryId);
            reportData.FactoryId = factoryId;
            reportData.LanguageExternalId = CurrentLanguageExternalId;

            var dt1 = new DateTime(StartReportDate.Value.Year, StartReportDate.Value.Month, StartReportDate.Value.Day, 00, 00, 00);
            var dt2 = new DateTime(EndReportDate.Value.Year, EndReportDate.Value.Month, EndReportDate.Value.Day, 23, 59, 59);

            reportData.StartDateTime = dt1;
            reportData.EndDateTime = dt2;

            reportData.Devices = Devices;

            var response = await UserDataRestApiService.GetAlarmEventsReport(reportData);

            response.EnsureSuccessStatusCode();

            var fileBytes = await response.Content.ReadAsByteArrayAsync();

            
            var fileName = $"{Name} - Отчет по авариям {dt1} - {dt2}.xlsx";

            await _jsRuntime.InvokeAsync<object>("SaveAsFile", fileName, Convert.ToBase64String(fileBytes));
        }
    }
}
