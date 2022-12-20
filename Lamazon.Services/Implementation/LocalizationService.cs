using Lamazon.Services.Abstraction;

namespace Lamazon.Services.Implementation
{
    public class LocalizationService : ILocalizationService
    {
        public string LocalizeString(string value)
        {
            if (value.Equals("food", StringComparison.InvariantCultureIgnoreCase))
            {
                return "Храна";
            }
            else
            {
                return value;
            }
        }
    }
}
