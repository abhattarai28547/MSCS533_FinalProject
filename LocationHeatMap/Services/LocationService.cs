public class LocationService
{
    public async Task<Location> GetLocationAsync()
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.High,
                    Timeout = TimeSpan.FromSeconds(30)
                });
            }
            return location;
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine($"Location error: {ex.Message}");
            return null;
        }
    }
}
