using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Client.Pages.Authentication
{
    public partial class ConfirmValidRegistration
    {
        [Inject] IStringLocalizer<ConfirmValidRegistration> Localizer { get; set; }
    }
}
