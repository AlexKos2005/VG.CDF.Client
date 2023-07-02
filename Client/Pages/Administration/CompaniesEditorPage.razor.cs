using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using VG.CDF.Client.Application.Companies.Queries;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services;

namespace VG.CDF.Client.Pages.Administration;

public partial class CompaniesEditorPage
{
    [Inject] protected ICompanyService CompanyService { get; set; }
    
    [Inject] protected IStringLocalizer<CompaniesEditorPage> Localizer { get; set; }
    [CascadingParameter] public IModalService Modal { get; set; } = default!;
    protected IList<CompanyDto> Companies { get; set; } = new List<CompanyDto>();

    protected override void OnInitialized()
    {
        //Companies = await CompanyService.GetList<GetCompaniesListQuery>(new GetCompaniesListQuery() { });
        Companies.Add(new CompanyDto(){Id = Guid.NewGuid(), Name = "1"});
        Companies.Add(new CompanyDto(){Id = Guid.NewGuid(), Name = "2"});
        Companies.Add(new CompanyDto(){Id = Guid.NewGuid(), Name = "3"});
    }

    protected async Task Click()
    {
        var options = new ModalOptions() 
        { 
            Position = ModalPosition.Middle
        };
        
        var company = new CompanyDto() { Name = "TestModal" };
        var parameters = new ModalParameters().Add(nameof(EditCompany.Company), company);
        var modal = Modal.Show<EditCompany>("",parameters,options);
        var modalResult = await modal.Result;

        if (modalResult.Confirmed)
        {
            var name = modalResult.Data.ToString();
        }
        
        modal.Close(modalResult);

    }
}