namespace NetworkInventory.Plugins.DataStore.SQLite;

public class Constants
{
	public const string DatabaseFileName = "NetworkInventorySQLite.db3";
	public static string DatabasePath =>
		Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
}
