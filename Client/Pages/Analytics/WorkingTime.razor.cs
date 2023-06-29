using Blazorise.Charts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Client.Pages.Analytics
{
    public partial class WorkingTime
    {
        const int _allTimeExtId = 24;
        const int _clearTimeExtId = 25;
        const int _stopByPressureTimeExtId = 33;

        const int _middlePressureExtId = 30;
        const int _maxPressureExtId = 31;

        const int _compressorNameExtId = 6;
        const int _compressorPowerExtId = 7;
        const int _compressorWorkPressureExtId = 8;
        const int _compressorProductivityExtId = 9;
        const int _feederNameExtId = 11;
        const int _feederRevPerMinuteExtId = 12;
        const int _feederReducerExtId = 13;



        [Parameter] public string FactoryId { get; set; }

        [Inject] ITagsGroupsRestApiService TagsGroupsRestApiService { get; set; }

        [Inject] IUserDataRestApiService UserDataRestApiService { get; set; }

        [Inject] AuthenticationStateProvider AuthProvider { get; set; }
        [Inject] protected IJSRuntime Js { get; set; }

        protected EquipmentInfo EquipmentInfo { get; set; } = new EquipmentInfo();
        protected DateTime? StartReportDate { get; set; }

        protected DateTime? EndReportDate { get; set; }

        protected int ClearTimeAvaregePercent { get; set; }

        protected int StopByPressureTimeAvaregePercent { get; set; }

        protected FactoryResponseDto Factory { get; set; } = new FactoryResponseDto();

        protected List<DeviceWithDescriptionsDto> Devices { get; set; } = new List<DeviceWithDescriptionsDto>();

        protected DeviceWithDescriptionsDto CurrentDevice { get; set; } = new DeviceWithDescriptionsDto();

        protected List<TagLiveResponseDto> TagsLive { get; set; } = new List<TagLiveResponseDto>();

        protected List<TagsGroupResponseDto> TagsGroups { get; set; } = new List<TagsGroupResponseDto>();


        protected List<MudBlazor.ChartSeries> WorkTimeSeries = new List<MudBlazor.ChartSeries>();

        protected List<MudBlazor.ChartSeries> PressureSeries = new List<MudBlazor.ChartSeries>();
        protected int[] AllTimeRange { get; set; }
        protected int[] ClearTimeRange { get; set; }

        protected string[] DatesRange { get; set; }

        protected LineChart<double> TimeLineChart { get; set; } = new LineChart<double>();

        protected LineChart<double> PressureLineChart { get; set; } = new LineChart<double>();

        protected List<string> TimeChartDates { get; set; } = new List<string>();

        protected List<string> PressureChartDates { get; set; } = new List<string>();

        List<string> backgroundColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 0.2f), ChartColor.FromRgba(54, 162, 235, 0.2f), ChartColor.FromRgba(255, 206, 86, 0.2f), ChartColor.FromRgba(75, 192, 192, 0.2f), ChartColor.FromRgba(153, 102, 255, 0.2f), ChartColor.FromRgba(255, 159, 64, 0.2f) };
        List<string> borderColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 1f), ChartColor.FromRgba(54, 162, 235, 1f), ChartColor.FromRgba(255, 206, 86, 1f), ChartColor.FromRgba(75, 192, 192, 1f), ChartColor.FromRgba(153, 102, 255, 1f), ChartColor.FromRgba(255, 159, 64, 1f) };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                await UpdateFactory();
                await UpdateDevices();

                //CurrentDevice = Devices.First();

                var gettingInfo = new TagsGroupsGettingInfoRequestDto()
                {
                    FactoryExternalId = Factory.ExternalId,
                    DeviceExternalId = Devices.First().ExternalId,
                    StartDate = StartReportDate ?? DateTime.Now.Date.AddDays(-10),
                    EndDate = EndReportDate ?? DateTime.Now.Date
                };

                await BuildWorkTimeCharts(gettingInfo);
                UpdateEquipmentInfo();
            }
           
        }

        protected override async Task OnParametersSetAsync()
        {
            var gettingInfo = new TagsGroupsGettingInfoRequestDto()
            {
                FactoryExternalId = Factory.ExternalId,
                DeviceExternalId = Devices.First().ExternalId,
                StartDate = StartReportDate ?? DateTime.Now.Date.AddDays(-10),
                EndDate = EndReportDate ?? DateTime.Now.Date
            };
            await UpdateTagsGroups(gettingInfo);
            UpdateEquipmentInfo();
        }

        protected override async Task OnInitializedAsync()
        {
            StartReportDate = DateTime.Now.AddDays(-10).Date;
            EndReportDate = DateTime.Now.Date;
            await UpdateFactory();
            await UpdateDevices();
            CurrentDevice = Devices.FirstOrDefault();
            //CurrentDevice = Devices.First();

            //StartReportDate = DateTime.Now.AddDays(-10).Date;
            //EndReportDate = DateTime.Now.Date;

            //var gettingInfo = new TagsGroupsGettingInfoRequestDto()
            //{
            //    FactoryExternalId = Factory.ExternalId,
            //    DeviceExternalId = Devices.First().ExternalId,
            //    StartDate = DateTime.Now.AddDays(-150).Date,
            //    EndDate = DateTime.Now.AddDays(-100).Date
            //};

            //await BuildWorkTimeCharts(gettingInfo);
        }

        protected async Task UpdateFactory()
        {
            int.TryParse(FactoryId, out int factoryId);

            var authState = await((ClientAuthenticationStateProvider)AuthProvider).GetAuthenticationStateAsync();
            var claimsList = authState.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value;
            int.TryParse(claimsList, out int userId);
            var userRequestDto = new GetUserFactoriesRequestDto()
            {
                UserId = userId
            };

            var userFactories = await UserDataRestApiService.GetUserFactories(userRequestDto);

            Factory = userFactories.Where(c => c.Id == factoryId).FirstOrDefault();
        }

        protected async Task UpdateDevices()
        {
            int.TryParse(FactoryId, out int factoryId);
            var devices = await UserDataRestApiService.GetUserDevices(factoryId);
            Devices = devices.OrderBy(c => c.ExternalId).ToList();
            
        }

        protected void UpdateCurrentDevice(int deviceExternalId)
        {
            if(deviceExternalId>0)
            CurrentDevice = Devices.Where(c => c.ExternalId == deviceExternalId).FirstOrDefault();
        }

        protected void UpdateEquipmentInfo()
        {
            var firtsTag = TagsGroups[0].TagsLive;

            EquipmentInfo.CompressorName = firtsTag.Where(c => c.TagParamExternalId == _compressorNameExtId).FirstOrDefault().Value ?? "";
            EquipmentInfo.CompressorPower = firtsTag.Where(c => c.TagParamExternalId == _compressorPowerExtId).FirstOrDefault().Value ?? "";
            EquipmentInfo.CompressorWorkPressure = firtsTag.Where(c => c.TagParamExternalId == _compressorWorkPressureExtId).FirstOrDefault().Value ?? "";
            EquipmentInfo.CompressorProductivity = firtsTag.Where(c => c.TagParamExternalId == _compressorProductivityExtId).FirstOrDefault().Value ?? "";
            EquipmentInfo.FeederName = firtsTag.Where(c => c.TagParamExternalId == _feederNameExtId).FirstOrDefault().Value ?? "";
            EquipmentInfo.FeederReducer = firtsTag.Where(c => c.TagParamExternalId == _feederReducerExtId).FirstOrDefault().Value ?? "";
            EquipmentInfo.FeederRevPerMinute = firtsTag.Where(c => c.TagParamExternalId == _feederRevPerMinuteExtId).FirstOrDefault().Value ?? "";

        }

        protected async void ChangeDevice(string deviceExternalId)
        {
            if(int.TryParse(deviceExternalId, out int deviceExtlId))
            {
                UpdateCurrentDevice(deviceExtlId);
                if (deviceExtlId == 0)
                {
                    return;
                }
                var gettingInfo = new TagsGroupsGettingInfoRequestDto()
                {
                    FactoryExternalId = Factory.ExternalId,
                    DeviceExternalId = CurrentDevice.ExternalId,
                    StartDate = StartReportDate ?? DateTime.Now.Date.AddDays(-10),
                    EndDate = EndReportDate ?? DateTime.Now.Date
                };

                await BuildWorkTimeCharts(gettingInfo);
            }

        }

        protected async Task UpdateTagsGroups(TagsGroupsGettingInfoRequestDto externalGettingInfo)
        {
            TagsGroupsGettingInfoRequestDto gettingInfo;
            if(externalGettingInfo == null || externalGettingInfo == default)
            {
                gettingInfo = new TagsGroupsGettingInfoRequestDto()
                {
                    FactoryExternalId = Factory.ExternalId,
                    DeviceExternalId = Devices.First().ExternalId,
                    StartDate = StartReportDate ?? DateTime.Now.Date.AddDays(-10),
                    EndDate = EndReportDate ?? DateTime.Now.Date
                };
            }
            else
            {
                gettingInfo = externalGettingInfo;
            }

            var result = await TagsGroupsRestApiService.GetTagsGroups(gettingInfo);
            TagsGroups = result;
        }

        protected async Task BuildWorkTimeCharts(TagsGroupsGettingInfoRequestDto externalGettingInfo)
        {
            try
            {
                var gettingInfo = new TagsGroupsGettingInfoRequestDto()
                {
                    FactoryExternalId = Factory.ExternalId,
                    DeviceExternalId = CurrentDevice.ExternalId,
                    StartDate = StartReportDate ?? DateTime.Now.Date.AddDays(-10),
                    EndDate = EndReportDate ?? DateTime.Now.Date
                };
                await UpdateTagsGroups(gettingInfo);
                if (!TagsGroups.Any())
                {
                    return;
                }

                var timeData = CalculatePercentWorkTimeData(TagsGroups);

                await TimeLineChart.Clear();
                await TimeLineChart.AddLabelsDatasetsAndUpdate(TimeChartDates, GetLineChartDataset("Чистое время, %", timeData.Where(c => c.Key == _clearTimeExtId).FirstOrDefault().Value));
                await TimeLineChart.AddDatasetsAndUpdate(GetLineChartDataset("Время остановок, %", timeData.Where(c => c.Key == _stopByPressureTimeExtId).FirstOrDefault().Value));

                var pressureData = CalculateAvaragePressureData(TagsGroups);

                await PressureLineChart.Clear();
                await PressureLineChart.AddLabelsDatasetsAndUpdate(PressureChartDates, GetLineChartDataset("Среднее давление, МПа", pressureData.Where(c => c.Key == _middlePressureExtId).FirstOrDefault().Value));
                await PressureLineChart.AddDatasetsAndUpdate(GetLineChartDataset("Максимальное давление, МПа", pressureData.Where(c => c.Key == _maxPressureExtId).FirstOrDefault().Value));

                
            }

            catch(Exception e)
            {

            }
           
        }

        LineChartDataset<double> GetLineChartDataset(string label,List<double> data)
        {
            return new LineChartDataset<double>
            {
                Label = label,
                Data = data,
                BackgroundColor = backgroundColors,
                BorderColor = borderColors,
                Fill = false,
                PointRadius = 5,
                CubicInterpolationMode = "default",
                
            };
        }

        protected Dictionary<int,List<double>> CalculatePercentWorkTimeData(List<TagsGroupResponseDto> tagsGroups)
        {
            var data = new Dictionary<int, List<double>>();
            var clearTimeData = new List<double>();
            var stopTimeData = new List<double>();
            int counter = 0;
            var dates = GetDates(tagsGroups);
            TimeChartDates = new List<string>();

            foreach (var date in dates)
            {
                double allTimeForDate = 0.0;
                double clearTimeForDate = 0.0;
                double stopByPressureTimeForDate = 0.0;
                var tagsGroupForDate = tagsGroups.Where(c => c.DateTime.Date == date.Date).ToList();

                foreach (var tagsGroup in tagsGroupForDate)
                {
                    allTimeForDate = allTimeForDate + tagsGroup.TagsLive.Where(c => c.TagParamExternalId == _allTimeExtId).Sum(c => Convert.ToDouble(c.Value));
                    clearTimeForDate = clearTimeForDate + tagsGroup.TagsLive.Where(c => c.TagParamExternalId == _clearTimeExtId).Sum(c => Convert.ToDouble(c.Value));
                    stopByPressureTimeForDate = stopByPressureTimeForDate + tagsGroup.TagsLive.Where(c => c.TagParamExternalId == _stopByPressureTimeExtId).Sum(c => Convert.ToDouble(c.Value));
                }

                var clearTimePercent = clearTimeForDate / (allTimeForDate * 0.01);
                var stopTimePercent = stopByPressureTimeForDate / (allTimeForDate * 0.01);
                ClearTimeAvaregePercent = ClearTimeAvaregePercent + (int)clearTimePercent;
                StopByPressureTimeAvaregePercent = StopByPressureTimeAvaregePercent + (int)stopTimePercent;

                clearTimeData.Add(clearTimePercent);
                stopTimeData.Add(stopTimePercent);
                TimeChartDates.Add(date.ToShortDateString());
              
                counter++;
            }

            data.Add(_clearTimeExtId, clearTimeData);
            data.Add(_stopByPressureTimeExtId, stopTimeData);

            return data;

        }

        protected Dictionary<int, List<double>> CalculateAvaragePressureData(List<TagsGroupResponseDto> tagsGroups)
        {
            var data = new Dictionary<int, List<double>>();
            var middlePressureData = new List<double>();
            var maxPressureData = new List<double>();
            int counter = 0;
            var dates = GetDates(tagsGroups);
            PressureChartDates = new List<string>();

            foreach (var date in dates)
            {
                var middlePressureForDate = 0;
                var maxPressureForDate = 0;
                var tagsGroupForDate = tagsGroups.Where(c => c.DateTime.Date == date.Date).ToList();

                foreach (var tagsGroup in tagsGroupForDate)
                {
                    var tt = tagsGroup.TagsLive.Where(c => c.TagParamExternalId == _middlePressureExtId).ToList();
                    middlePressureForDate = middlePressureForDate + tagsGroup.TagsLive.Where(c => c.TagParamExternalId == _middlePressureExtId).Sum(c => Convert.ToInt32(c.Value));
                    maxPressureForDate = maxPressureForDate + tagsGroup.TagsLive.Where(c => c.TagParamExternalId == _maxPressureExtId).Sum(c => Convert.ToInt32(c.Value));
                }

                var middlePressurePercent = middlePressureForDate / (tagsGroupForDate.Count());
                var maxPressurePercent = maxPressureForDate / (tagsGroupForDate.Count());

                middlePressureData.Add(middlePressurePercent);
                maxPressureData.Add(maxPressurePercent);
                PressureChartDates.Add(date.ToShortDateString());
                counter++;
            }

            data.Add(_middlePressureExtId, middlePressureData);
            data.Add(_maxPressureExtId, maxPressureData);

            return data;
        }

        //protected void CalculateWorkTimeData(List<TagsGroupResponseDto> tagsGroups)
        //{
        //    int counter = 0;
        //    var dates = GetDates(tagsGroups);
        //    ClearTimeAvaregePercent = 0;

        //    var series = new List<MudBlazor.ChartSeries>()
        //    {
        //        new MudBlazor.ChartSeries() { Name = "Общее время-граница 100%", Data = new double[dates.Count] },
        //        new MudBlazor.ChartSeries() { Name = "Чистое время", Data = new double[dates.Count] },
        //        new MudBlazor.ChartSeries() { Name = "Время остановок по давлению", Data = new double[dates.Count] },
        //        new MudBlazor.ChartSeries() { Name = "Общее время-граница 50%", Data = new double[dates.Count] },
        //    };

        //    AllTimeRange = new int[dates.Count];
        //    ClearTimeRange = new int[dates.Count];
        //    DatesRange = new string[dates.Count];

        //    foreach (var date in dates)
        //    {
        //        var allTimeForDate = 0;
        //        var clearTimeForDate = 0;
        //        var stopByPressureTimeForDate = 0;
        //        var tagsGroupForDate = tagsGroups.Where(c => c.DateTime.Date == date.Date).ToList();

        //        foreach (var tagsGroup in tagsGroupForDate)
        //        {
        //            allTimeForDate = allTimeForDate + tagsGroup.TagsLive.Where(c => c.TagParamExternalId == _allTimeExtId).Sum(c=>Convert.ToInt32(c.Value));
        //            clearTimeForDate = clearTimeForDate + tagsGroup.TagsLive.Where(c => c.TagParamExternalId == _clearTimeExtId).Sum(c => Convert.ToInt32(c.Value));
        //            stopByPressureTimeForDate = stopByPressureTimeForDate + tagsGroup.TagsLive.Where(c => c.TagParamExternalId == _stopByPressureTimeExtId).Sum(c => Convert.ToInt32(c.Value));
        //        }

        //        //series[0].Data[counter] = allTimeForDate;
        //        //series[1].Data[counter] = clearTimeForDate;

        //        //DatesRange[counter] = date.ToShortDateString();

        //        var percent1 = clearTimeForDate / (allTimeForDate * 0.01);
        //        var percent2 = stopByPressureTimeForDate / (allTimeForDate * 0.01);
        //        ClearTimeAvaregePercent = ClearTimeAvaregePercent + (int)percent1;
        //        StopByPressureTimeAvaregePercent = StopByPressureTimeAvaregePercent + (int)percent2;

        //        series[0].Data[counter] = 100;
        //        series[1].Data[counter] = percent1;
        //        series[2].Data[counter] = percent2;
        //        series[3].Data[counter] = 50;

        //        DatesRange[counter] = date.ToShortDateString();
        //        counter++;

        //    }

        //    ClearTimeAvaregePercent = ClearTimeAvaregePercent / dates.Count;
        //    StopByPressureTimeAvaregePercent = StopByPressureTimeAvaregePercent / dates.Count;
        //    WorkTimeSeries = series;

        //}

        protected void CalculatePressureData(List<TagsGroupResponseDto> tagsGroups)
        {
            int counter = 0;
            var dates = GetDates(tagsGroups);
            ClearTimeAvaregePercent = 0;

            var series = new List<MudBlazor.ChartSeries>()
            {
                new MudBlazor.ChartSeries() { Name = "Среднее давление", Data = new double[dates.Count] },
                new MudBlazor.ChartSeries() { Name = "Максимальное давление", Data = new double[dates.Count] },
            };

            foreach (var date in dates)
            {
                var middlePressureForDate = 0;
                var maxPressureForDate = 0;
                var tagsGroupForDate = tagsGroups.Where(c => c.DateTime.Date == date.Date).ToList();

                foreach (var tagsGroup in tagsGroupForDate)
                {
                    var tt = tagsGroup.TagsLive.Where(c => c.TagParamExternalId == _middlePressureExtId).ToList();
                    middlePressureForDate = middlePressureForDate + tagsGroup.TagsLive.Where(c => c.TagParamExternalId == _middlePressureExtId).Sum(c => Convert.ToInt32(c.Value));
                    maxPressureForDate = maxPressureForDate + tagsGroup.TagsLive.Where(c => c.TagParamExternalId == _maxPressureExtId).Sum(c => Convert.ToInt32(c.Value));   
                }

                var percent1 = middlePressureForDate / (tagsGroupForDate.Count());
                var percent2 = maxPressureForDate / (tagsGroupForDate.Count());
               
                series[0].Data[counter] = percent1*(-1);
                series[1].Data[counter] = percent2 * (-1);

                DatesRange[counter] = date.ToShortDateString();
                counter++;

            }

            PressureSeries = series;

        }

        protected List<DateTime> GetDates(List<TagsGroupResponseDto> tagsGroups)
        {
            var dates = new List<DateTime>();
            var datesHash = new HashSet<DateTime>();

            foreach (var tagGroup in tagsGroups)
            {
                datesHash.Add(tagGroup.DateTime.DateTime.Date);
            }

            return datesHash.ToList();
        }

    }
}
