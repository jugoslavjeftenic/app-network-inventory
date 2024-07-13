using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.UseCases.PluginInterfaces;

public interface IDeviceRepository
{
	Task<Device> GetDeviceByIdAsync(int deviceId);
	Task<List<Device>> GetDevicesAsync(string filterText);
}
