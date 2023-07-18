using MudBlazor;
using VG.CDF.Client.Application.Interfaces.Services;

namespace VG.CDF.Client.Services;

public class MessagePresentService : IMessagePresentService
{
    private readonly ISnackbar _snackbar;
    public MessagePresentService(ISnackbar snackbar)
    {
        _snackbar = snackbar;
        _snackbar.Configuration.ShowCloseIcon = true;
        _snackbar.Configuration.VisibleStateDuration = 5000;
        _snackbar.Configuration.HideTransitionDuration = 500;
        _snackbar.Configuration.ShowTransitionDuration = 500;
        _snackbar.Configuration.SnackbarVariant = Variant.Filled;
    }
    public void PresentWarning(string warnMessage)
    {
        _snackbar.Add(warnMessage, Severity.Warning);
    }

    public void PresentError(string warnMessage)
    {
        _snackbar.Add(warnMessage, Severity.Error);
    }
}