public class DatabaseHelper
{
    private readonly SQLiteConnection _db;

    public DatabaseHelper(string dbPath)
    {
        _db = new SQLiteConnection(dbPath);
        _db.CreateTable<UserLocation>();
    }

    public void SaveLocation(UserLocation location)
    {
        _db.Insert(location);
    }

    public List<UserLocation> GetLocations()
    {
        return _db.Table<UserLocation>().ToList();
    }
}
