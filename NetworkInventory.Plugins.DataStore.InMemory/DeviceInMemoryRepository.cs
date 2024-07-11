using NetworkInventory.UseCases.PluginInterfaces;

namespace NetworkInventory.Plugins.DataStore.InMemory;

public class DeviceInMemoryRepository : IDeviceRepository
{
	public Task<List<CoreBusiness.Device>> GetDevicesAsync(string filterText)
	{
		throw new NotImplementedException();
	}
}
