using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VG.CDF.Client.Interfaces.Services.RestApi;
using VG.CDF.Client.Models.ExcelModels;


namespace VG.CDF.Client.Pages.Factories
{
    public partial class Factory
    {
        [Parameter] public string FactoryId { get; set; }

        [Parameter] public string Name { get; set; }
        [Inject] IUserDataRestApiService UserDataRestApiService { get; set; }
        [Inject] protected IJSRuntime Js { get; set; }

        [Inject] IStringLocalizer<Factory> Localizer { get; set; }
        protected DateTime? StartReportDate { get; set; }

        protected DateTime? EndReportDate { get; set; }

        public bool IsFullChecked { get; set; } = true;

        protected string CurrentLanguageLabel { get; set; }

        protected int CurrentLanguageExternalId { get; set; }

        protected List<string> LanguageLabels { get; set; } = new List<string>();

        protected ExcelReportData TableData { get; set; } = new ExcelReportData();

        protected List<LanguageResponseDto> Languages { get; set; } = new List<LanguageResponseDto>();
        protected List<DeviceTagParamsResponseDto> DevicesTagParams { get; set; } = new List<DeviceTagParamsResponseDto>();
        protected List<DeviceWithDescriptionsDto> Devices {get;set;}

        protected List<TagParamWithDescriptions> TagParams { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Languages = await UserDataRestApiService.GetLanguages();
            CurrentLanguageLabel = Languages.Where(c=>c.LanguageExternalId == 1).FirstOrDefault().LanguageLabel;
            CurrentLanguageExternalId = Languages.Where(c => c.LanguageExternalId == 1).FirstOrDefault().LanguageExternalId;
            foreach (var lang in Languages)
            {
                LanguageLabels.Add(lang.LanguageLabel);
            }

            int.TryParse(FactoryId, out int factoryId);
            var devices = await UserDataRestApiService.GetUserDevices(factoryId);
            devices = devices.OrderBy(c => c.ExternalId).ToList();

            //var devices = await UserDataRestApiService.GetTagParamsForDevice(devices[0].Id);

            foreach (var device in devices)
            {
                try
                {
                    var deviceTagParams = new DeviceTagParamsResponseDto();
                    deviceTagParams.Device = device;
                    var tagParams = await UserDataRestApiService.GetTagParamsForDevice(device.Id);
                    tagParams.ForEach(c => c.IsEnabled = false);
                    tagParams = tagParams.Where(c => c.TagParamDescriptions.Count > 0).OrderBy(c => c.ExternalId).ToList();
                    deviceTagParams.TagParams.AddRange(tagParams);

                    DevicesTagParams.Add(deviceTagParams);
                }
                catch(Exception e)
                {

                }
            }



        }

        protected void DropCheck(int deviceExternalId)
        {
            var device = DevicesTagParams.Where(c => c.Device.ExternalId == deviceExternalId).FirstOrDefault();
            device.Device.IsEnabled = device.Device.IsEnabled == true ? false : true;

            foreach(var tagParam in device.TagParams)
            {
                tagParam.IsEnabled = device.Device.IsEnabled;
            }

        }

        protected void ChangeLanguageLabel(string tt)
        {
            CurrentLanguageLabel = tt;

            CurrentLanguageExternalId = Languages.Where(c => c.LanguageLabel == tt).FirstOrDefault().LanguageExternalId;
        }

        protected async Task ReportDownload()
        {
            var reportData = new TagParamsReportDataInfo();
            int.TryParse(FactoryId, out int factoryId);
            reportData.FactoryId = factoryId;
            reportData.LanguageExternalId = CurrentLanguageExternalId;

            var dt1 = new DateTime(StartReportDate.Value.Year, StartReportDate.Value.Month, StartReportDate.Value.Day, 00, 00, 00);
            var dt2 = new DateTime(EndReportDate.Value.Year, EndReportDate.Value.Month, EndReportDate.Value.Day, 23, 59, 59);

            reportData.StartDateTime = dt1;
            reportData.EndDateTime = dt2;

            reportData.DeviceTagParams = DevicesTagParams;


            var response = await UserDataRestApiService.GetTagsExcelData(reportData);

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<ExcelReportData>();

            TableData = data;

        }

            protected async Task ReportDownload2()
        {
            var reportData = new TagParamsReportDataInfo();
            int.TryParse(FactoryId, out int factoryId);
            reportData.FactoryId = factoryId;
            reportData.LanguageExternalId = CurrentLanguageExternalId;

            var dt1 = new DateTime(StartReportDate.Value.Year, StartReportDate.Value.Month, StartReportDate.Value.Day, 00, 00, 00);
            var dt2 = new DateTime(EndReportDate.Value.Year, EndReportDate.Value.Month, EndReportDate.Value.Day, 23, 59, 59);

            reportData.StartDateTime = dt1;
            reportData.EndDateTime = dt2;

            reportData.DeviceTagParams = DevicesTagParams;


            var response = await UserDataRestApiService.GetTagsReport(reportData);

            response.EnsureSuccessStatusCode();

            var fileBytes = await response.Content.ReadAsByteArrayAsync();

            var fileName = $"{Name} - Отчет по параметрам {dt1} - {dt2}.xlsx";

            await _jsRuntime.InvokeAsync<object>("SaveAsFile", fileName, Convert.ToBase64String(fileBytes));
        }

        //private async Task GetData()
        //{
        //    var devTagsParams = new List<DeviceTagParamsResponseDto>();
        //    var devices = new List<DeviceResponseDto>();
        //    int.TryParse(Factoryid, out int factoryId);
        //    devices = await UserDataRestApiService.GetUserDevices(factoryId);

        //    foreach (var device in Devices)
        //    {
        //        var devTags = new DeviceTagParamsResponseDto();
        //        var tagParams = new List<TagParamResponseDto>();
        //        tagParams = await UserDataRestApiService.GetTagParamsForDevice(device.ExternalId);

        //        devTags.Device = device;
        //        devTags.TagParams.AddRange(tagParams);
        //        devTagsParams.Add(devTags);

        //    }


        //}



    }
}
