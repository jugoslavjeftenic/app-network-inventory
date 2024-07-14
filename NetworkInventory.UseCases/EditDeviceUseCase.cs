using NetworkInventory.UseCases.Interfaces;
using NetworkInventory.UseCases.PluginInterfaces;
using Device = NetworkInventory.CoreBusiness.Device;

namespace NetworkInventory.UseCases;

public class EditDeviceUseCase(IDeviceRepository deviceRepository) : IEditDeviceUseCase
{
	private readonly IDeviceRepository _deviceRepository = deviceRepository;

	public async Task ExecuteAsync(int deviceId, Device device)
	{
		await _deviceRepository.UpdateDeviceAsync(deviceId, device);
	}
}
