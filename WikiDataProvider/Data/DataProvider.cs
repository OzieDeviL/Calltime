using WikiDataProvider.Data.Interfaces;
using WikiDataProvider.Data.Providers;

namespace WikiDataProvider.Data
{
    public sealed class DataProvider
    {
        private DataProvider() { }

        public static IDao Instance
        {
            get
            {
                return SqlDao.Instance;
            }
        }

    }
}
