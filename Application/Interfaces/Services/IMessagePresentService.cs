namespace VG.CDF.Client.Application.Interfaces.Services;

public interface IMessagePresentService
{
    void PresentWarning(string warnMessage);
    
    void PresentError(string warnMessage);
}