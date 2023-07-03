using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using VG.CDF.Client.Application.Companies.Commands;
using VG.CDF.Client.Application.Companies.Queries;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Pages.Administration.Parameter;

namespace VG.CDF.Client.Pages.Administration.Company;

public partial class CompaniesEditorPage
{
    [Inject] protected ICompanyService CompanyService { get; set; }
    
    [Inject] protected IStringLocalizer<CompaniesEditorPage> Localizer { get; set; }
    [CascadingParameter] public IModalService Modal { get; set; } = default!;
    protected IEnumerable<CompanyDto> Companies { get; set; } = new List<CompanyDto>();

    protected override async Task OnInitializedAsync()
    {
        Companies = await CompanyService.GetList<GetCompaniesListQuery>(new GetCompaniesListQuery() { });
    }

    protected async Task EditCompany(CompanyDto companyDto)
    {
        var parameters = new ModalParameters().Add("Company", companyDto);
        var modal = Modal.Show<EditCompanyModal>("Изменить",parameters);
        var modalResult = await modal.Result;

        if (modalResult.Confirmed)
        {
            var name = modalResult.Data.ToString();
            await CompanyService.Update(new CompanyDto(){Id = companyDto.Id,Name = name});
        }
        
        modal.Close(modalResult);
        
        Companies = await CompanyService.GetList<GetCompaniesListQuery>(new GetCompaniesListQuery() { });
    }
    protected async Task AddCompany()
    {
        var modal = Modal.Show<AddCompanyModal>("Создать");
        var modalResult = await modal.Result;

        if (modalResult.Confirmed)
        {
            var name = modalResult.Data.ToString();
            var createdCompany = await CompanyService.Create(new CreateCompanyCommand() { Name = name});
        }
        
        modal.Close(modalResult);
        
        Companies = await CompanyService.GetList<GetCompaniesListQuery>(new GetCompaniesListQuery() { });

    }
    
    protected async Task DeleteCompany(CompanyDto companyDto)
    {
        var parameters = new ModalParameters().Add("Company", companyDto);
        var modal = Modal.Show<DeleteCompanyModal>("Удалить",parameters);
        var modalResult = await modal.Result;

        if (modalResult.Confirmed)
        {
            await CompanyService.Delete<string>(companyDto.Id.ToString());
        }
        
        modal.Close(modalResult);
        
        Companies = await CompanyService.GetList<GetCompaniesListQuery>(new GetCompaniesListQuery() { });
    }


    protected async Task ShowParametersList(CompanyDto companyDto)
    {
        var parameters = new ModalParameters().Add("CompanyId", companyDto.Id);
        var modal = Modal.Show<ParametersListModal>("Параметры",parameters);
        var modalResult = await modal.Result;

        modal.Close(modalResult);
        
        Companies = await CompanyService.GetList<GetCompaniesListQuery>(new GetCompaniesListQuery() { });
    }
}