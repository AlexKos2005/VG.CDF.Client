using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace VG.CDF.Client.Pages.Authentication
{
    public partial class ConfirmValidRegistration
    {
        [Inject] IStringLocalizer<ConfirmValidRegistration> Localizer { get; set; }
    }
}
