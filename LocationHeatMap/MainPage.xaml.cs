namespace LocationHeatMap;

public partial class MainPage : ContentPage
{
	int count = 0;
	private readonly DatabaseHelper _databaseHelper;

    public MainPage(DatabaseHelper databaseHelper)
    {
    	InitializeComponent();
        _databaseHelper = databaseHelper;

        // Load data and initialize map
        LoadHeatMapData();
    }

    private void LoadHeatMapData()
    {
        // Fetch all saved locations
        var locations = _databaseHelper.GetLocations();

        // Add heat points for each location
        foreach (var loc in locations)
        {
            AddHeatPoint(HeatMap, loc.Latitude, loc.Longitude, 500); // Radius in meters
        }
    }

    private void AddHeatPoint(Map map, double latitude, double longitude, double radius)
    {
        // Create a circular overlay for heat map
        var circle = new Circle
        {
            Center = new Location(latitude, longitude),
            Radius = new Distance(radius),
            StrokeColor = Colors.Red,            // Circle border color
            FillColor = Colors.Red.WithAlpha(0.3f) // Circle fill color (transparent red)
        };
        map.MapElements.Add(circle);
    }


	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

