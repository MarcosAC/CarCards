using Xamarin.Essentials;

namespace CarCards.Helpers
{
    public class WiFiConection
    {
        public bool IsConnected()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                return true;

            return false;            
        }
    }
}
