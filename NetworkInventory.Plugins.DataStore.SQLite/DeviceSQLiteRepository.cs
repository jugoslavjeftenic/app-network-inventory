using NetworkInventory.UseCases.PluginInterfaces;
using SQLite;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.Plugins.DataStore.SQLite;

public class DeviceSQLiteRepository : IDeviceRepository
{
	private SQLiteAsyncConnection _database;

	public DeviceSQLiteRepository()
	{
		_database = new SQLiteAsyncConnection(Constants.DatabasePath);
		_database.CreateTableAsync<Device>();
	}

	public async Task AddDeviceAsync(Device device)
	{
		await _database.InsertAsync(device);
	}

	public async Task DeleteDeviceAsync(int deviceId)
	{
		var device = await GetDeviceByIdAsync(deviceId);
		if (device is not null && device.Id.Equals(deviceId))
		{
			await _database.DeleteAsync(device);
		}
	}

	public async Task<Device> GetDeviceByIdAsync(int deviceId)
	{
		return await _database
			.Table<Device>()
			.Where(x => x.Id.Equals(deviceId))
			.FirstOrDefaultAsync();
	}

	public async Task<List<Device>> GetDevicesAsync(string filterText)
	{
		if (string.IsNullOrWhiteSpace(filterText))
		{
			return await _database.Table<Device>().ToListAsync();
		}

		string queryParam = $"%{filterText}%";
		return await _database.QueryAsync<Device>(@"
			SELECT *
			FROM Device
			WHERE
				Name LIKE ? OR
				SerialNumber LIKE ? OR
				IPv4Address LIKE ? OR
				SubnetMask LIKE ? OR
				Location LIKE ? OR
				User LIKE ?
			", queryParam, queryParam, queryParam, queryParam, queryParam, queryParam);
	}

	public async Task UpdateDeviceAsync(int deviceId, Device device)
	{
		if (deviceId.Equals(device.Id))
		{
			await _database.UpdateAsync(device);
		}
	}
}
