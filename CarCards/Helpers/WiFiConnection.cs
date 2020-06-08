using Xamarin.Essentials;

namespace CarCards.Helpers
{
    public class WiFiConnection
    {
        public bool IsConnected()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                return true;

            return false;            
        }
    }
}
