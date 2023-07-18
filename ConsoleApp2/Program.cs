// See https://aka.ms/new-console-template for more information

using System.Reflection.Emit;
using Blazored.LocalStorage;
using Moq;
using VG.CDF.Client.Application.Companies.Commands;
using VG.CDF.Client.Application.Companies.Queries;
using VG.CDF.Client.Application.Dto;
using VG.CDF.Client.Application.Interfaces.Services;
using VG.CDF.Client.Infrastructure.Services.RestApi;

Console.WriteLine("Hello, World!");
string url = "api/admin/company/";

var lcStoreMoq = new Mock<ILocalStorageService>();

var messPresenterMoq = new Mock<IMessagePresentService>();

lcStoreMoq.Setup(c => c.GetItemAsStringAsync("authToken",null))
    .Returns(()=> new ValueTask<string>("apikey"));

var query = new GetCompaniesListQuery();

using (var httpClient = new HttpClient())
{
    httpClient.BaseAddress = new Uri("http://localhost:5000/");
    var crudService = new CrudService<CompanyDto>(httpClient, lcStoreMoq.Object);
    var service = new CompanyService(crudService,messPresenterMoq.Object);

    var res = await service.GetList<GetCompaniesListQuery>(new GetCompaniesListQuery() { Name = "InitComp2" });

    //var createRes = await service.Create<CreateCompanyCommand>(new CreateCompanyCommand() { Name = "InitComp2" });

    var updateRes = await service.Update<UpdateCompanyCommand>(new UpdateCompanyCommand(){Id = res.First().Id,Name = "InitComp2"});

    var deleteRes = await service.Delete<DeleteCompanyCommand>(new DeleteCompanyCommand(){Id = updateRes.Id});
}


Console.ReadLine();
