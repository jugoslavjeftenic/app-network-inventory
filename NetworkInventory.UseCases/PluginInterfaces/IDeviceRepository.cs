using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.UseCases.PluginInterfaces;

public interface IDeviceRepository
{
	Task<List<Device>> GetDevicesAsync(string filterText);
}
