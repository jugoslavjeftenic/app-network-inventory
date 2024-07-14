using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.UseCases.PluginInterfaces;

public interface IDeviceRepository
{
	Task AddDeviceAsync(Device device);
	Task DeleteDeviceAsync(int deviceId);
	Task<Device> GetDeviceByIdAsync(int deviceId);
	Task<List<Device>> GetDevicesAsync(string filterText);
	Task UpdateDeviceAsync(int deviceId, Device device);
}
