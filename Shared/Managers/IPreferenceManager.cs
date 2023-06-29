using System.Threading.Tasks;
using VG.CDF.Client.Shared.Settings;
using VG.CDF.Client.Shared.Wrapper;

namespace VG.CDF.Client.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}